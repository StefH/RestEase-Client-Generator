using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using RestEase;
using RestEaseClientGeneratorConsoleApp.Examples.wpraml.Models;

namespace RestEaseClientGeneratorConsoleApp.Examples.wpraml.Api
{
    /// <summary>
    /// Wpraml
    /// </summary>
    public interface IWpramlApi
    {
        /// <summary>
        /// GetAdresgegevensByKlantnummer (/adresgegevens/{klantnummer})
        /// </summary>
        [Get("/adresgegevens/{klantnummer}")]
        Task<AdresGegevens> GetAdresgegevensByKlantnummerAsync();

        /// <summary>
        /// PatchAdresgegevensByKlantnummer (/adresgegevens/{klantnummer})
        /// </summary>
        /// <param name="content"></param>
        [Patch("/adresgegevens/{klantnummer}")]
        [Header("Content-Type", "application/json")]
        Task<AdresGegevens> PatchAdresgegevensByKlantnummerAsync([Body] AdresGegevens content);

        /// <summary>
        /// GetKlantenByKlantnummerBankgegevens (/klanten/{klantnummer}/bankgegevens)
        /// </summary>
        [Get("/klanten/{klantnummer}/bankgegevens")]
        Task<BankGegevens> GetKlantenByKlantnummerBankgegevensAsync();

        /// <summary>
        /// PatchKlantenByKlantnummerBankgegevensExcasso (/klanten/{klantnummer}/bankgegevens/excasso)
        /// </summary>
        /// <param name="content"></param>
        [Patch("/klanten/{klantnummer}/bankgegevens/excasso")]
        [Header("Content-Type", "application/json")]
        Task<BankGegevens> PatchKlantenByKlantnummerBankgegevensExcassoAsync([Body] MuterenBankGegevens content);

        /// <summary>
        /// GetKlantenByKlantnummerDocumenten (/klanten/{klantnummer}/documenten)
        /// </summary>
        [Get("/klanten/{klantnummer}/documenten")]
        Task<Document> GetKlantenByKlantnummerDocumentenAsync();

        /// <summary>
        /// GetKlantenByKlantnummerDocumentenAndPlacetdocumentnummer (/klanten/{klantnummer}/documenten/{placetdocumentnummer})
        /// </summary>
        [Get("/klanten/{klantnummer}/documenten/{placetdocumentnummer}")]
        Task GetKlantenByKlantnummerDocumentenAndPlacetdocumentnummerAsync();

        /// <summary>
        /// GetKlantenByKlantnummerProducten (/klanten/{klantnummer}/producten)
        /// </summary>
        [Get("/klanten/{klantnummer}/producten")]
        Task<Product> GetKlantenByKlantnummerProductenAsync();

        /// <summary>
        /// PostLogin (/login)
        /// </summary>
        /// <param name="content"></param>
        [Post("/login")]
        [Header("Content-Type", "application/json")]
        Task<LoginTokenResponse> PostLoginAsync([Body] InlogGegevens content);

        /// <summary>
        /// GetKlantenByKlantnummerPersoonsgegevens (/klanten/{klantnummer}/persoonsgegevens)
        /// </summary>
        [Get("/klanten/{klantnummer}/persoonsgegevens")]
        Task<PersoonsGegevens> GetKlantenByKlantnummerPersoonsgegevensAsync();

        /// <summary>
        /// PatchKlantenByKlantnummerPersoonsgegevens (/klanten/{klantnummer}/persoonsgegevens)
        /// </summary>
        /// <param name="content"></param>
        [Patch("/klanten/{klantnummer}/persoonsgegevens")]
        [Header("Content-Type", "application/json")]
        Task<PersoonsGegevens> PatchKlantenByKlantnummerPersoonsgegevensAsync([Body] MuterenPersoonsGegevens content);

        /// <summary>
        /// GetWerkgeversgegevensByKlantnummer (/werkgeversgegevens/{klantnummer})
        /// </summary>
        [Get("/werkgeversgegevens/{klantnummer}")]
        Task<WerkgeversGegevens> GetWerkgeversgegevensByKlantnummerAsync();
    }
}
