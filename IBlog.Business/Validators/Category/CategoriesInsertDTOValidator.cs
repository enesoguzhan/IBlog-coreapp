using FluentValidation;
using IBlog.Entities.DTO.Categories;

namespace IBlog.Business.Validators.Category
{
    public class CategoriesInsertDTOValidator : AbstractValidator<CategoriesInsertDTO>
    {
        public CategoriesInsertDTOValidator()
        {
            RuleFor(s => s.Name).NotEmpty().WithMessage("Kategori ismi boş olamaz");
        }
    }
}
