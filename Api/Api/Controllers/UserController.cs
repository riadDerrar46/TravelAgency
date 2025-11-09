using Core.Application.BusnissLogic;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : Controller
{
    readonly IUsers_Handler _users_Handler;

    public UserController(IUsers_Handler users_Handler)
    {
        _users_Handler = users_Handler;
    }
    // GET: UserController
    [HttpGet]
    public async Task<ActionResult> GetAll()
    {
        var res = await _users_Handler.GetAll();
        return Ok(res);
    }

    // GET: UserController/Details/5
    [HttpGet("{id}")]
    public async Task<ActionResult> Details(int id)
    {
        var res = await _users_Handler.Get(id);
        if (res == null)
            return NotFound("user is not in DB");
        return Ok(res);
    }


    // POST: UserController/Create
    [HttpPost]
    public async Task<ActionResult> CreateAsync(User user)
    {
        if (user == null)
        {
            return BadRequest("User data is null.");
        }

        try
        {
            await _users_Handler.Create(user);
            return Ok("User created successfully.");
        }
        catch (Exception ex)
        {

            return BadRequest(user.CreationDate + "   " + ex.Message);

        }
    }


    // POST: UserController/Edit/5
    [HttpPut("{id}")]
    public async Task<ActionResult> EditAsync(int id, User user)
    {
        if (user == null)
            return NotFound("Try SomeWhere else");
        user.Id = id;
        try
        {
            await _users_Handler.Update(user);
            return Ok("User updated");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }



    // Delete: UserController/Delete/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        var res = await _users_Handler.Get(id);
        if (res == null)
            return NotFound("User is not in DB");
        try
        {
            await _users_Handler.Delete(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex);
        }
    }

    //Search User
    [HttpPost(Name = "Search-User")]
    public async Task<ActionResult> Search(User user)
    {
        if (user == null)
            return BadRequest("User data is null.");
        var res = await _users_Handler.Search(user.FirstName, user.LastName, user.Email,
            user.Password, user.PhoneNumber, user.IdCard_Number, user.Passport_Number);
        return Ok(res);
    }

}
