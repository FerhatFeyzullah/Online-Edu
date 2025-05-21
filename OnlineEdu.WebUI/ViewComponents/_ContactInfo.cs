using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.ContactDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.ViewComponents
{
    public class _ContactInfo:ViewComponent
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultContactDto>>("contacts");
            return View(values);
        }
    }
}
