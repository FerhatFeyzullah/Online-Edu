using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogDTOs;
using OnlineEdu.WebUI.Helper;
using OnlineEdu.WebUI.Services.TokenService;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogAllBlogs :ViewComponent
    {
        private readonly HttpClient _client;
        private readonly IMapper _mapper;

        public _BlogAllBlogs(IHttpClientFactory clientFactory, IMapper mapper)
        {
            _client = clientFactory.CreateClient("EduClient");
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<BlogWithCategoryAndWriterDto>>("Blogs");
            var mappedValue = _mapper.Map<List<BlogWithCategoryAndWriterDto>>(values);
            return View(mappedValue);
        }
    }
}
