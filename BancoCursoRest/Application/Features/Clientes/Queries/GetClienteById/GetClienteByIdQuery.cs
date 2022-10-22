using Application.DTOs;
using Application.Interfaces;
using Application.Wrappers;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Clientes.Queries.GetClienteById
{
    public class GetClienteByIdQuery : IRequest<Response<ClienteDto>>
    {
        public int Id { get; set; }

        public class GetClienteByIdQueryHandler : IRequestHandler<GetClienteByIdQuery, Response<ClienteDto>>
        {
            private readonly IMapper _mapper;
            private readonly IRepositoryAsync<Cliente> _repositoryAsync;

            public GetClienteByIdQueryHandler(IMapper mapper, IRepositoryAsync<Cliente> repositoryAsync)
            {
                _mapper = mapper;
                _repositoryAsync = repositoryAsync;
            }

            public async Task<Response<ClienteDto>> Handle(GetClienteByIdQuery request,
                CancellationToken cancellationToken)
            {
                var cliente = await _repositoryAsync.GetByIdAsync(request.Id, cancellationToken);

                if (cliente == null)
                    throw new KeyNotFoundException($"Registro no encontrado con el id {request.Id}");
                else
                {
                    var clienteDto = _mapper.Map<ClienteDto>(cliente);
                    return new Response<ClienteDto>(clienteDto);
                }
            }
        }
    }
}