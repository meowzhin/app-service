namespace FwksLab.Libs.Core.Abstractions;

public interface IIdentifiableResource<TPrimaryKey> where TPrimaryKey : struct
{
    TPrimaryKey Id { get; set; }
    Guid UniqueId { get; set; }
}