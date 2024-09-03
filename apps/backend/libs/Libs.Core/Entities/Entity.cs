using FwksLab.Libs.Core.Abstractions;

namespace FwksLab.Libs.Core.Entities;

public abstract class Entity<TPrimaryKey> : IIdentifiableResource<TPrimaryKey> where TPrimaryKey : struct
{
    public TPrimaryKey Id { get; set; }
    public Guid UniqueId { get; set; } = Guid.NewGuid();
}
