
namespace Core.Entities
{
  public abstract class EntityBase
  {
    public Guid Id { get; set; }
    public bool Status { get; set; }
    public DateTime CreatedAt { get; set; }
  }
}