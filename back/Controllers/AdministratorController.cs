using back.DbContexts.ApplicationDbContext;
using back.enums.eventTypes;
using back.enums.TargetTypes;
using back.models;
using back.models.Administrators;
using back.models.EventLogs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;
using back.common.loghelper;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class AdministratorController : ControllerBase
{
    public AdministratorController(ApplicationDbContext db, ILogger<WeatherForecastController> logger)
    {
        this.db = db;
        _logger = logger;
        this.dblog = new EventLogController(db,_logger);
    }

    private EventLogController dblog;

    private ApplicationDbContext db;
    private readonly ILogger<WeatherForecastController> _logger;

    [HttpGet]
    [ProducesResponseType(typeof(AdministratorGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = db.Administrators.AsNoTracking()
            .Include(a => a.Authoroty)
            .Select(a => new AdministratorGetResponse
            {
                Id = (Guid)a.Id,
                Name = a.Name,
                Email = a.Email,
                AuthorotyId = (Guid)a.AuthorotyId!,
                Authoroty = a.Authoroty,

                CreationTime = a.CreationTime,
                CreatorId = a.CreatorId,
                Creator = a.Creator,
                ModificationTime = a.ModificationTime,
                ModifierId = a.ModifierId,
                Modifier = a.Modifier,
            });
           
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
    [ProducesResponseType(typeof(AdministratorGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            var result = db.Administrators.AsNoTracking()
               .Where(p => p.Id == id)
               .Include(a => a.Authoroty)
                .Select(a => new AdministratorGetResponse
                {
                    Id = (Guid)a.Id,
                    Name = a.Name,
                    Email = a.Email,
                    AuthorotyId = (Guid)a.AuthorotyId!,
                    Authoroty = a.Authoroty,

                    CreationTime = a.CreationTime,
                    CreatorId = a.CreatorId,
                    Creator = a.Creator,
                    ModificationTime = a.ModificationTime,
                    ModifierId = a.ModifierId,
                    Modifier = a.Modifier,
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
                    ResponseCode = 404,
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
    [ProducesResponseType(typeof(AdministratorGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] AdministratorAddUpdateRequest request)
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
                });
            }
            var Administrator = new Administrator()
            {
                Name = request.Name,
                Email = request.Email,
                AuthorotyId = request.AuthorotyId,

                CreationTime = DateTime.Now,
                CreatorId = null,
                ModificationTime = DateTime.Now,
                ModifierId = null,
            };
            db.Administrators.Add(Administrator);
            await db.SaveChangesAsync();
            
            var log = new EventLog{
                CommandOriginId = null,
                CommandParentId = null,
                ExecutionTime = Administrator.CreationTime,
                TargetType = TargetType.Administrator,
                TargetId = Administrator.Id,
                SecondTargetType = null,
                SecondTargetId = null,
                CommandType = eventType.Add,
                Command = "Add: "+ common.loghelper.Comparer.partStringBuilder(Administrator),
            };
            db.EventLogs.Add(log);
            db.SaveChangesAsync();
            
            return await GetOne(Administrator.Id);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new BaseRequestResponse()
            {
                IsSuccesfull = false,
               MSG = ex.Message,
            });
        }
    }



    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(Guid id, [FromBody] AdministratorAddUpdateRequest request)
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

            var Administrator = db.Administrators.SingleOrDefault(c => c.Id == id);
            if (Administrator == null)
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false
                });
            }
            var Original = Administrator;

            Administrator.Name = request.Name;
            Administrator.Email = request.Email;
            Administrator.AuthorotyId = request.AuthorotyId;

            Administrator.ModifierId = null;
            Administrator.ModificationTime = DateTime.Now;


            db.EventLogs.Add(new EventLog{
                CommandOriginId = Administrator.ModifierId,
                CommandParentId = Administrator.ModifierId,
                ExecutionTime = Administrator.ModificationTime,
                TargetType = TargetType.Administrator,
                TargetId = Administrator.Id,
                CommandType = eventType.Update,
                Command = common.loghelper.Comparer.getDiff(Original,Administrator),
            });
            db.SaveChanges();
            return Ok();
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

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var AdministratorsToRemove = db.Administrators.Where(ic => id == ic.Id).SingleOrDefault();

            if (AdministratorsToRemove == null)
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = "Can't find.",
                    ResponseCode = 404
                });
            }
            db.Administrators.Remove(AdministratorsToRemove);
            db.EventLogs.Add(new EventLog{
                CommandOriginId = null,
                CommandParentId = null,
                ExecutionTime = DateTime.Now,
                TargetType = TargetType.Administrator,
                TargetId = id,
                CommandType = eventType.Delete,
                Command = "Removed",
            });
            await db.SaveChangesAsync();
            return Ok();
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


}
