using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BannerDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.ViewComponents
{
    public class _HomeBannerComponent: ViewComponent
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBannerDto>>("banners");
            return View(values);
        }
    }
    
}
