
namespace Business.Mappings
{
  public class QuestionOptionProfile : Profile
  {
    public QuestionOptionProfile()
    {
      // Add
      CreateMap<QuestionOptionAddDto, QuestionOption>();

      // Update

      // Get
      CreateMap<QuestionOption, QuestionOptionGetDto>();
    }
  }
}