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
    public sealed class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasKey(x => x.Id);

            var appUserRole = new AppUserRole
            {
                Id = Guid.NewGuid(),
                AppRoleId = new Guid("f39b093c-9887-4a86-bba5-48be3c1466e4"),
                AppUserId = new Guid("1e8b965f-a2ec-408b-a949-9f7fb137b3c4")
            };

            builder.HasData(appUserRole);
        }
    }
}
