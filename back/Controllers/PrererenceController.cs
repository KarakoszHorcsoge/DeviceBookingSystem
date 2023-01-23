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
    ApplicationDbContext db;
    private readonly ILogger<WeatherForecastController> _logger;

    public PreferenceController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        try
        {
            var result = db.Preferences.AsNoTracking()
            .Select(p => new PreferenceGetResponse
            {
                Id = p.Id,
                Name = p.Name,
                Value = p.Value,

            });
            return Ok(result.ToListAsync());
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, new BaseRequestResponse()
            {
                IsSuccesfull = false,
                MSG = "",
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
            

            var preference = new Preference()
            {
                
                Name = request.Name,
                Value = request.Value,
            };

            await db.Preferences.AddAsync(preference);
            await db.SaveChangesAsync();

            return Ok(new PreferenceAddUpdateResponse()
            {
                ResponseCode = 200,
                MSG = "It's on!!",
                IsSuccesfull = true,
                Preference = new PreferenceGetResponse(){
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
                //Message = this.localization.Translate("serverResponse.common.processError", HttpContext.Request.Headers["Accept-Language"]),
            });
        }
    }
}
