using gateway.Filters;
using gateway.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [TypeFilter<ExceptionFilter>]
    public class LookupsController(BookingDbContext context, ILogger<LookupsController> logger)
        : ControllerBase
    {
        private readonly ILogger<LookupsController> _logger = logger;
        private readonly BookingDbContext _context = context;

        [HttpGet("childs")]
        public async Task<IActionResult> GetChilds()
        {
            _logger.LogInformation("GetChilds called");
            var model = await _context
                .Child.Select(x => new LookupVM { ID = x.ChildID, Name = x.ChildName })
                .ToListAsync();
            return Ok(model);
        }

        [HttpGet("parents")]
        public async Task<IActionResult> GetParents()
        {
            _logger.LogInformation("GetParents called");
            var model = await _context
                .Parent.Select(x => new LookupVM { ID = x.ParentID, Name = x.ParentName })
                .ToListAsync();
            return Ok(model);
        }

        [HttpGet("psychologists")]
        public async Task<IActionResult> GetPsychologists()
        {
            _logger.LogInformation("GetPsychologists called");
            var model = await _context
                .Psychologist.Select(x => new LookupVM
                {
                    ID = x.PsychologistID,
                    Name = x.PsychologistName
                })
                .ToListAsync();
            return Ok(model);
        }
    }
}
