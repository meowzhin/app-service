using FwksLabs.Libs.Core.Types;
using FwksLabs.ResumeService.Core.OwnedTypes;

namespace FwksLabs.ResumeService.Core.Entities;

public class EmploymentHistoryEntity : BaseEntity
{
    public int ResumeId { get; }
    required public string Company { get; set; }
    required public string Position { get; set; }
    required public DateIntervalOwnedType DateInterval { get; set; }
    public string? Description { get; set; }

    public ResumeEntity? Resume { get; set; }
}

