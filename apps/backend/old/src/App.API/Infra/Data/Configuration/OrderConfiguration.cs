using FwksLabs.AppService.Core.Resources.Orders;
using FwksLabs.Libs.Infra.EntityFrameworkCore.Configuration.Common;
using FwksLabs.Libs.Infra.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FwksLabs.AppService.Infra.Data.Configuration;

public sealed class OrderConfiguration : EntityConfiguration<OrderEntity>, IEntityConfiguration
{
    public override string TableName => "Orders";

    public override void Extend(EntityTypeBuilder<OrderEntity> builder)
    {
        builder
            .HasOne(x => x.Customer)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.CustomerId, TableName, "CustomerId");
    }
}