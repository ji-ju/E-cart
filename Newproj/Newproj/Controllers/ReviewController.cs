using Microsoft.AspNetCore.Mvc;
using Newproj.Helper;
using Newproj.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Newproj.Controllers
{
    public class ReviewController : Controller
    {
        ProjectApi _api = new ProjectApi();

        public async Task<IActionResult> Index()
        {
            List<ReviewModel> review = new List<ReviewModel>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/Reviews");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                review = JsonConvert.DeserializeObject<List<ReviewModel>>(results);
            }
            return View(review);
        }
        public async Task<IActionResult> Details(int Id)
        {
            var review = new ReviewModel();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync($"api/Reviews/{Id}");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                review = JsonConvert.DeserializeObject<ReviewModel>(results);
            }
            return View(review);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ReviewModel review)
        {
            HttpClient client = _api.Initial();

            var postTask = client.PostAsJsonAsync<ReviewModel>("api/Reviews", review);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var assistant = new ReviewModel();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/Reviews/{Id}");
            return RedirectToAction("Index");
        }


    }
}
