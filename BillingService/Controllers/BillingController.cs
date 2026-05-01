using BillingService.Data;
using BillingService.DTOs;
using BillingService.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BillingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BillingController : ControllerBase
    {
        private readonly AppDbContext _db;

        public BillingController(AppDbContext db)
        {
            _db = db;
        }

        [HttpPost("fee-plan")]
        public async Task<IActionResult> CreateFeePlan(CreateFeePlanRequest request)
        {
            var plan = new FeePlan
            {
                ClientId = request.ClientId,
                PlanName = request.PlanName,
                FeeType = request.FeeType,
                FlatAmount = request.FlatAmount,
                PercentageRate = request.PercentageRate,
                Frequency = request.Frequency
            };

            _db.FeePlans.Add(plan);
            await _db.SaveChangesAsync();

            return Ok(plan);
        }

        [HttpGet("fee-plan/{clientId}")]
        public async Task<IActionResult> GetPlans(int clientId)
        {
            var plans = await _db.FeePlans
                .Where(x => x.ClientId == clientId && x.IsActive)
                .ToListAsync();

            return Ok(plans);
        }

        [HttpPost("generate-invoice/{clientId}")]
        public async Task<IActionResult> GenerateInvoice(int clientId)
        {
            var plan = await _db.FeePlans
                .FirstOrDefaultAsync(x => x.ClientId == clientId && x.IsActive);

            if (plan == null)
                return BadRequest("No active fee plan found");

            decimal amount = plan.FeeType == "Flat"
                ? plan.FlatAmount
                : 500000 * plan.PercentageRate / 100; // Demo AUM

            var invoice = new Invoice
            {
                ClientId = clientId,
                InvoiceNo = $"INV-{DateTime.UtcNow.Ticks.ToString()[^6..]}",
                Amount = amount,
                InvoiceDate = DateTime.UtcNow,
                DueDate = DateTime.UtcNow.AddDays(7),
                Status = "Pending"
            };

            _db.Invoices.Add(invoice);
            await _db.SaveChangesAsync();

            return Ok(invoice);
        }

        [HttpGet("invoices")]
        public async Task<IActionResult> GetInvoices()
        {
            var invoices = await _db.Invoices
                .OrderByDescending(x => x.Id)
                .ToListAsync();

            return Ok(invoices);
        }

        [HttpPut("mark-paid/{id}")]
        public async Task<IActionResult> MarkPaid(int id)
        {
            var invoice = await _db.Invoices.FindAsync(id);

            if (invoice == null)
                return NotFound();

            invoice.Status = "Paid";
            invoice.PaidDate = DateTime.UtcNow;

            await _db.SaveChangesAsync();

            return Ok(invoice);
        }

        [HttpGet("dashboard")]
        public async Task<IActionResult> Dashboard()
        {
            var totalRevenue = await _db.Invoices
                .Where(x => x.Status == "Paid")
                .SumAsync(x => (decimal?)x.Amount) ?? 0;

            var pending = await _db.Invoices
                .CountAsync(x => x.Status == "Pending");

            var totalInvoices = await _db.Invoices.CountAsync();

            return Ok(new
            {
                totalRevenue,
                pending,
                totalInvoices
            });
        }
    }
}
