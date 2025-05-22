using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.DTO.DTOs.MessageDTOs;
using OnlineEdu.WebUI.DTOs.ContactDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly HttpClient _client;

        public ContactController(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
        }
        public async Task<IActionResult> Index()
        {
            var value = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            ViewBag.map = value.Select(x => x.MapUrl).FirstOrDefault();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(CreateMessageDto createMessageDto)
        {
            await _client.PostAsJsonAsync("messages", createMessageDto);
            return RedirectToAction("Index","Contact");
        }


    }
}
