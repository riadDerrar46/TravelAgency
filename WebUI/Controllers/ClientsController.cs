using Core.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace WebUI.Controllers
{
    public class ClientsController : Controller
    {

        private readonly ILogger<ClientsController> _logger;
        private readonly HttpClient _httpClient;
        private const string _APIURL = " https://localhost:44375";


        public ClientsController(ILogger<ClientsController> logger)
        {
            _logger = logger;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(_APIURL);
        }
        // GET: Clients
        public async Task<IActionResult> Index()
        {
            HttpResponseMessage response = await _httpClient.GetAsync("/api/Client");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var clients = JsonSerializer.Deserialize<List<Client>>(data, options);
                return View(clients);
            }
            return View("");
        }


        // GET: Clients/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Client/{id}");
            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var data = await response.Content.ReadAsStringAsync();
                var client = JsonSerializer.Deserialize<Client>(data, options);
                return View(client);
            }
            return NotFound();
        }

        // GET: Clients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FirstName,LastName,Email,PhoneNumber,Second_PhoneNumber,Third_PhoneNumber," +
            "Job,IdCard_Number,IdCard_ImgUrl,Passport_Number,Passport_ImgUrl,Id,IsActive,CreationDate,DeleteDate")] Client client)
        {
            if (ModelState.IsValid)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(client), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync("/api/Client/Add-Client", content);
                if (response.IsSuccessStatusCode)
                {
                    //go back to main page Index
                    return RedirectToAction(nameof(Index));
                }

            }
            return BadRequest("Couldn't create a client ");
        }

        // GET: Clients/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Client/{id}");
            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var data = await response.Content.ReadAsStringAsync();
                var client = JsonSerializer.Deserialize<Client>(data, options);

                if (client == null)
                {
                    return NotFound();
                }
                return View(client);
            }
            return NotFound();



        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FirstName,LastName,Email,PhoneNumber,Second_PhoneNumber,Third_PhoneNumber,Job,IdCard_Number,IdCard_ImgUrl,Passport_Number,Passport_ImgUrl,Id,IsActive,CreationDate,DeleteDate")] Client client)
        {
            if (id != client.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                HttpContent content = new StringContent(JsonSerializer.Serialize(client), Encoding.UTF8, "application/json");
                try
                {

                    HttpResponseMessage response = await _httpClient.PutAsync($"/api/Client/{client.Id}", content);
                    if (response.IsSuccessStatusCode)
                    {
                        var options = new JsonSerializerOptions
                        {
                            PropertyNameCaseInsensitive = true
                        };
                        var data = await response.Content.ReadAsStringAsync();
                        var res = JsonSerializer.Deserialize<Client>(data, options);
                        return View(client);
                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return NotFound("Client is not Found in DB");
            }
            return NotFound();
        }

        // GET: Clients/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            HttpResponseMessage response = await _httpClient.GetAsync($"/api/Client/{id}");
            if (response.IsSuccessStatusCode)
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var data = await response.Content.ReadAsStringAsync();
                var client = JsonSerializer.Deserialize<Client>(data, options);

                if (client == null)
                {
                    return NotFound();
                }
                return View(client);
            }
            return NotFound();
        }

        // POST: Clients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            HttpResponseMessage response = await _httpClient.DeleteAsync($"/api/Client/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            return BadRequest("error occured while working with db");
        }


    }
}
