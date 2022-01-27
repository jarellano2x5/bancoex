using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bancoex.core.DTOs;
using bancoex.core.Entities;
using bancoex.core.Interfaces;

namespace bancoex.core.Services
{
	public class ClienteService : IClienteService
	{
        private readonly IRepository<Cliente> _repository;

        private readonly IMapper _mapper;

		public ClienteService(IRepository<Cliente> repository, IMapper mapper)
		{
            _repository = repository;
            _mapper = mapper;
		}

        public async Task<ClienteDTO> CreateAsync(ClienteDTO dto)
        {
            Cliente ent = _mapper.Map<Cliente>(dto);
            int id = await _repository.Create(ent);
            dto.Id = id;
            return dto;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Cliente entity = await _repository.Read(id);
            return await _repository.Delete(entity);
        }

        public async Task<IEnumerable<ClienteDTO>> GetActivoAsync()
        {
            return _mapper.Map<IEnumerable<ClienteDTO>>(await _repository.Filter(r => r.Activo == true));
        }

        public async Task<ClienteDTO> GetAsync(int id)
        {
            return _mapper.Map<ClienteDTO>(await _repository.Read(id));
        }

        public async Task<ClienteDTO> UpdateAsync(int id, ClienteDTO dto)
        {
            Cliente entity = await _repository.Read(id);
            if (entity == null) throw new Exception("Cliente no existe");
            dto.Id = entity.Id;
            int upid = await _repository.Update(id, _mapper.Map<Cliente>(dto));
            dto.Id = upid;
            return dto;
        }
    }
}

