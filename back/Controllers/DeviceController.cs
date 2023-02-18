using back.DbContexts.ApplicationDbContext;
using back.models;
using back.models.Devices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class DeviceController : ControllerBase
{
    public DeviceController(ApplicationDbContext db, ILogger<WeatherForecastController> logger)
    {
        this.db = db;
        _logger = logger;

    }

    private ApplicationDbContext db;
    private readonly ILogger<WeatherForecastController> _logger;

    [HttpGet]
    [ProducesResponseType(typeof(DeviceGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = db.Devices.AsNoTracking()
            .Include(r => r.DeviceType)
            .Include(r => r.Reception)
            .Select(r => new DeviceGetResponse
            {
                Id = (Guid)r.Id,
                DeviceStatus = r.DeviceStatus,
                Comment = r.Comment,
                DeviceTypeId =r.DeviceTypeId,
                DeviceType = r.DeviceType,
                ReceptionId = (Guid)r.ReceptionId!,
                Reception = r.Reception,
                PosesserId = r.PosesserId,
                Posesser = r.Posesser,

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
    [ProducesResponseType(typeof(DeviceGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            var result = db.Devices.AsNoTracking()
            .Where(p => p.Id == id)
            .Select(r => new DeviceGetResponse
            {
                Id = (Guid)r.Id,
                DeviceStatus = r.DeviceStatus,
                Comment = r.Comment,
                DeviceTypeId =r.DeviceTypeId,
                DeviceType = r.DeviceType,
                ReceptionId = (Guid)r.ReceptionId!,
                Reception = r.Reception,
                PosesserId = r.PosesserId,
                Posesser = r.Posesser,

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
    [ProducesResponseType(typeof(DeviceGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] DeviceAddUpdateRequest request)
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
            var Device = new Device()
            {
                DeviceStatus = request.DeviceStatus,
                Comment = request.Comment,
                DeviceTypeId =request.DeviceTypeId,
                ReceptionId = (Guid)request.ReceptionId,
                PosesserId = request.PosesserId,

                ModifierId = null,
                ModificationTime = DateTime.Now,
                CreatorId = null,
                CreationTime = DateTime.Now,
            };

            db.Devices.Add(Device);
            await db.SaveChangesAsync();

            return await GetOne(Device.Id);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] DeviceAddUpdateRequest request)
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

            var Device = await db.Devices.SingleOrDefaultAsync(c => c.Id == id);

            if (Device == null)
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false
                });
            }

            Device.DeviceStatus = request.DeviceStatus;
            Device.Comment = request.Comment;
            Device.DeviceTypeId =request.DeviceTypeId;
            Device.ReceptionId = (Guid)request.ReceptionId;
            Device.PosesserId = request.PosesserId;
            
            Device.ModifierId = null;
            Device.ModificationTime = DateTime.Now;

            await db.SaveChangesAsync();
            
            return await GetOne(Device.Id);
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
            var DevicesToRemove = await db.Devices.Where(ic => ids.Contains(ic.Id)).ToListAsync();

            if (!DevicesToRemove.Any())
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = "Can't find.",
                    ResponseCode = 404
                });
            }

            db.Devices.RemoveRange(DevicesToRemove);

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
