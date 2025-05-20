using Microsoft.AspNetCore.Mvc;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;
using OnlineEdu.WebUI.Helper;
using OnlineEdu.WebUI.Models;

namespace OnlineEdu.WebUI.ViewComponents.Blog
{
    public class _BlogCategoryWithBlogs:ViewComponent
    {
        private readonly HttpClient _client = HttpClientHelper.CreateClient();
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
