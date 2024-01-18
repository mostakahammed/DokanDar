using AutoMapper;
using DokanDar.Application.DTO;
using DokanDar.Application.IServices.EntityServices;
using DokanDar.Domain.Entities;
using DokanDar.Domain.IRepositories;
using DokanDar.Domain.IRepositories.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Infrastructure.Services.EntityServices
{
    public class ShelfService : GenericServices<Shelf, ShelfDto>, IShelfService
    {
        public ShelfService(IShelfRepository repository, IMapper mapper) 
            : base(repository, mapper)
        {
        }
    }
}
