namespace Models.Models
{
    /// <summary>
    /// create absent record
    /// </summary>
    public class Absentrecord
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        public int OndReiId { get; set; }

        /// <summary>
        /// Start date/time registration
        /// </summary>
        public string OndStart { get; set; }

        /// <summary>
        /// End date/time registration
        /// </summary>
        public string OndEinde { get; set; }

        /// <summary>
        /// Indication person is sick
        /// </summary>
        public int OndIsziek { get; set; }

        /// <summary>
        /// Reason absence reporting
        /// </summary>
        public string OndReden { get; set; }

        /// <summary>
        /// Reference
        /// </summary>
        public string OndReferentie { get; set; }

        /// <summary>
        /// Action type scripts
        /// </summary>
        public int OndSoort { get; set; }
    }

    /// <summary>
    /// create absent record
    /// </summary>
    public class Absentrecordguid
    {
        /// <summary>
        /// Customer GUID
        /// </summary>
        public string ReiGuid { get; set; }

        /// <summary>
        /// Start date/time registration
        /// </summary>
        public string OndStart { get; set; }

        /// <summary>
        /// End date/time registration
        /// </summary>
        public string OndEinde { get; set; }

        /// <summary>
        /// Indication person is sick
        /// </summary>
        public int OndIsziek { get; set; }

        /// <summary>
        /// Reason absence reporting
        /// </summary>
        public string OndReden { get; set; }

        /// <summary>
        /// Reference
        /// </summary>
        public string OndReferentie { get; set; }

        /// <summary>
        /// Action type scripts
        /// </summary>
        public int OndSoort { get; set; }
    }

    /// <summary>
    /// update absent record
    /// </summary>
    public class AbsentUpdaterecord
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        public int OndReiId { get; set; }

        /// <summary>
        /// Absense ID
        /// </summary>
        public int OndId { get; set; }

        /// <summary>
        /// End date/time registration
        /// </summary>
        public string OndEinde { get; set; }
    }

    /// <summary>
    /// update absent record
    /// </summary>
    public class AbsentUpdaterecordguid
    {
        /// <summary>
        /// Customer GUID
        /// </summary>
        public string ReiGuid { get; set; }

        /// <summary>
        /// Absense ID
        /// </summary>
        public int OndId { get; set; }

        /// <summary>
        /// End date/time registration
        /// </summary>
        public string OndEinde { get; set; }
    }

    /// <summary>
    /// address field
    /// </summary>
    public class Address
    {
        public string StreetAddress { get; set; }

        public string AreaReference { get; set; }

        public string PostalCode { get; set; }

        public string Country { get; set; }
    }

    public class AmountOfMoney
    {
        public double Amount { get; set; }

        public double AmountExVat { get; set; }

        /// <summary>
        /// ISO 4217 currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        public double VatRate { get; set; }

        public string VatCountryCode { get; set; }
    }

    /// <summary>
    /// Collection of combined trip records
    /// </summary>
    public class ArrayOfCombinedTrips
    {
        public int PlaRoute { get; set; }

        public int PlaId { get; set; }

        public int PlaVan { get; set; }

        public int PlaNaar { get; set; }

        public string PlaTijdstipOphalen { get; set; }
    }

    public class Asset
    {
        /// <summary>
        /// Identifier of an asset. Whenever used in Operator Information changed after every trip (GDPR).
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// true indicates the bike is currently reserved for someone else
        /// </summary>
        public bool IsReserved { get; set; }

        /// <summary>
        /// optional addition to determine if an asset is reserved in the future
        /// </summary>
        public DateTime IsReservedFrom { get; set; }

        /// <summary>
        /// optional addition to determine when asset is available in the future
        /// </summary>
        public DateTime IsReservedTo { get; set; }

        /// <summary>
        /// true indicates the asset is currently disabled (broken)
        /// </summary>
        public bool IsDisabled { get; set; }

        /// <summary>
        /// deep-linking option from GBFS+. Only added to be consistent with GBFS 2.0
        /// </summary>
        public string RentalUrl { get; set; }

        /// <summary>
        /// deep-linking option from GBFS 2.0. Only added to be consistent with GBFS 2.0
        /// </summary>
        public string RentalUrlAndroid { get; set; }

        /// <summary>
        /// deep-linking option from GBFS 2.0. Only added to be consistent with GBFS 2.0
        /// </summary>
        public string RentalUrlIOS { get; set; }

        public AssetProperties OverriddenProperties { get; set; }
    }

    /// <summary>
    /// what kind of asset is this? Classify it, give the aspects. Most aspects are optional and should be used when applicable.
    /// </summary>
    public class AssetProperties
    {
        /// <summary>
        /// name of asset (type), required in either assetType or asset, should match Content-Language
        /// </summary>
        public string Name { get; set; }

        public Place Location { get; set; }

        public string Fuel { get; set; }

        public string EnergyLabel { get; set; }

        public double Co2PerKm { get; set; }

        /// <summary>
        /// brand of the asset
        /// </summary>
        public string Brand { get; set; }

        public string Model { get; set; }

        public int BuildingYear { get; set; }

        /// <summary>
        /// true indicates asset is allowed to travel abroad
        /// </summary>
        public bool TravelAbroad { get; set; }

        /// <summary>
        /// true indicates airconditioning required
        /// </summary>
        public bool AirConditioning { get; set; }

        /// <summary>
        /// true indicates cabrio required
        /// </summary>
        public bool Cabrio { get; set; }

        /// <summary>
        /// colour of the asset, should match Content-Language
        /// </summary>
        public string Colour { get; set; }

        /// <summary>
        /// describes options to carry cargo, should match Content-Language
        /// </summary>
        public string Cargo { get; set; }

        public string EasyAccessibility { get; set; }

        /// <summary>
        /// number of gears of the asset
        /// </summary>
        public int Gears { get; set; }

        public string Gearbox { get; set; }

        /// <summary>
        /// Link to an image of the asset
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// true indicates infant seat required
        /// </summary>
        public bool InfantSeat { get; set; }

        /// <summary>
        /// number of persons able to use the asset
        /// </summary>
        public int Persons { get; set; }

        /// <summary>
        /// true indicates pets are allowed on asset
        /// </summary>
        public bool Pets { get; set; }

        public string Propulsion { get; set; }

        /// <summary>
        /// true indicates smoking is allowed on asset
        /// </summary>
        public bool Smoking { get; set; }

        /// <summary>
        /// percentage of charge available
        /// </summary>
        public int StateOfCharge { get; set; }

        /// <summary>
        /// true indicates towing hook required
        /// </summary>
        public bool TowingHook { get; set; }

        /// <summary>
        /// true indicates underground parking is allowed with asset
        /// </summary>
        public bool UndergroundParking { get; set; }

        /// <summary>
        /// true indicates winter tires required
        /// </summary>
        public bool WinterTires { get; set; }

        /// <summary>
        /// free text to describe asset, should match Content-Language
        /// </summary>
        public string Other { get; set; }

        /// <summary>
        /// this object can contain extra information about the type of asset. For instance values from the 'Woordenboek Reizigerskenmerken'. [https://github.com/efel85/TOMP-API/issues/17]. These values can also be used in the planning.
        /// </summary>
        public object Meta { get; set; }
    }

    public class AssetType
    {
        /// <summary>
        /// Unique identifier of an asset type,
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// If staionId is present, the nrAvailable is expected to find the availableity at that particular station
        /// </summary>
        public string StationId { get; set; }

        public int NrAvailable { get; set; }

        public Asset[] Assets { get; set; }

        public string AssetClass { get; set; }

        /// <summary>
        /// a more precise classification of the asset, like 'cargo bike', 'public bus', 'coach bus', 'office bus', 'water taxi',  'segway'. This is mandatory when using 'OTHER' as class.
        /// </summary>
        public string AssetSubClass { get; set; }

        public AssetProperties SharedProperties { get; set; }
    }

    public class BankAccount
    {
        /// <summary>
        /// account name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// account number
        /// </summary>
        public string Number { get; set; }

        public string Country { get; set; }

        /// <summary>
        /// bank identification, like BIC code
        /// </summary>
        public string BankIdentification { get; set; }
    }

    /// <summary>
    /// Car battery level update
    /// </summary>
    public class Batterylevel
    {
        public int WagId { get; set; }

        public int Battery { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// operation on the bookingOption
    /// </summary>
    public class BookingOperation
    {
        public string Operation { get; set; }
    }

    /// <summary>
    /// A booking requested by the MP
    /// </summary>
    public class BookingRequest
    {
        /// <summary>
        /// A unique identifier for the TO to know this booking by
        /// </summary>
        public string Id { get; set; }

        public Place From { get; set; }

        public Place To { get; set; }

        public object Customer { get; set; }
    }

    /// <summary>
    /// Any kind of card that isn't a license, only provide the cards that are required
    /// </summary>
    public class Card
    {
        /// <summary>
        /// description of the card
        /// </summary>
        public string CardDescription { get; set; }

        /// <summary>
        /// number of the card, like ID number, credit card or bank account number
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        /// additional number, like CVC code or IBAN code
        /// </summary>
        public string CardAdditionalNumber { get; set; }

        public DateTime ValidUntil { get; set; }

        public string Country { get; set; }
    }

    /// <summary>
    /// delay record
    /// </summary>
    public class Cardelay
    {
        public int WagId { get; set; }

        /// <summary>
        /// delay in seconds
        /// </summary>
        public int Delay { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// A generic description of a card, asset class and acceptors is only allowed for DISCOUNT/TRAVEL/OTHER cards
    /// </summary>
    public class CardType
    {
        public string Type { get; set; }

        /// <summary>
        /// For use in case of OTHER. Can be used in bilateral agreements.
        /// </summary>
        public string SubType { get; set; }

        public string AssetClass { get; set; }

        /// <summary>
        /// references to accepting parties, only if applicable
        /// </summary>
        public string[] Acceptors { get; set; }
    }

    /// <summary>
    /// Update car status
    /// </summary>
    public class Carstatus
    {
        public int WagId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }

        public int Statuscode { get; set; }
    }

    /// <summary>
    /// To identify the operator
    /// </summary>
    public class ChamberOfCommerceInfo
    {
        public string Number { get; set; }

        public string Place { get; set; }
    }

    /// <summary>
    /// Chat record
    /// </summary>
    public class Chatmessage
    {
        public int LsnWagId { get; set; }

        public int LsnChfId { get; set; }

        [Newtonsoft.Json.JsonProperty("Chatmessage")]
        public string Chatmessage_ { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// driver guid combination
    /// </summary>
    public class ChfGuid
    {
        [Newtonsoft.Json.JsonProperty("ChfGuid")]
        public string ChfGuid_ { get; set; }

        public string ChfPassword { get; set; }
    }

    /// <summary>
    /// chiron trip departure record
    /// </summary>
    public class Chironarrival
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        public string PitaneCustomer { get; set; }

        /// <summary>
        /// Trip number
        /// </summary>
        public string TripNumber { get; set; }

        /// <summary>
        /// KBO number
        /// </summary>
        public string KboNumber { get; set; }

        /// <summary>
        /// KBO name
        /// </summary>
        public string KboName { get; set; }

        public double Price { get; set; }

        public double Distance { get; set; }

        public double DepartureLatitude { get; set; }

        public double DepartureLongitude { get; set; }

        /// <summary>
        /// trip departure time
        /// </summary>
        public string DepartureTime { get; set; }

        public double ArrivalLatitude { get; set; }

        public double ArrivalLongitude { get; set; }

        /// <summary>
        /// trip dropoff time
        /// </summary>
        public string ArrivalTime { get; set; }

        /// <summary>
        /// driver card number
        /// </summary>
        public string DriverCardNumber { get; set; }

        /// <summary>
        /// car licenseplate
        /// </summary>
        public string VehicleLicensePlate { get; set; }
    }

    /// <summary>
    /// chiron trip departure record
    /// </summary>
    public class Chirondeparture
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        public string PitaneCustomer { get; set; }

        /// <summary>
        /// Trip number
        /// </summary>
        public string TripNumber { get; set; }

        /// <summary>
        /// KBO number
        /// </summary>
        public string KboNumber { get; set; }

        /// <summary>
        /// KBO name
        /// </summary>
        public string KboName { get; set; }

        public double Price { get; set; }

        public double Distance { get; set; }

        public double DepartureLatitude { get; set; }

        public double DepartureLongitude { get; set; }

        /// <summary>
        /// trip departure time
        /// </summary>
        public string DepartureTime { get; set; }

        /// <summary>
        /// driver card number
        /// </summary>
        public string DriverCardNumber { get; set; }

        /// <summary>
        /// car licenseplate
        /// </summary>
        public string VehicleLicensePlate { get; set; }
    }

    /// <summary>
    /// chiron reservation record
    /// </summary>
    public class Chironreservation
    {
        /// <summary>
        /// Customer ID
        /// </summary>
        public string PitaneCustomer { get; set; }

        /// <summary>
        /// Trip number
        /// </summary>
        public string TripNumber { get; set; }

        /// <summary>
        /// KBO number
        /// </summary>
        public string KboNumber { get; set; }

        /// <summary>
        /// KBO name
        /// </summary>
        public string KboName { get; set; }
    }

    public class Condition
    {
        /// <summary>
        /// The specific subclass of condition, should match the schema name exactly
        /// </summary>
        public string ConditionType { get; set; }

        /// <summary>
        /// An identifier for this condition that can be used to refer to this condition
        /// </summary>
        public string Id { get; set; }
    }

    /// <summary>
    /// in case the TO demands a deposit before usage. Requesting and refunding should be done using the /payment/claim-extra-costs endpoint.
    /// </summary>
    public class ConditionDeposit
    {
    }

    public class ConditionPostponedCommit
    {
        public DateTime UltimateResponseTime { get; set; }
    }

    /// <summary>
    /// a return area. In the condition list there can be multiple return area's.
    /// </summary>
    public class ConditionReturnArea
    {
        /// <summary>
        /// station to which the asset should be returned
        /// </summary>
        public string StationId { get; set; }

        public double[][][] ReturnArea { get; set; }

        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// the return hours of the facility (if different from operating-hours)
        /// </summary>
        public SystemHours[] ReturnHours { get; set; }
    }

    /// <summary>
    /// a lon, lat (WGS84, EPSG:4326)
    /// </summary>
    public class Coordinates
    {
        public double Lng { get; set; }

        public double Lat { get; set; }
    }

    /// <summary>
    /// delete cost record
    /// </summary>
    public class Costid
    {
        /// <summary>
        /// Cost ID
        /// </summary>
        public int PkoId { get; set; }
    }

    /// <summary>
    /// planning record
    /// </summary>
    public class Costplanning
    {
        public int PlaId { get; set; }

        public int ArtId { get; set; }

        public double ArtAantal { get; set; }

        public double ArtPrijs { get; set; }

        public string ArtTekst { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// default crow/trip record
    /// </summary>
    public class Crow
    {
        /// <summary>
        /// trip ID
        /// </summary>
        public int PcrPlaId { get; set; }

        /// <summary>
        /// CROW element
        /// </summary>
        public int PcrCroId { get; set; }
    }

    /// <summary>
    /// A MaaS user that wishes to make a booking, only use the fields required by booking conditions
    /// </summary>
    public class Customer
    {
        /// <summary>
        /// The identifier MaaS uses to identify the customer
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// optional reference field to the travelers in the planning request.
        /// </summary>
        public string TravelerReference { get; set; }

        public string Initials { get; set; }

        /// <summary>
        /// First name of the customer
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the customer
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Middle name of the customer
        /// </summary>
        public string MiddleName { get; set; }

        /// <summary>
        /// prefix of the customer, like titles
        /// </summary>
        public string Prefix { get; set; }

        /// <summary>
        /// postfix of the customer, like titles
        /// </summary>
        public string Postfix { get; set; }

        public Phone[] Phones { get; set; }

        /// <summary>
        /// the email address of the customer
        /// </summary>
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public Address Address { get; set; }

        /// <summary>
        /// base64 encoded
        /// </summary>
        public byte[] Photo { get; set; }

        public object[] Cards { get; set; }

        public object[] Licenses { get; set; }
    }

    /// <summary>
    /// loginname request record
    /// </summary>
    public class Customeremail
    {
        public string PorEmail { get; set; }
    }

    /// <summary>
    /// car / device IMEI
    /// </summary>
    public class Devicestatus
    {
        public string DevImei { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }

        public int Statuscode { get; set; }
    }

    /// <summary>
    /// update taxizone
    /// </summary>
    public class Devicezonestatus
    {
        public int LsnId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }

        public int LsnTaxizone { get; set; }
    }

    /// <summary>
    /// lat/lng routing
    /// </summary>
    public class Distancelatlng
    {
        public double OphLatitude { get; set; }

        public double OphLongitude { get; set; }

        public double BestLatitude { get; set; }

        public double BestLongitude { get; set; }
    }

    /// <summary>
    /// document record
    /// </summary>
    public class Document
    {
        public string DocExtensie { get; set; }

        public string DocBinairC64 { get; set; }

        public string DocNaam { get; set; }

        public string DocPincode { get; set; }

        public string DocApi { get; set; }
    }

    /// <summary>
    /// Driver email address
    /// </summary>
    public class Drivernotifystatus
    {
        public string ChfEmail { get; set; }

        public int ChfTplInloggen { get; set; }
    }

    /// <summary>
    /// Driver record primary keys
    /// </summary>
    public class Drivers
    {
        public int ChfId { get; set; }
    }

    /// <summary>
    /// Driver email address
    /// </summary>
    public class Driverstatus
    {
        public string ChfEmail { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }

        public int Statuscode { get; set; }
    }

    /// <summary>
    /// a formal description of an endpoint.
    /// </summary>
    public class Endpoint
    {
        public string Method { get; set; }

        /// <summary>
        /// the exact path of the endpoint, starting after the base URL
        /// </summary>
        public string Path { get; set; }

        public string EventType { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// does this endpoint support paging? In that case this endpoint can be accessed using query parameters offset=x and limit=y. Only allowed at endpoints that have specified these query parameters.
        /// </summary>
        public bool SupportsPaging { get; set; }

        public double MaxPageSize { get; set; }
    }

    /// <summary>
    /// a complete endpoint description, containing all endpoints, their status, but also the served scenarios and implemented process flows. The identifiers for the process flows can be found at https://github.com/TOMP-WG/TOMP-API/wiki/ProcessIdentifiers
    /// </summary>
    public class EndpointImplementation
    {
        public string Version { get; set; }

        public string BaseUrl { get; set; }

        public Endpoint[] Endpoints { get; set; }

        public string[] Scenarios { get; set; }

        public ProcessIdentifiers ProcessIdentifiers { get; set; }
    }

    /// <summary>
    /// An error that the service may send, e.g. in case of invalid input, missing authorization or internal service error. See https://github.com/TOMP-WG/TOMP-API/wiki/Error-handling-in-TOMP for further explanation of error code.
    /// </summary>
    public class Error
    {
        public double Errorcode { get; set; }

        /// <summary>
        /// The category of this type of error.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// A short, human-readable summary of the problem type.  It SHOULD NOT change from occurrence to occurrence of the problem, except to match Content-Language
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// The HTTP status code ([RFC7231], Section 6) generated by the origin server for this occurrence of the problem.
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// A human-readable explanation specific to this occurrence of the problem, could match Content-Language
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// A URI reference that identifies the specific occurrence of the problem.  It may or may not yield further information if dereferenced.
        /// </summary>
        public string Instance { get; set; }
    }

    /// <summary>
    /// Costs that the TO is charging the MP; credits are negative
    /// </summary>
    public class ExtraCosts
    {
        public string Category { get; set; }

        /// <summary>
        /// free text to describe the extra costs. Mandatory in case of 'OTHER', should match Content-Language
        /// </summary>
        public string Description { get; set; }

        public double Number { get; set; }

        public string NumberType { get; set; }

        public BankAccount Account { get; set; }

        /// <summary>
        /// Arbitrary metadata that a TO can add, like voucher codes
        /// </summary>
        public object Meta { get; set; }
    }

    /// <summary>
    /// the total fare is the sum of all parts, except for the 'MAX' farePart. This one descripes the maximum price for the complete leg.
    /// </summary>
    public class Fare
    {
        /// <summary>
        /// is this fare an estimation?
        /// </summary>
        public bool Estimated { get; set; }

        /// <summary>
        /// user friendly description of the fare (e.g. 'full fare'), should match Content-Language
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// in the future we'll set up an enumeration of possible "fare classes". For now it's free format.
        /// </summary>
        public string Class { get; set; }

        public object[] Parts { get; set; }
    }

    /// <summary>
    /// this describes a part of the fare (or discount). It contains a for instance the startup costs (fixed) or the flex part (e.g. 1.25 EUR per 2.0 MILES). The amount is tax included. In case of discounts, the values are negative. With 'MAX' you can specify e.g. a maximum of 15 euro per day. Percentage is mainly added for discounts. The `scale` properties create the ability to communicate scales (e.g. the first 4 kilometers you've to pay EUR 0.35 per kilometer, the kilometers 4 until 8 EUR 0.50 and above it EUR 0.80 per kilometer).
    /// </summary>
    public class FarePart
    {
        public string Type { get; set; }

        public string UnitType { get; set; }

        public double Units { get; set; }

        public double ScaleFrom { get; set; }

        public double ScaleTo { get; set; }

        public string ScaleType { get; set; }

        public string Name { get; set; }

        public string Class { get; set; }

        public object Meta { get; set; }
    }

    /// <summary>
    /// pause record
    /// </summary>
    public class Gpsbylicense
    {
        public string WagKenteken { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// default input field
    /// </summary>
    public class Inputfield
    {
        /// <summary>
        /// textfield
        /// </summary>
        public string Text { get; set; }
    }

    public class JournalEntry
    {
        /// <summary>
        /// id of the entry, leg id can be reused
        /// </summary>
        public string JournalId { get; set; }

        /// <summary>
        /// sequence id of the entry, in combination with journalId unique from TO perspective.
        /// </summary>
        public string JournalSequenceId { get; set; }

        /// <summary>
        /// the number of the invoice. Should be filled in when invoiced.
        /// </summary>
        public object InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string State { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Comment { get; set; }

        public double Distance { get; set; }

        public string DistanceType { get; set; }

        public double UsedTime { get; set; }

        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// the specification of the amount; how is it composed.
        /// </summary>
        public object Details { get; set; }
    }

    /// <summary>
    /// lat/lng record
    /// </summary>
    public class Latlng
    {
        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// A planned (segment of) a booked trip using one asset type
    /// </summary>
    public class Leg
    {
        /// <summary>
        /// The unique identifier (TO) of this leg
        /// </summary>
        public string Id { get; set; }

        public Place From { get; set; }

        public Place To { get; set; }

        /// <summary>
        /// The departure time of this leg
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// The intended arrival time at the to place
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// reference to the travelers field of the request. If missing, it is refering to the first (if any). it is an array to facilitate multiple users on one leg (e.g. using a car). If multiple access informations are needed, please create a leg per used asset.
        /// </summary>
        public string[] TravelerReferenceNumbers { get; set; }

        public AssetType AssetType { get; set; }

        /// <summary>
        /// The order of the leg in the booking. There can be multiple legs with the same sequence (different user or parallel usage (eg. parking lot and a bike)).
        /// </summary>
        public int LegSequenceNumber { get; set; }

        public Asset Asset { get; set; }

        public Fare Pricing { get; set; }

        public Suboperator Suboperator { get; set; }
    }

    /// <summary>
    /// event for the execution
    /// </summary>
    public class LegEvent
    {
        public DateTime Time { get; set; }

        public string Event { get; set; }

        /// <summary>
        /// free text, should match Content-Language
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// urls to support the event e.g. pictures justifying the exit conditions
        /// </summary>
        public string[] Url { get; set; }

        public Asset Asset { get; set; }
    }

    /// <summary>
    /// provides current asset location & duration and distance of the current leg
    /// </summary>
    public class LegProgress
    {
        public Coordinates Coordinates { get; set; }

        public int Duration { get; set; }

        public int Distance { get; set; }
    }

    /// <summary>
    /// driver or usage license for a specific user. Contains the number and the assetType you're allowed to operate (e.g. driver license for CAR)
    /// </summary>
    public class License
    {
        public string Number { get; set; }

        /// <summary>
        /// in most countries a driver license has also a code. As TO you can exactly verify, based on this code if the license allows to operate it's assets, if the assetType too generic.
        /// </summary>
        public string LicenseCode { get; set; }

        public DateTime ValidUntil { get; set; }
    }

    /// <summary>
    /// A category of license to use a certain asset class
    /// </summary>
    public class LicenseType
    {
        public string AssetClass { get; set; }

        public string IssuingCountry { get; set; }
    }

    /// <summary>
    /// Receive marketing information
    /// </summary>
    public class Marketing
    {
        /// <summary>
        /// Trip ID
        /// </summary>
        public int PlaId { get; set; }

        /// <summary>
        /// Marketing GUID
        /// </summary>
        public string PlaMarketing { get; set; }
    }

    /// <summary>
    /// password request record
    /// </summary>
    public class Passwordtoken
    {
        public string DevPasswordToken { get; set; }

        public string DevPasswordEmail { get; set; }
    }

    /// <summary>
    /// pause record
    /// </summary>
    public class Pauserecord
    {
        public int LsnId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }

        public string DevImei { get; set; }
    }

    /// <summary>
    /// customer paxx group update
    /// </summary>
    public class Paxxgroup
    {
        public int ReiId { get; set; }

        public string ReiGebdatum { get; set; }

        public int ReiPaxLevel { get; set; }

        public string ReiPaxIdentifier { get; set; }
    }

    /// <summary>
    /// customer paxx group update
    /// </summary>
    public class Paxxgroupguid
    {
        public string ReiGuid { get; set; }

        public string ReiGebdatum { get; set; }

        public int ReiPaxLevel { get; set; }

        public string ReiPaxIdentifier { get; set; }
    }

    public class Phone
    {
        /// <summary>
        /// only one phone in this array can have a true in this property
        /// </summary>
        public bool Preferred { get; set; }

        /// <summary>
        /// phone number. In case of international usage, always provide the country code.
        /// </summary>
        public string Number { get; set; }

        public string Kind { get; set; }

        public string Type { get; set; }
    }

    /// <summary>
    /// a origin or destination of a leg, non 3D. lon/lat in WGS84.
    /// </summary>
    public class Place
    {
        /// <summary>
        /// Human readable name of the place, could match Content-Language
        /// </summary>
        public string Name { get; set; }

        public StopReference[] StopReference { get; set; }

        /// <summary>
        /// reference to /operator/stations
        /// </summary>
        public string StationId { get; set; }

        public Coordinates Coordinates { get; set; }

        public Address PhysicalAddress { get; set; }

        public object ExtraInfo { get; set; }
    }

    /// <summary>
    /// planning record
    /// </summary>
    public class Planning
    {
        public int PlaId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// A travel planning for which bookable options are requested
    /// </summary>
    public class PlanningRequest
    {
        public Place From { get; set; }

        public double Radius { get; set; }

        public Place To { get; set; }

        /// <summary>
        /// The intended departure time. If left out and no arrivalTime is set, the current time should be assumed.
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// The intended arrival time, at the to place if set otherwise the time the user intends to stop using the asset.
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        /// <summary>
        /// The number of people that intend to travel, including the customer.
        /// </summary>
        public int NrOfTravelers { get; set; }

        /// <summary>
        /// Extra information about the people that intend to travel if relevant, length must be less than or equal to nrOftravelers.
        /// </summary>
        public Traveler[] Travelers { get; set; }

        /// <summary>
        /// The specific asset(s) the user wishes to receive leg options for
        /// </summary>
        public string[] UseAssets { get; set; }

        /// <summary>
        /// Id(s) of user groups that the user belongs to. This provides access to exclusive assets that are hidden to the public. Id's are agreed upon by TO and MP.
        /// </summary>
        public string[] UserGroups { get; set; }

        /// <summary>
        /// The specific asset type(s) the user wishes to receive leg options for
        /// </summary>
        public string[] UseAssetTypes { get; set; }
    }

    /// <summary>
    /// poi code
    /// </summary>
    public class Poi
    {
        public string VasCode { get; set; }

        public string PlaId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// PRDS confirmation
    /// </summary>
    public class Prdsconfirmation
    {
        public int PrdsId { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }

    public class ProcessIdentifiers
    {
        public string[] OperatorInformation { get; set; }

        public string[] Planning { get; set; }

        public string[] Booking { get; set; }

        public string[] TripExecution { get; set; }

        public string[] Support { get; set; }

        public string[] Payment { get; set; }

        public string[] General { get; set; }
    }

    /// <summary>
    /// set trip rating
    /// </summary>
    public class Rating
    {
        public int PlaId { get; set; }

        public int PlaPunten { get; set; }
    }

    /// <summary>
    /// customer guid combination
    /// </summary>
    public class ReiGuid
    {
        [Newtonsoft.Json.JsonProperty("ReiGuid")]
        public string ReiGuid_ { get; set; }

        public string ReiPassword { get; set; }
    }

    /// <summary>
    /// reset customer password request record
    /// </summary>
    public class Resetcustomerpassword
    {
        /// <summary>
        /// Customer guid
        /// </summary>
        public string ReiGuid { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string ReiAppPaswoord { get; set; }
    }

    /// <summary>
    /// reset driver password request record
    /// </summary>
    public class Resetdriverpassword
    {
        /// <summary>
        /// Driver email address
        /// </summary>
        public string ChfEmail { get; set; }

        /// <summary>
        /// Verification token
        /// </summary>
        public string ChfVerificatie { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        public string ChfAppPaswoord { get; set; }
    }

    /// <summary>
    /// reset user password request record
    /// </summary>
    public class Resetuserpassword
    {
        /// <summary>
        /// User key
        /// </summary>
        public int PorId { get; set; }

        /// <summary>
        /// Loginname
        /// </summary>
        public string PorInlogcode { get; set; }

        /// <summary>
        /// Hash password
        /// </summary>
        public string Hash { get; set; }
    }

    /// <summary>
    /// route confirmation record
    /// </summary>
    public class Routeconfirmation
    {
        public int PlaPmNummer { get; set; }

        public int PlaRoute { get; set; }
    }

    /// <summary>
    /// Service start record
    /// </summary>
    public class Servicestart
    {
        public int LsnWagId { get; set; }

        public int LsnChfId { get; set; }

        public double LsnKilometerstandAanvang { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }

        public int ChfSubcentrale { get; set; }

        public string DevImei { get; set; }
    }

    /// <summary>
    /// Service stop record
    /// </summary>
    public class Servicestop
    {
        public int LsnId { get; set; }

        public double LsnKilometerstandEinde { get; set; }

        public double Latitude { get; set; }

        public object Longitude { get; set; }

        public int Speed { get; set; }

        public string DevImei { get; set; }
    }

    /// <summary>
    /// sms record
    /// </summary>
    public class Sms
    {
        /// <summary>
        /// Your personal access key for the SMS provider.
        /// </summary>
        public string AccessKey { get; set; }

        /// <summary>
        /// Only one phone number. In case of international usage, always provide the country code.
        /// </summary>
        public string Recipient { get; set; }

        /// <summary>
        /// Originator or number (max 10 characters).
        /// </summary>
        public string Originator { get; set; }

        /// <summary>
        /// Your personal message.
        /// </summary>
        public string Body { get; set; }
    }

    /// <summary>
    /// reference to a stop (can be nation specific). This can help to specific pinpoint a (bus) stop. Extra information about the stop is not supplied; you should find it elsewhere.
    /// </summary>
    public class StopReference
    {
        public string Type { get; set; }

        /// <summary>
        /// this field should contain the complete ID. E.g. NL:S:13121110 or BE:S:79640040
        /// </summary>
        public string Id { get; set; }

        public string Country { get; set; }
    }

    /// <summary>
    /// The operator of a leg or asset, in case this is not the TO itself but should be shown to the user
    /// </summary>
    public class Suboperator
    {
        /// <summary>
        /// Name of the operator, could match Content-Language
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// the maasId from the operator
        /// </summary>
        public string MaasId { get; set; }

        /// <summary>
        /// short description of the operator, should match Content-Language
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// contact information, should match Content-Language
        /// </summary>
        public string Contact { get; set; }
    }

    public class SystemHours
    {
        public string UserType { get; set; }

        /// <summary>
        /// If this parameter is present, it means that startTime and endTime correspond to the opening and closing hours of the station. (GET /operator/stations)
        /// </summary>
        public string StationId { get; set; }

        /// <summary>
        /// If this parameter is present, it means that startTime and endTime correspond to the opening and closing hours for the region. (GET /operator/regions)
        /// </summary>
        public string RegionId { get; set; }

        public string StartTime { get; set; }

        public string EndTime { get; set; }

        /// <summary>
        /// An array of abbreviations (first 3 letters) of English names of the days of the week that this hour object applies to (i.e. ["mon", "tue"]). Each day can only appear once within all of the hours objects in this feed.
        /// </summary>
        public string[] Days { get; set; }
    }

    /// <summary>
    /// tariff record
    /// </summary>
    public class Tariff
    {
        public string FromAddress { get; set; }

        public string ToAddress { get; set; }

        public int ReiId { get; set; }

        public string ReiVorId { get; set; }

        public string ReiWsoId { get; set; }

        public int PlaLopers { get; set; }

        public int PlaRollers { get; set; }
    }

    /// <summary>
    /// tariff record Arrive
    /// </summary>
    public class Tariffarrive
    {
        public string FromAddress { get; set; }

        public string ToAddress { get; set; }

        public int ReiId { get; set; }

        public string ReiVorId { get; set; }

        public string ReiWsoId { get; set; }

        public int PlaLopers { get; set; }

        public int PlaRollers { get; set; }

        public int BtaId { get; set; }
    }

    /// <summary>
    /// The validity token (such as booking ID, travel ticket etc.) that MaaS clients will display to show their right to travel, or use to access an asset
    /// </summary>
    public class Token
    {
        public DateTime ValidFrom { get; set; }

        public DateTime ValidUntil { get; set; }

        /// <summary>
        /// The type of data held in this token, will later be an enum
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// Arbitrary data the TO may pass along the ticket to the client (e.g. a booking code, base64 encoded binary, QR code), later will be one of several types
        /// </summary>
        public object TokenData { get; set; }
    }

    /// <summary>
    /// A generic description of a traveler, not including any identifying information
    /// </summary>
    public class Traveler
    {
        /// <summary>
        /// Whether this traveler's identity and properties have been verified by the MaaS provider
        /// </summary>
        public bool IsValidated { get; set; }

        /// <summary>
        /// Age of the traveler, may be approximate
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// reference number of the traveler. This number could be used to refer to in the planning result.
        /// </summary>
        public string ReferenceNumber { get; set; }

        /// <summary>
        /// The kind of cards this traveler possesses
        /// </summary>
        public CardType[] CardTypes { get; set; }

        /// <summary>
        /// The kind of licenses this traveler possesses
        /// </summary>
        public LicenseType[] LicenseTypes { get; set; }

        public object Requirements { get; set; }
    }

    /// <summary>
    /// default trip record
    /// </summary>
    public class Trip
    {
        /// <summary>
        /// trip ID
        /// </summary>
        public int PlaId { get; set; }

        /// <summary>
        /// trip ID
        /// </summary>
        public string PlaNaamReiziger { get; set; }
    }

    /// <summary>
    /// cancel pending or waiting trip
    /// </summary>
    public class Tripcancel
    {
        public string PlaGuid { get; set; }

        public string PlaOpmerking { get; set; }
    }

    /// <summary>
    /// trip confirmation record
    /// </summary>
    public class Tripconfirmation
    {
        public int PlaId { get; set; }

        public int PlaPmNummer { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// Update trip status
    /// </summary>
    public class Tripstatus
    {
        public string SubToken { get; set; }

        public int PlaId { get; set; }

        public int PlaPmNummer { get; set; }

        public string PlaTimestamp { get; set; }

        public double PlaLatitude { get; set; }

        public double PlaLongitude { get; set; }

        public int Speed { get; set; }

        public string Licenseplate { get; set; }
    }

    /// <summary>
    /// trip status update record
    /// </summary>
    public class TripStatusUpdateAssigned
    {
        public int PlaId { get; set; }

        public string PlaTijdstipToewijzen { get; set; }

        public int PlaOdoStart { get; set; }

        public int Speed { get; set; }

        public string PlaCkenteken { get; set; }

        public string PlaCtelUitvoerder { get; set; }

        public string PlaCuitvoerder { get; set; }

        public int PlaExternVoertuigID { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }
    }

    /// <summary>
    /// trip status update record
    /// </summary>
    public class Tripstatusupdatedropoff
    {
        public int PlaId { get; set; }

        public string PlaTijdstipVrijmelden { get; set; }

        public int PlaOdoStop { get; set; }

        public string PlaPasnummer { get; set; }

        public int PlaWachtseconden { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int Speed { get; set; }

        public string PlaTxOpmerking { get; set; }

        public double PlaTxPaidAmount { get; set; }

        public double PlaTxPaidExtra { get; set; }

        public int PlaTxPaymentType { get; set; }

        public int LsnId { get; set; }
    }

    /// <summary>
    /// trip status update record
    /// </summary>
    public class Tripstatusupdatedropoffbyguid
    {
        public string PlaGuid { get; set; }

        public string PlaTijdstipVrijmelden { get; set; }

        public int PlaOdoStop { get; set; }

        public string PlaPasnummer { get; set; }

        public int PlaWachtseconden { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int Speed { get; set; }

        public string PlaTxOpmerking { get; set; }

        public double PlaTxPaidAmount { get; set; }

        public double PlaTxPaidExtra { get; set; }

        public int PlaTxPaymentType { get; set; }

        public int LsnId { get; set; }
    }

    /// <summary>
    /// trip status update record
    /// </summary>
    public class Tripstatusupdatenoshow
    {
        public int PlaId { get; set; }

        public string PlaTijdstipBestemmen { get; set; }

        public int PlaOdoStart { get; set; }

        public string PlaRedenloosmelden { get; set; }

        public int Speed { get; set; }

        public string PlaPasnummer { get; set; }

        public int PlaWachtseconden { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int LsnId { get; set; }
    }

    /// <summary>
    /// trip status update record
    /// </summary>
    public class Tripstatusupdatenoshowbyguid
    {
        public string PlaGuid { get; set; }

        public string PlaTijdstipBestemmen { get; set; }

        public int PlaOdoStart { get; set; }

        public string PlaRedenloosmelden { get; set; }

        public int Speed { get; set; }

        public string PlaPasnummer { get; set; }

        public int PlaWachtseconden { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int LsnId { get; set; }
    }

    /// <summary>
    /// trip payment update record
    /// </summary>
    public class Tripstatusupdatepayment
    {
        public int PlaId { get; set; }

        public double PlaTxPaidAmount { get; set; }

        public double PlaTxPaidExtra { get; set; }

        public int PlaBetaling { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// trip payment update record
    /// </summary>
    public class Tripstatusupdatepaymentguid
    {
        public string PlaGuid { get; set; }

        public string PlaStatus { get; set; }

        public double PlaTxPaidAmount { get; set; }

        public double PlaTxPaidExtra { get; set; }

        public int PlaBetaling { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// trip status update record
    /// </summary>
    public class Tripstatusupdatepickup
    {
        public int PlaId { get; set; }

        public string PlaTijdstipBestemmen { get; set; }

        public int PlaOdoStart { get; set; }

        public int Speed { get; set; }

        public string PlaPasnummer { get; set; }

        public int PlaWachtseconden { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int LsnId { get; set; }
    }

    /// <summary>
    /// trip status update record
    /// </summary>
    public class Tripstatusupdatepickupbyguid
    {
        public string PlaGuid { get; set; }

        public string PlaTijdstipBestemmen { get; set; }

        public int PlaOdoStart { get; set; }

        public int Speed { get; set; }

        public string PlaPasnummer { get; set; }

        public int PlaWachtseconden { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int LsnId { get; set; }
    }

    /// <summary>
    /// trip sector update record
    /// </summary>
    public class Tripstatusupdatesector
    {
        public int PlaId { get; set; }

        public int PlaBestSector { get; set; }

        public string Latitude { get; set; }

        public string Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// planning record
    /// </summary>
    public class Tripticket
    {
        public int PlaId { get; set; }

        public string PlaEmail { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }

    /// <summary>
    /// planning record
    /// </summary>
    public class Tripticketguid
    {
        public string PlaGuid { get; set; }

        public string PlaEmail { get; set; }

        public double Latitude { get; set; }

        public double Longitude { get; set; }

        public int Speed { get; set; }
    }
}