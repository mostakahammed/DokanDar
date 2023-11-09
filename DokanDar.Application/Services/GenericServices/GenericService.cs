using AutoMapper;
using DokanDar.Domain;
using DokanDar.Domain.Entities;
using DokanDar.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Application.Services.GenericServices
{
    public class GenericService<T, TEntityDTO> : IGenericService<T, TEntityDTO>
        where T : class
        where TEntityDTO : class
    {
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GenericService(IGenericRepository<T> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> AddAsync(TEntityDTO objtoCreate)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                var entity = _mapper.Map<TEntityDTO,T>(objtoCreate);
                await _repository.AddAsync(entity);
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
           
        }

        public async Task<bool> DeleteAsync(TEntityDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();

                await _repository.DeleteAsync(entity);
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
        }

        public async Task<IEnumerable<TEntityDTO>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<TEntityDTO> GetAsync(int id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<bool> UpdateAsync(int id, TEntityDTO entity)
        {
            try
            {
                await _unitOfWork.BeginTransactionAsync();
                await _repository.GetAsync(id);
                await _repository.UpdateAsync(entity);
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
        }
    }
}
