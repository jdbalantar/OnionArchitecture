using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.Features.Clientes.Commands.UpdateClienteCommand
{
    public class UpdateClienteCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string? Nombre { get; set; }

        public string? Apellido { get; set; }

        public DateTime? FechaNacimiento { get; set; }

        public string? Telefono { get; set; }

        public string? Email { get; set; }

        public string? Direccion { get; set; }
    }

    public class UpdateClienteCommandHandler : IRequestHandler<UpdateClienteCommand, Response<int>>
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryAsync<Cliente> _repositoryAsync;

        public UpdateClienteCommandHandler(IMapper mapper, IRepositoryAsync<Cliente> repositoryAsync)
        {
            _mapper = mapper;
            _repositoryAsync = repositoryAsync;
        }

        public async Task<Response<int>> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _repositoryAsync.GetByIdAsync(request.Id, cancellationToken);
            if (cliente == null)
                throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
            else
            {
                cliente.Nombre = request.Nombre ?? cliente.Nombre;
                cliente.Apellido = request.Apellido ?? cliente.Apellido;
                cliente.FechaNacimiento = request.FechaNacimiento ?? cliente.FechaNacimiento;
                cliente.Telefono = request.Telefono ?? cliente.Telefono;
                cliente.Email = request.Email ?? cliente.Email;
                cliente.Direccion = request.Direccion ?? cliente.Direccion;

                await _repositoryAsync.UpdateAsync(cliente, cancellationToken);
                return new Response<int>(cliente.Id);
            }
        }
    }
}