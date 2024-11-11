namespace FwksLabs.Libs.Core.Types;

public abstract class BaseEntity
{
    public int Id { get; }
    public Guid ReferenceId { get; } = Guid.NewGuid();
}
