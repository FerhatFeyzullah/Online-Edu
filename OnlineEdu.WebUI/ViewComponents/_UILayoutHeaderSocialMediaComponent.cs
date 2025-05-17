using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.SocialMediaDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.ViewComponents
{
    public class _UILayoutHeaderSocialMediaComponent:ViewComponent
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultSocialMediaDto>>("socialmedias");
            return View(values);
        }
    }
}
