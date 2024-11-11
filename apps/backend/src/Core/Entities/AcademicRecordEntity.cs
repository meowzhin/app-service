using FwksLabs.Libs.Core.Types;
using FwksLabs.ResumeService.Core.OwnedTypes;

namespace FwksLabs.ResumeService.Core.Entities;

public class AcademicRecordEntity : BaseEntity
{
    public int ResumeId { get; }
    required public string Course { get; set; }
    required public string Level { get; set; }
    required public string School { get; set; }
    required public DateIntervalOwnedType DateInterval { get; set; }
    public string? Description { get; set; }

    public ResumeEntity? Resume { get; set; }
}

