using FwksLabs.Libs.Postgres.Configuration;
using FwksLabs.ResumeService.Core.Entities;
using FwksLabs.ResumeService.Infra.Abstractions;

namespace FwksLabs.ResumeService.Infra.Data.Configuration;

public class CompetencyEntityConfiguration : BaseEntityConfiguration<CompetencyEntity>, IEntityConfiguration
{
    public override string? TableName => "Competencies";
}
