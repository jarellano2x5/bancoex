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

        public async Task<bool> Delete(int id)
        {
            return await _repository.Delete(id);
        }

        public async Task<IEnumerable<ClienteDTO>> GetActivoAsync()
        {
            return _mapper.Map<List<ClienteDTO>>(await _repository.Filter(r => r.Activo == true));
        }

        public async Task<ClienteDTO> GetAsync(int id)
        {
            return _mapper.Map<ClienteDTO>(await _repository.Read(id));
        }

        public async Task<ClienteDTO> UpdateAsync(int id, ClienteDTO dto)
        {
            int upid = await _repository.Update(id, _mapper.Map<Cliente>(dto));
            dto.Id = upid;
            return dto;
        }
    }
}

