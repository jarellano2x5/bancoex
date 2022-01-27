using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bancoex.core.DTOs;
using bancoex.core.Entities;
using bancoex.core.Interfaces;

namespace bancoex.core.Services
{
    public class CuentaService : ICuentaService
    {
        private readonly IRepository<Cuenta> _repository;
        private readonly IMapper _mapper;

        public CuentaService(IRepository<Cuenta> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CuentaDTO> CreateAsync(CuentaDTO dto)
        {
            int id = await _repository.Create(_mapper.Map<Cuenta>(dto));
            dto.Id = id;

            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Cuenta entity = await _repository.Read(id);

            return await _repository.Delete(entity);
        }

        public async Task<IEnumerable<CuentaDTO>> GetAllCuentasAsync(int idCliente)
        {
            return _mapper.Map<IEnumerable<CuentaDTO>>(
                await _repository.Filter(e => e.IdCliente == idCliente)
            );
        }

        public async Task<CuentaDTO> GetAsync(int id)
        {
            return _mapper.Map<CuentaDTO>(await _repository.Read(id));
        }

        public async Task<IEnumerable<CuentaDTO>> GetCuentasAsync(int idCliente)
        {
            return _mapper.Map<IEnumerable<CuentaDTO>>(
                await _repository.Filter(e => e.IdCliente == idCliente && e.Activa == true));
        }

        public async Task<CuentaDTO> UpdateAsync(int id, CuentaDTO dto)
        {
            Cuenta entity = await _repository.Read(id);
            if (entity == null) throw new Exception("Cuenta no existe");
            dto.Id = entity.Id;
            int upid = await _repository.Update(id, _mapper.Map<Cuenta>(dto));
            dto.Id = upid;
            return dto;
        }
    }
}