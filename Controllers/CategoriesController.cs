using Microsoft.AspNetCore.Mvc;
using ProductRegistration_Group.Models;
using System.Net.Http.Json;

namespace ProductRegistration_Group.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly HttpClient client = new HttpClient();
        private string url = "https://localhost:7085/api/CategoriesAPI";

        public IActionResult Index()
        {
            var categories = client.GetFromJsonAsync<List<Category>>(url).Result;
            return View(categories);
        }

        public IActionResult Create() => View();

        [HttpPost]
        public IActionResult Create(Category category)
        {
            var response = client.PostAsJsonAsync(url, category).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var category = client.GetFromJsonAsync<Category>($"{url}/{id}").Result;
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            var response = client.PutAsJsonAsync($"{url}/{category.Id}", category).Result;
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var response = client.DeleteAsync($"{url}/{id}").Result;
            return RedirectToAction("Index");
        }

        public IActionResult Details(int id)
        {
            var category = client.GetFromJsonAsync<Category>($"{url}/{id}").Result;
            return View(category);
        }
    }
}
