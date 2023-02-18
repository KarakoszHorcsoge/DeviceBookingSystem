using back.DbContexts.ApplicationDbContext;
using back.models;
using back.models.Persons;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class PersonController : ControllerBase
{
    public PersonController(ApplicationDbContext db, ILogger<WeatherForecastController> logger)
    {
        this.db = db;
        _logger = logger;

    }

    private ApplicationDbContext db;
    private readonly ILogger<WeatherForecastController> _logger;

    [HttpGet]
    [ProducesResponseType(typeof(PersonGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = db.Persons.AsNoTracking()
            .Include(r => r.PersonGroup)
            .Include(r => r.PersonType)
            .Select(r => new PersonGetResponse
            {
                Id = (Guid)r.Id,
                Name = r.Name,
                IsAbleToBorrow = r.IsAbleToBorrow,
                NeptunCode = r.NeptunCode,
                RegistrationNumber = r.RegistrationNumber,
                IdNumber = r.IdNumber,
                IdNumberType = r.IdNumberType,
                Email = r.Email,
                AdUsername = r.AdUsername,
                comment = r.comment,
                PersonGroupId = r.PersonGroupId,
                PersonGroup = r.PersonGroup,
                PersonTypeId = (Guid)r.PersonTypeId!,
                PersonType = r.PersonType,

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
    [ProducesResponseType(typeof(PersonGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            var result = db.Persons.AsNoTracking()
            .Where(p => p.Id == id)
            .Include(r => r.PersonGroup)
            .Include(r => r.PersonType)
            .Select(r => new PersonGetResponse
            {
                Id = (Guid)r.Id,
                Name = r.Name,
                IsAbleToBorrow = r.IsAbleToBorrow,
                NeptunCode = r.NeptunCode,
                RegistrationNumber = r.RegistrationNumber,
                IdNumber = r.IdNumber,
                IdNumberType = r.IdNumberType,
                Email = r.Email,
                AdUsername = r.AdUsername,
                comment = r.comment,
                PersonGroupId = r.PersonGroupId,
                PersonGroup = r.PersonGroup,
                PersonTypeId = (Guid)r.PersonTypeId!,
                PersonType = r.PersonType,

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
    [ProducesResponseType(typeof(PersonGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] PersonAddUpdateRequest request)
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
            var Person = new Person()
            {
                Name = request.Name,
                IsAbleToBorrow = request.IsAbleToBorrow,
                NeptunCode = request.NeptunCode,
                RegistrationNumber = request.RegistrationNumber,
                IdNumber = request.IdNumber,
                IdNumberType = request.IdNumberType,
                Email = request.Email,
                AdUsername = request.AdUsername,
                comment = request.comment,
                PersonGroupId = request.PersonGroupId,
                PersonTypeId = request.PersonTypeId,

                ModifierId = null,
                ModificationTime = DateTime.Now,
                CreatorId = null,
                CreationTime = DateTime.Now,
            };

            db.Persons.Add(Person);
            await db.SaveChangesAsync();

            return await GetOne(Person.Id);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] PersonAddUpdateRequest request)
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

            var Person = await db.Persons.SingleOrDefaultAsync(c => c.Id == id);

            if (Person == null)
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false
                });
            }

            Person.Name = request.Name;
            Person.IsAbleToBorrow = request.IsAbleToBorrow;
            Person.NeptunCode = request.NeptunCode;
            Person.RegistrationNumber = request.RegistrationNumber;
            Person.IdNumber = request.IdNumber;
            Person.IdNumberType = request.IdNumberType;
            Person.Email = request.Email;
            Person.AdUsername = request.AdUsername;
            Person.comment = request.comment;
            Person.PersonGroupId = request.PersonGroupId;
            Person.PersonTypeId = request.PersonTypeId;
            
            Person.ModifierId = null;
            Person.ModificationTime = DateTime.Now;

            await db.SaveChangesAsync();
            
            return await GetOne(Person.Id);
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
            var PersonsToRemove = await db.Persons.Where(ic => ids.Contains(ic.Id)).ToListAsync();

            if (!PersonsToRemove.Any())
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = "Can't find.",
                    ResponseCode = 404
                });
            }

            db.Persons.RemoveRange(PersonsToRemove);

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
