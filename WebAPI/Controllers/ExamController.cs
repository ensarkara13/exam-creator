
using Entities.DTOs.Exam;
using Microsoft.AspNetCore.Authorization;

namespace WebAPI.Controllers
{
  [ApiController]
  [Route("exams")]
  [Authorize]
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
    public async Task<IActionResult> GetExamAsync(Guid id)
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteExamAsync(Guid id)
    {
      Result result = await _examService.DeleteExamAsync(id);

      if (result.IsSuccess)
      {
        return NoContent();
      }

      return BadRequest(result.Message);
    }
  }
}