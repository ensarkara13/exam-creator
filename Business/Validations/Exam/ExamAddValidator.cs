
namespace Business.Validations.Exam
{
  public class ExamAddValidator : AbstractValidator<ExamAddDto>
  {
    public ExamAddValidator()
    {
      RuleFor(e => e.Title)
        .NotEmpty()
        .WithMessage("Sınav başlığı boş bırakılamaz.");
    }
  }
}