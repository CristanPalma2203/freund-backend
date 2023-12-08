using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplication.Mappers
{
    public class ClientDtoToClient : Profile
    {
        public ClientDtoToClient()
        {
            CreateMap<Dtos.ClientDto, Domain.Models.Client>();
            CreateMap<Domain.Models.Client, Dtos.ClientDto>();
        }
    }
}
