using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using OnlineEdu.WebUI.DTOs.SubscriberDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogSubscribe:ViewComponent
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();
        public IViewComponentResult Invoke()
        {

            return View();
        }

      
    }
}
 