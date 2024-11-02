using Ardalis.Result;
using AutoMapper;
using Finance.Control.Application.Common.Models;
using Finance.Control.Application.Dtos;
using Finance.Control.Application.Extensions;
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
    public class AppUserService(AppDbContext context, IMapper mapper)
    {

        public async Task<Result<AppUser>> AuthAsync(string email, string password)
        {
            try
            {
                var user = await context.AppUser
                    .Include(x => x.Role)
                    .FirstOrDefaultAsync(x => x.Email.Equals(email));

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


        public async Task<Result<PaginatedList<AppUserResponseDto>>> GetPagedAppUserAsync(GetPagedRequest request)
        {
            try
            {             
                var paged = await context
                    .AppUser
                    .Include(x => x.Role)                   
                    .OrderBy(x => x.Name)
                    .Select(x => mapper.Map<AppUserResponseDto>(x))
                    .PaginatedListAsync(request.PageNumber, request.PageSize);

                return Result.Success(paged);
            }
            catch (Exception e)
            {
                return Result.Error(e.Message);
            }
        }
    }
}
