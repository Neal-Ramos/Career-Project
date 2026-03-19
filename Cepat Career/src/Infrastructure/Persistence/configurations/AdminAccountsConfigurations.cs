using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Persistence.configurations
{
    public class AdminAccountsConfigurations: IEntityTypeConfiguration<AdminAccounts>
    {
        public void Configure(EntityTypeBuilder<AdminAccounts> builder)
        {
            builder.ToTable("AdminAccounts");
            
        }
    }
}