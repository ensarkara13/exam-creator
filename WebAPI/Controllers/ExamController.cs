
using Entities.DTOs.Exam;

namespace WebAPI.Controllers
{
  [ApiController]
  [Route("exams")]
  public class ExamController : ControllerBase
  {
    private readonly IExamService _examService;
    public ExamController(IExamService examService)
    {
      _examService = examService;
    }

    [HttpGet]
    public async Task<IActionResult> GetExamListAsync()
    {
      DataResult<List<ExamGetDto>> result = await _examService.GetExamListAsync();

      if (result.IsSuccess)
      {
        return Ok(result.Data);
      }

      return NotFound(result.Message);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetExamAsync(int id)
    {
      DataResult<ExamGetWithQuestionsDto> result = await _examService.GetExamAsync(id);

      if (result.IsSuccess)
      {
        return Ok(result.Data);
      }

      return NotFound(result.ErrorMessages);
    }

    [HttpPost]
    public async Task<IActionResult> AddExamAsync(ExamAddDto examAddDto)
    {
      Result result = await _examService.AddExamAsync(examAddDto);

      if (result.IsSuccess)
      {
        return StatusCode(201, examAddDto);
      }

      return BadRequest(result.ErrorMessages);
    }
  }
}