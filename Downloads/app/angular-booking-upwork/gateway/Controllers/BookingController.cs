using System;
using System.IO;
using System.Threading.Tasks;
using gateway.Filters;
using gateway.Mailer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gateway;

[ApiController]
[Route("api/[controller]")]
[TypeFilter<ExceptionFilter>]
public class BookingController(
    BookingDbContext context,
    ILogger<BookingController> logger,
    IEmailService emailService
) : ControllerBase
{
    private readonly ILogger<BookingController> _logger = logger;
    private readonly BookingDbContext _context = context;

    private readonly IEmailService _emailService = emailService;

    [HttpGet]
    public async Task<IActionResult> GetAllRequests()
    {
        _logger.LogInformation("GetAllRequests called");
        var model = await _context
            .BookingRequest.Include(x => x.Child)
            .Include(x => x.Parent)
            .Include(x => x.Psychologist)
            .ToListAsync();
        return Ok(model);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetOne(int id)
    {
        _logger.LogInformation("GetOne called, id: {id}", id);
        var model = await _context
            .BookingRequest.Include(x => x.Child)
            .Include(x => x.Parent)
            .Include(x => x.Psychologist)
            .FirstAsync(x => x.RequestID == id);
        return Ok(model);
    }

    [HttpPost]
    public async Task<IActionResult> Create(AppointmentRequestVM model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                BookingRequest bookingRequest =
                    new()
                    {
                        ParentID = 1, //TODO: Add ID of logged in user (parent)
                        ChildID = model.ChildID,
                        PsychologistID = model.PsychologistID,
                        PreferredDateTime = new DateTime(
                            model.PreferredDateTime.Year,
                            model.PreferredDateTime.Month,
                            model.PreferredDateTime.Day,
                            model.PreferredDateTime.Hour,
                            model.PreferredDateTime.Minute,
                            0
                        ),
                        RequestDate = DateTime.Now,
                        Status = "PENDING",
                        Comments = model.Comments ?? "No comments",
                    };
                _context.BookingRequest.Add(bookingRequest);
                await _context.SaveChangesAsync();
                return Ok(bookingRequest);
            }

            _logger.LogWarning("Invalid model state");
            return BadRequest("Invalid model state");
        }
        catch (Exception e)
        {
            _logger.LogError(e.ToString());
            throw;
        }
    }

    [HttpPost("check")]
    public async Task<IActionResult> CheckBooking(AppointmentRequestVM body)
    {
        _logger.LogInformation("CheckBooking called");

        var dateTime = new DateTime(
            body.PreferredDateTime.Year,
            body.PreferredDateTime.Month,
            body.PreferredDateTime.Day,
            body.PreferredDateTime.Hour,
            body.PreferredDateTime.Minute,
            0
        );

        var model = await _context.BookingRequest.FirstOrDefaultAsync(x =>
            x.ChildID == body.ChildID
            && x.PsychologistID == body.PsychologistID
            && x.PreferredDateTime == dateTime
            && x.RequestID != (body.RequestID > 0 ? body.RequestID : 0)
        );

        if (model == null)
        {
            return Ok(model);
        }

        return BadRequest("Slot already booked for selected date and time.");
    }

    [HttpPost("update-status")]
    public async Task<IActionResult> UpdateStatus(ApprovalVM body)
    {
        _logger.LogInformation("CheckBooking called");

        var model = await _context
            .BookingRequest.Include(x => x.Parent)
            .Include(x => x.Child)
            .Include(x => x.Psychologist)
            .FirstOrDefaultAsync(x => x.RequestID == body.RequestID);

        model.Status = body.Status;

        await _context.SaveChangesAsync();

        var template = _emailService.GetTemplate(model, body.Status);

        _emailService.SendEmail(
            model.Parent.EmailAddress,
            "Booking Request Confirmation",
            template
        );

        return Ok(model);
    }
}
