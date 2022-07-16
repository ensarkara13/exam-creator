namespace Entities.DTOs.QuestionOption
{
  public class QuestionOptionGetDto
  {
    public int Id { get; set; }
    public string OptionText { get; set; }
    public bool IsRightAnswer { get; set; }
  }
}