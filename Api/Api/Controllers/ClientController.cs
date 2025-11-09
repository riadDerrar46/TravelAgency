using Core.Application.BusnissLogic;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;


[Route("api/[controller]")]
[ApiController]
public class ClientController : Controller
{
    readonly IClient_Handler _Clients_Handler;

    public ClientController(IClient_Handler Clients_Handler)
    {
        _Clients_Handler = Clients_Handler;
    }
    // GET: ClientController
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var res = await _Clients_Handler.GetAll();
        return Ok(res);
    }

    // GET: ClientController/Details/5
    [HttpGet("{id}")]
    public async Task<ActionResult> Details(int id)
    {
        var res = await _Clients_Handler.Get(id);
        if (res == null)
            return NotFound("Client is not in DB");
        return Ok(res);
    }


    // POST: ClientController/Create
    [HttpPost("Add-Client")]
    public async Task<ActionResult> CreateAsync(Client Client)
    {
        if (Client == null)
        {
            return BadRequest("Client data is null.");
        }

        try
        {
            await _Clients_Handler.Create(Client);
            return Ok("Client created successfully.");
        }
        catch (Exception ex)
        {

            return BadRequest(Client.CreationDate + "   " + ex.Message);

        }
    }


    // POST: ClientController/Edit/5
    [HttpPut("{id}")]
    public async Task<ActionResult> EditAsync(int id, Client Client)
    {
        if (Client == null)
            return NotFound("Try SomeWhere else");
        Client.Id = id;
        try
        {
            await _Clients_Handler.Update(Client);
            return Ok("Client updated");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    // Delete: ClientController/Delete/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var res = await _Clients_Handler.Get(id);
        if (res == null)
            return NotFound("Client is not in DB");
        try
        {
            await _Clients_Handler.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    //Search Client
    [HttpPost(Name = "Search-Client")]
    public async Task<ActionResult> Search(Client Client)
    {
        if (Client == null)
            return BadRequest("Client data is null.");
        var res = await _Clients_Handler.Search(Client.FirstName, Client.LastName, Client.Email,
           Client.Job, Client.PhoneNumber, Client.IdCard_Number, Client.Passport_Number);
        return Ok(res);
    }

}
