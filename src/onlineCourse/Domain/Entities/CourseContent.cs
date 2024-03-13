using NArchitecture.Core.Persistence.Repositories;

namespace Domain.Entities;

public class CourseContent : Entity<Guid>
{
    public string Summary { get; set; }
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; }
    public virtual CourseDocument CourseDocument { get; set; }
}
