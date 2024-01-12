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
        private readonly IMapper _mapper;

        //========== Inject dependencies in constructor ================//
        public GenericServices(IGenericRepository<T> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
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
            var result = await _repository.AddAsync(entity);   
            return result;
        }

        //------------------ Update Existing Entity ----------------------//
        public async Task<bool> UpdateAsync(TDto dto)
        {
            if (dto == null)
                return false;

            var entity = _mapper.Map<T>(dto);
            var result = await _repository.UpdateAsync(entity);
            return result;
        }

        //------------------ Delete Existing Entity ----------------------//
        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                return false;

            var result = await _repository.DeleteAsync(entity);
            return result;
        }
    }
}
