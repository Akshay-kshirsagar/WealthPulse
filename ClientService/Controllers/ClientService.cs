using ClientService.Data;
using ClientService.DTOs;
using ClientService.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientService : ControllerBase
    {
        private readonly AppDbContext _db;

        public ClientService(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll(
            string? search = "",
            int page = 1,
            int pageSize = 10)
        {
            var query = _db.Clients.AsQueryable();

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(x =>
                    x.FullName.Contains(search) ||
                    x.Email.Contains(search) ||
                    x.ClientCode.Contains(search));
            }

            var total = await query.CountAsync();

            var data = await query
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(new
            {
                total,
                page,
                pageSize,
                data
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var client = await _db.Clients.FindAsync(id);

            if (client == null)
                return NotFound();

            return Ok(client);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateClientRequest request)
        {
            var code = $"CL{DateTime.UtcNow.Ticks.ToString()[^6..]}";

            var client = new Client
            {
                ClientCode = code,
                FullName = request.FullName,
                Email = request.Email,
                Phone = request.Phone,
                PAN = request.PAN,
                DateOfBirth = request.DateOfBirth,
                RiskProfile = request.RiskProfile,
                AdvisorCode = request.AdvisorCode
            };

            _db.Clients.Add(client);
            await _db.SaveChangesAsync();

            return Ok(client);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateClientRequest request)
        {
            var client = await _db.Clients.FindAsync(id);

            if (client == null)
                return NotFound();

            client.FullName = request.FullName;
            client.Email = request.Email;
            client.Phone = request.Phone;
            client.RiskProfile = request.RiskProfile;
            client.IsActive = request.IsActive;

            await _db.SaveChangesAsync();

            return Ok(client);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var client = await _db.Clients.FindAsync(id);

            if (client == null)
                return NotFound();

            _db.Clients.Remove(client);
            await _db.SaveChangesAsync();

            return Ok("Deleted successfully");
        }
    }
}
