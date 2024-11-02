﻿using Finance.Control.Application.Mappers;
using Finance.Control.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Services
            services.AddScoped<AppUserService>();

            //Automapper
            services.AddAutoMapper(typeof(DomainToDtoMappingProfile));
            services.AddAutoMapper(typeof(DtoToDomainMappingProfile));

            return services;
        }
    }
}
