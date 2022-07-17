namespace Business.Concrete
{
  public class ExamManager : IExamService
  {
    private readonly IExamRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<ExamAddDto> _addValidator;
    private readonly IQuestionService _questionService;
    public ExamManager(IExamRepository repository, IMapper mapper, IValidator<ExamAddDto> addValidator, IQuestionService questionService)
    {
      _repository = repository;
      _mapper = mapper;
      _addValidator = addValidator;
      _questionService = questionService;
    }
    public async Task<Result> AddExamAsync(ExamAddDto examAddDto)
    {
      ValidationResult validationResult = _addValidator.Validate(examAddDto);

      if (!validationResult.IsValid)
      {
        return Result.Failure(validationResult);
      }

      Exam exam = _mapper.Map<Exam>(examAddDto);
      await _repository.Add(exam);

      foreach (QuestionAddDto question in examAddDto.Questions)
      {
        question.ExamId = exam.Id;
      }

      await _questionService.AddQuestionListAsync(examAddDto.Questions);

      return Result.Success();
    }

    public Task<Result> DeleteExamAsync(Guid id)
    {
      throw new NotImplementedException();
    }

    public async Task<DataResult<ExamGetWithQuestionsDto>> GetExamAsync(Guid id)
    {
      Exam exam = await _repository.GetExamWithQuestions(id);
      if (exam == null)
      {
        return DataResult<ExamGetWithQuestionsDto>.Failure("İstenilen sınav bulunamadı");
      }

      ExamGetWithQuestionsDto examDto = _mapper.Map<ExamGetWithQuestionsDto>(exam);

      return DataResult<ExamGetWithQuestionsDto>.Success(examDto);
    }

    public async Task<DataResult<List<ExamGetDto>>> GetExamListAsync()
    {
      List<Exam> exams = await _repository.GetAll();
      if (exams?.Count == 0)
      {
        return DataResult<List<ExamGetDto>>.Failure("Hiç sınav bulunmamaktadır.");
      }

      List<ExamGetDto> examGetDtos = _mapper.Map<List<ExamGetDto>>(exams);

      return DataResult<List<ExamGetDto>>.Success(examGetDtos);
    }

    public Task<Result> UpdateExamAsync(ExamUpdateDto examUpdateDto)
    {
      throw new NotImplementedException();
    }
  }
}