using back.Data.ApplicationDbContext;
using back.models;
using back.models.Preferences;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class PreferenceController : ControllerBase
{
    public PreferenceController(ApplicationDbContext db, ILogger<WeatherForecastController> logger)
    {
        this.db = db;
        _logger = logger;

    }

    private ApplicationDbContext db;
    private readonly ILogger<WeatherForecastController> _logger;

    [HttpGet]
    [ProducesResponseType(typeof(PreferenceGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = db.Preferences.AsNoTracking()
            .Select(p => new PreferenceGetResponse
            {
                Id = (Guid)p.Id,
                Name = p.Name,
                Value = p.Value,

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
    [ProducesResponseType(typeof(PreferenceGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            var result = db.Preferences.AsNoTracking()
               .Where(p => p.Id == id)
               .Select(p => new PreferenceGetResponse
               {
                   Id = (Guid)p.Id,
                   Name = p.Name,
                   Value = p.Value,
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
    [ProducesResponseType(typeof(PreferenceGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] PreferenceAddUpdateRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = ModelState.Select(x => x.Value!.Errors)
                           .Where(y=>y.Count>0)
                           .ToList().ToString() !,
                    ResponseCode = 400
                }); ;
            }
            var preference = new Preference()
            {

                Name = request.Name,
                Value = request.Value,
            };

            db.Preferences.Add(preference);
            await db.SaveChangesAsync();

            return Ok(new PreferenceAddUpdateResponse()
            {
                ResponseCode = 200,
                MSG = "It's on!!",
                IsSuccesfull = true,
                Preference = new PreferenceGetResponse()
                {
                    Name = preference.Name,
                    Value = preference.Value
                }
            });
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
    public async Task<IActionResult> Update(Guid id, [FromBody] PreferenceAddUpdateRequest request)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = ModelState.Select(x => x.Value!.Errors)
                           .Where(y=>y.Count>0)
                           .ToList().ToString() !,
                    ResponseCode = 400
                }); ;
            }

            var preference = await db.Preferences.SingleOrDefaultAsync(c => c.Id == id);

            if (preference != null)
            {
                preference.Name = request.Name;
                preference.Value = request.Value;

                //preference.UpdateUserId = this.currentUserIdFromToken;
                preference.ModificationTime = DateTime.Now;

                await db.SaveChangesAsync();
            }
            else
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false
                });
            }

            return Ok(new BaseRequestResponse()
            {
                IsSuccesfull = true,
                MSG = "Adatok sikeresen frissítve.",
                ResponseCode = 200
            });
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
    [ProducesResponseType( StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Delete(Guid[] ids)
    {
        try
        {
            var preferencesToRemove = await db.Preferences.Where(ic => ids.Contains(ic.Id)).ToListAsync();
            
            if(!preferencesToRemove.Any()){
               return StatusCode(404, new BaseRequestResponse(){
                    IsSuccesfull = false,
                    MSG="Can't find.",
                    ResponseCode=404
               });               
            }

            db.Preferences.RemoveRange(preferencesToRemove);

            await db.SaveChangesAsync();
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new BaseRequestResponse()
            {
                IsSuccesfull = false,
                MSG = ex.Message,
                ResponseCode=500
            });
        }
    }


}
