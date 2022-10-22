﻿using Application.Features.Clientes.Commands.CreateClienteCommand;
using AutoMapper;
using Domain.Entities;

namespace Application.Mapping
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            #region Commands

            CreateMap<CreateClienteCommand, Cliente>();

            #endregion
        }
    }
}