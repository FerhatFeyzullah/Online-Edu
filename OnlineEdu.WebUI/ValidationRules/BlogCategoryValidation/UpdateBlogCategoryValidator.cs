using FluentValidation;
using OnlineEdu.WebUI.DTOs.BlogCategoryDTOs;

namespace OnlineEdu.WebUI.ValidationRules.BlogCategoryValidation
{
    public class UpdateBlogCategoryValidator:AbstractValidator<UpdateBlogCategoryDto>
    {
        public UpdateBlogCategoryValidator()
        {
            RuleFor(x => x.CategoryName)
                .NotEmpty().WithMessage("Blog Kategori Adı Boş Geçilemez.")
                .MaximumLength(30).WithMessage("Blog Kategori Adı 30 Karakterden Fazla Olamaz.");
        }
    }
}
