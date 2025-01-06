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
    public class ConfigureWalletTransactionRelationship : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasOne(c => c.Wallet).WithMany().HasForeignKey(c => c.WalletId);
        }
    }
}