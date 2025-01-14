using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Finance.Control.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Finance.Control.Infra.Data.Configurations
{
    public class AccountsConfiguration : IEntityTypeConfiguration<Accounts>
    {
        public void Configure(EntityTypeBuilder<Accounts> builder)
        {
            builder.ToTable(nameof(Accounts));

            builder.HasKey(x => x.Id);

            builder.Property(d => d.Description)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(d => d.Value)
               .IsRequired();

            builder.HasOne(d => d.Category)
                .WithMany()
                .HasForeignKey(d => d.CategoryId);

        }
    }
}
