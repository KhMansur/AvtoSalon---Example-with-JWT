using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.data.model
{
    public class Kompaniya
    {
        public int Id { get; set; }
        public string Nomi { get; set; }
        public string Adress { get; set; }
        public virtual List<Mashina> mashinalar { get; set; }



    }
}
