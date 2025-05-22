using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDTOs;
using OnlineEdu.WebUI.DTOs.SubscriberDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.Controllers
{
    public class BlogController : Controller
    {
        private readonly HttpClient _client;

        public BlogController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Subscribe(CreateSubscriberDto createSubscriberDto)
        {
            await _client.PostAsJsonAsync("Subscribers", createSubscriberDto);
            return RedirectToAction("Index","Home");

        }

        public async Task<IActionResult> BlogDetails(int id)
        {
            var value = await _client.GetFromJsonAsync<BlogWithCategoryAndWriterDto>("blogs/" + id);
            return View(value);
        }
        [HttpGet]
        public async Task<IActionResult> GetBlogsByCategoryId(int id)
        {
            var value = await _client.GetFromJsonAsync<List<ResultBlogsByCategoryDto>>("blogs/GetBlogsByCategoryId/" + id);

            ViewBag.CategoryName = value.Select(x => x.BlogCategory.CategoryName).FirstOrDefault();
            return View(value);
        }
    }
}
