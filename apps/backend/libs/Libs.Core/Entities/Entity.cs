using FwksLabs.Libs.Core.Abstractions.Entities;

namespace FwksLabs.Libs.Core.Entities;

public class Entity<TPrimaryKey> : IDeletableEntity where TPrimaryKey : struct
{
    public virtual TPrimaryKey Id { get; set; }
    public virtual Guid UniqueId { get; set; } = Guid.NewGuid();
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}
