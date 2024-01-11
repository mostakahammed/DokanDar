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
    public class CategoryService : GenericServices<Category, CategoryDto>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork, IMapper mapper) 
            : base(repository, unitOfWork, mapper)
        {
        }
    }
}
