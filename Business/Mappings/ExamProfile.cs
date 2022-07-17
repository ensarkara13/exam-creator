

namespace Business.Mappings
{
  public class ExamProfile : Profile
  {
    public ExamProfile()
    {
      // Add
      CreateMap<ExamAddDto, Exam>().ForMember(d => d.Id, s => s.MapFrom(s => Guid.NewGuid()));

      // Update
      CreateMap<ExamUpdateDto, Exam>();

      // Get
      CreateMap<Exam, ExamGetDto>();
      CreateMap<Exam, ExamGetWithQuestionsDto>();
    }
  }
}