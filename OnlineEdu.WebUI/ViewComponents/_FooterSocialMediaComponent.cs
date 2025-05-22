using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SocialMediaDTOs;
using OnlineEdu.WebUI.Helper;
using OnlineEdu.WebUI.Services.TokenService;

namespace OnlineEdu.WebUI.ViewComponents
{
    public class _FooterSocialMediaComponent:ViewComponent
    {
        private readonly HttpClient _client;

        public _FooterSocialMediaComponent(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");

        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialmedias");
            return View(values);
        }
    }
}
