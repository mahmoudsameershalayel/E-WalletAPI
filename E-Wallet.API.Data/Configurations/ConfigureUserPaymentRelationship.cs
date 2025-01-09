using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Wallet.API.Data.DBEntities;

namespace E_Wallet.API.Data.Configurations
{
    public class ConfigureUserPaymentRelationship : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.HasOne(c => c.ApplicationUser).WithOne().HasForeignKey<Payment>(c => c.ApplicationUserId);
        }
    }
}