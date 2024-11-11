using FwksLabs.Libs.Postgres.Configuration;
using FwksLabs.ResumeService.Core.Entities;
using FwksLabs.ResumeService.Infra.Abstractions;
using FwksLabs.ResumeService.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FwksLabs.ResumeService.Infra.Data.Configuration;

public class AcademicRecordEntityConfiguration : BaseEntityConfiguration<AcademicRecordEntity>, IEntityConfiguration
{
    public override string? TableName => "AcademicRecords";

    public override void Extend(EntityTypeBuilder<AcademicRecordEntity> builder)
    {
        builder
            .Property(x => x.DateInterval)
            .IsJsonb();
    }
}