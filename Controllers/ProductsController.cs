using Microsoft.AspNetCore.Mvc;
using ProductRegistration_Group.Models;
using static System.Net.WebRequestMethods;

namespace ProductRegistration_Group.Controllers
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
            if (response.IsSuccessStatusCode)
            {
                products = response.Content.ReadFromJsonAsync<List<Product>>().Result;
            }
            return View(products);
        }

        //details 
        public IActionResult Details(int id)
        {
            Product product = null;
            HttpResponseMessage response = client.GetAsync($"{url}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                product = response.Content.ReadFromJsonAsync<Product>().Result;
            }

            return View(product);
        }


        //Create [get]
        public IActionResult Create()
        {
            // Get all categories from API
            HttpResponseMessage response = client.GetAsync("https://localhost:7085/api/CategoriesAPI").Result;

            if (response.IsSuccessStatusCode)
            {
                var categories = response.Content.ReadFromJsonAsync<List<Category>>().Result;
                ViewBag.Categories = categories;
            }

            return View();
        }


        //Create [post]
        [HttpPost]
        public IActionResult Create(Product product)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(url, product).Result;
            if (response.IsSuccessStatusCode)
            {

                return RedirectToAction("Index");
            }

            return View(product);
        }


        //Edit [get]

        public IActionResult Edit(int id)
        {
            Product product = null;
            HttpResponseMessage response = client.GetAsync($"{url}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                product = response.Content.ReadFromJsonAsync<Product>().Result;
            }


            return View(product);
        }

        //Edit [Post]

        [HttpPost]
        public IActionResult Edit(int id, Product product)
        {
            HttpResponseMessage response = client.PutAsJsonAsync($"{url}/{id}", product).Result;

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }

        //Delete [get] 
        public IActionResult Delete(int id)
        {
            Product product = null;
            HttpResponseMessage response = client.GetAsync($"{url}/{id}").Result;
            if (response.IsSuccessStatusCode)
            {
                product = response.Content.ReadFromJsonAsync<Product>().Result;
            }
            return View(product);
        }


        //Delete [post]
        [HttpPost]
        public IActionResult Delete(int id, Product product)
        {
            HttpResponseMessage response = client.DeleteAsync($"{url}/{id}").Result;

            return RedirectToAction("Index");
        }

    }
}
