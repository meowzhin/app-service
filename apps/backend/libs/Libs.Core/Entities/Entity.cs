namespace FwksLabs.Libs.Core.Entities;

public class Entity<TPrimaryKey> where TPrimaryKey : struct
{
    public virtual TPrimaryKey Id { get; set; }
    public virtual Guid UniqueId { get; set; } = Guid.NewGuid();
}
