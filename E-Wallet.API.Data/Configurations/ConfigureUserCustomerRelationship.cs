using E_Wallet.API.Data.DBEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Wallet.API.Data.Configurations
{
    public class ConfigureUserCustomerRelationship : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasOne(c => c.ApplicationUser).WithOne().HasForeignKey<Customer>(c => c.ApplicationUserId);
        }
    }
}
