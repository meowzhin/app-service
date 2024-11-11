using FwksLabs.Libs.Core.Types;
using FwksLabs.ResumeService.Core.Enums;

namespace FwksLabs.ResumeService.Core.Entities;

public class CompetencyEntity : BaseEntity
{
    public int ResumeId { get; }
    required public CompetencyCategory Type { get; set; }
    required public string Name { get; set; }
    public string? Level { get; set; }

    public ResumeEntity? Resume { get; set; }
}

