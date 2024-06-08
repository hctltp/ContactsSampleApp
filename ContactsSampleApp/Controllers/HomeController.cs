using ContactsSampleApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;


namespace ContactsSampleApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // This method returns a list of contacts
        [HttpGet]
        public JsonResult GetContacts(int pageNumber = 1, int pageSize = 20)
        {
            var allContacts = GetAllContacts();
            var contacts = allContacts.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            var hasMore = contacts.Count == pageSize && (pageNumber * pageSize) < allContacts.Count;

            return new JsonResult(new { contacts, hasMore });
        }

        // Simulated data source
        private List<Contact> GetAllContacts()
        {
            // Generate some sample data
            var contacts = new List<Contact>();
            for (int i = 1; i <= 37; i++)
            {
                contacts.Add(new Contact
                {
                    Id = i,
                    Name = $"Contact {i}",
                    Email = $"contact{i}@example.com",
                    Phone = $"555-010{i:D2}",
                    ImageUrl = $"/images/contact-images/contact ({i}).jpg"
                });
            }
            return contacts;
        }
    }
}
