using Web.data.DTO;

namespace avtosalon.Services
{
    public interface IMashinaService
    {
        Task<AddMashinaDTO> Add(AddMashinaDTO mashinadto);
        Task<PrintMashinaDTO> GetAll();
    }
}
