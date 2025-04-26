using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VeteransMuseum.Application.News.GetNews;
using VeteransMuseum.Application.News.GetNewsById;
using VeteransMuseum.Domain.Abstractions;

namespace VeteransMuseum.WebApi.Controllers.News;

[ApiController]
[Route("api/news")]
public class NewsController : ControllerBase
{
    private readonly ISender _sender;
 
    public NewsController(ISender sender)
    {
        _sender = sender;
    }
    
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetNewsById(Guid id, CancellationToken cancellationToken)
    {
        var query = new GetNewsByIdQuery(id);
 
        Result<NewsResponse> result = await _sender.Send(query, cancellationToken);
 
        return result.IsSuccess ? Ok(result.Value) : NotFound();
    }
    
    [AllowAnonymous]
    [HttpGet]
    public async Task<IActionResult> GetNews(CancellationToken cancellationToken)
    {
        var query = new GetNewsQuery();
 
        Result<IReadOnlyList<NewsResponse>> result = await _sender.Send(query, cancellationToken);
 
        return Ok(result.Value);
    }
    
    // [HttpPost]
    // [Authorize(Roles = Roles.Admin)]
    // public async Task<IActionResult> CreateNews(
    //     AddVeteranRequest request,
    //     CancellationToken cancellationToken)
    // {
    //     var command = new AddVeteranCommand(
    //         request.FirstName,
    //         request.LastName,
    //         request.MiddleName,
    //         request.BirthDate,
    //         request.DeathDate,
    //         request.Biography,
    //         request.Rank,
    //         request.Awards,
    //         request.MilitaryUnit,
    //         request.Battles,
    //         request.ImageUrl
    //         );
    //
    //     var result = await _sender.Send(command, cancellationToken);
    //
    //     if (result.IsFailure)
    //     {
    //         return BadRequest(result.Error);
    //     }
    //          
    //     return Ok(result.Value);
    // }
}