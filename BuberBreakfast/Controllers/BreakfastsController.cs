using BuberBreakfast.Contracts.Breakfast;
using BuberBreakfast.Models;
using BuberBreakfast.ServiceErrors;
using BuberBreakfast.Services.Breakfasts;
using ErrorOr;
using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

public class BreakfastsController : ApiController
{
    private readonly IBreakfastService _breakfastService;

    public BreakfastsController(IBreakfastService breakfastService)
    {
        _breakfastService = breakfastService;
    }

    [HttpPost]
    public IActionResult CreateBreakfast(CreateBreakfastRequest request)
    {
        Console.WriteLine("IActionResult CreateBreakfast(CreateBreakfastRequest request) in BreakfastsController");
        ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.From(request);

        if (requestToBreakfastResult.IsError)
        {
            return Problem(requestToBreakfastResult.Errors);
        }

        var breakfast = requestToBreakfastResult.Value;
        ErrorOr<Created> createBreakfastResult = _breakfastService.CreateBreakfast(breakfast);

        return createBreakfastResult.Match(
            created => CreatedAtGetBreakfast(breakfast),
            errors => Problem(errors));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBreakfast(Guid id)
    {
        Console.WriteLine("IActionResult GetBreakfast(Guid id) in BreakfastsController");
        ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);

        return getBreakfastResult.Match(
            breakfast => Ok(MapBreakfastResponse(breakfast)),
            errors => Problem(errors));
    }

    [HttpGet("all")]
    public IActionResult GetAllBreakfasts()
    {
        Console.WriteLine("IActionResult GetAllBreakfasts() in BreakfastsController");
        ErrorOr<List<Breakfast>> getAllBreakfastsResult = _breakfastService.GetAllBreakfasts();

        return getAllBreakfastsResult.Match(
            breakfast => Ok(getAllBreakfastsResult.Value.Select(MapBreakfastResponse)),
            errors => Problem(errors));
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpsertBreakfast(Guid id, UpsertBreakfastRequest request)
    {
        ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.From(id, request);

        if (requestToBreakfastResult.IsError)
        {
            return Problem(requestToBreakfastResult.Errors);
        }

        var breakfast = requestToBreakfastResult.Value;
        ErrorOr<UpsertedBreakfast> upsertBreakfastResult = _breakfastService.UpsertBreakfast(breakfast);

        return upsertBreakfastResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetBreakfast(breakfast) : NoContent(),
            errors => Problem(errors));
    }

    [HttpGet("search")]
    public IActionResult SearchBreakfasts([FromQuery]string query)
    {
        ErrorOr<List<Breakfast>> searchBreakfastsResult = _breakfastService.SearchBreakfasts(query);

        return searchBreakfastsResult.Match(
            breakfasts => Ok(breakfasts.Select(MapBreakfastResponse)),
            errors => Problem(errors));
    }

    [HttpPatch("{id:guid}")]
    public IActionResult RenameBreakfast(Guid id, RenameBreakfastRequest request)
    {
        ErrorOr<Breakfast> getBreakfastResult = _breakfastService.GetBreakfast(id);
        if (getBreakfastResult.IsError)
        {
            return Problem(getBreakfastResult.Errors);
        }

        var breakfast = getBreakfastResult.Value;
        ErrorOr<Breakfast> requestToBreakfastResult = Breakfast.From(id, breakfast, request);

        if (requestToBreakfastResult.IsError)
        {
            return Problem(requestToBreakfastResult.Errors);
        }

        var renamedBreakfast = requestToBreakfastResult.Value;
        ErrorOr<Breakfast> renameBreakfastResult = _breakfastService.RenameBreakfast(id, renamedBreakfast);

        return renameBreakfastResult.Match(
            breakfast => NoContent(),
            errors => Problem(errors));

    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBreakfast(Guid id)
    {
        ErrorOr<Deleted> deleteBreakfastResult = _breakfastService.DeleteBreakfast(id);

        return deleteBreakfastResult.Match(
            deleted => NoContent(),
            errors => Problem(errors));
    }

    private static BreakfastResponse MapBreakfastResponse(Breakfast breakfast)
    {
        return new BreakfastResponse(
            breakfast.Id,
            breakfast.Name,
            breakfast.Description,
            breakfast.StartDateTime,
            breakfast.EndDateTime,
            breakfast.LastModifiedDateTime,
            breakfast.Savory,
            breakfast.Sweet);
    }

    private CreatedAtActionResult CreatedAtGetBreakfast(Breakfast breakfast)
    {
        return CreatedAtAction(
            actionName: nameof(GetBreakfast),
            routeValues: new { id = breakfast.Id },
            value: MapBreakfastResponse(breakfast));
    }
}
