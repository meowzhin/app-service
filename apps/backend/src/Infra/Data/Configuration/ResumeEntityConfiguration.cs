using FwksLabs.Libs.Postgres.Configuration;
using FwksLabs.ResumeService.Core.Entities;
using FwksLabs.ResumeService.Infra.Abstractions;
using FwksLabs.ResumeService.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FwksLabs.ResumeService.Infra.Data.Configuration;

public class ResumeEntityConfiguration : BaseEntityConfiguration<ResumeEntity>, IEntityConfiguration
{
    public override string? TableName => "Resumes";

    public override void Extend(EntityTypeBuilder<ResumeEntity> builder)
    {
        builder
            .HasIndex(x => x.Slug)
            .IsUnique();

        builder
            .Property(x => x.Name)
            .IsJsonb();

        builder
            .Property(x => x.Location!)
            .IsJsonb();

        builder
            .Property(x => x.ContactInformation!)
            .IsJsonb();

        builder
            .Property(x => x.Socials)
            .IsJsonb();

        builder
            .HasMany(x => x.Competencies)
            .WithOne(x => x.Resume)
            .HasForeignKey(x => x.ResumeId, TableName!);

        builder
            .HasMany(x => x.EmploymentHistory)
            .WithOne(x => x.Resume)
            .HasForeignKey(x => x.ResumeId, TableName!);

        builder
            .HasMany(x => x.AcademicRecords)
            .WithOne(x => x.Resume)
            .HasForeignKey(x => x.ResumeId, TableName!);
    }
}
