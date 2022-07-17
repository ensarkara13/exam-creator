namespace Entities.DTOs.QuestionOption
{
  public class QuestionOptionAddDto
  {
    public string OptionText { get; set; }
    public bool IsRightAnswer { get; set; }
    public Guid QuestionId { get; set; }
  }
}