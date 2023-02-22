using Web.data.model;

namespace avtosalon.Repositories
{
    public interface IKompaniyaRepository
    {
        Kompaniya Add(Kompaniya Kompaniya);
       List<Kompaniya> Get();
    }
}
