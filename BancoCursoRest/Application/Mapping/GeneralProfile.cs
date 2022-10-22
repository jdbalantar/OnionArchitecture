﻿using Application.DTOs;
using Application.Features.Clientes.Commands.CreateClienteCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region DTOs

            CreateMap<Cliente, ClienteDto>();

            #endregion

            #region Commands

            CreateMap<CreateClienteCommand, Cliente>();

            #endregion
        }
    }
}