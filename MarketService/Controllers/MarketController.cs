using MarketService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MarketService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MarketController : ControllerBase
    {
        private readonly KiteService _kite;

        public MarketController(KiteService kite)
        {
            _kite = kite;
        }

        [HttpGet("holdings")]
        public async Task<IActionResult> Holdings()
        {
            var data = await _kite.GetHoldings();
            return Ok(data);
        }

        [HttpGet("positions")]
        public async Task<IActionResult> Positions()
        {
            var data = await _kite.GetPositions();
            return Ok(data);
        }

        [HttpGet("orders")]
        public async Task<IActionResult> Orders()
        {
            var data = await _kite.GetOrders();
            return Ok(data);
        }

        [HttpGet("quote/{symbol}")]
        public async Task<IActionResult> Quote(string symbol)
        {
            var data = await _kite.GetQuote(symbol);
            return Ok(data);
        }

        [HttpGet("history/{token}")]
        public async Task<IActionResult> History(
            string token,
            string from,
            string to,
            string interval = "day")
        {
            var data = await _kite.GetHistorical(token, from, to, interval);
            return Ok(data);
        }

        [HttpGet("instruments")]
        public async Task<IActionResult> Instruments()
        {
            var data = await _kite.GetInstruments();
            return Ok(data);
        }
    }
}
