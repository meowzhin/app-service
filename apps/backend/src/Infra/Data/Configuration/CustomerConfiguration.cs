using FwksLabs.AppService.Core.Resources.Customers;
using FwksLabs.Libs.Infra.EntityFrameworkCore.Configuration.Common;
using FwksLabs.Libs.Infra.Postgres.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FwksLabs.ResumeService.Infra.Data.Configuration;

public sealed class CustomerConfiguration : EntityConfiguration<CustomerEntity>, IEntityConfiguration
{
    public override string TableName => "Customers";

    public override void Extend(EntityTypeBuilder<CustomerEntity> builder)
    {
        builder
            .Property(static x => x.Name)
            .HasJsonbType();

        builder
            .Property(static x => x.Phone)
            .HasJsonbType();

        builder
            .Property(static x => x.Address)
            .HasJsonbType();
    }
}
