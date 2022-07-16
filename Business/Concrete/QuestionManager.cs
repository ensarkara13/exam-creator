namespace Business.Concrete
{
  public class QuestionManager : IQuestionService
  {
    private readonly IQuestionRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<QuestionAddDto> _addValidator;
    public QuestionManager(IQuestionRepository repository, IMapper mapper, IValidator<QuestionAddDto> addValidator)
    {
      _repository = repository;
      _mapper = mapper;
      _addValidator = addValidator;
    }
    public async Task<Result> AddQuestionListAsync(List<QuestionAddDto> questionAddDtos)
    {
      foreach (QuestionAddDto addDto in questionAddDtos)
      {
        ValidationResult validationResult = _addValidator.Validate(addDto);

        if (!validationResult.IsValid)
        {
          return Result.Failure(validationResult);
        }
      }

      List<Question> questions = _mapper.Map<List<Question>>(questionAddDtos);

      await _repository.AddRange(questions);
      return Result.Success();
    }

    public Task<Result> DeleteQuestionAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}