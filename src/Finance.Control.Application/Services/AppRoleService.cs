using Finance.Control.Domain.Entities;
using Finance.Control.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Application.Services
{
    public class AppRoleService(AppDbContext context)
    {
        public async Task<IEnumerable<AppRole>> GetAllAsync()
        {
            return await context.AppRole.ToListAsync();
        }
    }
}
