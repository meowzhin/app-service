namespace FwksLabs.Libs.Core.Abstractions.Entities;

public interface IDeletableEntity
{
    bool IsDeleted { get; set; }
    DateTime? DeletedAt { get; set; }
}
