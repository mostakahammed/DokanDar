using DokanDar.Application.Services.GenericServices;
using DokanDar.Domain.Entities;
using DokanDar.Domain.Interfaces;
using DokanDar.Domain.Interfaces.EntityRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Application.Services.EntityServices
{
    public interface ICategoryService: IGenericService<Category>
    {

    }

    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(ICategoryRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddAsync(Category entity)
        {
            await _repository.AddAsync(entity);
            await _unitOfWork.CommitTransactionAsync();
            return true;
        }

        public Task<bool> DeleteAsync(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Category>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Category> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateAsync(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
