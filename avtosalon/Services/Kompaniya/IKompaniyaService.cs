using Web.data.DTO;
using Web.data.model;

namespace avtosalon.Services
{
    public interface IKompaniyaService
    {
        Task<AddKompaniyaDTO> Add(AddKompaniyaDTO kompaniyaDto);
        Task<List<PrintKompaniyaDTO>> Get();
    }
}
