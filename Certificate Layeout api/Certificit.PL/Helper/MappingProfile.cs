using AutoMapper;
using Certificit.DAL.Entities;
using Certificit.DAL.Entities.Identity;
using Certificit.PL.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using NetTopologySuite.IO;
using System;
using System.IO;
using System.Text;

namespace Certificit.PL.Helper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            //Users

            CreateMap<AppUser, ReturnUserToListDto>()
                .ReverseMap();

            CreateMap<AppUser, ReturnUserInfoDto>()
                .ReverseMap();

            CreateMap<AppUser, EditeUserDto>()
                .ReverseMap();


            // Role
            CreateMap<IdentityRole, RoleDto>()
                    .ReverseMap();
            CreateMap<IdentityRole, ReturnRoleDto>()
                    .ReverseMap();


            //Log
            CreateMap<Log, ReturnlogDto>()
                .ReverseMap();

            CreateMap<LogDto, Log>()
             .ForMember(dto => dto.Date, opt => opt.MapFrom(src =>
             src.DataTime.HasValue ? src.DataTime.Value.ToString("yyyy-MM-dd HH:mm:ss") : string.Empty))
        .ReverseMap();




            // Certificate 
            CreateMap<CertificateViewLayout33, ReturnCertficateInformation>()
              .ForMember(dest => dest.Geom, opt => opt.MapFrom<NewInformationGeometryToGeoJsonResolver>())
              .ForMember(dest => dest.ImageName, opt => opt.MapFrom<PictureResolver>())
            .ReverseMap();
            
            CreateMap<CertificateViewLayoutEdit, ReturnCertficateInformation>()
              .ForMember(dest => dest.Geom, opt => opt.MapFrom<EditInformationGeometryToGeoJsonResolver>())
              .ForMember(dest => dest.ImageName, opt => opt.MapFrom<EditPictureResolver>())
            .ReverseMap();

            CreateMap<CertificateViewLayoutEdit , ReturnListDto >()
            .ForMember(dest => dest.Geom, opt => opt.MapFrom<EditGeometryToGeoJsonResolver>())
            .ReverseMap();


            CreateMap<CertificateViewLayout33,ReturnListDto > ()
            .ForMember(dest => dest.Geom, opt => opt.MapFrom<GeometryToGeoJsonResolver>())
            .ReverseMap();


            //pathes 

            CreateMap<PathsDto, CertificateFolder>()
            .ReverseMap();
        }
    }
}