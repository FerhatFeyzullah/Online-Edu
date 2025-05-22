using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;
using OnlineEdu.WebUI.Helper;
using OnlineEdu.WebUI.Models;
using OnlineEdu.WebUI.Services.TokenService;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogCategoryWithBlogs:ViewComponent
    {
        private readonly HttpClient _client;
        

        public _BlogCategoryWithBlogs(IHttpClientFactory clientFactory)
        {
            _client = clientFactory.CreateClient("EduClient");
           
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _client.GetFromJsonAsync<List<ResultBlogCategoryDto>>("blogCategories/GetCategoriesWithBlogs");

            var categories = (from x in values
                              select new BlogCategoryWithCountViewModel
                              {
                                  CategoryName = x.CategoryName,
                                  BlogCount = x.Blogs.Count,
                                  BlogCategoryId = x.BlogCategoryId
                                  
                              }).ToList();
            

            return View(categories);
        }
    }
}
