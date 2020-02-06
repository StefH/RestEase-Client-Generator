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
        Task<AdresGegevens> GetAdresgegevensByKlantnummerAsync([Header("Authorization")] string authorization, [Path] int? klantnummer);

        /// <summary>
        /// PatchAdresgegevensByKlantnummer (/adresgegevens/{klantnummer})
        /// </summary>
        /// <param name="content"></param>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Patch("/adresgegevens/{klantnummer}")]
        [Header("Content-Type", "application/json")]
        Task<AdresGegevens> PatchAdresgegevensByKlantnummerAsync([Body] AdresGegevens content, [Header("Authorization")] string authorization, [Path] int? klantnummer);

        /// <summary>
        /// GetKlantenByKlantnummerBankgegevens (/klanten/{klantnummer}/bankgegevens)
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/klanten/{klantnummer}/bankgegevens")]
        Task<BankGegevens> GetKlantenByKlantnummerBankgegevensAsync([Header("Authorization")] string authorization, [Path] int? klantnummer);

        /// <summary>
        /// PatchKlantenByKlantnummerBankgegevensExcasso (/klanten/{klantnummer}/bankgegevens/excasso)
        /// </summary>
        /// <param name="content"></param>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Patch("/klanten/{klantnummer}/bankgegevens/excasso")]
        [Header("Content-Type", "application/json")]
        Task<BankGegevens> PatchKlantenByKlantnummerBankgegevensExcassoAsync([Body] MuterenBankGegevens content, [Header("Authorization")] string authorization, [Path] int? klantnummer);

        /// <summary>
        /// GetKlantenByKlantnummerDocumenten (/klanten/{klantnummer}/documenten)
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/klanten/{klantnummer}/documenten")]
        Task<Document> GetKlantenByKlantnummerDocumentenAsync([Header("Authorization")] string authorization, [Path] int? klantnummer);

        /// <summary>
        /// GetKlantenByKlantnummerDocumentenAndPlacetdocumentnummer (/klanten/{klantnummer}/documenten/{placetdocumentnummer})
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        /// <param name="placetdocumentnummer"></param>
        [Get("/klanten/{klantnummer}/documenten/{placetdocumentnummer}")]
        Task GetKlantenByKlantnummerDocumentenAndPlacetdocumentnummerAsync([Header("Authorization")] string authorization, [Path] int? klantnummer, [Path] int? placetdocumentnummer);

        /// <summary>
        /// GetKlantenByKlantnummerProducten (/klanten/{klantnummer}/producten)
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/klanten/{klantnummer}/producten")]
        Task<Product> GetKlantenByKlantnummerProductenAsync([Header("Authorization")] string authorization, [Path] int? klantnummer);

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
        Task<PersoonsGegevens> GetKlantenByKlantnummerPersoonsgegevensAsync([Header("Authorization")] string authorization, [Path] int? klantnummer);

        /// <summary>
        /// PatchKlantenByKlantnummerPersoonsgegevens (/klanten/{klantnummer}/persoonsgegevens)
        /// </summary>
        /// <param name="content"></param>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Patch("/klanten/{klantnummer}/persoonsgegevens")]
        [Header("Content-Type", "application/json")]
        Task<PersoonsGegevens> PatchKlantenByKlantnummerPersoonsgegevensAsync([Body] MuterenPersoonsGegevens content, [Header("Authorization")] string authorization, [Path] int? klantnummer);

        /// <summary>
        /// GetWerkgeversgegevensByKlantnummer (/werkgeversgegevens/{klantnummer})
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/werkgeversgegevens/{klantnummer}")]
        Task<WerkgeversGegevens> GetWerkgeversgegevensByKlantnummerAsync([Header("Authorization")] string authorization, [Path] int? klantnummer);
    }
}
