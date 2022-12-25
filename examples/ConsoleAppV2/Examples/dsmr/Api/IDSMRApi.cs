using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using ConsoleAppV2.Examples.dsmr.Models;
using RestEase;
using ConsoleAppV2.Examples.DSMR.Models;

namespace ConsoleAppV2.Examples.DSMR.Api
{
    /// <summary>
    /// Summary: # Postman collection- Download current collection [here](/static/dsmr_frontend/postman/collection.json).- Download current variables [here](/static/dsmr_frontend/postman/variables.json).
    /// Title  : DSMR-reader API
    /// Version: v5.9
    /// </summary>
    public interface IDSMRApi
    {
        [Header("Authorization")]
        AuthenticationHeaderValue AuthKey { get; set; }

        /// <summary>
        /// Retrieves any readings stored. The readings are either constructed from incoming telegrams or were created usingthis API.### Query parameters- *Only mandatory when explicitly marked with the **required** label. Can be omitted otherwise.*- ``limit`` / ``offset``: Pagination for iterating when having large result sets.- ``ordering``: Order by either ``timestamp`` (ASC) or ``-timestamp`` (DESC).- ``timestamp__gte`` / ``timestamp__lte``: Can be used for generic filtering the results     returned by reading timestamp with the given datetime as placeholder `X` below. Note the ``Y-m-d HH:MM:SS``     format for `X`, in the local timezone. **Should be changed to ISO 8601 some day, supporting timezone hints.**- ⚠️ **Deprecated** ~``timestamp``: Reading timestamp must **exactly match** the given value (``Y-m-d HH:MM:SS``).~### Changes- Deprecated the ``timestamp`` query parameter in DSMR-reader v5.3, will be dropped completely in v6.x### Request samples```// Fetching the latest reading created.GET /api/v2/consumption/energy-supplier-prices?ordering=-timestamp&limit=1// Get all readings of a specific "day", presuming that day is 15 January 2022.GET /api/v2/datalogger/dsmrreading?timestamp__gte=2022-01-15 00:00:00&timestamp__lte=2022-01-15 23:59:59```
        ///
        /// DSMRReadingsList (/api/v2/datalogger/dsmrreading)
        /// </summary>
        /// <param name="limit">Number of results to return per page.</param>
        /// <param name="offset">The initial index from which to return the results.</param>
        /// <param name="ordering">Which field to use when ordering the results.</param>
        /// <param name="timestamp">timestamp</param>
        /// <param name="timestampGte">Reading timestamp must be after or equal to `X`</param>
        /// <param name="timestampLte">Reading timestamp must be before or equal to `X`</param>
        [Get("/api/v2/datalogger/dsmrreading")]
        Task<Reading> DSMRReadingsListAsync([Query] int limit, [Query] int offset, [Query] string ordering, [Query] string timestamp, [Query(Name = "timestamp__gte")] string timestampGte, [Query(Name = "timestamp__lte")] string timestampLte);

        /// <summary>
        /// Creates a reading from separate values, omitting the need for the original telegram.### Notes- This requires you to **manually parse** any telegrams, e.g. when using ``dsmr_parser`` or a similar tool.- Readings are processed *simultaneously* by the background process. So inserting readings retroactively *might*cause undesired results due to side effects. *If your stats are not correctly after regenerating, see below,try it again while having your datalogger disabled.*- Inserting historic data might require you to **delete all aggregated data** as well, using:```sudo su - postgrespsql dsmrreadertruncate dsmr_consumption_electricityconsumption;truncate dsmr_consumption_gasconsumption;truncate dsmr_stats_daystatistics;truncate dsmr_stats_hourstatistics;// This query can take a long time!update dsmr_datalogger_dsmrreading set processed = False;// This will process all readings again, from the very first start, and aggregate them once more.// It might take a long time, depending on your total reading count stored and hardware used.```
        ///
        /// DSMRReadingsCreate (/api/v2/datalogger/dsmrreading)
        /// </summary>
        /// <param name="content"></param>
        [Post("/api/v2/datalogger/dsmrreading")]
        [Header("Content-Type", "application/json")]
        Task<DsmrReading> DSMRReadingsCreateAsync([Body] DsmrReading content);

        /// <summary>
        /// Retrieve meter statistics extracted by the datalogger. Also contains the latest telegram read for convenience.### Query parameters- *Only mandatory when explicitly marked with the **required** label. Can be omitted otherwise.*- Do **not use** ``ordering``, as it's a faulty query parameter that should not be there nor works at all!
        ///
        /// MeterStatisticsGet (/api/v2/datalogger/meter-statistics)
        /// </summary>
        /// <param name="ordering">Which field to use when ordering the results.</param>
        [Get("/api/v2/datalogger/meter-statistics")]
        Task<MeterStatistics> MeterStatisticsGetAsync([Query] string ordering);

        /// <summary>
        /// Manually update any meter statistics fields.### Notes- Only use this when you're **not** using the built-in datalogger **nor** the v1 telegram API.     *It should auto-update otherwise!*
        ///
        /// MeterStatisticsPartialUpdate (/api/v2/datalogger/meter-statistics)
        /// </summary>
        /// <param name="content"></param>
        /// <param name="ordering">Which field to use when ordering the results.</param>
        [Patch("/api/v2/datalogger/meter-statistics")]
        [Header("Content-Type", "application/json")]
        Task<MeterStatistics> MeterStatisticsPartialUpdateAsync([Body] MeterStatistics content, [Query] string ordering);

        /// <summary>
        /// Retrieves the energy supplier prices (contracts).### Notes- These are the contracts manually entered in DSMR-reader's admin interface. Can be used for manualcalculations.> *E.g. fetching any contracts active today, then fetch all day statistics filtered by the contract's start/end,finally summing up the total consumption for that contract. Similar to DSMR-reader's GUI regarding contact totals.*### Query parameters- *Only mandatory when explicitly marked with the **required** label. Can be omitted otherwise.*- ``limit`` / ``offset``: Optional pagination. Probably not needed unless you have *a lot* of contracts.- ``ordering``: Order by either ``start`` (ASC), ``-start`` (DESC), ``end`` (ASC) or ``-end`` (DESC).- ``start__gte`` / ``start__lte`` / ``end__gte`` / ``end__lte``: Can be used for generic filtering the results     returned by contracts' start/end with the given date as placeholder `X` below. Note the ``Y-m-d`` format for `X`.### Changes- This endpoint was added in DSMR-reader v5.3### Request samples```// Get the most recent contract, based on its start date.GET /api/v2/consumption/energy-supplier-prices?ordering=-start&limit=1// Get all contracts active/applying to "today", presuming "today" is 15 June 2022.GET /api/v2/consumption/energy-supplier-prices?start__lte=2022-06-15&end__gte=2022-06-15```
        ///
        /// EnergySupplierPricesList (/api/v2/consumption/energy-supplier-prices)
        /// </summary>
        /// <param name="limit">Number of results to return per page.</param>
        /// <param name="offset">The initial index from which to return the results.</param>
        /// <param name="ordering">Which field to use when ordering the results.</param>
        /// <param name="startGte">Contract start date must be after or equal to `X`</param>
        /// <param name="startLte">Contract start date must be before or equal to `X`</param>
        /// <param name="endGte">Contract end date must be after or equal to `X`</param>
        /// <param name="endLte">Contract end date must be before or equal to `X`</param>
        [Get("/api/v2/consumption/energy-supplier-prices")]
        Task<Reading> EnergySupplierPricesListAsync([Query] int limit, [Query] int offset, [Query] string ordering, [Query(Name = "start__gte")] string startGte, [Query(Name = "start__lte")] string startLte, [Query(Name = "end__gte")] string endGte, [Query(Name = "end__lte")] string endLte);

        /// <summary>
        /// Retrieves any data regarding electricity consumption. This is based on the readings processed.### Query parameters- *Only mandatory when explicitly marked with the **required** label. Can be omitted otherwise.*- ``limit`` / ``offset``: Pagination for iterating when having large result sets.- ``ordering``: Order by either ``read_at`` (ASC) or ``-read_at`` (DESC).- ``read_at__gte`` / ``read_at__lte``: Can be used for generic filtering the results     returned by consumption timestamp with the given datetime as placeholder `X` below. Note the ``Y-m-d HH:MM:SS``     format for `X`, in the local timezone. **Should be changed to ISO 8601 some day, supporting timezone hints.**- ⚠️ **Deprecated** ~`read_at`: Consumption timestamp must **exactly match** the given value (``Y-m-d HH:MM:SS``).~### Changes- Deprecated the ``read_at`` query parameter in DSMR-reader v5.3, will be dropped completely in v6.x
        ///
        /// ElectricityConsumptionList (/api/v2/consumption/electricity)
        /// </summary>
        /// <param name="limit">Number of results to return per page.</param>
        /// <param name="offset">The initial index from which to return the results.</param>
        /// <param name="ordering">Which field to use when ordering the results.</param>
        /// <param name="readAt">read_at</param>
        /// <param name="readAtGte">Consumption timestamp must be after or equal to `X`</param>
        /// <param name="readAtLte">Consumption timestamp must be before or equal to `X`</param>
        [Get("/api/v2/consumption/electricity")]
        Task<Reading> ElectricityConsumptionListAsync([Query] int limit, [Query] int offset, [Query] string ordering, [Query(Name = "read_at")] string readAt, [Query(Name = "read_at__gte")] string readAtGte, [Query(Name = "read_at__lte")] string readAtLte);

        /// <summary>
        /// Retrieves any data regarding quarter-hour peak electricity consumption. This is based on the readings processed.### Query parameters- *Only mandatory when explicitly marked with the **required** label. Can be omitted otherwise.*- ``limit`` / ``offset``: Pagination for iterating when having large result sets.- ``ordering``: Order by either ``read_at_start`` (ASC), ``-read_at_start`` (DESC), ``average_delivered`` (ASC) or     ``-average_delivered`` (DESC).- ``read_at_start__gte`` / ``read_at_start__lte``: Can be used for generic filtering the results     returned by quarter-hour peak electricity START timestamp with the given datetime as placeholder `X` below.     Note the ``Y-m-d HH:MM:SS`` format for `X`, in the local timezone.     **Should be changed to ISO 8601 some day, supporting timezone hints.**- ``average_delivered__gte`` / ``average_delivered__lte``: Can be used for generic filtering the results     returned by the average calculated (In kW).
        ///
        /// QuarterHourPeakElectricityConsumptionList (/api/v2/consumption/quarter-hour-peak-electricity)
        /// </summary>
        /// <param name="limit">Number of results to return per page.</param>
        /// <param name="offset">The initial index from which to return the results.</param>
        /// <param name="ordering">Which field to use when ordering the results.</param>
        /// <param name="readAtStartGte">Quarter-hour peak consumption start timestamp must be after or equal to `X`</param>
        /// <param name="readAtStartLte">Quarter-hour peak consumption start timestamp must be before or equal to `X`</param>
        /// <param name="averageDeliveredGte">Quarter-hour peak consumption average must be higher or equal to `X`</param>
        /// <param name="averageDeliveredLte">Quarter-hour peak consumption average must be lower or equal to `X`</param>
        [Get("/api/v2/consumption/quarter-hour-peak-electricity")]
        Task<Reading> QuarterHourPeakElectricityConsumptionListAsync([Query] int limit, [Query] int offset, [Query] string ordering, [Query(Name = "read_at_start__gte")] string readAtStartGte, [Query(Name = "read_at_start__lte")] string readAtStartLte, [Query(Name = "average_delivered__gte")] string averageDeliveredGte, [Query(Name = "average_delivered__lte")] string averageDeliveredLte);

        /// <summary>
        /// Returns the live electricity consumption, containing the same data as the Dashboard header.
        ///
        /// ElectricityConsumptionLive (/api/v2/consumption/electricity-live)
        /// </summary>
        [Get("/api/v2/consumption/electricity-live")]
        Task<ElectricityLive> ElectricityConsumptionLiveAsync();

        /// <summary>
        /// Retrieves any data regarding gas consumption. This is based on the readings processed.### Query parameters- *Only mandatory when explicitly marked with the **required** label. Can be omitted otherwise.*- ``limit`` / ``offset``: Pagination for iterating when having large result sets.- ``ordering``: Order by either ``read_at`` (ASC) or ``-read_at`` (DESC).- ``read_at__gte`` / ``read_at__lte``: Can be used for generic filtering the results     returned by consumption timestamp with the given datetime as placeholder `X` below. Note the ``Y-m-d HH:MM:SS``     format for `X`, in the local timezone. **Should be changed to ISO 8601 some day, supporting timezone hints.**- ⚠️ **Deprecated** ~`read_at`: Consumption timestamp must **exactly match** the given value (``Y-m-d HH:MM:SS``).~### Changes- Deprecated the ``read_at`` query parameter in DSMR-reader v5.3, will be dropped completely in v6.x
        ///
        /// GasConsumptionList (/api/v2/consumption/gas)
        /// </summary>
        /// <param name="limit">Number of results to return per page.</param>
        /// <param name="offset">The initial index from which to return the results.</param>
        /// <param name="ordering">Which field to use when ordering the results.</param>
        /// <param name="readAt">read_at</param>
        /// <param name="readAtGte">Consumption timestamp must be after or equal to `X`</param>
        /// <param name="readAtLte">Consumption timestamp must be before or equal to `X`</param>
        [Get("/api/v2/consumption/gas")]
        Task<Reading> GasConsumptionListAsync([Query] int limit, [Query] int offset, [Query] string ordering, [Query(Name = "read_at")] string readAt, [Query(Name = "read_at__gte")] string readAtGte, [Query(Name = "read_at__lte")] string readAtLte);

        /// <summary>
        /// Returns the latest gas consumption.
        ///
        /// GasConsumptionLive (/api/v2/consumption/gas-live)
        /// </summary>
        [Get("/api/v2/consumption/gas-live")]
        Task<object[]> GasConsumptionLiveAsync();

        /// <summary>
        /// Returns the consumption of the current day so far.
        ///
        /// TodaySConsumptionGet (/api/v2/consumption/today)
        /// </summary>
        [Get("/api/v2/consumption/today")]
        Task<object[]> TodaySConsumptionGetAsync();

        /// <summary>
        /// Retrieves any aggregated day statistics, as displayed in the Archive.### Notes- These are automatically generated a few hours after midnight, based on the consumption data.### Query parameters- *Only mandatory when explicitly marked with the **required** label. Can be omitted otherwise.*- ``limit`` / ``offset``: Pagination for iterating when having large result sets.- ``ordering``: Order by either ``day`` (ASC) or ``-day`` (DESC).- ``day__gte`` / ``day__lte``: Can be used for generic filtering the results     returned by dates with the given date as placeholder `X` below.  ote the ``Y-m-d`` format for `X`.- ⚠️ **Deprecated** ~`day`: Date must **exactly match** the given value (``Y-m-d HH:MM:SS``).~### Changes- Deprecated the ``day`` query parameter in DSMR-reader v5.3, will be dropped completely in v6.x
        ///
        /// DayStatisticsList (/api/v2/statistics/day)
        /// </summary>
        /// <param name="limit">Number of results to return per page.</param>
        /// <param name="offset">The initial index from which to return the results.</param>
        /// <param name="ordering">Which field to use when ordering the results.</param>
        /// <param name="day">day</param>
        /// <param name="dayGte">Date must be after or equal to `X`</param>
        /// <param name="dayLte">Date must be before or equal to `X`</param>
        [Get("/api/v2/statistics/day")]
        Task<Reading> DayStatisticsListAsync([Query] int limit, [Query] int offset, [Query] string ordering, [Query] string day, [Query(Name = "day__gte")] string dayGte, [Query(Name = "day__lte")] string dayLte);

        /// <summary>
        /// Creates statistics for a day, overriding any DSMR-reader internals.### Notes- Should only be used to import historic data.
        ///
        /// DayStatisticsCreate (/api/v2/statistics/day)
        /// </summary>
        /// <param name="content"></param>
        [Post("/api/v2/statistics/day")]
        [Header("Content-Type", "application/json")]
        Task<DayStatistics> DayStatisticsCreateAsync([Body] DayStatistics content);

        /// <summary>
        /// Retrieves any aggregated hour statistics, as displayed in the Archive.### Notes- These are automatically generated a few hours after midnight, based on the consumption data.### Query parameters- *Only mandatory when explicitly marked with the **required** label. Can be omitted otherwise.*- ``limit`` / ``offset``: Pagination for iterating when having large result sets.- ``ordering``: Order by either ``hour_start`` (ASC) or ``-hour_start`` (DESC).- ``hour_start__gte`` / ``hour_start__lte``: Can be used for generic filtering the results     returned by hour start timestamp with the given datetime as placeholder `X` below. Note the ``Y-m-d HH:MM:SS``     format for `X`, in the local timezone. **Should be changed to ISO 8601 some day, supporting timezone hints.**- ⚠️ **Deprecated** ~`hour_start`: Hour start timestamp must **exactly match** the given value (`Y-m-d HH:MM:SS`).~### Changes- Deprecated the ``hour_start`` query parameter in DSMR-reader v5.3, will be dropped completely in v6.x
        ///
        /// HourStatisticsList (/api/v2/statistics/hour)
        /// </summary>
        /// <param name="limit">Number of results to return per page.</param>
        /// <param name="offset">The initial index from which to return the results.</param>
        /// <param name="ordering">Which field to use when ordering the results.</param>
        /// <param name="hourStart">hour_start</param>
        /// <param name="hourStartGte">Hour start must be after or equal to `X`</param>
        /// <param name="hourStartLte">Hour start must be before or equal to `X`</param>
        [Get("/api/v2/statistics/hour")]
        Task<Reading> HourStatisticsListAsync([Query] int limit, [Query] int offset, [Query] string ordering, [Query(Name = "hour_start")] string hourStart, [Query(Name = "hour_start__gte")] string hourStartGte, [Query(Name = "hour_start__lte")] string hourStartLte);

        /// <summary>
        /// Returns the version of DSMR-reader you are running.
        ///
        /// ApplicationVersion (/api/v2/application/version)
        /// </summary>
        [Get("/api/v2/application/version")]
        Task<object[]> ApplicationVersionAsync();

        /// <summary>
        /// Returns any monitoring issues found. Reflects the same (issue) data as displayed on the Status page.
        ///
        /// ApplicationMonitoring (/api/v2/application/monitoring)
        /// </summary>
        [Get("/api/v2/application/monitoring")]
        Task<object[]> ApplicationMonitoringAsync();
    }
}