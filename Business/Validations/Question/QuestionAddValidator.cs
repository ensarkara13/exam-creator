
namespace Business.Validations.Question
{
  public class QuestionAddValidator : AbstractValidator<QuestionAddDto>
  {
    public QuestionAddValidator()
    {
      RuleFor(q => q.QuestionText)
        .NotEmpty()
        .WithMessage("Soru alanı boş bırakılamaz.")
        .MinimumLength(5);

      RuleFor(q => q.ExamId)
        .GreaterThan(0)
        .WithMessage("Geçersiz sınav ID");
    }
  }
}