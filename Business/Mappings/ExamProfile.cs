

namespace Business.Mappings
{
  public class ExamProfile : Profile
  {
    public ExamProfile()
    {
      // Add
      CreateMap<ExamAddDto, Exam>();

      // Update
      CreateMap<ExamUpdateDto, Exam>();

      // Get
      CreateMap<Exam, ExamGetDto>();
      CreateMap<Exam, ExamGetWithQuestionsDto>();
    }
  }
}