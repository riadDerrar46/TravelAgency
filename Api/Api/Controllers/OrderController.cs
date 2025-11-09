using Core.Application.BusnissLogic;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : Controller
{
    readonly IOrder_Handler _Orders_Handler;

    public OrderController(IOrder_Handler Orders_Handler)
    {
        _Orders_Handler = Orders_Handler;
    }
    // GET: OrderController
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var res = await _Orders_Handler.GetAll();
        return Ok(res);
    }

    // GET: OrderController/Details/5
    [HttpGet("{id}")]
    public async Task<ActionResult> Details(int id)
    {
        var res = await _Orders_Handler.Get(id);
        if (res == null)
            return NotFound("Order is not in DB");
        return Ok(res);
    }


    // POST: OrderController/Create
    [HttpPost("Add-Order")]
    public async Task<ActionResult> CreateAsync(Order Order)
    {
        if (Order == null)
        {
            return BadRequest("Order data is null.");
        }

        try
        {
            await _Orders_Handler.Create(Order);
            return Ok("Order created successfully.");
        }
        catch (Exception ex)
        {

            return BadRequest(Order.CreationDate + "   " + ex.Message);

        }
    }


    // POST: OrderController/Edit/5
    [HttpPut("{id}")]
    public async Task<ActionResult> EditAsync(int id, Order Order)
    {
        if (Order == null)
            return NotFound("Try SomeWhere else");
        Order.Id = id;
        try
        {
            await _Orders_Handler.Update(Order);
            return Ok("Order updated");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    // Delete: OrderController/Delete/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var res = await _Orders_Handler.Get(id);
        if (res == null)
            return NotFound("Order is not in DB");
        try
        {
            await _Orders_Handler.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    //Search Order
    [HttpPost(Name = "Search-Order")]
    public async Task<ActionResult> Search(int clientId)
    {
        if (clientId == null)
            return BadRequest("Order data is null.");
        var res = await _Orders_Handler.GetOrdersByClientId(clientId);
        return Ok(res);
    }

}
