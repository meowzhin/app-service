using FwksLabs.Libs.Core.Types;
using FwksLabs.ResumeService.Core.OwnedTypes;

namespace FwksLabs.ResumeService.Core.Entities;

public class ResumeEntity : BaseEntity
{
    required public string Slug { get; set; }
    required public NameOwnedType Name { get; set; }
    required public string Title { get; set; }
    required public string Summary { get; set; }
    public LocationOwnedType? Location { get; set; }
    public ContactInformationOwnedType? ContactInformation { get; set; }
    public ICollection<SocialOwnedType> Socials { get; set; } = [];

    public ICollection<CompetencyEntity> Competencies { get; set; } = [];
    public ICollection<EmploymentHistoryEntity> EmploymentHistory { get; set; } = [];
    public ICollection<AcademicRecordEntity> AcademicRecords { get; set; } = [];
}