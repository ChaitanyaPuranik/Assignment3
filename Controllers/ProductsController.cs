using Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Assignment3.Controllers
{
    public class ProductsController : Controller
    {

        private string url = "https://localhost:7085/api/ProductsAPI";
        private readonly HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Product> products = new List<Product>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if(response.IsSuccessStatusCode)
            {
                products = response.Content.ReadFromJsonAsync<List<Product>>().Result;
            }
            return View(products);
        }
    }
}
