namespace Business.Concrete
{
  public class QuestionOptionManager : IQuestionOptionService
  {
    private readonly IQuestionOptionRepository _repository;
    private readonly IMapper _mapper;
    private readonly IValidator<QuestionOptionAddDto> _addValidator;
    public QuestionOptionManager(IQuestionOptionRepository repository, IMapper mapper, IValidator<QuestionOptionAddDto> addValidator)
    {
      _repository = repository;
      _mapper = mapper;
      _addValidator = addValidator;
    }
    public async Task<Result> AddQuestionOptionListAsync(List<QuestionOptionAddDto> questionOptionAddDtos)
    {
      foreach (QuestionOptionAddDto questionOptionAddDto in questionOptionAddDtos)
      {
        ValidationResult validationResult = _addValidator.Validate(questionOptionAddDto);

        if (!validationResult.IsValid)
        {
          return Result.Failure(validationResult);
        }
      }

      List<QuestionOption> questionOptions = _mapper.Map<List<QuestionOption>>(questionOptionAddDtos);

      await _repository.AddRange(questionOptions);

      return Result.Success();
    }
  }
}