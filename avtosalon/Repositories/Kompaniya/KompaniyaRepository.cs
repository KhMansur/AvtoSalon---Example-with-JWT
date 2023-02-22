using Microsoft.EntityFrameworkCore;
using Web.data.AdDbConection;
using Web.data.model;

namespace avtosalon.Repositories
{
    public class KompaniyaRepository : IKompaniyaRepository
    {
        AppDbcontext context;
        public KompaniyaRepository(AppDbcontext context)
        {
                this.context = context;
        }
        public Kompaniya Add(Kompaniya Kompaniya)
        {
            context.Kompaniyalar.Add(Kompaniya);
            context.SaveChanges();
            return Kompaniya;
        }

        public List<Kompaniya> Get()
        {
           return context.Kompaniyalar.Include(p => p.mashinalar).ToList();
        }
    }
}
