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
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/adresgegevens/{klantnummer}")]
        Task<AdresGegevens> GetAdresgegevensByKlantnummerAsync([Header("Authorization")] string authorization, [Path] string klantnummer);

        /// <summary>
        /// PatchAdresgegevensByKlantnummer (/adresgegevens/{klantnummer})
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        /// <param name="content"></param>
        [Patch("/adresgegevens/{klantnummer}")]
        [Header("Content-Type", "application/json")]
        Task<AdresGegevens> PatchAdresgegevensByKlantnummerAsync([Header("Authorization")] string authorization, [Path] string klantnummer, [Body] AdresGegevens content);

        /// <summary>
        /// GetKlantenByKlantnummerBankgegevens (/klanten/{klantnummer}/bankgegevens)
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/klanten/{klantnummer}/bankgegevens")]
        Task<BankGegevens> GetKlantenByKlantnummerBankgegevensAsync([Header("Authorization")] string authorization, [Path] string klantnummer);

        /// <summary>
        /// PatchKlantenByKlantnummerBankgegevensExcasso (/klanten/{klantnummer}/bankgegevens/excasso)
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        /// <param name="content"></param>
        [Patch("/klanten/{klantnummer}/bankgegevens/excasso")]
        [Header("Content-Type", "application/json")]
        Task<BankGegevens> PatchKlantenByKlantnummerBankgegevensExcassoAsync([Header("Authorization")] string authorization, [Path] string klantnummer, [Body] MuterenBankGegevens content);

        /// <summary>
        /// GetKlantenByKlantnummerDocumenten (/klanten/{klantnummer}/documenten)
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/klanten/{klantnummer}/documenten")]
        Task<Document> GetKlantenByKlantnummerDocumentenAsync([Header("Authorization")] string authorization, [Path] string klantnummer);

        /// <summary>
        /// GetKlantenByKlantnummerDocumentenAndPlacetdocumentnummer (/klanten/{klantnummer}/documenten/{placetdocumentnummer})
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        /// <param name="placetdocumentnummer"></param>
        [Get("/klanten/{klantnummer}/documenten/{placetdocumentnummer}")]
        Task GetKlantenByKlantnummerDocumentenAndPlacetdocumentnummerAsync([Header("Authorization")] string authorization, [Path] string klantnummer, [Path] string placetdocumentnummer);

        /// <summary>
        /// GetKlantenByKlantnummerProducten (/klanten/{klantnummer}/producten)
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/klanten/{klantnummer}/producten")]
        Task<Product> GetKlantenByKlantnummerProductenAsync([Header("Authorization")] string authorization, [Path] string klantnummer);

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
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/klanten/{klantnummer}/persoonsgegevens")]
        Task<PersoonsGegevens> GetKlantenByKlantnummerPersoonsgegevensAsync([Header("Authorization")] string authorization, [Path] string klantnummer);

        /// <summary>
        /// PatchKlantenByKlantnummerPersoonsgegevens (/klanten/{klantnummer}/persoonsgegevens)
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        /// <param name="content"></param>
        [Patch("/klanten/{klantnummer}/persoonsgegevens")]
        [Header("Content-Type", "application/json")]
        Task<PersoonsGegevens> PatchKlantenByKlantnummerPersoonsgegevensAsync([Header("Authorization")] string authorization, [Path] string klantnummer, [Body] MuterenPersoonsGegevens content);

        /// <summary>
        /// GetWerkgeversgegevensByKlantnummer (/werkgeversgegevens/{klantnummer})
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/werkgeversgegevens/{klantnummer}")]
        Task<WerkgeversGegevens> GetWerkgeversgegevensByKlantnummerAsync([Header("Authorization")] string authorization, [Path] string klantnummer);
    }
}
