using System.Net.Http.Headers;

namespace MarketService.Services
{
    public class KiteService
    {
        private readonly HttpClient _http;
        private readonly IConfiguration _config;

        public KiteService(HttpClient http, IConfiguration config)
        {
            _http = http;
            _config = config;

            var apiKey = _config["Kite:ApiKey"];
            var accessToken = _config["Kite:AccessToken"];

            _http.BaseAddress = new Uri(_config["Kite:BaseUrl"]!);
            _http.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue(
                    "token",
                    $"{apiKey}:{accessToken}");
        }

        public async Task<string> GetHoldings()
        {
            return await _http.GetStringAsync("/portfolio/holdings");
        }

        public async Task<string> GetPositions()
        {
            return await _http.GetStringAsync("/portfolio/positions");
        }

        public async Task<string> GetOrders()
        {
            return await _http.GetStringAsync("/orders");
        }

        public async Task<string> GetQuote(string symbol)
        {
            return await _http.GetStringAsync($"/quote?i=NSE:{symbol}");
        }

        public async Task<string> GetHistorical(
            string instrumentToken,
            string from,
            string to,
            string interval = "day")
        {
            return await _http.GetStringAsync(
                $"/instruments/historical/{instrumentToken}/{interval}?from={from}&to={to}");
        }

        public async Task<string> GetInstruments()
        {
            return await _http.GetStringAsync("/instruments");
        }
    }
}
