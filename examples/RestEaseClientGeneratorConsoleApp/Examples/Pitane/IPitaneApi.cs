using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using AnyOfTypes;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.Pitane.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.Pitane.Api
{
    /// <summary>
    /// Pitane Network API v3.0.1 - Pitane B.V.  Pitane API - MaaS Mobility Provider - TOMP API support Last update - 2022-01-26 - [More information](https://pitane.dev) 
    /// </summary>
    public interface IPitaneApi
    {
        [Header("pitane-key")]
        string PitaneKey { get; set; }

        /// <summary>
        /// GetPitaneEasyTravelDistance (/pitaneEasyTravelDistance)
        /// </summary>
        /// <param name="zipFrom"></param>
        /// <param name="zipTo"></param>
        [Get("/pitaneEasyTravelDistance")]
        Task<object> GetPitaneEasyTravelDistanceAsync([Query(Name = "zip_from")] string zipFrom, [Query(Name = "zip_to")] string zipTo);

        /// <summary>
        /// GetPitaneDeviceDocumentsPin (/pitaneDeviceDocumentsPin)
        /// </summary>
        /// <param name="pincode"></param>
        [Get("/pitaneDeviceDocumentsPin")]
        Task<object> GetPitaneDeviceDocumentsPinAsync([Query] string pincode);

        /// <summary>
        /// GetPitaneping (/pitaneping)
        /// </summary>
        [Get("/pitaneping")]
        Task<object> GetPitanepingAsync();

        /// <summary>
        /// PostPitaneChironSendReservation (/pitaneChironSendReservation)
        /// </summary>
        /// <param name="content">chiron reservation record</param>
        [Post("/pitaneChironSendReservation")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneChironSendReservationAsync([Body] Chironreservation content);

        /// <summary>
        /// PostPitaneChironSendDeparture (/pitaneChironSendDeparture)
        /// </summary>
        /// <param name="content">chiron trip departure record</param>
        [Post("/pitaneChironSendDeparture")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneChironSendDepartureAsync([Body] Chirondeparture content);

        /// <summary>
        /// PostPitaneChironSendArrival (/pitaneChironSendArrival)
        /// </summary>
        /// <param name="content">chiron trip departure record</param>
        [Post("/pitaneChironSendArrival")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneChironSendArrivalAsync([Body] Chironarrival content);

        /// <summary>
        /// GetPitaneChironCredentialTest (/pitaneChironCredentialTest)
        /// </summary>
        /// <param name="pitaneCustomer"></param>
        [Get("/pitaneChironCredentialTest")]
        Task<object> GetPitaneChironCredentialTestAsync([Query] string pitaneCustomer);

        /// <summary>
        /// GetPitaneAuthenticate (/pitaneAuthenticate)
        /// </summary>
        /// <param name="pitaneVersion"></param>
        /// <param name="pitaneUsername"></param>
        [Get("/pitaneAuthenticate")]
        Task<object> GetPitaneAuthenticateAsync([Header("pitane-version")] string pitaneVersion, [Header("pitane-username")] string pitaneUsername);

        /// <summary>
        /// GetPitaneCustomerTransportTypesRetrievebyID (/pitaneCustomerTransportTypesRetrievebyID)
        /// </summary>
        /// <param name="reiId"></param>
        /// <param name="appVersion"></param>
        [Get("/pitaneCustomerTransportTypesRetrievebyID")]
        Task<object> GetPitaneCustomerTransportTypesRetrievebyIDAsync([Query(Name = "rei_id")] int reiId, [Header("AppVersion")] string appVersion);

        /// <summary>
        /// GetPitaneCustomerTransportTypesRetrievebyGUID (/pitaneCustomerTransportTypesRetrievebyGUID)
        /// </summary>
        /// <param name="reiGuid"></param>
        /// <param name="appVersion"></param>
        [Get("/pitaneCustomerTransportTypesRetrievebyGUID")]
        Task<object> GetPitaneCustomerTransportTypesRetrievebyGUIDAsync([Query(Name = "rei_guid")] string reiGuid, [Header("AppVersion")] string appVersion);

        /// <summary>
        /// GetPitaneCustomerRetrieveVirtualPlanning (/pitaneCustomerRetrieveVirtualPlanning)
        /// </summary>
        /// <param name="reiId"></param>
        /// <param name="plaDatum"></param>
        /// <param name="offset"></param>
        [Get("/pitaneCustomerRetrieveVirtualPlanning")]
        Task<object> GetPitaneCustomerRetrieveVirtualPlanningAsync([Query(Name = "rei_id")] int reiId, [Query(Name = "pla_datum")] string plaDatum, [Query] int? offset);

        /// <summary>
        /// GetPitaneCustomerAddressRetrievebyID (/pitaneCustomerAddressRetrievebyID)
        /// </summary>
        /// <param name="reiId"></param>
        [Get("/pitaneCustomerAddressRetrievebyID")]
        Task<object> GetPitaneCustomerAddressRetrievebyIDAsync([Query(Name = "rei_id")] int reiId);

        /// <summary>
        /// GetPitaneCustomerAddressRetrievebyGUID (/pitaneCustomerAddressRetrievebyGUID)
        /// </summary>
        /// <param name="reiGuid"></param>
        [Get("/pitaneCustomerAddressRetrievebyGUID")]
        Task<object> GetPitaneCustomerAddressRetrievebyGUIDAsync([Query(Name = "rei_guid")] string reiGuid);

        /// <summary>
        /// PostPitaneCustomerDeleteByGUID (/pitaneCustomerDeleteByGUID)
        /// </summary>
        /// <param name="content">customer guid combination</param>
        [Post("/pitaneCustomerDeleteByGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneCustomerDeleteByGUIDAsync([Body] ReiGuid content);

        /// <summary>
        /// GetPitaneContactsRetrievebyEmail (/pitaneContactsRetrievebyEmail)
        /// </summary>
        /// <param name="cprEmail"></param>
        [Get("/pitaneContactsRetrievebyEmail")]
        Task<object> GetPitaneContactsRetrievebyEmailAsync([Query(Name = "cpr_email")] string cprEmail);

        /// <summary>
        /// GetPitaneCustomerRetrieveComplainsByGuid (/pitaneCustomerRetrieveComplainsByGuid)
        /// </summary>
        /// <param name="reiGuid"></param>
        [Get("/pitaneCustomerRetrieveComplainsByGuid")]
        Task<object> GetPitaneCustomerRetrieveComplainsByGuidAsync([Query(Name = "rei_guid")] string reiGuid);

        /// <summary>
        /// GetPitaneCustomerTripDateSetRetrievebyID (/pitaneCustomerTripDateSetRetrievebyID)
        /// </summary>
        /// <param name="reiId"></param>
        /// <param name="reiStartdate"></param>
        /// <param name="reiEnddate"></param>
        /// <param name="plaStatus"></param>
        /// <param name="plaSoortvervoer"></param>
        /// <param name="offset"></param>
        [Get("/pitaneCustomerTripDateSetRetrievebyID")]
        Task<object> GetPitaneCustomerTripDateSetRetrievebyIDAsync([Query(Name = "rei_id")] int reiId, [Query(Name = "rei_startdate")] string reiStartdate, [Query(Name = "rei_enddate")] string reiEnddate, [Query(Name = "pla_status")] string plaStatus, [Query(Name = "pla_soortvervoer")] string plaSoortvervoer, [Query] int? offset);

        /// <summary>
        /// GetPitaneCustomerTripDateSetRetrievebyGUID (/pitaneCustomerTripDateSetRetrievebyGUID)
        /// </summary>
        /// <param name="reiGuid"></param>
        /// <param name="reiStartdate"></param>
        /// <param name="reiEnddate"></param>
        /// <param name="plaStatus"></param>
        /// <param name="plaSoortvervoer"></param>
        /// <param name="offset"></param>
        [Get("/pitaneCustomerTripDateSetRetrievebyGUID")]
        Task<object> GetPitaneCustomerTripDateSetRetrievebyGUIDAsync([Query(Name = "rei_guid")] string reiGuid, [Query(Name = "rei_startdate")] string reiStartdate, [Query(Name = "rei_enddate")] string reiEnddate, [Query(Name = "pla_status")] string plaStatus, [Query(Name = "pla_soortvervoer")] string plaSoortvervoer, [Query] int? offset);

        /// <summary>
        /// GetPitaneCustomerRetrievebyZipcodeExtBirth (/pitaneCustomerRetrievebyZipcodeExtBirth)
        /// </summary>
        /// <param name="reiGebdatum"></param>
        /// <param name="adrPostcode"></param>
        /// <param name="adrHuisnummer"></param>
        /// <param name="adrToevoeging"></param>
        /// <param name="adrCheck"></param>
        [Get("/pitaneCustomerRetrievebyZipcodeExtBirth")]
        Task<object> GetPitaneCustomerRetrievebyZipcodeExtBirthAsync([Query(Name = "rei_gebdatum")] string reiGebdatum, [Query(Name = "adr_postcode")] string adrPostcode, [Query(Name = "adr_huisnummer")] string adrHuisnummer, [Query(Name = "adr_toevoeging")] string adrToevoeging, [Query(Name = "adr_check")] int? adrCheck);

        /// <summary>
        /// PostPitaneSendCustomerAbsent (/pitaneSendCustomerAbsent)
        /// </summary>
        /// <param name="content">create absent record</param>
        [Post("/pitaneSendCustomerAbsent")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendCustomerAbsentAsync([Body] Absentrecord content);

        /// <summary>
        /// PostPitaneSendCustomerAbsentByGUID (/pitaneSendCustomerAbsentByGUID)
        /// </summary>
        /// <param name="content">create absent record</param>
        [Post("/pitaneSendCustomerAbsentByGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendCustomerAbsentByGUIDAsync([Body] Absentrecordguid content);

        /// <summary>
        /// PostPitaneCalculateTariffArrive (/pitaneCalculateTariffArrive)
        /// </summary>
        /// <param name="content">tariff record Arrive</param>
        [Post("/pitaneCalculateTariffArrive")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneCalculateTariffArriveAsync([Body] Tariffarrive content);

        /// <summary>
        /// PostPitaneCalculateTariff (/pitaneCalculateTariff)
        /// </summary>
        /// <param name="content">tariff record</param>
        [Post("/pitaneCalculateTariff")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneCalculateTariffAsync([Body] Tariff content);

        /// <summary>
        /// PostPitaneSendTripInsert (/pitaneSendTripInsert)
        /// </summary>
        /// <param name="content">default trip record</param>
        [Post("/pitaneSendTripInsert")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripInsertAsync([Body] Trip content);

        /// <summary>
        /// PostPitaneInsertTripCROW (/pitaneInsertTripCROW)
        /// </summary>
        /// <param name="content">default crow/trip record</param>
        [Post("/pitaneInsertTripCROW")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneInsertTripCROWAsync([Body] Crow content);

        /// <summary>
        /// PostPitaneSendCustomerAbsentUpdate (/pitaneSendCustomerAbsentUpdate)
        /// </summary>
        /// <param name="content">update absent record</param>
        [Post("/pitaneSendCustomerAbsentUpdate")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendCustomerAbsentUpdateAsync([Body] AbsentUpdaterecord content);

        /// <summary>
        /// PostPitaneSendCustomerAbsentUpdateByGUID (/pitaneSendCustomerAbsentUpdateByGUID)
        /// </summary>
        /// <param name="content">update absent record</param>
        [Post("/pitaneSendCustomerAbsentUpdateByGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendCustomerAbsentUpdateByGUIDAsync([Body] AbsentUpdaterecordguid content);

        /// <summary>
        /// GetPitaneArticleOnlineRetrieve (/pitaneArticleOnlineRetrieve)
        /// </summary>
        [Get("/pitaneArticleOnlineRetrieve")]
        Task<object> GetPitaneArticleOnlineRetrieveAsync();

        /// <summary>
        /// GetPitaneSendCustomerAbsentSummary (/pitaneSendCustomerAbsentSummary)
        /// </summary>
        /// <param name="ondReiId">Customer ID</param>
        [Get("/pitaneSendCustomerAbsentSummary")]
        Task<object> GetPitaneSendCustomerAbsentSummaryAsync([Query(Name = "ond_rei_id")] int ondReiId);

        /// <summary>
        /// GetPitaneSendCustomerAbsentSummaryByGUID (/pitaneSendCustomerAbsentSummaryByGUID)
        /// </summary>
        /// <param name="reiGuid">Customer ID</param>
        [Get("/pitaneSendCustomerAbsentSummaryByGUID")]
        Task<object> GetPitaneSendCustomerAbsentSummaryByGUIDAsync([Query(Name = "rei_guid")] string reiGuid);

        /// <summary>
        /// GetPitaneCollectTrips (/pitaneCollectTrips)
        /// </summary>
        /// <param name="plaDatumtijdFrom">Start date/time collection.</param>
        /// <param name="plaDatumtijdTo">End date/time collection.</param>
        /// <param name="plaSoortvervoer">Travel kind collection</param>
        /// <param name="plaRolstoel">Wheelchair only</param>
        /// <param name="plaRolstoelExcluded">Wheelchair trips excluded</param>
        /// <param name="plaEigenaarFiltered">Wheelchair trips excluded</param>
        /// <param name="plaEigenaar">Trip owner (optional)</param>
        [Get("/pitaneCollectTrips")]
        Task<object> GetPitaneCollectTripsAsync([Query(Name = "pla_datumtijd_from")] string plaDatumtijdFrom, [Query(Name = "pla_datumtijd_to")] string plaDatumtijdTo, [Query(Name = "pla_soortvervoer")] string plaSoortvervoer, [Query(Name = "pla_rolstoel")] bool plaRolstoel, [Query(Name = "pla_rolstoel_excluded")] bool plaRolstoelExcluded, [Query(Name = "pla_eigenaar_filtered")] bool plaEigenaarFiltered, [Query(Name = "pla_eigenaar")] string plaEigenaar);

        /// <summary>
        /// GetPitaneCollectTripsByAPI (/pitaneCollectTripsByAPI)
        /// </summary>
        /// <param name="subToken">Start date/time collection.</param>
        /// <param name="plaDatumtijdFrom">Start date/time collection.</param>
        /// <param name="plaDatumtijdTo">End date/time collection.</param>
        /// <param name="plaSoortvervoer">Travel kind collection</param>
        /// <param name="plaRolstoel">Wheelchair only</param>
        /// <param name="plaRolstoelExcluded">Wheelchair trips excluded</param>
        /// <param name="plaEigenaarFiltered">Wheelchair trips excluded</param>
        /// <param name="plaEigenaar">Trip owner (optional)</param>
        [Get("/pitaneCollectTripsByAPI")]
        Task<object> GetPitaneCollectTripsByAPIAsync([Query(Name = "sub_token")] string subToken, [Query(Name = "pla_datumtijd_from")] string plaDatumtijdFrom, [Query(Name = "pla_datumtijd_to")] string plaDatumtijdTo, [Query(Name = "pla_soortvervoer")] string plaSoortvervoer, [Query(Name = "pla_rolstoel")] bool plaRolstoel, [Query(Name = "pla_rolstoel_excluded")] bool plaRolstoelExcluded, [Query(Name = "pla_eigenaar_filtered")] bool plaEigenaarFiltered, [Query(Name = "pla_eigenaar")] string plaEigenaar);

        /// <summary>
        /// Create route
        /// </summary>
        /// <param name="content">Collection of combined trip records</param>
        [Post("/pitaneUpdateTripCollection")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneUpdateTripCollectionAsync([Body] ArrayOfCombinedTrips[] content);

        /// <summary>
        /// GetPitaneGetmetaInformation (/pitaneGetmetaInformation)
        /// </summary>
        /// <param name="tablename">Table name - see table definitions</param>
        [Get("/pitaneGetmetaInformation")]
        Task<object> GetPitaneGetmetaInformationAsync([Query] string tablename);

        /// <summary>
        /// PostPitaneHashConvert (/pitaneHashConvert)
        /// </summary>
        /// <param name="content">default input field</param>
        [Post("/pitaneHashConvert")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneHashConvertAsync([Body] Inputfield content);

        /// <summary>
        /// PostPitaneUserResetPassword (/pitaneUserResetPassword)
        /// </summary>
        /// <param name="content">reset user password request record</param>
        [Post("/pitaneUserResetPassword")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneUserResetPasswordAsync([Body] Resetuserpassword content);

        /// <summary>
        /// PostPitaneDriverResetPassword (/pitaneDriverResetPassword)
        /// </summary>
        /// <param name="content">reset driver password request record</param>
        [Post("/pitaneDriverResetPassword")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDriverResetPasswordAsync([Body] Resetdriverpassword content);

        /// <summary>
        /// PostPitaneCustomerResetPassword (/pitaneCustomerResetPassword)
        /// </summary>
        /// <param name="content">reset customer password request record</param>
        [Post("/pitaneCustomerResetPassword")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneCustomerResetPasswordAsync([Body] Resetcustomerpassword content);

        /// <summary>
        /// PostPitanedevicesendvoicerequest (/pitanedevicesendvoicerequest)
        /// </summary>
        /// <param name="chfEmail">Your personal access key for the SMS provider.</param>
        [Post("/pitanedevicesendvoicerequest")]
        Task<object> PostPitanedevicesendvoicerequestAsync([Query(Name = "chf_email")] string chfEmail);

        /// <summary>
        /// PostPitaneDeviceSendPushMessageSMS (/pitaneDeviceSendPushMessageSMS)
        /// </summary>
        /// <param name="content">sms record</param>
        [Post("/pitaneDeviceSendPushMessageSMS")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendPushMessageSMSAsync([Body] Sms content);

        /// <summary>
        /// PostPitaneMarketingTraject (/pitaneMarketingTraject)
        /// </summary>
        /// <param name="content">Receive marketing information</param>
        [Post("/pitaneMarketingTraject")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneMarketingTrajectAsync([Body] Marketing content);

        /// <summary>
        /// PostPitaneAddressFromLatLong (/pitaneAddressFromLatLong)
        /// </summary>
        /// <param name="content">lat/lng record</param>
        [Post("/pitaneAddressFromLatLong")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneAddressFromLatLongAsync([Body] Latlng content);

        /// <summary>
        /// PostPitaneGetLatLongFromAddress (/pitaneGetLatLongFromAddress)
        /// </summary>
        /// <param name="content">address field</param>
        [Post("/pitaneGetLatLongFromAddress")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneGetLatLongFromAddressAsync([Body] Address content);

        /// <summary>
        /// PostPitaneRoutingDistancebyLatLong (/pitaneRoutingDistancebyLatLong)
        /// </summary>
        /// <param name="content">lat/lng routing</param>
        [Post("/pitaneRoutingDistancebyLatLong")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneRoutingDistancebyLatLongAsync([Body] Distancelatlng content);

        /// <summary>
        /// PostPitaneRoutingRouteLegsbyLatLong (/pitaneRoutingRouteLegsbyLatLong)
        /// </summary>
        /// <param name="content">lat/lng routing</param>
        [Post("/pitaneRoutingRouteLegsbyLatLong")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneRoutingRouteLegsbyLatLongAsync([Body] Distancelatlng content);

        /// <summary>
        /// GetPitaneDeviceRequestDriverAccountbyGSM (/pitaneDeviceRequestDriverAccountbyGSM)
        /// </summary>
        /// <param name="chfMobiel"></param>
        [Get("/pitaneDeviceRequestDriverAccountbyGSM")]
        Task<object> GetPitaneDeviceRequestDriverAccountbyGSMAsync([Query(Name = "chf_mobiel")] string chfMobiel);

        /// <summary>
        /// PostPitanedevicesendrouteconfirmation (/pitanedevicesendrouteconfirmation)
        /// </summary>
        /// <param name="content">route confirmation record</param>
        [Post("/pitanedevicesendrouteconfirmation")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitanedevicesendrouteconfirmationAsync([Body] Routeconfirmation content);

        /// <summary>
        /// PostPitaneDeviceSendPlanningConfirmation (/pitaneDeviceSendPlanningConfirmation)
        /// </summary>
        /// <param name="content">planning record</param>
        [Post("/pitaneDeviceSendPlanningConfirmation")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendPlanningConfirmationAsync([Body] Planning content);

        /// <summary>
        /// PostPitaneDeviceSendDestinationbyPOI (/pitaneDeviceSendDestinationbyPOI)
        /// </summary>
        /// <param name="content">poi code</param>
        [Post("/pitaneDeviceSendDestinationbyPOI")]
        [Header("Content-Type", "application/json")]
        Task<Response<object>> PostPitaneDeviceSendDestinationbyPOIAsync([Body] Poi content);

        /// <summary>
        /// PostPitaneCustomerResetPasswordByEmailToken (/pitaneCustomerResetPasswordByEmailToken)
        /// </summary>
        /// <param name="content">password request record</param>
        [Post("/pitaneCustomerResetPasswordByEmailToken")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneCustomerResetPasswordByEmailTokenAsync([Body] Passwordtoken content);

        /// <summary>
        /// PostPitaneDeviceResetPasswordByEmailToken (/pitaneDeviceResetPasswordByEmailToken)
        /// </summary>
        /// <param name="content">password request record</param>
        [Post("/pitaneDeviceResetPasswordByEmailToken")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceResetPasswordByEmailTokenAsync([Body] Passwordtoken content);

        /// <summary>
        /// PostPitaneResetPasswordByEmailToken (/pitaneResetPasswordByEmailToken)
        /// </summary>
        /// <param name="content">password request record</param>
        [Post("/pitaneResetPasswordByEmailToken")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneResetPasswordByEmailTokenAsync([Body] Passwordtoken content);

        /// <summary>
        /// PostPitanersendloginnamebyemail (/pitanersendloginnamebyemail)
        /// </summary>
        /// <param name="content">loginname request record</param>
        [Post("/pitanersendloginnamebyemail")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitanersendloginnamebyemailAsync([Body] Customeremail content);

        /// <summary>
        /// PostPitaneDeviceSendServiceStart (/pitaneDeviceSendServiceStart)
        /// </summary>
        /// <param name="content">Service start record</param>
        [Post("/pitaneDeviceSendServiceStart")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendServiceStartAsync([Body] Servicestart content);

        /// <summary>
        /// PostPitaneNSSendServiceStartByNSD (/pitaneNSSendServiceStartByNSD)
        /// </summary>
        /// <param name="lsnWagId"></param>
        /// <param name="lsnChfId"></param>
        /// <param name="lsnKilometerstandAanvang"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="lsnNspId"></param>
        /// <param name="chfSubcentrale"></param>
        /// <param name="lsnNsdId"></param>
        /// <param name="devImei"></param>
        /// <param name="plaId"></param>
        [Post("/pitaneNSSendServiceStartByNSD")]
        Task<object> PostPitaneNSSendServiceStartByNSDAsync([Query(Name = "lsn_wag_id")] int lsnWagId, [Query(Name = "lsn_chf_id")] int lsnChfId, [Query(Name = "lsn_kilometerstand_aanvang")] int lsnKilometerstandAanvang, [Query] double latitude, [Query] double longitude, [Query(Name = "lsn_nsp_id")] int lsnNspId, [Query(Name = "chf_subcentrale")] int chfSubcentrale, [Query(Name = "lsn_nsd_id")] int lsnNsdId, [Query(Name = "dev_imei")] string devImei, [Query(Name = "pla_id")] int plaId);

        /// <summary>
        /// PostPitaneNSSendServiceStart (/pitaneNSSendServiceStart)
        /// </summary>
        /// <param name="lsnWagId"></param>
        /// <param name="lsnChfId"></param>
        /// <param name="lsnKilometerstandAanvang"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="lsnNspId"></param>
        /// <param name="chfSubcentrale"></param>
        /// <param name="lsnNsdId"></param>
        /// <param name="devImei"></param>
        /// <param name="plaId"></param>
        [Post("/pitaneNSSendServiceStart")]
        Task<object> PostPitaneNSSendServiceStartAsync([Query(Name = "lsn_wag_id")] int lsnWagId, [Query(Name = "lsn_chf_id")] int lsnChfId, [Query(Name = "lsn_kilometerstand_aanvang")] int lsnKilometerstandAanvang, [Query] double latitude, [Query] double longitude, [Query(Name = "lsn_nsp_id")] int lsnNspId, [Query(Name = "chf_subcentrale")] int chfSubcentrale, [Query(Name = "lsn_nsd_id")] int lsnNsdId, [Query(Name = "dev_imei")] string devImei, [Query(Name = "pla_id")] int plaId);

        /// <summary>
        /// PostPitaneNSSendServiceStop (/pitaneNSSendServiceStop)
        /// </summary>
        /// <param name="lsnId"></param>
        /// <param name="lsnKilometerstandEinde"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="devImei"></param>
        [Post("/pitaneNSSendServiceStop")]
        Task<object> PostPitaneNSSendServiceStopAsync([Query(Name = "lsn_id")] int lsnId, [Query(Name = "lsn_kilometerstand_einde")] int lsnKilometerstandEinde, [Query] double? latitude, [Query] double? longitude, [Query(Name = "dev_imei")] string devImei);

        /// <summary>
        /// PostPitaneDeviceSendServiceStop (/pitaneDeviceSendServiceStop)
        /// </summary>
        /// <param name="content">Service stop record</param>
        [Post("/pitaneDeviceSendServiceStop")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendServiceStopAsync([Body] Servicestop content);

        /// <summary>
        /// PostPitaneDeviceSendTripConfirmation (/pitaneDeviceSendTripConfirmation)
        /// </summary>
        /// <param name="plaId"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="speed"></param>
        /// <param name="devImei"></param>
        [Post("/pitaneDeviceSendTripConfirmation")]
        Task<object> PostPitaneDeviceSendTripConfirmationAsync([Query(Name = "pla_id")] int plaId, [Query] double? latitude, [Query] double? longitude, [Query] int? speed, [Query(Name = "dev_imei")] string devImei);

        /// <summary>
        /// PostPitaneSendTripCancelbyGUID (/pitaneSendTripCancelbyGUID)
        /// </summary>
        /// <param name="content">cancel pending or waiting trip</param>
        [Post("/pitaneSendTripCancelbyGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripCancelbyGUIDAsync([Body] Tripcancel content);

        /// <summary>
        /// PostPitaneSendTripConfirmation (/pitaneSendTripConfirmation)
        /// </summary>
        /// <param name="content">trip confirmation record</param>
        [Post("/pitaneSendTripConfirmation")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripConfirmationAsync([Body] Tripconfirmation content);

        /// <summary>
        /// PostPitaneDeviceSendTripNoShow (/pitaneDeviceSendTripNoShow)
        /// </summary>
        /// <param name="plaId"></param>
        /// <param name="plaLoosreden"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="speed"></param>
        /// <param name="devImei"></param>
        [Post("/pitaneDeviceSendTripNoShow")]
        Task<object> PostPitaneDeviceSendTripNoShowAsync([Query(Name = "pla_id")] int plaId, [Query(Name = "pla_loosreden")] string plaLoosreden, [Query] double? latitude, [Query] double? longitude, [Query] int? speed, [Query(Name = "dev_imei")] string devImei);

        /// <summary>
        /// PostPitaneSendTripTicket (/pitaneSendTripTicket)
        /// </summary>
        /// <param name="content">planning record</param>
        [Post("/pitaneSendTripTicket")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripTicketAsync([Body] Tripticket content);

        /// <summary>
        /// PostPitaneSendTripTicketByGUID (/pitaneSendTripTicketByGUID)
        /// </summary>
        /// <param name="content">planning record</param>
        [Post("/pitaneSendTripTicketByGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripTicketByGUIDAsync([Body] Tripticketguid content);

        /// <summary>
        /// PostPitaneSendTripCost (/pitaneSendTripCost)
        /// </summary>
        /// <param name="content">planning record</param>
        [Post("/pitaneSendTripCost")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripCostAsync([Body] Costplanning content);

        /// <summary>
        /// PostPitaneSendTripRating (/pitaneSendTripRating)
        /// </summary>
        /// <param name="content">set trip rating</param>
        [Post("/pitaneSendTripRating")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripRatingAsync([Body] Rating content);

        /// <summary>
        /// GetPitaneSendCustomerRating (/pitaneSendCustomerRating)
        /// </summary>
        /// <param name="plaGuid"></param>
        /// <param name="plaPunten"></param>
        [Get("/pitaneSendCustomerRating")]
        Task<object> GetPitaneSendCustomerRatingAsync([Query(Name = "pla_guid")] string plaGuid, [Query(Name = "pla_punten")] int? plaPunten);

        /// <summary>
        /// PostPitaneSendTripCostDeleted (/pitaneSendTripCostDeleted)
        /// </summary>
        /// <param name="content">delete cost record</param>
        [Post("/pitaneSendTripCostDeleted")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripCostDeletedAsync([Body] Costid content);

        /// <summary>
        /// PostPitaneDeviceSendTripCallCustomer (/pitaneDeviceSendTripCallCustomer)
        /// </summary>
        /// <param name="content">planning record</param>
        [Post("/pitaneDeviceSendTripCallCustomer")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendTripCallCustomerAsync([Body] Planning content);

        /// <summary>
        /// PostPitaneDeviceSendChatMessage (/pitaneDeviceSendChatMessage)
        /// </summary>
        /// <param name="content">Chat record</param>
        [Post("/pitaneDeviceSendChatMessage")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendChatMessageAsync([Body] Chatmessage content);

        /// <summary>
        /// PostPitaneDeviceSendPauseStart (/pitaneDeviceSendPauseStart)
        /// </summary>
        /// <param name="content">pause record</param>
        [Post("/pitaneDeviceSendPauseStart")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendPauseStartAsync([Body] Pauserecord content);

        /// <summary>
        /// PostPitaneDeviceSendPauseStop (/pitaneDeviceSendPauseStop)
        /// </summary>
        /// <param name="content">pause record</param>
        [Post("/pitaneDeviceSendPauseStop")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendPauseStopAsync([Body] Pauserecord content);

        /// <summary>
        /// PostPitaneDeviceSendDocuments (/pitaneDeviceSendDocuments)
        /// </summary>
        /// <param name="content">document record</param>
        [Post("/pitaneDeviceSendDocuments")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendDocumentsAsync([Body] Document content);

        /// <summary>
        /// GetPitaneDeviceRequestDocuments (/pitaneDeviceRequestDocuments)
        /// </summary>
        /// <param name="docSleutel"></param>
        /// <param name="docType"></param>
        [Get("/pitaneDeviceRequestDocuments")]
        Task<object> GetPitaneDeviceRequestDocumentsAsync([Query(Name = "doc_sleutel")] int docSleutel, [Query(Name = "doc_type")] int? docType);

        /// <summary>
        /// GetPitaneDeviceRequestPOI (/pitaneDeviceRequestPOI)
        /// </summary>
        [Get("/pitaneDeviceRequestPOI")]
        Task<object> GetPitaneDeviceRequestPOIAsync();

        /// <summary>
        /// GetPitaneDeviceRequestTaxiZones (/pitaneDeviceRequestTaxiZones)
        /// </summary>
        [Get("/pitaneDeviceRequestTaxiZones")]
        Task<object> GetPitaneDeviceRequestTaxiZonesAsync();

        /// <summary>
        /// GetPitaneDeviceRequestDocument (/pitaneDeviceRequestDocument)
        /// </summary>
        /// <param name="docApi"></param>
        [Get("/pitaneDeviceRequestDocument")]
        Task<object> GetPitaneDeviceRequestDocumentAsync([Query(Name = "doc_api")] string docApi);

        /// <summary>
        /// PostPitaneDeviceSendGPSbyLicenseplate (/pitaneDeviceSendGPSbyLicenseplate)
        /// </summary>
        /// <param name="content">pause record</param>
        [Post("/pitaneDeviceSendGPSbyLicenseplate")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendGPSbyLicenseplateAsync([Body] Gpsbylicense content);

        /// <summary>
        /// GetPitaneDataCarGroup (/pitaneDataCarGroup)
        /// </summary>
        [Get("/pitaneDataCarGroup")]
        Task<string> GetPitaneDataCarGroupAsync();

        /// <summary>
        /// GetPitaneRetrieveCoverage (/pitaneRetrieveCoverage)
        /// </summary>
        /// <param name="bdlLatitude"></param>
        /// <param name="bdlLongitude"></param>
        [Get("/pitaneRetrieveCoverage")]
        Task<object> GetPitaneRetrieveCoverageAsync([Query(Name = "bdl_latitude")] string bdlLatitude, [Query(Name = "bdl_longitude")] string bdlLongitude);

        /// <summary>
        /// GetPitaneCarRetrieveByDriver (/pitaneCarRetrieveByDriver)
        /// </summary>
        /// <param name="chfId"></param>
        [Get("/pitaneCarRetrieveByDriver")]
        Task<object> GetPitaneCarRetrieveByDriverAsync([Query(Name = "chf_id")] int? chfId);

        /// <summary>
        /// GetPitaneDevicePRDS (/pitaneDevicePRDS)
        /// </summary>
        /// <param name="prdsLsnId"></param>
        [Get("/pitaneDevicePRDS")]
        Task<object> GetPitaneDevicePRDSAsync([Query(Name = "prds_lsn_id")] string prdsLsnId);

        /// <summary>
        /// GetPitaneCarRetrieveLicensePlates (/pitaneCarRetrieveLicensePlates)
        /// </summary>
        [Get("/pitaneCarRetrieveLicensePlates")]
        Task<object> GetPitaneCarRetrieveLicensePlatesAsync();

        /// <summary>
        /// GetPitaneRetrieveFleetTariff (/pitaneRetrieveFleetTariff)
        /// </summary>
        [Get("/pitaneRetrieveFleetTariff")]
        Task<object> GetPitaneRetrieveFleetTariffAsync();

        /// <summary>
        /// GetPitaneFleetRetrievebyAPI (/pitaneFleetRetrievebyAPI)
        /// </summary>
        /// <param name="subToken"></param>
        [Get("/pitaneFleetRetrievebyAPI")]
        Task<object> GetPitaneFleetRetrievebyAPIAsync([Query(Name = "sub_token")] string subToken);

        /// <summary>
        /// GetPitaneCarRetrieveLicensePlatesSub (/pitaneCarRetrieveLicensePlatesSub)
        /// </summary>
        /// <param name="wagSubcentrale"></param>
        [Get("/pitaneCarRetrieveLicensePlatesSub")]
        Task<object> GetPitaneCarRetrieveLicensePlatesSubAsync([Query(Name = "wag_subcentrale")] int? wagSubcentrale);

        /// <summary>
        /// GetPitaneCarRetrieveLicenseData (/pitaneCarRetrieveLicenseData)
        /// </summary>
        /// <param name="wagKenteken"></param>
        /// <param name="accessKey"></param>
        [Get("/pitaneCarRetrieveLicenseData")]
        Task<object> GetPitaneCarRetrieveLicenseDataAsync([Query(Name = "wag_kenteken")] string wagKenteken, [Query(Name = "access_key")] string accessKey);

        /// <summary>
        /// GetPitaneCarRetrieveBCTData (/pitaneCarRetrieveBCTData)
        /// </summary>
        /// <param name="wagKenteken"></param>
        /// <param name="accessKey"></param>
        [Get("/pitaneCarRetrieveBCTData")]
        Task<object> GetPitaneCarRetrieveBCTDataAsync([Query(Name = "wag_kenteken")] string wagKenteken, [Query(Name = "access_key")] string accessKey);

        /// <summary>
        /// GetPitaneCarRetrieveByTPL (/pitaneCarRetrieveByTPL)
        /// </summary>
        /// <param name="wagPitanelink"></param>
        [Get("/pitaneCarRetrieveByTPL")]
        Task<object> GetPitaneCarRetrieveByTPLAsync([Query(Name = "wag_pitanelink")] string wagPitanelink);

        /// <summary>
        /// GetPitaneCarRetrieveByNumber (/pitaneCarRetrieveByNumber)
        /// </summary>
        /// <param name="wagTaxis"></param>
        [Get("/pitaneCarRetrieveByNumber")]
        Task<object> GetPitaneCarRetrieveByNumberAsync([Query(Name = "wag_taxis")] string wagTaxis);

        /// <summary>
        /// GetPitaneCarRetrieveByLicense (/pitaneCarRetrieveByLicense)
        /// </summary>
        /// <param name="wagImei"></param>
        [Get("/pitaneCarRetrieveByLicense")]
        Task<object> GetPitaneCarRetrieveByLicenseAsync([Query(Name = "wag_imei")] string wagImei);

        /// <summary>
        /// GetPitaneCarRetrieveByImei (/pitaneCarRetrieveByImei)
        /// </summary>
        /// <param name="wagImei"></param>
        [Get("/pitaneCarRetrieveByImei")]
        Task<object> GetPitaneCarRetrieveByImeiAsync([Query(Name = "wag_imei")] string wagImei);

        /// <summary>
        /// GetPitaneCarRetrieveByID (/pitaneCarRetrieveByID)
        /// </summary>
        /// <param name="wagId"></param>
        [Get("/pitaneCarRetrieveByID")]
        Task<object> GetPitaneCarRetrieveByIDAsync([Query(Name = "wag_id")] int? wagId);

        /// <summary>
        /// PostPitaneCarSetDelay (/pitaneCarSetDelay)
        /// </summary>
        /// <param name="content">delay record</param>
        [Post("/pitaneCarSetDelay")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneCarSetDelayAsync([Body] Cardelay content);

        /// <summary>
        /// PostPitaneDevicePRDSConfirm (/pitaneDevicePRDSConfirm)
        /// </summary>
        /// <param name="content">PRDS confirmation</param>
        [Post("/pitaneDevicePRDSConfirm")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDevicePRDSConfirmAsync([Body] Prdsconfirmation content);

        /// <summary>
        /// PostPitaneSendTripGPSUpdate (/pitaneSendTripGPSUpdate)
        /// </summary>
        /// <param name="content">Update trip status</param>
        [Post("/pitaneSendTripGPSUpdate")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripGPSUpdateAsync([Body] Tripstatus content);

        /// <summary>
        /// PostPitaneCarSetStatus (/pitaneCarSetStatus)
        /// </summary>
        /// <param name="content">Update car status</param>
        [Post("/pitaneCarSetStatus")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneCarSetStatusAsync([Body] Carstatus content);

        /// <summary>
        /// PostPitaneDriverSetStatus (/pitaneDriverSetStatus)
        /// </summary>
        /// <param name="content">Driver email address</param>
        [Post("/pitaneDriverSetStatus")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDriverSetStatusAsync([Body] Driverstatus content);

        /// <summary>
        /// PostPitaneDriverNotifyUpdate (/pitaneDriverNotifyUpdate)
        /// </summary>
        /// <param name="content">Driver email address</param>
        [Post("/pitaneDriverNotifyUpdate")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDriverNotifyUpdateAsync([Body] Drivernotifystatus content);

        /// <summary>
        /// PostPitaneDeviceSetStatus (/pitaneDeviceSetStatus)
        /// </summary>
        /// <param name="content">car / device IMEI</param>
        [Post("/pitaneDeviceSetStatus")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSetStatusAsync([Body] Devicestatus content);

        /// <summary>
        /// PostPitaneDeviceSendZoneUpdate (/pitaneDeviceSendZoneUpdate)
        /// </summary>
        /// <param name="content">update taxizone</param>
        [Post("/pitaneDeviceSendZoneUpdate")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDeviceSendZoneUpdateAsync([Body] Devicezonestatus content);

        /// <summary>
        /// PostPitaneCarSetBatteryLevel (/pitaneCarSetBatteryLevel)
        /// </summary>
        /// <param name="content">Car battery level update</param>
        [Post("/pitaneCarSetBatteryLevel")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneCarSetBatteryLevelAsync([Body] Batterylevel content);

        /// <summary>
        /// GetPitaneNSRetrieveShiftbyProjectNumber (/pitaneNSRetrieveShiftbyProjectNumber)
        /// </summary>
        /// <param name="nspNummer"></param>
        [Get("/pitaneNSRetrieveShiftbyProjectNumber")]
        Task<object> GetPitaneNSRetrieveShiftbyProjectNumberAsync([Query(Name = "nsp_nummer")] string nspNummer);

        /// <summary>
        /// GetPitaneNSRetrieveNetexByTrip (/pitaneNSRetrieveNetexByTrip)
        /// </summary>
        /// <param name="plaId"></param>
        [Get("/pitaneNSRetrieveNetexByTrip")]
        Task<object> GetPitaneNSRetrieveNetexByTripAsync([Query(Name = "pla_id")] int plaId);

        /// <summary>
        /// GetPitaneNSRetrieveNetexByTripGUID (/pitaneNSRetrieveNetexByTripGUID)
        /// </summary>
        /// <param name="plaGuid"></param>
        [Get("/pitaneNSRetrieveNetexByTripGUID")]
        Task<object> GetPitaneNSRetrieveNetexByTripGUIDAsync([Query(Name = "pla_guid")] string plaGuid);

        /// <summary>
        /// GetPitaneNSRetrieveNetexByID (/pitaneNSRetrieveNetexByID)
        /// </summary>
        /// <param name="netId"></param>
        [Get("/pitaneNSRetrieveNetexByID")]
        Task<object> GetPitaneNSRetrieveNetexByIDAsync([Query(Name = "net_id")] int netId);

        /// <summary>
        /// GetPitaneNSRetrieveNetexByGUID (/pitaneNSRetrieveNetexByGUID)
        /// </summary>
        /// <param name="netGuid"></param>
        [Get("/pitaneNSRetrieveNetexByGUID")]
        Task<object> GetPitaneNSRetrieveNetexByGUIDAsync([Query(Name = "net_guid")] string netGuid);

        /// <summary>
        /// GetPitaneNSRetrieveTripsByNSD (/pitaneNSRetrieveTripsByNSD)
        /// </summary>
        /// <param name="nsdId"></param>
        /// <param name="plaSubcentrale"></param>
        [Get("/pitaneNSRetrieveTripsByNSD")]
        Task<object> GetPitaneNSRetrieveTripsByNSDAsync([Query(Name = "nsd_id")] int nsdId, [Query(Name = "pla_subcentrale")] int plaSubcentrale);

        /// <summary>
        /// GetPitaneNSRetrieveTripsByNSP (/pitaneNSRetrieveTripsByNSP)
        /// </summary>
        /// <param name="nspId"></param>
        [Get("/pitaneNSRetrieveTripsByNSP")]
        Task<object> GetPitaneNSRetrieveTripsByNSPAsync([Query(Name = "nsp_id")] int nspId);

        /// <summary>
        /// GetPitaneNSRetrieveShiftbyProject (/pitaneNSRetrieveShiftbyProject)
        /// </summary>
        /// <param name="nspId"></param>
        [Get("/pitaneNSRetrieveShiftbyProject")]
        Task<object> GetPitaneNSRetrieveShiftbyProjectAsync([Query(Name = "nsp_id")] int? nspId);

        /// <summary>
        /// GetPitaneNSRetrieveProjects (/pitaneNSRetrieveProjects)
        /// </summary>
        /// <param name="nspFrom"></param>
        /// <param name="nspTo"></param>
        [Get("/pitaneNSRetrieveProjects")]
        Task<object> GetPitaneNSRetrieveProjectsAsync([Query(Name = "nsp_from")] string nspFrom, [Query(Name = "nsp_to")] string nspTo);

        /// <summary>
        /// GetPitaneNSRetrieveBusStationsByID (/pitaneNSRetrieveBusStationsByID)
        /// </summary>
        /// <param name="bhaIdFrom"></param>
        /// <param name="bhaIdTo"></param>
        [Get("/pitaneNSRetrieveBusStationsByID")]
        Task<object> GetPitaneNSRetrieveBusStationsByIDAsync([Query(Name = "bha_id_from")] int? bhaIdFrom, [Query(Name = "bha_id_to")] int? bhaIdTo);

        /// <summary>
        /// GetPitaneNSRetrieveBusStationsByGUID (/pitaneNSRetrieveBusStationsByGUID)
        /// </summary>
        /// <param name="bhaIdFromGuid"></param>
        /// <param name="bhaIdToGuid"></param>
        [Get("/pitaneNSRetrieveBusStationsByGUID")]
        Task<object> GetPitaneNSRetrieveBusStationsByGUIDAsync([Query(Name = "bha_id_from_guid")] string bhaIdFromGuid, [Query(Name = "bha_id_to_guid")] string bhaIdToGuid);

        /// <summary>
        /// GetPitaneNSRetrieveBusStationsByStationAlias (/pitaneNSRetrieveBusStationsByStationAlias)
        /// </summary>
        /// <param name="nssCodeFrom"></param>
        /// <param name="nssCodeTo"></param>
        [Get("/pitaneNSRetrieveBusStationsByStationAlias")]
        Task<object> GetPitaneNSRetrieveBusStationsByStationAliasAsync([Query(Name = "nss_code_from")] string nssCodeFrom, [Query(Name = "nss_code_to")] string nssCodeTo);

        /// <summary>
        /// GetPitaneNSRetrieveProjectsByID (/pitaneNSRetrieveProjectsByID)
        /// </summary>
        /// <param name="nspId"></param>
        [Get("/pitaneNSRetrieveProjectsByID")]
        Task<object> GetPitaneNSRetrieveProjectsByIDAsync([Query(Name = "nsp_id")] int? nspId);

        /// <summary>
        /// GetPitaneNSRetrieveProjectsByGUID (/pitaneNSRetrieveProjectsByGUID)
        /// </summary>
        /// <param name="nspGuid"></param>
        [Get("/pitaneNSRetrieveProjectsByGUID")]
        Task<object> GetPitaneNSRetrieveProjectsByGUIDAsync([Query(Name = "nsp_guid")] string nspGuid);

        /// <summary>
        /// GetPitaneNSRetrieveProjectsByDate (/pitaneNSRetrieveProjectsByDate)
        /// </summary>
        /// <param name="nspStartdatum"></param>
        /// <param name="offset"></param>
        [Get("/pitaneNSRetrieveProjectsByDate")]
        Task<object> GetPitaneNSRetrieveProjectsByDateAsync([Query(Name = "nsp_startdatum")] string nspStartdatum, [Query] int? offset);

        /// <summary>
        /// GetPitaneNSRetrieveProjectsBySubcentrale (/pitaneNSRetrieveProjectsBySubcentrale)
        /// </summary>
        /// <param name="nsdStartdatum"></param>
        /// <param name="chfSubcentrale"></param>
        /// <param name="nspId"></param>
        /// <param name="offset"></param>
        [Get("/pitaneNSRetrieveProjectsBySubcentrale")]
        Task<object> GetPitaneNSRetrieveProjectsBySubcentraleAsync([Query(Name = "nsd_startdatum")] string nsdStartdatum, [Query(Name = "chf_subcentrale")] int? chfSubcentrale, [Query(Name = "nsp_id")] int? nspId, [Query] int? offset);

        /// <summary>
        /// GetPitaneNSRetrieveProjectTripsBySubcentrale (/pitaneNSRetrieveProjectTripsBySubcentrale)
        /// </summary>
        /// <param name="nspStartdatum"></param>
        /// <param name="nspId"></param>
        /// <param name="chfSubcentrale"></param>
        /// <param name="offset"></param>
        [Get("/pitaneNSRetrieveProjectTripsBySubcentrale")]
        Task<object> GetPitaneNSRetrieveProjectTripsBySubcentraleAsync([Query(Name = "nsp_startdatum")] string nspStartdatum, [Query(Name = "nsp_id")] int nspId, [Query(Name = "chf_subcentrale")] int chfSubcentrale, [Query] int? offset);

        /// <summary>
        /// GetPitaneNSRetrieveBusStatus (/pitaneNSRetrieveBusStatus)
        /// </summary>
        [Get("/pitaneNSRetrieveBusStatus")]
        Task<object> GetPitaneNSRetrieveBusStatusAsync();

        /// <summary>
        /// GetPitaneNSRetrieveStationsByAlias (/pitaneNSRetrieveStationsByAlias)
        /// </summary>
        /// <param name="nssAliasFrom"></param>
        /// <param name="nssAliasTo"></param>
        [Get("/pitaneNSRetrieveStationsByAlias")]
        Task<object> GetPitaneNSRetrieveStationsByAliasAsync([Query(Name = "nss_alias_from")] string nssAliasFrom, [Query(Name = "nss_alias_to")] string nssAliasTo);

        /// <summary>
        /// GetPitaneNSRetrieveStationsInNeighborhood (/pitaneNSRetrieveStationsInNeighborhood)
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="limit"></param>
        [Get("/pitaneNSRetrieveStationsInNeighborhood")]
        Task<object> GetPitaneNSRetrieveStationsInNeighborhoodAsync([Query] string latitude, [Query] string longitude, [Query] int limit);

        /// <summary>
        /// GetPitaneNSRetrieveShiftsbySubcontractor (/pitaneNSRetrieveShiftsbySubcontractor)
        /// </summary>
        /// <param name="nspId"></param>
        /// <param name="ndrSubId"></param>
        [Get("/pitaneNSRetrieveShiftsbySubcontractor")]
        Task<object> GetPitaneNSRetrieveShiftsbySubcontractorAsync([Query(Name = "nsp_id")] int? nspId, [Query(Name = "ndr_sub_id")] int? ndrSubId);

        /// <summary>
        /// GetPitaneNSRetrieveShiftsbySubcontractorGUID (/pitaneNSRetrieveShiftsbySubcontractorGUID)
        /// </summary>
        /// <param name="nspGuid"></param>
        /// <param name="ndrSubGuid"></param>
        [Get("/pitaneNSRetrieveShiftsbySubcontractorGUID")]
        Task<object> GetPitaneNSRetrieveShiftsbySubcontractorGUIDAsync([Query(Name = "nsp_guid")] string nspGuid, [Query(Name = "ndr_sub_guid")] string ndrSubGuid);

        /// <summary>
        /// GetPitaneNSSendServiceSummary (/pitaneNSSendServiceSummary)
        /// </summary>
        /// <param name="lsnId"></param>
        [Get("/pitaneNSSendServiceSummary")]
        Task<object> GetPitaneNSSendServiceSummaryAsync([Query(Name = "lsn_id")] int lsnId);

        /// <summary>
        /// GetPitaneDriverSendServiceSummary (/pitaneDriverSendServiceSummary)
        /// </summary>
        /// <param name="lsnId"></param>
        [Get("/pitaneDriverSendServiceSummary")]
        Task<object> GetPitaneDriverSendServiceSummaryAsync([Query(Name = "lsn_id")] int lsnId);

        /// <summary>
        /// PostPitaneNSSendStationDeparture (/pitaneNSSendStationDeparture)
        /// </summary>
        /// <param name="plaId"></param>
        /// <param name="lsnId"></param>
        /// <param name="plaOdoStart"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        [Post("/pitaneNSSendStationDeparture")]
        Task<object> PostPitaneNSSendStationDepartureAsync([Query(Name = "pla_id")] int plaId, [Query(Name = "lsn_id")] int lsnId, [Query(Name = "pla_odo_start")] int plaOdoStart, [Query] double? latitude, [Query] double? longitude);

        /// <summary>
        /// PostPitaneNSSendStationDepartureBGUID (/pitaneNSSendStationDepartureBGUID)
        /// </summary>
        /// <param name="plaGuid"></param>
        /// <param name="lsnId"></param>
        /// <param name="plaOdoStart"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        [Post("/pitaneNSSendStationDepartureBGUID")]
        Task<object> PostPitaneNSSendStationDepartureBGUIDAsync([Query(Name = "pla_guid")] string plaGuid, [Query(Name = "lsn_id")] int lsnId, [Query(Name = "pla_odo_start")] int plaOdoStart, [Query] double? latitude, [Query] double? longitude);

        /// <summary>
        /// PostPitaneNSSendStationArrival (/pitaneNSSendStationArrival)
        /// </summary>
        /// <param name="plaId"></param>
        /// <param name="plaTijdstipVrijmelden"></param>
        /// <param name="plaOdoStop"></param>
        /// <param name="lsnId"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="plaNsStatus"></param>
        [Post("/pitaneNSSendStationArrival")]
        Task<object> PostPitaneNSSendStationArrivalAsync([Query(Name = "pla_id")] int plaId, [Query(Name = "pla_tijdstip_vrijmelden")] string plaTijdstipVrijmelden, [Query(Name = "pla_odo_stop")] int plaOdoStop, [Query(Name = "lsn_id")] int lsnId, [Query] double? latitude, [Query] double? longitude, [Query(Name = "pla_ns_status")] string plaNsStatus);

        /// <summary>
        /// PostPitaneNSSendStationArrivalByGUID (/pitaneNSSendStationArrivalByGUID)
        /// </summary>
        /// <param name="plaGuid"></param>
        /// <param name="plaTijdstipVrijmelden"></param>
        /// <param name="plaOdoStop"></param>
        /// <param name="lsnId"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="plaNsStatus"></param>
        [Post("/pitaneNSSendStationArrivalByGUID")]
        Task<object> PostPitaneNSSendStationArrivalByGUIDAsync([Query(Name = "pla_guid")] string plaGuid, [Query(Name = "pla_tijdstip_vrijmelden")] string plaTijdstipVrijmelden, [Query(Name = "pla_odo_stop")] int plaOdoStop, [Query(Name = "lsn_id")] int lsnId, [Query] double? latitude, [Query] double? longitude, [Query(Name = "pla_ns_status")] string plaNsStatus);

        /// <summary>
        /// PostPitaneNSSendStationNoShow (/pitaneNSSendStationNoShow)
        /// </summary>
        /// <param name="plaId"></param>
        /// <param name="plaOdoStart"></param>
        /// <param name="lsnId"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        [Post("/pitaneNSSendStationNoShow")]
        Task<object> PostPitaneNSSendStationNoShowAsync([Query(Name = "pla_id")] int plaId, [Query(Name = "pla_odo_start")] int plaOdoStart, [Query(Name = "lsn_id")] int lsnId, [Query] double? latitude, [Query] double? longitude);

        /// <summary>
        /// PostPitaneNSSendStandby (/pitaneNSSendStandby)
        /// </summary>
        /// <param name="wagId"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="wagStandbyExpiration"></param>
        /// <param name="nssCode"></param>
        [Post("/pitaneNSSendStandby")]
        Task<object> PostPitaneNSSendStandbyAsync([Query(Name = "wag_id")] int wagId, [Query] double latitude, [Query] double longitude, [Query(Name = "wag_standby_expiration")] string wagStandbyExpiration, [Query(Name = "nss_code")] string nssCode);

        /// <summary>
        /// PostPitaneNSSendStandbyByGUID (/pitaneNSSendStandbyByGUID)
        /// </summary>
        /// <param name="wagGuid"></param>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <param name="wagStandbyExpiration"></param>
        /// <param name="nssCode"></param>
        [Post("/pitaneNSSendStandbyByGUID")]
        Task<object> PostPitaneNSSendStandbyByGUIDAsync([Query(Name = "wag_guid")] string wagGuid, [Query] double latitude, [Query] double longitude, [Query(Name = "wag_standby_expiration")] string wagStandbyExpiration, [Query(Name = "nss_code")] string nssCode);

        /// <summary>
        /// GetPitaneRouteStatusRetrievebyID (/pitaneRouteStatusRetrievebyID)
        /// </summary>
        /// <param name="plaRoute"></param>
        [Get("/pitaneRouteStatusRetrievebyID")]
        Task<object> GetPitaneRouteStatusRetrievebyIDAsync([Query(Name = "pla_route")] int? plaRoute);

        /// <summary>
        /// GetPitaneRouteRetrievebyID (/pitaneRouteRetrievebyID)
        /// </summary>
        /// <param name="plaRoute"></param>
        [Get("/pitaneRouteRetrievebyID")]
        Task<object> GetPitaneRouteRetrievebyIDAsync([Query(Name = "pla_route")] int? plaRoute);

        /// <summary>
        /// GetPitaneTripRetrieveCostByID (/pitaneTripRetrieveCostByID)
        /// </summary>
        /// <param name="plaId"></param>
        [Get("/pitaneTripRetrieveCostByID")]
        Task<object> GetPitaneTripRetrieveCostByIDAsync([Query(Name = "pla_id")] int? plaId);

        /// <summary>
        /// GetPitaneTripRetrievebyExternalID (/pitaneTripRetrievebyExternalID)
        /// </summary>
        /// <param name="plaExternRitnummer"></param>
        [Get("/pitaneTripRetrievebyExternalID")]
        Task<object> GetPitaneTripRetrievebyExternalIDAsync([Query(Name = "pla_extern_ritnummer")] int? plaExternRitnummer);

        /// <summary>
        /// GetPaymentJournalEntry (/payment/journal-entry)
        /// </summary>
        /// <param name="acceptLanguage">list of the languages/localizations the user would like to see</param>
        /// <param name="api">personal API key</param>
        /// <param name="apiVersion">Version of the API</param>
        /// <param name="from">start of the selection</param>
        /// <param name="to">end of the selection</param>
        /// <param name="state"></param>
        /// <param name="id"></param>
        /// <param name="category">type of booking line (e.g. fare, addition costs, fines, ...)</param>
        /// <param name="offset">start of the selection</param>
        /// <param name="limit">count of the selection</param>
        [Get("/payment/journal-entry")]
        Task<object> GetPaymentJournalEntryAsync([Header("Accept-Language")] string acceptLanguage, [Header("Api")] string api, [Header("Api-Version")] string apiVersion, [Query] DateTime? from, [Query] DateTime? to, [Query] string state, [Query] string id, [Query] string category, [Query] double? offset, [Query] double? limit);

        /// <summary>
        /// PostBookings (/bookings)
        /// </summary>
        /// <param name="acceptLanguage">list of the languages/localizations the user would like to see</param>
        /// <param name="api">personal API key</param>
        /// <param name="apiVersion">Version of the API</param>
        /// <param name="content">A booking requested by the MP</param>
        [Post("/bookings")]
        [Header("Content-Type", "application/json")]
        Task<object> PostBookingsAsync([Header("Accept-Language")] string acceptLanguage, [Header("Api")] string api, [Header("Api-Version")] string apiVersion, [Body] BookingRequest content);

        /// <summary>
        /// PostPlannings (/plannings)
        /// </summary>
        /// <param name="acceptLanguage">list of the languages/localizations the user would like to see</param>
        /// <param name="api">personal API key</param>
        /// <param name="apiVersion">Version of the API</param>
        /// <param name="content">A travel planning for which bookable options are requested</param>
        [Post("/plannings")]
        [Header("Content-Type", "application/json")]
        Task<Response<AnyOf<Planning, object>>> PostPlanningsAsync([Header("Accept-Language")] string acceptLanguage, [Header("Api")] string api, [Header("Api-Version")] string apiVersion, [Body] PlanningRequest content);

        /// <summary>
        /// GetBookingsById (/bookings/{id})
        /// </summary>
        /// <param name="acceptLanguage">list of the languages/localizations the user would like to see</param>
        /// <param name="api">personal API key</param>
        /// <param name="apiVersion">Version of the API</param>
        /// <param name="id"></param>
        [Get("/bookings/{id}")]
        Task<Response<AnyOf<Booking, object>>> GetBookingsByIdAsync([Header("Accept-Language")] string acceptLanguage, [Header("Api")] string api, [Header("Api-Version")] string apiVersion, [Path] string id);

        /// <summary>
        /// PutBookingsById (/bookings/{id})
        /// </summary>
        /// <param name="acceptLanguage">list of the languages/localizations the user would like to see</param>
        /// <param name="api">personal API key</param>
        /// <param name="apiVersion">Version of the API</param>
        /// <param name="id"></param>
        /// <param name="content">The booking information describing the state and details of an agreed upon trip</param>
        [Put("/bookings/{id}")]
        [Header("Content-Type", "application/json")]
        Task<object> PutBookingsByIdAsync([Header("Accept-Language")] string acceptLanguage, [Header("Api")] string api, [Header("Api-Version")] string apiVersion, [Path] string id, [Body] Booking content);

        /// <summary>
        /// DeleteBookingsById (/bookings/{id})
        /// </summary>
        /// <param name="acceptLanguage">list of the languages/localizations the user would like to see</param>
        /// <param name="api">personal API key</param>
        /// <param name="apiVersion">Version of the API</param>
        /// <param name="id"></param>
        [Delete("/bookings/{id}")]
        Task<object> DeleteBookingsByIdAsync([Header("Accept-Language")] string acceptLanguage, [Header("Api")] string api, [Header("Api-Version")] string apiVersion, [Path] string id);

        /// <summary>
        /// PostBookingsByIdEvents (/bookings/{id}/events)
        /// </summary>
        /// <param name="acceptLanguage">list of the languages/localizations the user would like to see</param>
        /// <param name="api">personal API key</param>
        /// <param name="apiVersion">Version of the API</param>
        /// <param name="id"></param>
        /// <param name="content">operation on the bookingOption</param>
        [Post("/bookings/{id}/events")]
        [Header("Content-Type", "application/json")]
        Task<object> PostBookingsByIdEventsAsync([Header("Accept-Language")] string acceptLanguage, [Header("Api")] string api, [Header("Api-Version")] string apiVersion, [Path] string id, [Body] BookingOperation content);

        /// <summary>
        /// PostPaymentByIdClaimExtraCosts (/payment/{id}/claim-extra-costs)
        /// </summary>
        /// <param name="acceptLanguage">list of the languages/localizations the user would like to see</param>
        /// <param name="api">personal API key</param>
        /// <param name="apiVersion">Version of the API</param>
        /// <param name="id">Booking identifier</param>
        /// <param name="content">Costs that the TO is charging the MP; credits are negative</param>
        [Post("/payment/{id}/claim-extra-costs")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPaymentByIdClaimExtraCostsAsync([Header("Accept-Language")] string acceptLanguage, [Header("Api")] string api, [Header("Api-Version")] string apiVersion, [Path] string id, [Body] ExtraCosts content);

        /// <summary>
        /// GetPlanningsBookingIntent (/plannings/booking-intent)
        /// </summary>
        /// <param name="fromLat"></param>
        /// <param name="fromLng"></param>
        /// <param name="toLat"></param>
        /// <param name="toLng"></param>
        /// <param name="startTime"></param>
        /// <param name="endTime"></param>
        /// <param name="travellers"></param>
        [Get("/plannings/booking-intent")]
        Task<object> GetPlanningsBookingIntentAsync([Query(Name = "from_lat")] string fromLat, [Query(Name = "from_lng")] string fromLng, [Query(Name = "to_lat")] string toLat, [Query(Name = "to_lng")] string toLng, [Query] string startTime, [Query] string endTime, [Query] int travellers);

        /// <summary>
        /// GetPitaneTripFare (/pitaneTripFare)
        /// </summary>
        /// <param name="plaGuid"></param>
        [Get("/pitaneTripFare")]
        Task<object> GetPitaneTripFareAsync([Query(Name = "pla_guid")] string plaGuid);

        /// <summary>
        /// GetPitaneTripRetrieveByID (/pitaneTripRetrieveByID)
        /// </summary>
        /// <param name="plaId"></param>
        [Get("/pitaneTripRetrieveByID")]
        Task<object> GetPitaneTripRetrieveByIDAsync([Query(Name = "pla_id")] int? plaId);

        /// <summary>
        /// GetPitaneTripRetrieveByCustomerGUID (/pitaneTripRetrieveByCustomerGUID)
        /// </summary>
        /// <param name="reiGuid"></param>
        /// <param name="plaDatumFrom"></param>
        /// <param name="plaDatumTo"></param>
        /// <param name="offset"></param>
        [Get("/pitaneTripRetrieveByCustomerGUID")]
        Task<object> GetPitaneTripRetrieveByCustomerGUIDAsync([Query(Name = "rei_guid")] string reiGuid, [Query(Name = "pla_datum_from")] string plaDatumFrom, [Query(Name = "pla_datum_to")] string plaDatumTo, [Query] int? offset);

        /// <summary>
        /// GetPitaneTripWMOGate12ByGUID (/pitaneTripWMO_gate12ByGUID)
        /// </summary>
        /// <param name="plaGuid"></param>
        [Get("/pitaneTripWMO_gate12ByGUID")]
        Task<object> GetPitaneTripWMOGate12ByGUIDAsync([Query(Name = "pla_guid")] string plaGuid);

        /// <summary>
        /// GetPitaneTripRetrieveByGUID (/pitaneTripRetrieveByGUID)
        /// </summary>
        /// <param name="plaGuid"></param>
        /// <param name="offset"></param>
        [Get("/pitaneTripRetrieveByGUID")]
        Task<object> GetPitaneTripRetrieveByGUIDAsync([Query(Name = "pla_guid")] string plaGuid, [Query] int? offset);

        /// <summary>
        /// GetPitaneTripStatusRetrieveByID (/pitaneTripStatusRetrieveByID)
        /// </summary>
        /// <param name="plaId"></param>
        [Get("/pitaneTripStatusRetrieveByID")]
        Task<object> GetPitaneTripStatusRetrieveByIDAsync([Query(Name = "pla_id")] int? plaId);

        /// <summary>
        /// GetPitaneTripStatusRetrieveByGUID (/pitaneTripStatusRetrieveByGUID)
        /// </summary>
        /// <param name="plaGuid"></param>
        [Get("/pitaneTripStatusRetrieveByGUID")]
        Task<object> GetPitaneTripStatusRetrieveByGUIDAsync([Query(Name = "pla_guid")] string plaGuid);

        /// <summary>
        /// PostPitaneSendTripAssigned (/pitaneSendTripAssigned)
        /// </summary>
        /// <param name="content">trip status update record</param>
        [Post("/pitaneSendTripAssigned")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripAssignedAsync([Body] TripStatusUpdateAssigned content);

        /// <summary>
        /// PostPitaneSendDropoffSector (/pitaneSendDropoffSector)
        /// </summary>
        /// <param name="content">trip sector update record</param>
        [Post("/pitaneSendDropoffSector")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendDropoffSectorAsync([Body] Tripstatusupdatesector content);

        /// <summary>
        /// PostPitaneSendTripPickup (/pitaneSendTripPickup)
        /// </summary>
        /// <param name="content">trip status update record</param>
        [Post("/pitaneSendTripPickup")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripPickupAsync([Body] Tripstatusupdatepickup content);

        /// <summary>
        /// PostPitaneSendTripPickupByGUID (/pitaneSendTripPickupByGUID)
        /// </summary>
        /// <param name="content">trip status update record</param>
        [Post("/pitaneSendTripPickupByGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripPickupByGUIDAsync([Body] Tripstatusupdatepickupbyguid content);

        /// <summary>
        /// PostPitaneSendTripDropOff (/pitaneSendTripDropOff)
        /// </summary>
        /// <param name="content">trip status update record</param>
        [Post("/pitaneSendTripDropOff")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripDropOffAsync([Body] Tripstatusupdatedropoff content);

        /// <summary>
        /// PostPitaneSendTripDropOffByGUID (/pitaneSendTripDropOffByGUID)
        /// </summary>
        /// <param name="content">trip status update record</param>
        [Post("/pitaneSendTripDropOffByGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripDropOffByGUIDAsync([Body] Tripstatusupdatedropoffbyguid content);

        /// <summary>
        /// PostPitaneSendTripPayment (/pitaneSendTripPayment)
        /// </summary>
        /// <param name="content">trip payment update record</param>
        [Post("/pitaneSendTripPayment")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripPaymentAsync([Body] Tripstatusupdatepayment content);

        /// <summary>
        /// PostPitaneSendTripPaymentByGuid (/pitaneSendTripPaymentByGuid)
        /// </summary>
        /// <param name="content">trip payment update record</param>
        [Post("/pitaneSendTripPaymentByGuid")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripPaymentByGuidAsync([Body] Tripstatusupdatepaymentguid content);

        /// <summary>
        /// PostPitaneSendTripNoShow (/pitaneSendTripNoShow)
        /// </summary>
        /// <param name="content">trip status update record</param>
        [Post("/pitaneSendTripNoShow")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripNoShowAsync([Body] Tripstatusupdatenoshow content);

        /// <summary>
        /// PostPitaneSendTripNoShowByGUID (/pitaneSendTripNoShowByGUID)
        /// </summary>
        /// <param name="content">trip status update record</param>
        [Post("/pitaneSendTripNoShowByGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneSendTripNoShowByGUIDAsync([Body] Tripstatusupdatenoshowbyguid content);

        /// <summary>
        /// GetPitaneCustomerMobilityIndications (/pitaneCustomerMobilityIndications)
        /// </summary>
        [Get("/pitaneCustomerMobilityIndications")]
        Task<string> GetPitaneCustomerMobilityIndicationsAsync();

        /// <summary>
        /// GetPitaneMobilityIndicationsByCustomer (/pitaneMobilityIndicationsByCustomer)
        /// </summary>
        /// <param name="reiId"></param>
        [Get("/pitaneMobilityIndicationsByCustomer")]
        Task<string> GetPitaneMobilityIndicationsByCustomerAsync([Query(Name = "rei_id")] int? reiId);

        /// <summary>
        /// GetPitaneCustomerMobilityTools (/pitaneCustomerMobilityTools)
        /// </summary>
        [Get("/pitaneCustomerMobilityTools")]
        Task<string> GetPitaneCustomerMobilityToolsAsync();

        /// <summary>
        /// GetPitaneCustomerActiveTripRetrievebyEmail (/pitaneCustomerActiveTripRetrievebyEmail)
        /// </summary>
        /// <param name="plaEmail"></param>
        [Get("/pitaneCustomerActiveTripRetrievebyEmail")]
        Task<string> GetPitaneCustomerActiveTripRetrievebyEmailAsync([Query(Name = "pla_email")] string plaEmail);

        /// <summary>
        /// GetPitaneMobilityToolsByCustomer (/pitaneMobilityToolsByCustomer)
        /// </summary>
        /// <param name="reiId"></param>
        [Get("/pitaneMobilityToolsByCustomer")]
        Task<string> GetPitaneMobilityToolsByCustomerAsync([Query(Name = "rei_id")] int? reiId);

        /// <summary>
        /// GetPitaneDataRetrieveNews (/pitaneDataRetrieveNews)
        /// </summary>
        [Get("/pitaneDataRetrieveNews")]
        Task<string> GetPitaneDataRetrieveNewsAsync();

        /// <summary>
        /// GetPitaneDataRetrieveMainNews (/pitaneDataRetrieveMainNews)
        /// </summary>
        [Get("/pitaneDataRetrieveMainNews")]
        Task<string> GetPitaneDataRetrieveMainNewsAsync();

        /// <summary>
        /// GetPitaneDataAirportsCarTypes (/pitaneDataAirportsCarTypes)
        /// </summary>
        /// <param name="airIata"></param>
        [Get("/pitaneDataAirportsCarTypes")]
        Task<string> GetPitaneDataAirportsCarTypesAsync([Query(Name = "air_iata")] string airIata);

        /// <summary>
        /// GetPitaneDataLedgers (/pitaneDataLedgers)
        /// </summary>
        [Get("/pitaneDataLedgers")]
        Task<GetPitaneDataLedgersResult> GetPitaneDataLedgersAsync();

        /// <summary>
        /// GetPitaneRetrieveSubcentrales (/pitaneRetrieveSubcentrales)
        /// </summary>
        [Get("/pitaneRetrieveSubcentrales")]
        Task<object> GetPitaneRetrieveSubcentralesAsync();

        /// <summary>
        /// GetPitaneRetrieveSubcentralesByPin (/pitaneRetrieveSubcentralesByPin)
        /// </summary>
        /// <param name="pin"></param>
        [Get("/pitaneRetrieveSubcentralesByPin")]
        Task<object> GetPitaneRetrieveSubcentralesByPinAsync([Query] string pin);

        /// <summary>
        /// GetPitaneDataCompanies (/pitaneDataCompanies)
        /// </summary>
        [Get("/pitaneDataCompanies")]
        Task<string> GetPitaneDataCompaniesAsync();

        /// <summary>
        /// GetPitaneDataCountries (/pitaneDataCountries)
        /// </summary>
        [Get("/pitaneDataCountries")]
        Task<object> GetPitaneDataCountriesAsync();

        /// <summary>
        /// GetPitaneDataCrow (/pitaneDataCrow)
        /// </summary>
        [Get("/pitaneDataCrow")]
        Task<object> GetPitaneDataCrowAsync();

        /// <summary>
        /// GetPitaneDataCostcenters (/pitaneDataCostcenters)
        /// </summary>
        [Get("/pitaneDataCostcenters")]
        Task<string> GetPitaneDataCostcentersAsync();

        /// <summary>
        /// GetPitanePostalZoneInternal (/pitanePostalZoneInternal)
        /// </summary>
        /// <param name="reiGuid"></param>
        /// <param name="pickupPostalcode"></param>
        /// <param name="destinationPostalcode"></param>
        [Get("/pitanePostalZoneInternal")]
        Task<object> GetPitanePostalZoneInternalAsync([Query(Name = "rei_guid")] string reiGuid, [Query(Name = "pickup_postalcode")] string pickupPostalcode, [Query(Name = "destination_postalcode")] string destinationPostalcode);

        /// <summary>
        /// GetPitaneDataVAT (/pitaneDataVAT)
        /// </summary>
        [Get("/pitaneDataVAT")]
        Task<string> GetPitaneDataVATAsync();

        /// <summary>
        /// GetPitaneDataTripTypes (/pitaneDataTripTypes)
        /// </summary>
        [Get("/pitaneDataTripTypes")]
        Task<string> GetPitaneDataTripTypesAsync();

        /// <summary>
        /// GetPitaneDataAirports (/pitaneDataAirports)
        /// </summary>
        [Get("/pitaneDataAirports")]
        Task<string> GetPitaneDataAirportsAsync();

        /// <summary>
        /// GetPitaneDataTripStatus (/pitaneDataTripStatus)
        /// </summary>
        [Get("/pitaneDataTripStatus")]
        Task<string> GetPitaneDataTripStatusAsync();

        /// <summary>
        /// GetPitaneDriverRetrieveAccessbyPassword (/pitaneDriverRetrieveAccessbyPassword)
        /// </summary>
        /// <param name="chfEmail"></param>
        /// <param name="chfAppPaswoord"></param>
        [Get("/pitaneDriverRetrieveAccessbyPassword")]
        Task<object> GetPitaneDriverRetrieveAccessbyPasswordAsync([Query(Name = "chf_email")] string chfEmail, [Query(Name = "chf_app_paswoord")] string chfAppPaswoord);

        /// <summary>
        /// GetPitaneCustomerRetrieveAccessbyPassword (/pitaneCustomerRetrieveAccessbyPassword)
        /// </summary>
        /// <param name="reiEmail"></param>
        /// <param name="reiAppPaswoord"></param>
        [Get("/pitaneCustomerRetrieveAccessbyPassword")]
        Task<object> GetPitaneCustomerRetrieveAccessbyPasswordAsync([Query(Name = "rei_email")] string reiEmail, [Query(Name = "rei_app_paswoord")] string reiAppPaswoord);

        /// <summary>
        /// GetPitaneDriverRetrieveAccessbyToken (/pitaneDriverRetrieveAccessbyToken)
        /// </summary>
        /// <param name="chfEmail"></param>
        /// <param name="chfVerificatie"></param>
        /// <param name="offset"></param>
        [Get("/pitaneDriverRetrieveAccessbyToken")]
        Task<object> GetPitaneDriverRetrieveAccessbyTokenAsync([Query(Name = "chf_email")] string chfEmail, [Query(Name = "chf_verificatie")] string chfVerificatie, [Query] int? offset);

        /// <summary>
        /// GetPitaneCustomerRetrieveByEmail (/pitaneCustomerRetrieveByEmail)
        /// </summary>
        /// <param name="reiEmail"></param>
        /// <param name="reiAppPaswoord"></param>
        /// <param name="offset"></param>
        [Get("/pitaneCustomerRetrieveByEmail")]
        Task<object> GetPitaneCustomerRetrieveByEmailAsync([Query(Name = "rei_email")] string reiEmail, [Query(Name = "rei_app_paswoord")] string reiAppPaswoord, [Query] int? offset);

        /// <summary>
        /// GetPitaneCustomerCheckByEmail (/pitaneCustomerCheckByEmail)
        /// </summary>
        /// <param name="reiEmail"></param>
        /// <param name="offset"></param>
        [Get("/pitaneCustomerCheckByEmail")]
        Task<object> GetPitaneCustomerCheckByEmailAsync([Query(Name = "rei_email")] string reiEmail, [Query] int? offset);

        /// <summary>
        /// GetPitaneCustomerRetrieveByGuid (/pitaneCustomerRetrieveByGuid)
        /// </summary>
        /// <param name="reiGuid"></param>
        /// <param name="offset"></param>
        [Get("/pitaneCustomerRetrieveByGuid")]
        Task<object> GetPitaneCustomerRetrieveByGuidAsync([Query(Name = "rei_guid")] string reiGuid, [Query] int? offset);

        /// <summary>
        /// GetPitaneCustomerRetrieveCrowByGuid (/pitaneCustomerRetrieveCrowByGuid)
        /// </summary>
        /// <param name="reiGuid"></param>
        /// <param name="offset"></param>
        [Get("/pitaneCustomerRetrieveCrowByGuid")]
        Task<object> GetPitaneCustomerRetrieveCrowByGuidAsync([Query(Name = "rei_guid")] string reiGuid, [Query] int? offset);

        /// <summary>
        /// GetPitaneCustomerRetrieveRelationsByGuid (/pitaneCustomerRetrieveRelationsByGuid)
        /// </summary>
        /// <param name="reiGuid"></param>
        /// <param name="offset"></param>
        [Get("/pitaneCustomerRetrieveRelationsByGuid")]
        Task<object> GetPitaneCustomerRetrieveRelationsByGuidAsync([Query(Name = "rei_guid")] string reiGuid, [Query] int? offset);

        /// <summary>
        /// PostPitaneDriverDeleteByGUID (/pitaneDriverDeleteByGUID)
        /// </summary>
        /// <param name="content">driver guid combination</param>
        [Post("/pitaneDriverDeleteByGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitaneDriverDeleteByGUIDAsync([Body] ChfGuid content);

        /// <summary>
        /// GetPitaneDriverRetrievebyEmail (/pitaneDriverRetrievebyEmail)
        /// </summary>
        /// <param name="chfEmail"></param>
        /// <param name="offset"></param>
        [Get("/pitaneDriverRetrievebyEmail")]
        Task<object> GetPitaneDriverRetrievebyEmailAsync([Query(Name = "chf_email")] string chfEmail, [Query] int? offset);

        /// <summary>
        /// GetPitaneDriverRetrieveStatusByEmail (/pitaneDriverRetrieveStatusByEmail)
        /// </summary>
        /// <param name="chfEmail"></param>
        /// <param name="offset"></param>
        [Get("/pitaneDriverRetrieveStatusByEmail")]
        Task<object> GetPitaneDriverRetrieveStatusByEmailAsync([Query(Name = "chf_email")] string chfEmail, [Query] int? offset);

        /// <summary>
        /// GetPitaneDriverRetrieveShiftByEmail (/pitaneDriverRetrieveShiftByEmail)
        /// </summary>
        /// <param name="chfEmail"></param>
        /// <param name="lsnAanvang"></param>
        /// <param name="offset"></param>
        [Get("/pitaneDriverRetrieveShiftByEmail")]
        Task<object> GetPitaneDriverRetrieveShiftByEmailAsync([Query(Name = "chf_email")] string chfEmail, [Query(Name = "lsn_aanvang")] string lsnAanvang, [Query] int? offset);

        /// <summary>
        /// GetPitaneDriverRetrieveTripsbyShift (/pitaneDriverRetrieveTripsbyShift)
        /// </summary>
        /// <param name="chfEmail"></param>
        /// <param name="lsnId"></param>
        /// <param name="offset"></param>
        [Get("/pitaneDriverRetrieveTripsbyShift")]
        Task<object> GetPitaneDriverRetrieveTripsbyShiftAsync([Query(Name = "chf_email")] string chfEmail, [Query(Name = "lsn_id")] int lsnId, [Query] int? offset);

        /// <summary>
        /// GetPitaneDriverRetrieveShiftbyID (/pitaneDriverRetrieveShiftbyID)
        /// </summary>
        /// <param name="chfId"></param>
        /// <param name="offset"></param>
        [Get("/pitaneDriverRetrieveShiftbyID")]
        Task<object> GetPitaneDriverRetrieveShiftbyIDAsync([Query(Name = "chf_id")] int chfId, [Query] int? offset);

        /// <summary>
        /// GetPitaneDriverRetrieveTripsTrajectByShift (/pitaneDriverRetrieveTripsTrajectByShift)
        /// </summary>
        /// <param name="lsnId"></param>
        /// <param name="offset"></param>
        [Get("/pitaneDriverRetrieveTripsTrajectByShift")]
        Task<object> GetPitaneDriverRetrieveTripsTrajectByShiftAsync([Query(Name = "lsn_id")] int lsnId, [Query] int? offset);

        /// <summary>
        /// GetPitaneDriverRetrieveFinishedTripsbyShift (/pitaneDriverRetrieveFinishedTripsbyShift)
        /// </summary>
        /// <param name="chfId"></param>
        /// <param name="lsnId"></param>
        /// <param name="offset"></param>
        [Get("/pitaneDriverRetrieveFinishedTripsbyShift")]
        Task<object> GetPitaneDriverRetrieveFinishedTripsbyShiftAsync([Query(Name = "chf_id")] int chfId, [Query(Name = "lsn_id")] int lsnId, [Query] int? offset);

        /// <summary>
        /// GetPitaneDriverRetrievePlannedTripsbyDriver (/pitaneDriverRetrievePlannedTripsbyDriver)
        /// </summary>
        /// <param name="chfId"></param>
        /// <param name="plaDatum"></param>
        /// <param name="offset"></param>
        [Get("/pitaneDriverRetrievePlannedTripsbyDriver")]
        Task<object> GetPitaneDriverRetrievePlannedTripsbyDriverAsync([Query(Name = "chf_id")] int chfId, [Query(Name = "pla_datum")] string plaDatum, [Query] int? offset);

        /// <summary>
        /// GetPitaneFleetRetrieveByAvailability (/pitaneFleetRetrieveByAvailability)
        /// </summary>
        /// <param name="chfId"></param>
        /// <param name="offset"></param>
        [Get("/pitaneFleetRetrieveByAvailability")]
        Task<Drivers> GetPitaneFleetRetrieveByAvailabilityAsync([Query(Name = "chf_id")] int chfId, [Query] int? offset);

        /// <summary>
        /// PostPitaneCreateDriver (/pitaneCreateDriver)
        /// </summary>
        [Post("/pitaneCreateDriver")]
        Task<object> PostPitaneCreateDriverAsync();

        /// <summary>
        /// PostPitaneCreateCustomer (/pitaneCreateCustomer)
        /// </summary>
        [Post("/pitaneCreateCustomer")]
        Task<object> PostPitaneCreateCustomerAsync();

        /// <summary>
        /// PostPitaneCreateAddress (/pitaneCreateAddress)
        /// </summary>
        [Post("/pitaneCreateAddress")]
        Task<object> PostPitaneCreateAddressAsync();

        /// <summary>
        /// PostPitaneUpdateCustomer (/pitaneUpdateCustomer)
        /// </summary>
        [Post("/pitaneUpdateCustomer")]
        Task<object> PostPitaneUpdateCustomerAsync();

        /// <summary>
        /// PostPitaneUpdateAddress (/pitaneUpdateAddress)
        /// </summary>
        [Post("/pitaneUpdateAddress")]
        Task<object> PostPitaneUpdateAddressAsync();

        /// <summary>
        /// PostPitanePaxxGroup (/pitanePaxxGroup)
        /// </summary>
        /// <param name="content">customer paxx group update</param>
        [Post("/pitanePaxxGroup")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitanePaxxGroupAsync([Body] Paxxgroup content);

        /// <summary>
        /// PostPitanePaxxGroupByGUID (/pitanePaxxGroupByGUID)
        /// </summary>
        /// <param name="content">customer paxx group update</param>
        [Post("/pitanePaxxGroupByGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitanePaxxGroupByGUIDAsync([Body] Paxxgroupguid content);

        /// <summary>
        /// PostPitanePaxxUnGroup (/pitanePaxxUnGroup)
        /// </summary>
        /// <param name="content">customer paxx group update</param>
        [Post("/pitanePaxxUnGroup")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitanePaxxUnGroupAsync([Body] Paxxgroup content);

        /// <summary>
        /// PostPitanePaxxUnGroupByGUID (/pitanePaxxUnGroupByGUID)
        /// </summary>
        /// <param name="content">customer paxx group update</param>
        [Post("/pitanePaxxUnGroupByGUID")]
        [Header("Content-Type", "application/json")]
        Task<object> PostPitanePaxxUnGroupByGUIDAsync([Body] Paxxgroupguid content);

        /// <summary>
        /// GetPitanePaxxTripStatus (/pitanePaxxTripStatus)
        /// </summary>
        /// <param name="reiPaxLevel"></param>
        /// <param name="reiPaxIdentifier"></param>
        /// <param name="plaDatum"></param>
        /// <param name="plaStatus"></param>
        /// <param name="offset"></param>
        [Get("/pitanePaxxTripStatus")]
        Task<object> GetPitanePaxxTripStatusAsync([Query(Name = "rei_pax_level")] int reiPaxLevel, [Query(Name = "rei_pax_identifier")] string reiPaxIdentifier, [Query(Name = "pla_datum")] string plaDatum, [Query(Name = "pla_status")] string plaStatus, [Query] int? offset);

        /// <summary>
        /// PostPitaneUpdateDriver (/pitaneUpdateDriver)
        /// </summary>
        [Post("/pitaneUpdateDriver")]
        Task<object> PostPitaneUpdateDriverAsync();

        /// <summary>
        /// DeletePitaneDeleteDriver (/pitaneDeleteDriver)
        /// </summary>
        /// <param name="chfId"></param>
        [Delete("/pitaneDeleteDriver")]
        Task<object> DeletePitaneDeleteDriverAsync([Query(Name = "chf_id")] int? chfId);
    }
}
namespace RestEaseClientGeneratorConsoleApp.Examples.Pitane.Models
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
        /// <summary>
        /// This should be in the base unit as defined by the ISO 4217 currency code with the appropriate number of decimal places and omitting the currency symbol. e.g. if the price is in US Dollars the price would be 9.95. This is inclusive VAT
        /// </summary>
        public double Amount { get; set; }

        public double AmountExVat { get; set; }

        /// <summary>
        /// ISO 4217 currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// value added tax rate (percentage of amount)
        /// </summary>
        public double VatRate { get; set; }

        /// <summary>
        /// two-letter country codes according to ISO 3166-1
        /// </summary>
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

        /// <summary>
        /// what kind of asset is this? Classify it, give the aspects. Most aspects are optional and should be used when applicable.
        /// </summary>
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

        /// <summary>
        /// a origin or destination of a leg, non 3D. lon/lat in WGS84.
        /// </summary>
        public Place Location { get; set; }

        public string Fuel { get; set; }

        /// <summary>
        /// Energy efficiency
        /// </summary>
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

        /// <summary>
        /// describes if asset is or needs to be easily accessible
        /// </summary>
        public string EasyAccessibility { get; set; }

        /// <summary>
        /// number of gears of the asset
        /// </summary>
        public int Gears { get; set; }

        /// <summary>
        /// type of gearbox
        /// </summary>
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

        /// <summary>
        /// way in which the asset is powered
        /// </summary>
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
        public AssetPropertiesMeta Meta { get; set; }
    }

    /// <summary>
    /// this object can contain extra information about the type of asset. For instance values from the 'Woordenboek Reizigerskenmerken'. [https://github.com/efel85/TOMP-API/issues/17]. These values can also be used in the planning.
    /// </summary>
    public class AssetPropertiesMeta
    {
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

        public Asset Assets { get; set; }

        /// <summary>
        /// These classes are taken from the NeTeX standard, but ALL and UNKNOWN are removed. On the other hand OTHER and PARKING are added.
        /// </summary>
        public string AssetClass { get; set; }

        /// <summary>
        /// a more precise classification of the asset, like 'cargo bike', 'public bus', 'coach bus', 'office bus', 'water taxi',  'segway'. This is mandatory when using 'OTHER' as class.
        /// </summary>
        public string AssetSubClass { get; set; }

        /// <summary>
        /// what kind of asset is this? Classify it, give the aspects. Most aspects are optional and should be used when applicable.
        /// </summary>
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

        /// <summary>
        /// two-letter country codes according to ISO 3166-1
        /// </summary>
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
    /// The booking information describing the state and details of an agreed upon trip
    /// </summary>
    public class Booking : BookingRequest
    {
        /// <summary>
        /// The life-cycle state of the booking (from NEW to FINISHED)
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// A planned (segment of) a booked trip using one asset type
        /// </summary>
        public Leg Legs { get; set; }

        /// <summary>
        /// The pricing information of the overall booking, in addition to any leg pricing, if not all legs have pricing the booking should have the fare
        /// </summary>
        public BookingPricing Pricing { get; set; }

        /// <summary>
        /// Arbitrary information that a TO can add
        /// </summary>
        public BookingExtraData ExtraData { get; set; }
    }

    /// <summary>
    /// Arbitrary information that a TO can add
    /// </summary>
    public class BookingExtraData
    {
    }

    /// <summary>
    /// operation on the bookingOption
    /// </summary>
    public class BookingOperation
    {
        public string Operation { get; set; }
    }

    /// <summary>
    /// The pricing information of the overall booking, in addition to any leg pricing, if not all legs have pricing the booking should have the fare
    /// </summary>
    public class BookingPricing : Fare
    {
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

        /// <summary>
        /// information about the origin, only to supply when requested in the conditionRequireBookingData
        /// </summary>
        public BookingRequestFrom From { get; set; }

        /// <summary>
        /// information about the destination, only to supply when requested in the conditionRequireBookingData
        /// </summary>
        public BookingRequestTo To { get; set; }

        /// <summary>
        /// The user that wants to make this booking, only to supply when requested in the conditionRequireBookingData
        /// </summary>
        public BookingRequestCustomer Customer { get; set; }
    }

    /// <summary>
    /// The user that wants to make this booking, only to supply when requested in the conditionRequireBookingData
    /// </summary>
    public class BookingRequestCustomer : Customer
    {
    }

    /// <summary>
    /// information about the origin, only to supply when requested in the conditionRequireBookingData
    /// </summary>
    public class BookingRequestFrom : Place
    {
    }

    /// <summary>
    /// information about the destination, only to supply when requested in the conditionRequireBookingData
    /// </summary>
    public class BookingRequestTo : Place
    {
    }

    /// <summary>
    /// Any kind of card that isn't a license, only provide the cards that are required
    /// </summary>
    public class Card : CardType
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

        /// <summary>
        /// two-letter country codes according to ISO 3166-1
        /// </summary>
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
        /// <summary>
        /// The broad category of card
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// For use in case of OTHER. Can be used in bilateral agreements.
        /// </summary>
        public string SubType { get; set; }

        /// <summary>
        /// These classes are taken from the NeTeX standard, but ALL and UNKNOWN are removed. On the other hand OTHER and PARKING are added.
        /// </summary>
        public string AssetClass { get; set; }

        public string Acceptors { get; set; }
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

        /// <summary>
        /// trip price including taxes
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// trip distance kilometers
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// trip latitude pickup
        /// </summary>
        public double DepartureLatitude { get; set; }

        /// <summary>
        /// trip longitude pickup
        /// </summary>
        public double DepartureLongitude { get; set; }

        /// <summary>
        /// trip departure time
        /// </summary>
        public string DepartureTime { get; set; }

        /// <summary>
        /// trip latitude dropoff
        /// </summary>
        public double ArrivalLatitude { get; set; }

        /// <summary>
        /// trip longitude dropoff
        /// </summary>
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

        /// <summary>
        /// trip price including taxes
        /// </summary>
        public double Price { get; set; }

        /// <summary>
        /// trip distance kilometers
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// trip latitude pickup
        /// </summary>
        public double DepartureLatitude { get; set; }

        /// <summary>
        /// trip longitude pickup
        /// </summary>
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
    public class ConditionDeposit : Condition
    {
        /// <summary>
        /// This should be in the base unit as defined by the ISO 4217 currency code with the appropriate number of decimal places and omitting the currency symbol. e.g. if the price is in US Dollars the price would be 9.95. This is inclusive VAT
        /// </summary>
        public double Amount { get; set; }

        public double AmountExVat { get; set; }

        /// <summary>
        /// ISO 4217 currency code
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        /// value added tax rate (percentage of amount)
        /// </summary>
        public double VatRate { get; set; }

        /// <summary>
        /// two-letter country codes according to ISO 3166-1
        /// </summary>
        public string VatCountryCode { get; set; }

    }

    /// <summary>
    /// in case the TO demands a direct payment after usage.
    /// </summary>
    public class ConditionPayWhenFinished : Condition
    {
    }

    public class ConditionPostponedCommit : Condition
    {
        public DateTime UltimateResponseTime { get; set; }
    }

    public class ConditionRequireBookingData : Condition
    {
        public string RequiredFields { get; set; }
    }

    /// <summary>
    /// a return area. In the condition list there can be multiple return area's.
    /// </summary>
    public class ConditionReturnArea : Condition
    {
        /// <summary>
        /// station to which the asset should be returned
        /// </summary>
        public string StationId { get; set; }

        /// <summary>
        /// area in which the asset should be returned as GeoJSON Polygon coordinates
        /// </summary>
        public ConditionReturnAreaReturnArea ReturnArea { get; set; }

        /// <summary>
        /// a lon, lat (WGS84, EPSG:4326)
        /// </summary>
        public Coordinates Coordinates { get; set; }

        public SystemHours ReturnHours { get; set; }
    }

    /// <summary>
    /// area in which the asset should be returned as GeoJSON Polygon coordinates
    /// </summary>
    public class ConditionReturnAreaReturnArea : GeojsonPolygon
    {
    }

    /// <summary>
    /// in case the TO demands a upfront payment before usage. The payment should be made in the booking phase.
    /// </summary>
    public class ConditionUpfrontPayment : Condition
    {
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
    public class Customer : Traveler
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

        public Phone Phones { get; set; }

        /// <summary>
        /// the email address of the customer
        /// </summary>
        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        /// <summary>
        /// address field
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// base64 encoded
        /// </summary>
        public byte[] Photo { get; set; }

        /// <summary>
        /// Any kind of card that isn't a license, only provide the cards that are required
        /// </summary>
        public Card Cards { get; set; }

        /// <summary>
        /// driver or usage license for a specific user. Contains the number and the assetType you're allowed to operate (e.g. driver license for CAR)
        /// </summary>
        public License Licenses { get; set; }
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

        /// <summary>
        /// in case the path is ending in /events, the event type/operator enum should be added here.
        /// </summary>
        public string EventType { get; set; }

        public string Status { get; set; }

        /// <summary>
        /// does this endpoint support paging? In that case this endpoint can be accessed using query parameters offset=x and limit=y. Only allowed at endpoints that have specified these query parameters.
        /// </summary>
        public bool SupportsPaging { get; set; }

        /// <summary>
        /// the maximum size of the pages (only valid when supportsPaging=true). If the limit-parameter of the request is above this amount, a http code 400 will be returned.
        /// </summary>
        public double MaxPageSize { get; set; }
    }

    /// <summary>
    /// a complete endpoint description, containing all endpoints, their status, but also the served scenarios and implemented process flows. The identifiers for the process flows can be found at https://github.com/TOMP-WG/TOMP-API/wiki/ProcessIdentifiers
    /// </summary>
    public class EndpointImplementation
    {
        public string Version { get; set; }

        public string BaseUrl { get; set; }

        /// <summary>
        /// a formal description of an endpoint.
        /// </summary>
        public Endpoint Endpoints { get; set; }

        public string Scenarios { get; set; }

        public ProcessIdentifiers ProcessIdentifiers { get; set; }
    }

    /// <summary>
    /// An error that the service may send, e.g. in case of invalid input, missing authorization or internal service error. See https://github.com/TOMP-WG/TOMP-API/wiki/Error-handling-in-TOMP for further explanation of error code.
    /// </summary>
    public class Error
    {
        /// <summary>
        /// The TOMP specific error code. See https://github.com/TOMP-WG/TOMP-API/wiki/Error-handling-in-TOMP for more details of this error.
        /// </summary>
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
    public class ExtraCosts : AmountOfMoney
    {
        public string Category { get; set; }

        /// <summary>
        /// free text to describe the extra costs. Mandatory in case of 'OTHER', should match Content-Language
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// e.g. number of litres, number of kilowatthour, etc
        /// </summary>
        public double Number { get; set; }

        public string NumberType { get; set; }

        public BankAccount Account { get; set; }

        /// <summary>
        /// Arbitrary metadata that a TO can add, like voucher codes
        /// </summary>
        public ExtraCostsMeta Meta { get; set; }
    }

    /// <summary>
    /// Arbitrary metadata that a TO can add, like voucher codes
    /// </summary>
    public class ExtraCostsMeta
    {
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

        /// <summary>
        /// this describes a part of the fare (or discount). It contains a for instance the startup costs (fixed) or the flex part (e.g. 1.25 EUR per 2.0 MILES). The amount is tax included. In case of discounts, the values are negative. With 'MAX' you can specify e.g. a maximum of 15 euro per day. Percentage is mainly added for discounts. The `scale` properties create the ability to communicate scales (e.g. the first 4 kilometers you've to pay EUR 0.35 per kilometer, the kilometers 4 until 8 EUR 0.50 and above it EUR 0.80 per kilometer).
        /// </summary>
        public FarePart Parts { get; set; }
    }

    /// <summary>
    /// this describes a part of the fare (or discount). It contains a for instance the startup costs (fixed) or the flex part (e.g. 1.25 EUR per 2.0 MILES). The amount is tax included. In case of discounts, the values are negative. With 'MAX' you can specify e.g. a maximum of 15 euro per day. Percentage is mainly added for discounts. The `scale` properties create the ability to communicate scales (e.g. the first 4 kilometers you've to pay EUR 0.35 per kilometer, the kilometers 4 until 8 EUR 0.50 and above it EUR 0.80 per kilometer).
    /// </summary>
    public class FarePart : AmountOfMoney
    {
        /// <summary>
        /// type of fare part
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// in case of 'FLEX' mandatory. E.g. 0.5 EUR per HOUR
        /// </summary>
        public string UnitType { get; set; }

        /// <summary>
        /// the number of km, seconds etc in the `per` part. In the first example of the description this should be 2.0
        /// </summary>
        public double Units { get; set; }

        public double ScaleFrom { get; set; }

        public double ScaleTo { get; set; }

        public string ScaleType { get; set; }

        public string Name { get; set; }

        public string Class { get; set; }

        public FarePartMeta Meta { get; set; }
    }

    public class FarePartMeta
    {
    }

    /// <summary>
    /// An array  of WGS84 coordinate pairs
    /// </summary>
    public class GeojsonLine
    {
        public double[][] geojsonLine { get; set; }
    }

    /// <summary>
    /// Geojson Coordinate
    /// </summary>
    public class GeojsonPoint
    {
        public double[] geojsonPoint { get; set; }
    }

    /// <summary>
    /// geojson representation of a polygon. First and last point must be equal. See also https://geojson.org/geojson-spec.html#polygon and example https://geojson.org/geojson-spec.html#id4. The order should be lon, lat [[[lon1, lat1], [lon2,lat2], [lon3,lat3], [lon1,lat1]]], the first point should match the last point.
    /// </summary>
    public class GeojsonPolygon
    {
        public double[][][] geojsonPolygon { get; set; }
    }

    public class GetPitaneDataLedgersResult
    {
        public string Result { get; set; }
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

    public class JournalEntry : AmountOfMoney
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
        public JournalEntryInvoiceId InvoiceId { get; set; }

        public DateTime InvoiceDate { get; set; }

        public string State { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string Comment { get; set; }

        /// <summary>
        /// the travelled distance. Only if applicable.
        /// </summary>
        public double Distance { get; set; }

        public string DistanceType { get; set; }

        /// <summary>
        /// the time in seconds that the assed is used. Only if applicable.
        /// </summary>
        public double UsedTime { get; set; }

        public BankAccount BankAccount { get; set; }

        /// <summary>
        /// the specification of the amount; how is it composed.
        /// </summary>
        public JournalEntryDetails Details { get; set; }
    }

    /// <summary>
    /// the specification of the amount; how is it composed.
    /// </summary>
    public class JournalEntryDetails
    {
    }

    /// <summary>
    /// the number of the invoice. Should be filled in when invoiced.
    /// </summary>
    public class JournalEntryInvoiceId
    {
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

        /// <summary>
        /// The departure location of this leg, using this asset type
        /// </summary>
        public LegFrom From { get; set; }

        /// <summary>
        /// The destination of this leg, using this asset type
        /// </summary>
        public LegTo To { get; set; }

        /// <summary>
        /// The departure time of this leg
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// The intended arrival time at the to place
        /// </summary>
        public DateTime ArrivalTime { get; set; }

        public string TravelerReferenceNumbers { get; set; }

        /// <summary>
        /// The asset type used in this leg as determined during booking
        /// </summary>
        public LegAssetType AssetType { get; set; }

        /// <summary>
        /// The order of the leg in the booking. There can be multiple legs with the same sequence (different user or parallel usage (eg. parking lot and a bike)).
        /// </summary>
        public int LegSequenceNumber { get; set; }

        /// <summary>
        /// The concrete asset used for the execution of the leg
        /// </summary>
        public LegAsset Asset { get; set; }

        /// <summary>
        /// The leg-specific pricing information, all fares are additive, if the booking does not have pricing set all legs should
        /// </summary>
        public LegPricing Pricing { get; set; }

        /// <summary>
        /// The operator of a leg or asset, in case this is not the TO itself but should be shown to the user
        /// </summary>
        public Suboperator Suboperator { get; set; }
    }

    /// <summary>
    /// The concrete asset used for the execution of the leg
    /// </summary>
    public class LegAsset : Asset
    {
    }

    /// <summary>
    /// The asset type used in this leg as determined during booking
    /// </summary>
    public class LegAssetType : AssetType
    {
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

        public string Url { get; set; }

        public Asset Asset { get; set; }
    }

    /// <summary>
    /// The departure location of this leg, using this asset type
    /// </summary>
    public class LegFrom : Place
    {
    }

    /// <summary>
    /// The leg-specific pricing information, all fares are additive, if the booking does not have pricing set all legs should
    /// </summary>
    public class LegPricing : Fare
    {
    }

    /// <summary>
    /// provides current asset location & duration and distance of the current leg
    /// </summary>
    public class LegProgress
    {
        /// <summary>
        /// a lon, lat (WGS84, EPSG:4326)
        /// </summary>
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// A duration of some time (relative to a time) in milliseconds
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// The estimated distance travelled in the leg (in meters)
        /// </summary>
        public int Distance { get; set; }
    }

    /// <summary>
    /// The destination of this leg, using this asset type
    /// </summary>
    public class LegTo : Place
    {
    }

    /// <summary>
    /// driver or usage license for a specific user. Contains the number and the assetType you're allowed to operate (e.g. driver license for CAR)
    /// </summary>
    public class License : LicenseType
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
        /// <summary>
        /// These classes are taken from the NeTeX standard, but ALL and UNKNOWN are removed. On the other hand OTHER and PARKING are added.
        /// </summary>
        public string AssetClass { get; set; }

        /// <summary>
        /// two-letter country codes according to ISO 3166-1
        /// </summary>
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

        /// <summary>
        /// reference to a stop (can be nation specific). This can help to specific pinpoint a (bus) stop. Extra information about the stop is not supplied; you should find it elsewhere.
        /// </summary>
        public StopReference StopReference { get; set; }

        /// <summary>
        /// reference to /operator/stations
        /// </summary>
        public string StationId { get; set; }

        /// <summary>
        /// a lon, lat (WGS84, EPSG:4326)
        /// </summary>
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// address field
        /// </summary>
        public Address PhysicalAddress { get; set; }

        public PlaceExtraInfo ExtraInfo { get; set; }
    }

    public class PlaceExtraInfo
    {
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
        /// <summary>
        /// a origin or destination of a leg, non 3D. lon/lat in WGS84.
        /// </summary>
        public Place From { get; set; }

        /// <summary>
        /// Maximum distance in meters a user wants to travel to reach the travel option
        /// </summary>
        public double Radius { get; set; }

        /// <summary>
        /// a origin or destination of a leg, non 3D. lon/lat in WGS84.
        /// </summary>
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
        /// A generic description of a traveler, not including any identifying information
        /// </summary>
        public Traveler Travelers { get; set; }

        public string UseAssets { get; set; }

        public string UserGroups { get; set; }

        public string UseAssetTypes { get; set; }
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
        public string OperatorInformation { get; set; }

        public string Planning { get; set; }

        public string Booking { get; set; }

        public string TripExecution { get; set; }

        public string Support { get; set; }

        public string Payment { get; set; }

        public string General { get; set; }
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
    /// Requirements the users has ((dis)abilities, share [TRUE|FALSE], preferences [TBD]). See also 'https://github.com/TOMP-WG/TOMP-API/blob/master/documents/Woordenboek%20Reizigerskenmerken%20CROW.pdf'
    /// </summary>
    public class Requirements
    {
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

        public ServicestopLongitude Longitude { get; set; }

        public int Speed { get; set; }

        public string DevImei { get; set; }
    }

    public class ServicestopLongitude
    {
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
        /// <summary>
        /// type of external reference (GTFS, CHB).
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// this field should contain the complete ID. E.g. NL:S:13121110 or BE:S:79640040
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// two-letter country codes according to ISO 3166-1
        /// </summary>
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
        /// <summary>
        /// This indicates that this set of rental hours applies to either members or non-members only.
        /// </summary>
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

        public string Days { get; set; }
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
        public TokenTokenData TokenData { get; set; }
    }

    /// <summary>
    /// Arbitrary data the TO may pass along the ticket to the client (e.g. a booking code, base64 encoded binary, QR code), later will be one of several types
    /// </summary>
    public class TokenTokenData
    {
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
        /// A generic description of a card, asset class and acceptors is only allowed for DISCOUNT/TRAVEL/OTHER cards
        /// </summary>
        public CardType CardTypes { get; set; }

        /// <summary>
        /// A category of license to use a certain asset class
        /// </summary>
        public LicenseType LicenseTypes { get; set; }

        /// <summary>
        /// Requirements the users has ((dis)abilities, share [TRUE|FALSE], preferences [TBD]). See also 'https://github.com/TOMP-WG/TOMP-API/blob/master/documents/Woordenboek%20Reizigerskenmerken%20CROW.pdf'
        /// </summary>
        public Requirements Requirements { get; set; }
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
namespace RestEaseClientGeneratorConsoleApp.Examples.Pitane.Models
{
    public static class PlaEigenaarConstants
    {
        public const string _000 = "000";

        public const string _001 = "001";

        public const string _002 = "002";

        public const string _003 = "003";

        public const string _004 = "004";

        public const string _005 = "005";

        public const string _006 = "006";

        public const string _007 = "007";

        public const string _008 = "008";

        public const string _009 = "009";

        public const string _010 = "010";

        public const string _011 = "011";

        public const string _012 = "012";

        public const string _013 = "013";
    }

    public static class StateConstants
    {
        public const string TOINVOICE = "TO_INVOICE";

        public const string INVOICED = "INVOICED";
    }

    public static class CategoryConstants
    {
        public const string ALL = "ALL";

        public const string DAMAGE = "DAMAGE";

        public const string LOSS = "LOSS";

        public const string STOLEN = "STOLEN";

        public const string EXTRAUSAGE = "EXTRA_USAGE";

        public const string REFUND = "REFUND";

        public const string FINE = "FINE";

        public const string OTHERASSETUSED = "OTHER_ASSET_USED";

        public const string CREDIT = "CREDIT";

        public const string VOUCHER = "VOUCHER";

        public const string DEPOSIT = "DEPOSIT";

        public const string OTHER = "OTHER";
    }

    /// <summary>
    /// These classes are taken from the NeTeX standard, but ALL and UNKNOWN are removed. On the other hand OTHER and PARKING are added.
    /// </summary>
    public static class AssetClassConstants
    {
        public const string AIR = "AIR";

        public const string BUS = "BUS";

        public const string TROLLEYBUS = "TROLLEYBUS";

        public const string TRAM = "TRAM";

        public const string COACH = "COACH";

        public const string RAIL = "RAIL";

        public const string INTERCITYRAIL = "INTERCITYRAIL";

        public const string URBANRAIL = "URBANRAIL";

        public const string METRO = "METRO";

        public const string WATER = "WATER";

        public const string CABLEWAY = "CABLEWAY";

        public const string FUNICULAR = "FUNICULAR";

        public const string TAXI = "TAXI";

        public const string SELFDRIVE = "SELFDRIVE";

        public const string FOOT = "FOOT";

        public const string BICYCLE = "BICYCLE";

        public const string MOTORCYCLE = "MOTORCYCLE";

        public const string CAR = "CAR";

        public const string SHUTTLE = "SHUTTLE";

        public const string OTHER = "OTHER";

        public const string PARKING = "PARKING";

        public const string MOPED = "MOPED";

        public const string STEP = "STEP";
    }

    public static class AssetPropertiesFuelConstants
    {
        public const string NONE = "NONE";

        public const string GASOLINE = "GASOLINE";

        public const string DIESEL = "DIESEL";

        public const string ELECTRIC = "ELECTRIC";

        public const string HYBRIDGASOLINE = "HYBRID_GASOLINE";

        public const string HYBRIDDIESEL = "HYBRID_DIESEL";

        public const string HYBRIDGAS = "HYBRID_GAS";

        public const string HYDROGEN = "HYDROGEN";

        public const string GAS = "GAS";

        public const string BIOMASS = "BIO_MASS";

        public const string KEROSINE = "KEROSINE";

        public const string OTHER = "OTHER";
    }

    /// <summary>
    /// Energy efficiency
    /// </summary>
    public static class AssetPropertiesEnergyLabelConstants
    {
        public const string A = "A";

        public const string B = "B";

        public const string C = "C";

        public const string D = "D";

        public const string E = "E";
    }

    /// <summary>
    /// describes if asset is or needs to be easily accessible
    /// </summary>
    public static class AssetPropertiesEasyAccessibilityConstants
    {
        public const string LIFT = "LIFT";

        public const string ESCALATOR = "ESCALATOR";

        public const string GROUNDLEVEL = "GROUND_LEVEL";

        public const string SIGHTIMPAIRMENT = "SIGHTIMPAIRMENT";

        public const string HEARINGIMPAIRMENT = "HEARINGIMPAIRMENT";

        public const string WHEELCHAIR = "WHEELCHAIR";
    }

    /// <summary>
    /// type of gearbox
    /// </summary>
    public static class AssetPropertiesGearboxConstants
    {
        public const string MANUAL = "MANUAL";

        public const string AUTOMATIC = "AUTOMATIC";

        public const string SEMIAUTOMATIC = "SEMIAUTOMATIC";
    }

    /// <summary>
    /// way in which the asset is powered
    /// </summary>
    public static class AssetPropertiesPropulsionConstants
    {
        public const string MUSCLE = "MUSCLE";

        public const string ELECTRIC = "ELECTRIC";

        public const string GASOLINE = "GASOLINE";

        public const string DIESEL = "DIESEL";

        public const string HYBRID = "HYBRID";

        public const string LPG = "LPG";

        public const string HYDROGEN = "HYDROGEN";
    }

    /// <summary>
    /// These classes are taken from the NeTeX standard, but ALL and UNKNOWN are removed. On the other hand OTHER and PARKING are added.
    /// </summary>
    public static class AssetTypeAssetClassConstants
    {
        public const string AIR = "AIR";

        public const string BUS = "BUS";

        public const string TROLLEYBUS = "TROLLEYBUS";

        public const string TRAM = "TRAM";

        public const string COACH = "COACH";

        public const string RAIL = "RAIL";

        public const string INTERCITYRAIL = "INTERCITYRAIL";

        public const string URBANRAIL = "URBANRAIL";

        public const string METRO = "METRO";

        public const string WATER = "WATER";

        public const string CABLEWAY = "CABLEWAY";

        public const string FUNICULAR = "FUNICULAR";

        public const string TAXI = "TAXI";

        public const string SELFDRIVE = "SELFDRIVE";

        public const string FOOT = "FOOT";

        public const string BICYCLE = "BICYCLE";

        public const string MOTORCYCLE = "MOTORCYCLE";

        public const string CAR = "CAR";

        public const string SHUTTLE = "SHUTTLE";

        public const string OTHER = "OTHER";

        public const string PARKING = "PARKING";

        public const string MOPED = "MOPED";

        public const string STEP = "STEP";
    }

    /// <summary>
    /// The life-cycle state of the booking (from NEW to FINISHED)
    /// </summary>
    public static class BookingStateConstants
    {
        public const string NEW = "NEW";

        public const string PENDING = "PENDING";

        public const string REJECTED = "REJECTED";

        public const string RELEASED = "RELEASED";

        public const string EXPIRED = "EXPIRED";

        public const string CONDITIONALCONFIRMED = "CONDITIONAL_CONFIRMED";

        public const string CONFIRMED = "CONFIRMED";

        public const string CANCELLED = "CANCELLED";

        public const string STARTED = "STARTED";

        public const string FINISHED = "FINISHED";
    }

    public static class BookingOperationOperationConstants
    {
        public const string CANCEL = "CANCEL";

        public const string EXPIRE = "EXPIRE";

        public const string DENY = "DENY";

        public const string COMMIT = "COMMIT";
    }

    /// <summary>
    /// The broad category of card
    /// </summary>
    public static class CardTypeTypeConstants
    {
        public const string ID = "ID";

        public const string DISCOUNT = "DISCOUNT";

        public const string TRAVEL = "TRAVEL";

        public const string BANK = "BANK";

        public const string CREDIT = "CREDIT";

        public const string PASSPORT = "PASSPORT";

        public const string OTHER = "OTHER";
    }

    /// <summary>
    /// These classes are taken from the NeTeX standard, but ALL and UNKNOWN are removed. On the other hand OTHER and PARKING are added.
    /// </summary>
    public static class CardTypeAssetClassConstants
    {
        public const string AIR = "AIR";

        public const string BUS = "BUS";

        public const string TROLLEYBUS = "TROLLEYBUS";

        public const string TRAM = "TRAM";

        public const string COACH = "COACH";

        public const string RAIL = "RAIL";

        public const string INTERCITYRAIL = "INTERCITYRAIL";

        public const string URBANRAIL = "URBANRAIL";

        public const string METRO = "METRO";

        public const string WATER = "WATER";

        public const string CABLEWAY = "CABLEWAY";

        public const string FUNICULAR = "FUNICULAR";

        public const string TAXI = "TAXI";

        public const string SELFDRIVE = "SELFDRIVE";

        public const string FOOT = "FOOT";

        public const string BICYCLE = "BICYCLE";

        public const string MOTORCYCLE = "MOTORCYCLE";

        public const string CAR = "CAR";

        public const string SHUTTLE = "SHUTTLE";

        public const string OTHER = "OTHER";

        public const string PARKING = "PARKING";

        public const string MOPED = "MOPED";

        public const string STEP = "STEP";
    }

    public static class ConditionRequireBookingDataRequiredFieldsConstants
    {
        public const string FROMADDRESS = "FROM_ADDRESS";

        public const string TOADDRESS = "TO_ADDRESS";

        public const string BIRTHDATE = "BIRTHDATE";

        public const string EMAIL = "EMAIL";

        public const string PERSONALADDRESS = "PERSONAL_ADDRESS";

        public const string PHONENUMBERS = "PHONE_NUMBERS";

        public const string LICENSES = "LICENSES";

        public const string BANKCARDS = "BANK_CARDS";

        public const string DISCOUNTCARDS = "DISCOUNT_CARDS";

        public const string TRAVELCARDS = "TRAVEL_CARDS";

        public const string IDCARDS = "ID_CARDS";

        public const string CREDITCARDS = "CREDIT_CARDS";

        public const string NAME = "NAME";

        public const string AGE = "AGE";
    }

    public static class DayConstants
    {
        public const string MON = "MON";

        public const string TUE = "TUE";

        public const string WED = "WED";

        public const string THU = "THU";

        public const string FRI = "FRI";

        public const string SAT = "SAT";

        public const string SUN = "SUN";
    }

    public static class EndpointMethodConstants
    {
        public const string POST = "POST";

        public const string PUT = "PUT";

        public const string GET = "GET";

        public const string DELETE = "DELETE";

        public const string PATCH = "PATCH";
    }

    /// <summary>
    /// in case the path is ending in /events, the event type/operator enum should be added here.
    /// </summary>
    public static class EndpointEventTypeConstants
    {
        public const string PREPARE = "PREPARE";

        public const string ASSIGNASSET = "ASSIGN_ASSET";

        public const string SETINUSE = "SET_IN_USE";

        public const string PAUSE = "PAUSE";

        public const string STARTFINISHING = "START_FINISHING";

        public const string FINISH = "FINISH";

        public const string ISSUE = "ISSUE";

        public const string CANCEL = "CANCEL";

        public const string EXPIRE = "EXPIRE";

        public const string DENY = "DENY";

        public const string COMMIT = "COMMIT";
    }

    public static class EndpointStatusConstants
    {
        public const string NOTIMPLEMENTED = "NOT_IMPLEMENTED";

        public const string DIALECT = "DIALECT";

        public const string IMPLEMENTED = "IMPLEMENTED";
    }

    public static class EndpointImplementationScenariosConstants
    {
        public const string POSTPONEDCOMMIT = "POSTPONED_COMMIT";

        public const string DEPOSIT = "DEPOSIT";

        public const string PAYWHENFINISHED = "PAY_WHEN_FINISHED";

        public const string REQUIREBOOKINGDATA = "REQUIRE_BOOKING_DATA";

        public const string RETURNAREA = "RETURN_AREA";

        public const string UPFRONTPAYMENT = "UPFRONT_PAYMENT";
    }

    public static class ExtraCostsCategoryConstants
    {
        public const string ALL = "ALL";

        public const string DAMAGE = "DAMAGE";

        public const string LOSS = "LOSS";

        public const string STOLEN = "STOLEN";

        public const string EXTRAUSAGE = "EXTRA_USAGE";

        public const string REFUND = "REFUND";

        public const string FINE = "FINE";

        public const string OTHERASSETUSED = "OTHER_ASSET_USED";

        public const string CREDIT = "CREDIT";

        public const string VOUCHER = "VOUCHER";

        public const string DEPOSIT = "DEPOSIT";

        public const string OTHER = "OTHER";
    }

    public static class ExtraCostsNumberTypeConstants
    {
        public const string LITER = "LITER";

        public const string KILOWATTHOUR = "KILOWATTHOUR";

        public const string CO2COMPENSATION = "CO2_COMPENSATION";

        public const string OTHER = "OTHER";
    }

    /// <summary>
    /// type of fare part
    /// </summary>
    public static class FarePartTypeConstants
    {
        public const string FIXED = "FIXED";

        public const string FLEX = "FLEX";

        public const string MAX = "MAX";
    }

    /// <summary>
    /// in case of 'FLEX' mandatory. E.g. 0.5 EUR per HOUR
    /// </summary>
    public static class FarePartUnitTypeConstants
    {
        public const string KM = "KM";

        public const string SECOND = "SECOND";

        public const string MINUTE = "MINUTE";

        public const string HOUR = "HOUR";

        public const string MILE = "MILE";

        public const string PERCENTAGE = "PERCENTAGE";
    }

    public static class FarePartScaleTypeConstants
    {
        public const string KM = "KM";

        public const string MILE = "MILE";

        public const string HOUR = "HOUR";

        public const string MINUTE = "MINUTE";
    }

    public static class JournalCategoryConstants
    {
        public const string ALL = "ALL";

        public const string DAMAGE = "DAMAGE";

        public const string LOSS = "LOSS";

        public const string STOLEN = "STOLEN";

        public const string EXTRAUSAGE = "EXTRA_USAGE";

        public const string REFUND = "REFUND";

        public const string FINE = "FINE";

        public const string OTHERASSETUSED = "OTHER_ASSET_USED";

        public const string CREDIT = "CREDIT";

        public const string VOUCHER = "VOUCHER";

        public const string DEPOSIT = "DEPOSIT";

        public const string OTHER = "OTHER";
    }

    public static class JournalEntryStateConstants
    {
        public const string TOINVOICE = "TO_INVOICE";

        public const string INVOICED = "INVOICED";
    }

    public static class JournalEntryDistanceTypeConstants
    {
        public const string KM = "KM";

        public const string MILE = "MILE";
    }

    public static class JournalStateConstants
    {
        public const string TOINVOICE = "TO_INVOICE";

        public const string INVOICED = "INVOICED";
    }

    public static class LegEventEventConstants
    {
        public const string PREPARE = "PREPARE";

        public const string ASSIGNASSET = "ASSIGN_ASSET";

        public const string SETINUSE = "SET_IN_USE";

        public const string PAUSE = "PAUSE";

        public const string STARTFINISHING = "START_FINISHING";

        public const string FINISH = "FINISH";

        public const string TIMEEXTEND = "TIME_EXTEND";

        public const string TIMEPOSTPONE = "TIME_POSTPONE";
    }

    /// <summary>
    /// status of a leg
    /// </summary>
    public static class LegStateConstants
    {
        public const string NOTSTARTED = "NOT_STARTED";

        public const string PREPARING = "PREPARING";

        public const string INUSE = "IN_USE";

        public const string PAUSED = "PAUSED";

        public const string FINISHING = "FINISHING";

        public const string FINISHED = "FINISHED";

        public const string ISSUEREPORTED = "ISSUE_REPORTED";
    }

    /// <summary>
    /// These classes are taken from the NeTeX standard, but ALL and UNKNOWN are removed. On the other hand OTHER and PARKING are added.
    /// </summary>
    public static class LicenseTypeAssetClassConstants
    {
        public const string AIR = "AIR";

        public const string BUS = "BUS";

        public const string TROLLEYBUS = "TROLLEYBUS";

        public const string TRAM = "TRAM";

        public const string COACH = "COACH";

        public const string RAIL = "RAIL";

        public const string INTERCITYRAIL = "INTERCITYRAIL";

        public const string URBANRAIL = "URBANRAIL";

        public const string METRO = "METRO";

        public const string WATER = "WATER";

        public const string CABLEWAY = "CABLEWAY";

        public const string FUNICULAR = "FUNICULAR";

        public const string TAXI = "TAXI";

        public const string SELFDRIVE = "SELFDRIVE";

        public const string FOOT = "FOOT";

        public const string BICYCLE = "BICYCLE";

        public const string MOTORCYCLE = "MOTORCYCLE";

        public const string CAR = "CAR";

        public const string SHUTTLE = "SHUTTLE";

        public const string OTHER = "OTHER";

        public const string PARKING = "PARKING";

        public const string MOPED = "MOPED";

        public const string STEP = "STEP";
    }

    public static class PhoneKindConstants
    {
        public const string LANDLINE = "LANDLINE";

        public const string MOBILE = "MOBILE";
    }

    public static class PhoneTypeConstants
    {
        public const string PRIVATE = "PRIVATE";

        public const string BUSINESS = "BUSINESS";

        public const string OTHER = "OTHER";
    }

    public static class ScenarioConstants
    {
        public const string POSTPONEDCOMMIT = "POSTPONED_COMMIT";

        public const string DEPOSIT = "DEPOSIT";

        public const string PAYWHENFINISHED = "PAY_WHEN_FINISHED";

        public const string REQUIREBOOKINGDATA = "REQUIRE_BOOKING_DATA";

        public const string RETURNAREA = "RETURN_AREA";

        public const string UPFRONTPAYMENT = "UPFRONT_PAYMENT";
    }

    /// <summary>
    /// type of external reference (GTFS, CHB).
    /// </summary>
    public static class StopReferenceTypeConstants
    {
        public const string GTFSSTOPID = "GTFS_STOP_ID";

        public const string GTFSSTOPCODE = "GTFS_STOP_CODE";

        public const string GTFSAREAID = "GTFS_AREA_ID";

        public const string CHBSTOPPLACECODE = "CHB_STOP_PLACE_CODE";

        public const string CHBQUAYCODE = "CHB_QUAY_CODE";

        public const string NSCODE = "NS_CODE";
    }

    /// <summary>
    /// This indicates that this set of rental hours applies to either members or non-members only.
    /// </summary>
    public static class SystemHoursUserTypeConstants
    {
        public const string MEMBER = "MEMBER";

        public const string NONMEMBERS = "NON_MEMBERS";
    }

    public static class SystemHoursDaysConstants
    {
        public const string MON = "MON";

        public const string TUE = "TUE";

        public const string WED = "WED";

        public const string THU = "THU";

        public const string FRI = "FRI";

        public const string SAT = "SAT";

        public const string SUN = "SUN";
    }
}
