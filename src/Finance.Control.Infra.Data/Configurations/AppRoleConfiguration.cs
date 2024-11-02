using Finance.Control.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Infra.Data.Configurations
{
    public sealed class AppRoleConfiguration : IEntityTypeConfiguration<AppRole>
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.appUsers)
                .WithOne(x => x.Role)
                .IsRequired()
                .HasForeignKey(x => x.AppRoleId);

            var role = new AppRole
            {
                Id = new Guid("f39b093c-9887-4a86-bba5-48be3c1466e4"),
                Name = "Administrator"
            };

            builder.HasData(role);
        }
    }
}
