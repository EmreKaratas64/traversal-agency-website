using AutoMapper;
using DTOLayer.DTOs.NotificationDTOs;
using EntityLayer.Concrete;
using OnlineTravel.Models;

namespace OnlineTravel.Mapping.AutoMapperProfile
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Notification, NotificationAddDto>();
            CreateMap<NotificationAddDto, Notification>();

            CreateMap<Notification, NotificationListDto>();
            CreateMap<NotificationListDto, Notification>();

            CreateMap<AppUser, RegisterViewModelDto>();
            CreateMap<RegisterViewModelDto, AppUser>();

            CreateMap<AppUser, LoginViewModelDto>();
            CreateMap<LoginViewModelDto, AppUser>();
        }
    }
}
