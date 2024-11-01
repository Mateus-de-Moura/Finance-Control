using Ardalis.Result;
using Finance.Control.Domain.Entities;
using Finance.Control.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Application.Services
{
    public class AppUserService(AppDbContext context)
    {

        public async Task<Result<AppUser>> AuthAsync(string email, string password)
        {
            try
            {
                var user = await context.AppUser
                    .FirstOrDefaultAsync(x => x.Email.Equals(email));

                var appUserRole = await context.Role.FirstOrDefaultAsync(x => x.AppUserId.Equals(user!.Id));

                if (appUserRole != null)
                {
                    var roles = await context.AppRole.FirstOrDefaultAsync(x => x.Id.Equals(appUserRole.AppRoleId));
                    user!.UserRole = roles;
                }

                if (user is null)
                    return Result.NotFound();

                if (user.IsActive is false)
                    return Result.Invalid(new ValidationError("Email", "Usuário desativado. Entre em contato com um administrador"));

                if (BCrypt.Net.BCrypt.Verify(password, user.PasswordHash) is false)
                    return Result.Invalid(new ValidationError("Email", "Usuário ou senha inválidos", string.Empty, ValidationSeverity.Info));

                return Result.Success(user);
            }
            catch (Exception e)
            {
                return Result.Error(e.Message);
            }
        }
    }
}
