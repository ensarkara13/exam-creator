namespace Business.Concrete
{
  public class QuestionManager : IQuestionService
  {
    private readonly IQuestionRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<QuestionAddDto> _addValidator;
    private readonly IQuestionOptionService _optionService;
    public QuestionManager(IQuestionRepository repository, IMapper mapper, IValidator<QuestionAddDto> addValidator, IQuestionOptionService optionService)
    {
      _repository = repository;
      _mapper = mapper;
      _addValidator = addValidator;
      _optionService = optionService;
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

      for (int i = 0; i < questionAddDtos.Count; i++)
      {
        foreach (QuestionOptionAddDto optionAddDto in questionAddDtos[i].QuestionOptions)
        {
          optionAddDto.QuestionId = questions[i].Id;
        }
        await _optionService.AddQuestionOptionListAsync(questionAddDtos[i].QuestionOptions);
      }

      return Result.Success();
    }

    public Task<Result> DeleteQuestionAsync(int id)
    {
      throw new NotImplementedException();
    }
  }
}