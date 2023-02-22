using AutoMapper;
using avtosalon.Repositories;
using Web.data.AdDbConection;
using Web.data.DTO;
using Web.data.model;

namespace avtosalon.Services
{
    public class KompaniyaService : IKompaniyaService
    {
        
        IMapper mapper;
        IKompaniyaRepository kompaniyaService;
        public KompaniyaService(IMapper mapper, IKompaniyaRepository kompaniyaService)
        {
            
            this.mapper = mapper;
            this.kompaniyaService = kompaniyaService;
        }

        public async Task<AddKompaniyaDTO> Add(AddKompaniyaDTO kompaniyaDto)
        {
            var res = mapper.Map<Kompaniya>(kompaniyaDto);
            return mapper.Map<AddKompaniyaDTO>(kompaniyaService.Add(res));
        }

        public async Task<List<PrintKompaniyaDTO>> Get()
        {
            return mapper.Map<List<PrintKompaniyaDTO>>( kompaniyaService.Get());
        }
    }
}
