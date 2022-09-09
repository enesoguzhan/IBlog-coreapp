using FluentValidation;
using IBlog.Entities;

namespace IBlog.Business.Validators.Blog
{
    public class BlogsValidator : AbstractValidator<Blogs>
    {
        public BlogsValidator()
        {
            RuleFor(s => s.Name).MinimumLength(10).WithMessage("Daha Uzun Başlık Adı Giriniz");

            RuleFor(s => s.Explanation).NotNull().WithMessage("Blog İçeriği Boş Olamaz")
                .NotEmpty().WithMessage("Blog İçeriği Boş Olamaz")
                .MinimumLength(50).WithMessage("Daha Uzun İçerik Giriniz");
            RuleFor(s => s.CategoryId).NotNull().WithMessage("Lütfen Kategori Seçiniz");
        }
    }
}
