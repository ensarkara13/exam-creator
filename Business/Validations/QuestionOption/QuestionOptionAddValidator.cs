
namespace Business.Validations.QuestionOption
{
  public class QuestionOptionAddValidator : AbstractValidator<QuestionOptionAddDto>
  {
    public QuestionOptionAddValidator()
    {
      RuleFor(q => q.OptionText)
        .NotEmpty()
        .WithMessage("Seçenek alanı boş bırakılamaz.");

      RuleFor(q => q.QuestionId)
        .NotEmpty();
    }
  }
}