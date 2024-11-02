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
    public sealed class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.HasKey(x => x.Id);

            var user = new AppUser
            {
                Id = new Guid("1e8b965f-a2ec-408b-a949-9f7fb137b3c4"),
                Email = "admin@admin.com",
                IsActive = true,
                Name = "Admin",
                AppRoleId = new Guid("f39b093c-9887-4a86-bba5-48be3c1466e4")
            };

            var passwordSalt = BCrypt.Net.BCrypt.GenerateSalt();
            var passwordHash = BCrypt.Net.BCrypt.HashPassword("teste",passwordSalt);

            user.PasswordSalt = passwordSalt;
            user.PasswordHash = passwordHash;

            builder.HasData(user);          
        }
    }
}
