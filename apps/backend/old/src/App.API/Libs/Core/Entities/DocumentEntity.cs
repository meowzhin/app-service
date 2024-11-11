namespace FwksLabs.Libs.Core.Entities;

public class DocumentEntity : Entity<Guid>
{
    public override Guid Id { get; set; } = Guid.NewGuid();
}
