using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace WebUI.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly HttpClient _httpClient;
        private const string _APIURL = " https://localhost:44375";

        public OrdersController(ILogger<OrdersController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_APIURL);
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Order");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var orders = JsonSerializer.Deserialize<List<Order>>(data, options);
                return View(orders);
            }
            return View(new List<Order>());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var response = await _httpClient.GetAsync($"/api/Order/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var order = JsonSerializer.Deserialize<Order>(data, options);
                return View(order);
            }
            return NotFound();
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDate,TotalAmount,Status,Status_Reason,TravelPlan_Id,ClientId,Id,IsActive,CreationDate,DeleteDate")] Order order)
        {
            if (!ModelState.IsValid) return View(order);
            var content = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("/api/Order", content);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return BadRequest("Couldn't create order");
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var response = await _httpClient.GetAsync($"/api/Order/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var order = JsonSerializer.Deserialize<Order>(data, options);
                if (order == null) return NotFound();
                return View(order);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDate,TotalAmount,Status,Status_Reason,TravelPlan_Id,ClientId,Id,IsActive,CreationDate,DeleteDate")] Order order)
        {
            if (id != order.Id) return NotFound();
            if (!ModelState.IsValid) return View(order);
            var content = new StringContent(JsonSerializer.Serialize(order), Encoding.UTF8, "application/json");
            var response = await _httpClient.PutAsync($"/api/Order/{order.Id}", content);
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return NotFound();
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var response = await _httpClient.GetAsync($"/api/Order/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                var order = JsonSerializer.Deserialize<Order>(data, options);
                if (order == null) return NotFound();
                return View(order);
            }
            return NotFound();
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _httpClient.DeleteAsync($"/api/Order/{id}");
            if (response.IsSuccessStatusCode) return RedirectToAction(nameof(Index));
            return BadRequest("error occured while working with db");
        }
    }
}
