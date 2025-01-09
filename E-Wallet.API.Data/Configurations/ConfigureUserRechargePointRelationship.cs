using E_Wallet.API.Data.DBEntities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.Configurations
{
    public class ConfigureUserRechargePointRelationship : IEntityTypeConfiguration<RechargePoint>
    {
        public void Configure(EntityTypeBuilder<RechargePoint> builder)
        {
            builder.HasOne(c => c.ApplicationUser).WithOne().HasForeignKey<RechargePoint>(c => c.ApplicationUserId);
        }
    }
}