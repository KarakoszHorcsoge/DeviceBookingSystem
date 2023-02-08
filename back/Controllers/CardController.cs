using back.DbContexts.ApplicationDbContext;
using back.models;
using back.models.Cards;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace back.Controllers;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    public CardController(ApplicationDbContext db, ILogger<WeatherForecastController> logger)
    {
        this.db = db;
        _logger = logger;

    }

    private ApplicationDbContext db;
    private readonly ILogger<WeatherForecastController> _logger;

    [HttpGet]
    [ProducesResponseType(typeof(CardGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAll()
    {
        try
        {
            var result = db.Cards.AsNoTracking()
            .Include(r=>r.Owner)
            .Select(r => new CardGetResponse
            {
                Id = (Guid)r.Id,
                IsActive = r.IsActive,
                ExperationDate = r.ExperationDate,
                OwnerId = (Guid)r.OwnerId!,
                Owner = r.Owner,
                Comment = r.Comment,

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
    [ProducesResponseType(typeof(CardGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetOne(Guid id)
    {
        try
        {
            var result = db.Cards.AsNoTracking()
            .Where(p => p.Id == id)
            .Include(r=>r.Owner)
            .Select(r => new CardGetResponse
            {
                Id = (Guid)r.Id,
                IsActive = r.IsActive,
                ExperationDate = r.ExperationDate,
                OwnerId = (Guid)r.OwnerId!,
                Owner = r.Owner,
                Comment = r.Comment,

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
    [ProducesResponseType(typeof(CardGetResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status403Forbidden)]
    [ProducesResponseType(typeof(BaseRequestResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Add([FromBody] CardAddUpdateRequest request)
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
            var Card = new Card()
            {
                IsActive = request.IsActive ?? true,
                ExperationDate = request.ExperationDate,
                OwnerId = (Guid)request.OwnerId!,
                Comment = request.Comment,

                ModifierId = null,
                ModificationTime = request.OriginalSendTime,
                CreatorId = null,
                CreationTime = request.OriginalSendTime,
            };

            db.Cards.Add(Card);
            await db.SaveChangesAsync();

            return await GetOne(Card.Id);
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
    public async Task<IActionResult> Update(Guid id, [FromBody] CardAddUpdateRequest request)
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

            var Card = await db.Cards.SingleOrDefaultAsync(c => c.Id == id);

            if (Card == null)
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false
                });
            }

            Card.IsActive = request.IsActive ?? true;
            Card.ExperationDate = request.ExperationDate;
            Card.OwnerId = (Guid)request.OwnerId!;
            Card.Comment = request.Comment;
            
            Card.ModifierId = null;
            Card.ModificationTime = request.OriginalSendTime;

            await db.SaveChangesAsync();
            
            return await GetOne(Card.Id);
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
            var CardsToRemove = await db.Cards.Where(ic => ids.Contains(ic.Id)).ToListAsync();

            if (!CardsToRemove.Any())
            {
                return StatusCode(404, new BaseRequestResponse()
                {
                    IsSuccesfull = false,
                    MSG = "Can't find.",
                    ResponseCode = 404
                });
            }

            db.Cards.RemoveRange(CardsToRemove);

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
