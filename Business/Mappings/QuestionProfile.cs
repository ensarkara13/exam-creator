
namespace Business.Mappings
{
  public class QuestionProfile : Profile
  {
    public QuestionProfile()
    {
      // Add
      CreateMap<QuestionAddDto, Question>();

      // Update

      // Get
      CreateMap<Question, QuestionGetDto>();
    }
  }
}