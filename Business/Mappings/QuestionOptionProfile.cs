
namespace Business.Mappings
{
  public class QuestionOptionProfile : Profile
  {
    public QuestionOptionProfile()
    {
      // Add
      CreateMap<QuestionOptionAddDto, QuestionOption>().ForMember(d => d.Id, s => s.MapFrom(s => Guid.NewGuid()));

      // Update

      // Get
      CreateMap<QuestionOption, QuestionOptionGetDto>();
    }
  }
}