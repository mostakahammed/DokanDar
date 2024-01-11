using AutoMapper;
using DokanDar.Application.IServices;
using DokanDar.Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DokanDar.Infrastructure.Services
{
    public class GenericServices<T, TDto> : IGenericService<T, TDto> 
        where T : class
        where TDto : class
    {
        //========== Private Dependencies =================//
        private readonly IGenericRepository<T> _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        //========== Inject dependencies in constructor ================//
        public GenericServices(IGenericRepository<T> repository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //==================== DbContext Save Changes in Database =================//
        private async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _unitOfWork.CommitTransactionAsync();
                return true;
            }
            catch
            {
                await _unitOfWork.RollbackTransactionAsync();
                return false;
            }
        }

        //======================================================================================//
        //======================== Basic CRUD Operation For Generic Entities ===================//
        //======================================================================================//


        //------------------ Get Single Entity By ID ----------------------//
        public async Task<TDto> GetByIdAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            var dto = _mapper.Map<TDto>(entity);
            return dto;
        }

        //------------------ Get Entities Lists ----------------------//
        public async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entityList = await _repository.GetAllAsync();
            var dtoList = _mapper.Map<IEnumerable<TDto>>(entityList);
            return dtoList;
        }

        //------------------ Add New Entity ----------------------//
        public async Task<bool> AddAsync(TDto dto)
        {
            if (dto == null)
                return false;

            var entity = _mapper.Map<T>(dto);
            await _unitOfWork.BeginTransactionAsync();     
            await _repository.AddAsync(entity);
            var result = await SaveChangesAsync();     
            return result;
        }

        //------------------ Update Existing Entity ----------------------//
        public async Task<bool> UpdateAsync(TDto dto)
        {
            if (dto == null)
                return false;

            var entity = _mapper.Map<T>(dto);
            await _unitOfWork.BeginTransactionAsync();
            await _repository.UpdateAsync(entity);
            var result = await SaveChangesAsync();
            return result;
        }

        //------------------ Delete Existing Entity ----------------------//
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;

            await _unitOfWork.BeginTransactionAsync();
            await _repository.DeleteAsync(entity);

            var result = await SaveChangesAsync();
            return result;
        }
    }
}
