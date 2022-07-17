
namespace Business.Mappings
{
  public class QuestionProfile : Profile
  {
    public QuestionProfile()
    {
      // Add
      CreateMap<QuestionAddDto, Question>().ForMember(d => d.Id, s => s.MapFrom(s => Guid.NewGuid()));

      // Update

      // Get
      CreateMap<Question, QuestionGetDto>();
      CreateMap<Question, QuestionGetWithOptionsDto>();
    }
  }
}