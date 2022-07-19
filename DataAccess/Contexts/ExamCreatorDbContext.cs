using Core.Entities;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace DataAccess.Contexts
{
  public class ExamCreatorDbContext : DbContext
  {
    public ExamCreatorDbContext(DbContextOptions<ExamCreatorDbContext> options) : base(options)
    {
    }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<QuestionOption> QuestionOptions { get; set; }
    public DbSet<UserExam> UserExams { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {

      builder.Entity<User>()
      .HasKey(u => u.Id);

      builder.Entity<User>()
      .HasMany(u => u.UserExams)
      .WithOne(u => u.User);

      builder.Entity<Exam>()
      .HasMany(e => e.UserExams)
      .WithOne(e => e.Exam)
      .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<Exam>()
      .HasMany(e => e.Questions)
      .WithOne(e => e.Exam)
      .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<Question>()
      .HasMany(q => q.QuestionOptions)
      .WithOne(q => q.Question)
      .OnDelete(DeleteBehavior.Cascade);

      builder.Entity<UserExam>()
      .HasKey(u => new { u.ExamId, u.UserId });

      base.OnModelCreating(builder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
      IEnumerable<EntityEntry<EntityBase>> entries = ChangeTracker.Entries<EntityBase>();

      foreach (EntityEntry<EntityBase> entry in entries)
      {
        switch (entry.State)
        {
          case EntityState.Added:
            entry.Entity.CreatedAt = DateTime.Now;
            break;
        }
      }

      return await base.SaveChangesAsync(cancellationToken);
    }
  }
}
