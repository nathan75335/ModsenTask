using AutoMapper;
using TaskModsen.Entities;
using TaskModsen.Models;

namespace ModsenTask.Data
{
    /// <summary>
    /// use the auto map to map the data from the Eventfeast class to the request
    /// </summary>
    public class AutoMapProfile : Profile
    {
        public AutoMapProfile()
        {
            CreateMap<EventFeast, EventFeastRequest>()
                .ForMember(dest => dest.NameOfEvent , opt => opt.MapFrom(src => src.NameOfEvent))
                 .ForMember(dest => dest.DesctiptionOfEvent, opt => opt.MapFrom(src => src.DesctiptionOfEvent))
                 .ForMember(dest => dest.FioOrganizator, opt => opt.MapFrom(src => src.FioOrganizator))
                  .ForMember(dest => dest.FioSpeaker, opt => opt.MapFrom(src => src.FioSpeaker))
                   .ForMember(dest => dest.Adress, opt => opt.MapFrom(src => src.Adress))
                   .ForMember(dest => dest.TimeOfEvent, opt => opt.MapFrom(src => src.TimeOfEvent)).ReverseMap();
        }         
    }
}
