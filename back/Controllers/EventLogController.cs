using back.DbContexts.ApplicationDbContext;
using back.models;
using back.models.EventLogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class EventLogController : ControllerBase
{
    public EventLogController(ApplicationDbContext db, ILogger<WeatherForecastController> logger)
    {
        this.db = db;
        _logger = logger;

    }

    private ApplicationDbContext db;
    private readonly ILogger<WeatherForecastController> _logger;

    [HttpGet]
    [ProducesResponseType(typeof(EventLogGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = db.EventLogs.AsNoTracking()
            .AsSplitQuery()
            .Include(r => r.CommandOrigin)
            .Include(r => r.CommandParent)
            .Select(r => new EventLogGetResponse
            {
                CommandOriginId = r.CommandOriginId,
                CommandOrigin = r.CommandOrigin,
                CommandParentId = (Guid)r.CommandParentId!,
                CommandParent = r.CommandParent,
                ExecutionTime = r.ExecutionTime,
                TargetType = r.TargetType,
                TargetId = r.TargetId,
                SecondTargetId = r.SecondTargetId,
                CommandType = r.CommandType,
                Command = r.Command,
                ParentEventLogId = r.ParentEventLogId,
                ParentEventLog = r.ParentEventLog,
                ChildEventLogId = r.ChildEventLogId,
                ChildEventLog = r.ChildEventLog 
            });
            var final = await result.ToListAsync();
            
            return Ok(await result.ToListAsync());
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, new BaseRequestResponse()
            {
                IsSuccesfull = false,
                MSG = ex.Message,
                ResponseCode = 500
            });
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(EventLogGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            var result = db.EventLogs.AsNoTracking()
            .Where(p => p.Id == id)
            .AsSplitQuery()
            .Include(r => r.CommandOrigin)
            .Include(r => r.CommandParent)
            .Select(r => new EventLogGetResponse
            {
                CommandOriginId = r.CommandOriginId,
                CommandOrigin = r.CommandOrigin,
                CommandParentId = (Guid)r.CommandParentId!,
                CommandParent = r.CommandParent,
                ExecutionTime = r.ExecutionTime,
                TargetType = r.TargetType,
                TargetId = r.TargetId,
                SecondTargetId = r.SecondTargetId,
                CommandType = r.CommandType,
                Command = r.Command,
                ParentEventLogId = r.ParentEventLogId,
                ParentEventLog = r.ParentEventLog,
                ChildEventLogId = r.ChildEventLogId,
                ChildEventLog = r.ChildEventLog 
            }).SingleOrDefaultAsync();

            if (result != null)
            {
                return Ok(await result);
            }
            else
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = "There is none",
                    ResponseCode = 404
                });
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, new BaseRequestResponse()
            {
                IsSuccesfull = false,
                MSG = ex.Message,
                ResponseCode = 500
            });
        }
    }

    [HttpPost]
    [ProducesResponseType(typeof(EventLogGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] EventLogAddUpdateRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = ModelState.Select(x => x.Value!.Errors)
                           .Where(y => y.Count > 0)
                           .ToList().ToString()!,
                    ResponseCode = 400
                }); ;
            }
            var EventLog = new EventLog()
            {
                CommandOriginId = request.CommandOriginId,
                CommandParentId = request.CommandParentId,
                ExecutionTime = request.ExecutionTime,
                TargetType = request.TargetType,
                TargetId = request.TargetId,
                SecondTargetId = request.SecondTargetId,
                CommandType = request.CommandType,
                Command = request.Command,
                ParentEventLogId = request.ParentEventLogId,
                ChildEventLogId = request.ChildEventLogId,
            };

            db.EventLogs.Add(EventLog);
            await db.SaveChangesAsync();

            return await GetOne(EventLog.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new BaseRequestResponse()
            {
                IsSuccesfull = false,
                MSG = ex.Message
            });
        }
    }

}
