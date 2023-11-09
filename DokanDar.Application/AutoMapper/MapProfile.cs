using AutoMapper;
using DokanDar.Application.DTO;
using DokanDar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Application.AutoMapper
{
    public class MapProfile: Profile
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
        }
    }
}
