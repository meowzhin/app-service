namespace FwksLabs.Libs.Core.Types;

public class DocumentEntity : Entity<Guid>
{
    public override Guid Id { get; set; } = Guid.NewGuid();
}
