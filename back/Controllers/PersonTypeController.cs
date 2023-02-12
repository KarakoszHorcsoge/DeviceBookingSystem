using back.DbContexts.ApplicationDbContext;
using back.models;
using back.models.PersonTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonTypeController : ControllerBase
{
    public PersonTypeController(ApplicationDbContext db, ILogger<WeatherForecastController> logger)
    {
        this.db = db;
        _logger = logger;

    }

    private ApplicationDbContext db;
    private readonly ILogger<WeatherForecastController> _logger;

    [HttpGet]
    [ProducesResponseType(typeof(PersonTypeGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = db.PersonTypes.AsNoTracking()
            .Select(r => new PersonTypeGetResponse
            {
                Id = (Guid)r.Id,
                Name = r.Name,
                IsBorrowable = r.IsBorrowable,
                CardPrefix = r.CardPrefix,
                Comment = r.Comment,

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
    [ProducesResponseType(typeof(PersonTypeGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            var result = db.PersonTypes.AsNoTracking()
            .Where(p => p.Id == id)
            .Select(r => new PersonTypeGetResponse
            {
                Id = (Guid)r.Id,
                Name = r.Name,
                IsBorrowable = r.IsBorrowable,
                CardPrefix = r.CardPrefix,
                Comment = r.Comment,

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
    [ProducesResponseType(typeof(PersonTypeGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] PersonTypeAddUpdateRequest request)
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
            var PersonType = new PersonType()
            {
                Name = request.Name,
                IsBorrowable = request.IsBorrowable,
                CardPrefix = request.CardPrefix,
                Comment = request.Comment,

                ModifierId = null,
                ModificationTime = request.OriginalSendTime,
                CreatorId = null,
                CreationTime = request.OriginalSendTime,
            };

            db.PersonTypes.Add(PersonType);
            await db.SaveChangesAsync();

            return await GetOne(PersonType.Id);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] PersonTypeAddUpdateRequest request)
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

            var PersonType = await db.PersonTypes.SingleOrDefaultAsync(c => c.Id == id);

            if (PersonType == null)
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false
                });
            }

            PersonType.Name = request.Name;
            PersonType.IsBorrowable = request.IsBorrowable;
            PersonType.CardPrefix = request.CardPrefix;
            PersonType.Comment = request.Comment;
            
            PersonType.ModifierId = null;
            PersonType.ModificationTime = request.OriginalSendTime;

            await db.SaveChangesAsync();
            
            return await GetOne(PersonType.Id);
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
            var PersonTypesToRemove = await db.PersonTypes.Where(ic => ids.Contains(ic.Id)).ToListAsync();

            if (!PersonTypesToRemove.Any())
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = "Can't find.",
                    ResponseCode = 404
                });
            }

            db.PersonTypes.RemoveRange(PersonTypesToRemove);

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
