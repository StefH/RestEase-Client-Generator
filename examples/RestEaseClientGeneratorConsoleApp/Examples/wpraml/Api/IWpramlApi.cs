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
        [Patch("/adresgegevens/{klantnummer}")]
        Task<AdresGegevens> PatchAdresgegevensByKlantnummerAsync([Header("Authorization")] string authorization, [Path] string klantnummer);

        /// <summary>
        /// PatchKlantenByKlantnummerBankgegevensExcasso (/klanten/{klantnummer}/bankgegevens/excasso)
        /// </summary>
        /// <param name="authorization"></param>
        [Patch("/klanten/{klantnummer}/bankgegevens/excasso")]
        Task<BankGegevens> PatchKlantenByKlantnummerBankgegevensExcassoAsync([Header("Authorization")] string authorization);

        /// <summary>
        /// GetKlantenByKlantnummerDocumenten (/klanten/{klantnummer}/documenten)
        /// </summary>
        /// <param name="authorization"></param>
        [Get("/klanten/{klantnummer}/documenten")]
        Task<Document> GetKlantenByKlantnummerDocumentenAsync([Header("Authorization")] string authorization);

        /// <summary>
        /// GetKlantenByKlantnummerDocumentenAndPlacetdocumentnummer (/klanten/{klantnummer}/documenten/{placetdocumentnummer})
        /// </summary>
        /// <param name="authorization"></param>
        [Get("/klanten/{klantnummer}/documenten/{placetdocumentnummer}")]
        Task GetKlantenByKlantnummerDocumentenAndPlacetdocumentnummerAsync([Header("Authorization")] string authorization);

        /// <summary>
        /// GetKlantenByKlantnummerProducten (/klanten/{klantnummer}/producten)
        /// </summary>
        /// <param name="authorization"></param>
        [Get("/klanten/{klantnummer}/producten")]
        Task<Product> GetKlantenByKlantnummerProductenAsync([Header("Authorization")] string authorization);

        /// <summary>
        /// PostLogin (/login)
        /// </summary>
        [Post("/login")]
        Task<LoginTokenResponse> PostLoginAsync();

        /// <summary>
        /// GetKlantenByKlantnummerPersoonsgegevens (/klanten/{klantnummer}/persoonsgegevens)
        /// </summary>
        /// <param name="authorization"></param>
        [Get("/klanten/{klantnummer}/persoonsgegevens")]
        Task<PersoonsGegevens> GetKlantenByKlantnummerPersoonsgegevensAsync([Header("Authorization")] string authorization);

        /// <summary>
        /// PatchKlantenByKlantnummerPersoonsgegevens (/klanten/{klantnummer}/persoonsgegevens)
        /// </summary>
        /// <param name="authorization"></param>
        [Patch("/klanten/{klantnummer}/persoonsgegevens")]
        Task<PersoonsGegevens> PatchKlantenByKlantnummerPersoonsgegevensAsync([Header("Authorization")] string authorization);

        /// <summary>
        /// GetWerkgeversgegevensByKlantnummer (/werkgeversgegevens/{klantnummer})
        /// </summary>
        /// <param name="authorization"></param>
        /// <param name="klantnummer"></param>
        [Get("/werkgeversgegevens/{klantnummer}")]
        Task<WerkgeversGegevens> GetWerkgeversgegevensByKlantnummerAsync([Header("Authorization")] string authorization, [Path] string klantnummer);
    }
}
