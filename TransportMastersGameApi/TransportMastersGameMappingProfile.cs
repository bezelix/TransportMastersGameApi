using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransportMastersGameApi.Entities;
using TransportMastersGameApi.Models;

namespace TransportMastersGameApi
{
    public class TransportMastersGameMappingProfile : Profile
    {
        public TransportMastersGameMappingProfile()
        {
            CreateMap<RegisterUserDto, User>()
               .ForMember(r => r.PasswordHash, c => c.MapFrom(dto => dto.Password));


            CreateMap<User, UserSimpleDataDto>();
            CreateMap<LocationDataDto, Destination>();
            CreateMap<Cargo, CargoDto>();
            CreateMap<Delivery, DeliveryDto>();
            CreateMap<Destination, DestinationDto>();
            CreateMap<Vehicle, VehicleDto>();

            //create
            CreateMap<CreateDeliveryDto, Delivery>();
            CreateMap<CreateCargoDto, Cargo>();

        }
    }
}
