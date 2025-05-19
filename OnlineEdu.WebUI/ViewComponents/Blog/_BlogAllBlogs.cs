using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDTOs;
using OnlineEdu.WebUI.Helper;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogAllBlogs(IMapper _mapper):ViewComponent
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogDto>>("Blogs");
            var mappedValue = _mapper.Map<List<ResultBlogDto>>(values);
            return View(mappedValue);
        }
    }
}
