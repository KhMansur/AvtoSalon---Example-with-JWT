using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.data.model
{
    public class Mashina
    {
        public int Id { get; set; }
        public string modei { get; set; }
        public string rangi { get; set; }
        public int yili { get; set; }
        public int Kompaniya_Id { get; set; }

        public virtual Kompaniya Kompaniya { get; set; }

        
    }
}
