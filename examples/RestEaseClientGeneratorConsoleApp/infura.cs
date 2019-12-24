using System.Threading.Tasks;
using RestEase;
using InfuraTest.Models;

namespace InfuraTest.Api
{
    public interface IinfuraApi
    {
        /// <summary>
        /// GetV1JsonrpcAndNetworkMethods (/v1/jsonrpc/{network}/methods)
        /// </summary>
        /// <param name="network">Ethereum network in lowercase</param>
        [Get("/v1/jsonrpc/{network}/methods")]
        Task<MethodsResponse> GetV1JsonrpcAndNetworkMethodsAsync([Path] string network);

        /// <summary>
        /// GetV1JsonrpcAndNetworkByMethod (/v1/jsonrpc/{network}/{method})
        /// </summary>
        /// <param name="network">Ethereum network in lowercase</param>
        /// <param name="method">JSON-RPC method. Use the `/v1/jsonrpc/{network}/methods` endpoint to get the list of permitted methods.</param>
        /// <param name="_params">This is the `params` field that would normally be part of the JSON-RPC POST body. Use the exact same format. If it's omitted, it will default to an empty array.</param>
        [Get("/v1/jsonrpc/{network}/{method}")]
        Task<JSONRPCResponse> GetV1JsonrpcAndNetworkByMethodAsync([Path] string network, [Path] string method, [Query(Name = "params")] string[] _params);

        /// <summary>
        /// PostV1JsonrpcAndNetwork (/v1/jsonrpc/{network})
        /// </summary>
        /// <param name="network">Ethereum network in lowercase</param>
        /// <param name="jSONRPCRequest"></param>
        [Post("/v1/jsonrpc/{network}")]
        Task<JSONRPCResponse> PostV1JsonrpcAndNetworkAsync([Path] string network, [Body] JSONRPCRequest jSONRPCRequest);

        /// <summary>
        /// GetV1TickerSymbols (/v1/ticker/symbols)
        /// </summary>
        [Get("/v1/ticker/symbols")]
        Task<SymbolsResponse> GetV1TickerSymbolsAsync();

        /// <summary>
        /// GetV1TickerAndSymbol (/v1/ticker/{symbol})
        /// </summary>
        /// <param name="symbol">Ticker symbol (currency pair)</param>
        [Get("/v1/ticker/{symbol}")]
        Task<TickerResponse> GetV1TickerAndSymbolAsync([Path] string symbol);

        /// <summary>
        /// GetV1TickerAndSymbolFull (/v1/ticker/{symbol}/full)
        /// </summary>
        /// <param name="symbol">Ticker symbol (currency pair)</param>
        [Get("/v1/ticker/{symbol}/full")]
        Task<TickerFullResponse> GetV1TickerAndSymbolFullAsync([Path] string symbol);

        /// <summary>
        /// GetV1Blacklist (/v1/blacklist)
        /// </summary>
        [Get("/v1/blacklist")]
        Task<string[]> GetV1BlacklistAsync();

        /// <summary>
        /// GetV2Blacklist (/v2/blacklist)
        /// </summary>
        [Get("/v2/blacklist")]
        Task<BlacklistResponse> GetV2BlacklistAsync();
    }
}

namespace InfuraTest.Models
{
    public class MethodsResponse
    {
        public string[] Get { get; set; }

        public string[] Post { get; set; }
    }
}

namespace InfuraTest.Models
{
    public class JSONRPCRequest
    {
        public string Jsonrpc { get; set; }

        public int Id { get; set; }

        public string Method { get; set; }

        public object[] Params { get; set; }
    }
}

namespace InfuraTest.Models
{
    public class JSONRPCResponse
    {
        public string Jsonrpc { get; set; }

        public int Id { get; set; }

        public string Result { get; set; }
    }
}

namespace InfuraTest.Models
{
    public class SymbolsResponse
    {
        public string[] Symbols { get; set; }
    }
}

namespace InfuraTest.Models
{
    public class TickerResponse
    {
        public string Base { get; set; }

        public string Quote { get; set; }

        public double Bid { get; set; }

        public double Ask { get; set; }

        public string Exchange { get; set; }

        public double Volume { get; set; }

        public int NumExchanges { get; set; }

        public double TotalVolume { get; set; }

        public int Timestamp { get; set; }
    }
}

namespace InfuraTest.Models
{
    public class TickerFullResponse
    {
        public string Base { get; set; }

        public string Quote { get; set; }

        public object[] Tickers { get; set; }
    }
}

namespace InfuraTest.Models
{
    public class BlacklistResponse
    {
        public int Version { get; set; }

        public int Tolerance { get; set; }

        public string[] Fuzzylist { get; set; }

        public string[] Whitelist { get; set; }

        public string[] Blacklist { get; set; }
    }
}

