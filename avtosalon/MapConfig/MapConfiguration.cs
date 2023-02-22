using AutoMapper;
using Web.data.DTO;
using Web.data.model;

namespace avtosalon.MapConfig
{
    public class MapConfiguration : Profile
    {
        public MapConfiguration()
        {
            CreateMap<AddMashinaDTO, Mashina >().ReverseMap();
            CreateMap<AddKompaniyaDTO,Kompaniya>().ReverseMap();

            CreateMap<Kompaniya, PrintKompaniyaDTO>().ForMember(p => p.mashinalar, s => s.MapFrom(p => p.mashinalar.Select(s => s.modei).ToList()));
            CreateMap<Mashina, PrintMashinaDTO>().ForMember(p => p.Kompaniya_nomi, s => s.MapFrom(p => p.Kompaniya.Nomi));

            CreateMap<ApiUser, UserDto > ().ReverseMap();
        }
    }
}
