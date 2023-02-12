using back.DbContexts.ApplicationDbContext;
using back.models;
using back.models.Receptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class ReceptionController : ControllerBase
{
    public ReceptionController(ApplicationDbContext db, ILogger<WeatherForecastController> logger)
    {
        this.db = db;
        _logger = logger;

    }

    private ApplicationDbContext db;
    private readonly ILogger<WeatherForecastController> _logger;

    [HttpGet]
    [ProducesResponseType(typeof(ReceptionGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = db.Receptions.AsNoTracking()
            .Select(r => new ReceptionGetResponse
            {
                Id = (Guid)r.Id,
                Name = r.Name,
                Address = r.Address,
                Comment = r.Comment,
                AdminId = (Guid)r.AdminId!,

                CreationTime = r.CreationTime,
                CreatorId = r.CreatorId,
                Creator = r.Creator,
                ModificationTime = r.ModificationTime,
                ModifierId = r.ModifierId,
                Modifier = r.Modifier,
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
    [ProducesResponseType(typeof(ReceptionGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            var result = db.Receptions.AsNoTracking()
            .Where(p => p.Id == id)
            .Select(r => new ReceptionGetResponse
            {
                Id = (Guid)r.Id,
                Name = r.Name,
                Address = r.Address,
                Comment = r.Comment,
                AdminId = (Guid)r.AdminId!,

                CreationTime = r.CreationTime,
                CreatorId = r.CreatorId,
                Creator = r.Creator,
                ModificationTime = r.ModificationTime,
                ModifierId = r.ModifierId,
                Modifier = r.Modifier,
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
    [ProducesResponseType(typeof(ReceptionGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] ReceptionAddUpdateRequest request)
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
            var Reception = new Reception()
            {
                Name = request.Name,
                Address = request.Address,
                Comment = request.Comment,
                AdminId = request.AdminId!,

                ModifierId = null,
                ModificationTime = request.OriginalSendTime,
                CreatorId = null,
                CreationTime = request.OriginalSendTime,
            };

            db.Receptions.Add(Reception);
            await db.SaveChangesAsync();

            return await GetOne(Reception.Id);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] ReceptionAddUpdateRequest request)
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

            var Reception = await db.Receptions.SingleOrDefaultAsync(c => c.Id == id);

            if (Reception == null)
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false
                });
            }

            Reception.Name = request.Name;
            Reception.Address = request.Address;
            Reception.Comment = request.Comment;
            Reception.AdminId = request.AdminId;
            
            Reception.ModifierId = null;
            Reception.ModificationTime = request.OriginalSendTime;

            await db.SaveChangesAsync();
            
            return await GetOne(Reception.Id);
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
            var ReceptionsToRemove = await db.Receptions.Where(ic => ids.Contains(ic.Id)).ToListAsync();

            if (!ReceptionsToRemove.Any())
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = "Can't find.",
                    ResponseCode = 404
                });
            }

            db.Receptions.RemoveRange(ReceptionsToRemove);

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
