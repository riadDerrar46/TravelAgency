using Core.Application.BusnissLogic;
using Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

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
    public ActionResult GetAll()
    {
        return Ok("hi");
    }

    // GET: UserController/Details/5

    [HttpGet("{id}")]
    public async Task<ActionResult> Details(int id)
    {
       var res = await  _users_Handler.Get(id);
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
            
                return BadRequest(user.CreationDate +"   " + ex.Message);
            
        }
    }

   

    // POST: UserController/Edit/5
    [HttpPost]
    
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }



    // POST: UserController/Delete/5
    [HttpDelete]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
