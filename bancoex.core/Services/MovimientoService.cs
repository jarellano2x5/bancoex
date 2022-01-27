using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using bancoex.core.DTOs;
using bancoex.core.Entities;
using bancoex.core.Enums;
using bancoex.core.Interfaces;

namespace bancoex.core.Services
{
    public class MovimientoService : IMovimientoService
    {
        private readonly IRepository<Movimiento> _repository;
        private readonly IRepository<Cuenta> _repositoryCuenta;
        private readonly IMapper _mapper;

        public MovimientoService(
            IRepository<Movimiento> repository,
            IRepository<Cuenta> cuenta,
            IMapper mapper
        )
        {
            _repository = repository;
            _repositoryCuenta = cuenta;
            _mapper = mapper;
        }

        public async Task<MovimientoDTO> CreateAsync(MovimientoDTO dto)
        {
            bool ck = await Validate(dto);
            if (!ck) throw new Exception("Cuenta sin saldo suficiente");
            Cuenta cta = await _repositoryCuenta.Read(dto.IdCuenta);
            Movimiento entity = _mapper.Map<Movimiento>(dto);
            
            entity.Saldo = cta.Saldo;
            entity.Fecha = DateTime.Now;

            int id = await _repository.Create(entity);
            dto.Id = id;

            if (entity.Tipo == TipoMov.Cargo)
                cta.Saldo -= entity.Importe;
            else
                cta.Saldo += entity.Importe;
            await _repositoryCuenta.Update(cta.Id, cta);

            return dto;
        }

        public async Task<MovimientoDTO> GetAsync(int id)
        {
            return _mapper.Map<MovimientoDTO>(await _repository.Read(id));
        }

        public async Task<IEnumerable<MovimientoDTO>> GetMovAsync(int idCuenta)
        {
            return _mapper.Map<IEnumerable<MovimientoDTO>>(
                await _repository.Filter(e => e.IdCuenta == idCuenta)
            );
        }

        private async Task<bool> Validate(MovimientoDTO dto)
        {
            if (dto.Tipo == TipoMov.Cargo)
            {
                Cuenta cta = await _repositoryCuenta.Read(dto.IdCuenta);
                if (cta.Saldo < dto.Importe)
                    return false;
            }
            return true;
        }
    }
}