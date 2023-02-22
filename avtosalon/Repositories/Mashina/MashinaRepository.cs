using Microsoft.EntityFrameworkCore;
using Web.data.AdDbConection;
using Web.data.model;

namespace avtosalon.Repositories
{
    public class MashinaRepository : IMashinaRepository
    {
        AppDbcontext context;
        public MashinaRepository(AppDbcontext context)
        {
            this.context = context;
        }
        public Mashina Add(Mashina mashina)
        {
            context.Mashinalar.Add(mashina);
            context.SaveChanges();
            return mashina;
        }

        public List<Mashina> Get()
        {
           return context.Mashinalar.Include(p => p.Kompaniya).ToList();
        }
    }
}
