using Core.Application.BusnissLogic;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TravelPlanController : Controller
{
    readonly ITravelPlan_Handler _TravelPlans_Handler;

    public TravelPlanController(ITravelPlan_Handler TravelPlans_Handler)
    {
        _TravelPlans_Handler = TravelPlans_Handler;
    }
    // GET: TravelPlanController
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var res = await _TravelPlans_Handler.GetAll();
        return Ok(res);
    }

    // GET: TravelPlanController/Details/5
    [HttpGet("{id}")]
    public async Task<ActionResult> Details(int id)
    {
        var res = await _TravelPlans_Handler.Get(id);
        if (res == null)
            return NotFound("TravelPlan is not in DB");
        return Ok(res);
    }


    // POST: TravelPlanController/Create
    [HttpPost("Add-TravelPlan")]
    public async Task<ActionResult> CreateAsync(TravelPlan TravelPlan)
    {
        if (TravelPlan == null)
        {
            return BadRequest("TravelPlan data is null.");
        }

        try
        {
            await _TravelPlans_Handler.Create(TravelPlan);
            return Ok("TravelPlan created successfully.");
        }
        catch (Exception ex)
        {

            return BadRequest(TravelPlan.CreationDate + "   " + ex.Message);

        }
    }


    // POST: TravelPlanController/Edit/5
    [HttpPut("{id}")]
    public async Task<ActionResult> EditAsync(int id, TravelPlan TravelPlan)
    {
        if (TravelPlan == null)
            return NotFound("Try SomeWhere else");
        TravelPlan.Id = id;
        try
        {
            await _TravelPlans_Handler.Update(TravelPlan);
            return Ok("TravelPlan updated");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    // Delete: TravelPlanController/Delete/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var res = await _TravelPlans_Handler.Get(id);
        if (res == null)
            return NotFound("TravelPlan is not in DB");
        try
        {
            await _TravelPlans_Handler.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    //Search TravelPlan
    [HttpPost("Search-TravelPlan")]
    public async Task<ActionResult> Search(TravelPlan travelPlan)
    {
        if (travelPlan == null)
            return BadRequest("TravelPlan data is null.");
        var res = await _TravelPlans_Handler.Search(travelPlan);
        return Ok(res);
    }

}
