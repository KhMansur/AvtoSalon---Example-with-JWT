using Web.data.model;

namespace avtosalon.Repositories
{
    public interface IMashinaRepository
    {
        Mashina Add(Mashina mashina);
       List< Mashina> Get();
    }
}
