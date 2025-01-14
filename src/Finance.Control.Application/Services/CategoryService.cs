using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ardalis.Result;
using AutoMapper;
using Finance.Control.Application.Common.Models;
using Finance.Control.Application.Dtos;
using Finance.Control.Application.Extensions;
using Finance.Control.Domain.Entities;
using Finance.Control.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Finance.Control.Application.Services
{
    public class CategoryService(AppDbContext context)
    {
        public async Task<Result<PaginatedList<Category>>> GetPagedAppUserAsync(GetPagedRequest request)
        {
            try
            {
                var paged = await context
                    .Category
                    .Where(c => string.IsNullOrEmpty(request.Name) || c.Name.Contains(request.Name))
                    .PaginatedListAsync(request.PageNumber, request.PageSize);

                return Result.Success(paged);
            }
            catch (Exception e)
            {
                return Result.Error(e.Message);
            }
        }

        public async Task<Result<Category>> CreateCategoryAsync(Category category)
        {
            var categoryExists = await context.Category.FirstOrDefaultAsync(c => c.Name.Equals(category.Name));

            if (categoryExists == null)
            {
                context.Category.Add(category);
                var rowsAffected = await context.SaveChangesAsync();

                return rowsAffected > 0 ?
                    Result.Success(category)
                    : Result.Error("Erro ao salvar a categoria");
            }


            return Result.Error("Ja existe uma categoria com esse nome.");
        }

        public async Task<Result<Category>> GetById(Guid categoryId)
        {
            var categoryExists = await context.Category.FirstOrDefaultAsync(c => c.Id.Equals(categoryId));

            if (categoryExists != null)
                return Result.Success(categoryExists);
            else
                return Result.Error("Categoria nao encontrada.");
        }

        public async Task<Result<Category>> UpdateCategory(Category category)
        {
            var entity = await context.Category.FirstOrDefaultAsync(c => c.Id.Equals(category.Id));

            if (category != null)
            {
                entity.Active = category.Active;
                entity.Name = category.Name;
                entity.Type = category.Type;

                context.Category.Entry(entity).State = EntityState.Modified;

                var rowsAffected = await context.SaveChangesAsync();


                return rowsAffected > 0 ?
                    Result.Success(entity)
                    : Result.Error("Erro ao atualizar a categoria");
            }

            return Result.Error("Categoria nao encontrada.");
        }
    }
}
