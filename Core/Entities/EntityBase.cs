using System;

namespace Core.Entities
{
  public abstract class EntityBase
  {
    public int Id { get; set; }
    public DateTime CreatedAt { get; set; }
    public bool Status { get; set; }
  }
}