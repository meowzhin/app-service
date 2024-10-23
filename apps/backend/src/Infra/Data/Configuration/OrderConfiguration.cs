using FwksLabs.AppService.Core.Resources.Orders;
using FwksLabs.Libs.Infra.EntityFrameworkCore.Configuration.Common;
using FwksLabs.Libs.Infra.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FwksLabs.ResumeService.Infra.Data.Configuration;

public sealed class OrderConfiguration : EntityConfiguration<OrderEntity>, IEntityConfiguration
{
    public override string TableName => "Orders";

    public override void Extend(EntityTypeBuilder<OrderEntity> builder)
    {
        builder
            .HasOne(static x => x.Customer)
            .WithMany(static x => x.Orders)
            .HasForeignKey(static x => x.CustomerId, TableName, "CustomerId");
    }
}