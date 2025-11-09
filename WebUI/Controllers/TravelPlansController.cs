using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace WebUI.Controllers
{
    public class TravelPlansController : Controller
    {
        private readonly ILogger<TravelPlansController> _logger;
        private readonly HttpClient _httpClient;
        private const string _APIURL = " https://localhost:44375";

        public TravelPlansController(ILogger<TravelPlansController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_APIURL);
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/TravelPlan");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var plans = JsonSerializer.Deserialize<List<TravelPlan>>(data, options);
                return View(plans);
            }
            return View(new List<TravelPlan>());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var response = await _httpClient.GetAsync($"/api/TravelPlan/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var plan = JsonSerializer.Deserialize<TravelPlan>(data, options);
                return View(plan);
            }
            return NotFound();
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,NumberOfPeople,Destination,Description,StartDate,EndDate,Budget,Id,IsActive,CreationDate,DeleteDate")] TravelPlan plan)
        {
            if (!ModelState.IsValid) return View(plan);
            var content = new StringContent(JsonSerializer.Serialize(plan), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/TravelPlan", content);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return BadRequest("Couldn't create travel plan");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var response = await _httpClient.GetAsync($"/api/TravelPlan/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var plan = JsonSerializer.Deserialize<TravelPlan>(data, options);
                if (plan == null) return NotFound();
                return View(plan);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,NumberOfPeople,Destination,Description,StartDate,EndDate,Budget,Id,IsActive,CreationDate,DeleteDate")] TravelPlan plan)
        {
            if (id != plan.Id) return NotFound();
            if (!ModelState.IsValid) return View(plan);
            var content = new StringContent(JsonSerializer.Serialize(plan), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/TravelPlan/{plan.Id}", content);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return NotFound();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var response = await _httpClient.GetAsync($"/api/TravelPlan/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var plan = JsonSerializer.Deserialize<TravelPlan>(data, options);
                if (plan == null) return NotFound();
                return View(plan);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/TravelPlan/{id}");
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return BadRequest("error occured while working with db");
        }
    }
}