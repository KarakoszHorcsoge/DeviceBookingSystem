using back.DbContexts.ApplicationDbContext;
using back.models;
using back.models.BorrowRestrictions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class BorrowRestrictionController : ControllerBase
{
    public BorrowRestrictionController(ApplicationDbContext db, ILogger<WeatherForecastController> logger)
    {
        this.db = db;
        _logger = logger;

    }

    private ApplicationDbContext db;
    private readonly ILogger<WeatherForecastController> _logger;

    [HttpGet]
    [ProducesResponseType(typeof(BorrowRestrictionGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = db.BorrowRestrictions.AsNoTracking()
            .AsSplitQuery()
            .Include(r => r.Creator)
            .Include(r => r.Modifier)
            .Include(r => r.Reception)
            .Include(r => r.Device)
            .Include(r => r.DeviceType)
            .Select(r => new BorrowRestrictionGetResponse
            {
                Id = (Guid)r.Id,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                ReceptionId = (Guid)r.ReceptionId!,
                Reception = r.Reception,
                DeviceId = r.DeviceId,
                Device = r.Device,
                DeviceTypeId = r.DeviceTypeId,
                DeviceType = r.DeviceType,

                CreationTime = r.CreationTime,
                CreatorId = r.CreatorId,
                Creator = r.Creator,
                ModificationTime = r.ModificationTime,
                Modifier = r.Modifier
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
    [ProducesResponseType(typeof(BorrowRestrictionGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            var result = db.BorrowRestrictions.AsNoTracking()
            .Where(p => p.Id == id)
            .AsSplitQuery()
            .Include(r => r.Creator)
            .Include(r => r.Modifier)
            .Include(r => r.Reception)
            .Include(r => r.Device)
            .Include(r => r.DeviceType)
            .Select(r => new BorrowRestrictionGetResponse
            {
                Id = (Guid)r.Id,
                StartTime = r.StartTime,
                EndTime = r.EndTime,
                ReceptionId = (Guid)r.ReceptionId!,
                Reception = r.Reception,
                DeviceId = r.DeviceId,
                Device = r.Device,
                DeviceTypeId = r.DeviceTypeId,
                DeviceType = r.DeviceType,

                CreationTime = r.CreationTime,
                CreatorId = r.CreatorId,
                Creator = r.Creator,
                ModificationTime = r.ModificationTime,
                Modifier = r.Modifier
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
    [ProducesResponseType(typeof(BorrowRestrictionGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] BorrowRestrictionAddUpdateRequest request)
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
            var BorrowRestriction = new BorrowRestriction()
            {
                StartTime = request.StartTime,
                EndTime = request.EndTime,
                ReceptionId = (Guid)request.ReceptionId!,
                DeviceId = request.DeviceId,
                DeviceTypeId = request.DeviceTypeId,

                ModifierId = null,
                ModificationTime = request.OriginalSendTime,
                CreatorId = null,
                CreationTime = request.OriginalSendTime,
            };

            db.BorrowRestrictions.Add(BorrowRestriction);
            await db.SaveChangesAsync();

            return await GetOne(BorrowRestriction.Id);
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



    [HttpPut("{id}")]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(Guid id, [FromBody] BorrowRestrictionAddUpdateRequest request)
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

            var BorrowRestriction = await db.BorrowRestrictions.SingleOrDefaultAsync(c => c.Id == id);

            if (BorrowRestriction == null)
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false
                });
            }

            BorrowRestriction.StartTime = request.StartTime;
            BorrowRestriction.EndTime = request.EndTime;
            BorrowRestriction.ReceptionId = (Guid)request.ReceptionId!;
            BorrowRestriction.DeviceId = request.DeviceId;
            BorrowRestriction.DeviceTypeId = request.DeviceTypeId;
            
            BorrowRestriction.ModifierId = null;
            BorrowRestriction.ModificationTime = request.OriginalSendTime;

            await db.SaveChangesAsync();
            
            return await GetOne(BorrowRestriction.Id);
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

    [HttpDelete("{ids}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid[] ids)
    {
        try
        {
            var BorrowRestrictionsToRemove = await db.BorrowRestrictions.Where(ic => ids.Contains(ic.Id)).ToListAsync();

            if (!BorrowRestrictionsToRemove.Any())
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = "Can't find.",
                    ResponseCode = 404
                });
            }

            db.BorrowRestrictions.RemoveRange(BorrowRestrictionsToRemove);

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
