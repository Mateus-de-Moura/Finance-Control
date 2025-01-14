using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using Finance.Control.Application.Common.Models;
using Finance.Control.Application.Extensions;
using Finance.Control.Domain.Entities;
using Finance.Control.Infra.Data.Contexts;

namespace Finance.Control.Application
{
    public class AccountsPayableService(AppDbContext context)
    {

        public async Task<Result<string>> CreateAsync(Accounts model)
        {
            context.Accounts.Add(model);
            var rowsAffected = await context.SaveChangesAsync();

            return rowsAffected > 0 ?
                Result.Success("Cadastrado com sucesso.") :
                Result.Error("Erro ao cadastrar conta");
        }

        public async Task<Result<PaginatedList<Accounts>>> GetPagedAppUserAsync(GetPagedRequest request)
        {
            try
            {
                var paged = await context
                    .Accounts
                    .Where(c => string.IsNullOrEmpty(request.Name) || c.Description.Contains(request.Name))
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
