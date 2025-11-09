using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace WebUI.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<UsersController> _logger;
        private readonly HttpClient _httpClient;
        private const string _APIURL = " https://localhost:44375";

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_APIURL);
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/User");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var users = JsonSerializer.Deserialize<List<User>>(data, options);
                return View(users);
            }
            return View(new List<User>());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/User/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var user = JsonSerializer.Deserialize<User>(data, options);
                return View(user);
            }
            return NotFound();
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,Password,PhoneNumber,Second_PhoneNumber,Third_PhoneNumber,IdCard_Number,Passport_Number,Id,IsActive,CreationDate,DeleteDate")] User user)
        {
            if (!ModelState.IsValid) return View(user);
            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/User", content);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return BadRequest("Couldn't create user");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var response = await _httpClient.GetAsync($"/api/User/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var user = JsonSerializer.Deserialize<User>(data, options);
                if (user == null) return NotFound();
                return View(user);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Email,Password,PhoneNumber,Second_PhoneNumber,Third_PhoneNumber,IdCard_Number,Passport_Number,Id,IsActive,CreationDate,DeleteDate")] User user)
        {
            if (id != user.Id) return NotFound();
            if (!ModelState.IsValid) return View(user);
            var content = new StringContent(JsonSerializer.Serialize(user), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/User/{user.Id}", content);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return NotFound();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var response = await _httpClient.GetAsync($"/api/User/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var user = JsonSerializer.Deserialize<User>(data, options);
                if (user == null) return NotFound();
                return View(user);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/User/{id}");
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return BadRequest("error occured while working with db");
        }
    }
}
