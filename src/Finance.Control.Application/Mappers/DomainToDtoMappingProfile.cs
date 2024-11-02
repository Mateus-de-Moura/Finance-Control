using AutoMapper;
using Finance.Control.Application.Dtos;
using Finance.Control.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance.Control.Application.Mappers
{
    public class DomainToDtoMappingProfile : Profile
    {
        public DomainToDtoMappingProfile()
        {
            CreateMap<AppUser, AppUserResponseDto>();
        }
    }
}
