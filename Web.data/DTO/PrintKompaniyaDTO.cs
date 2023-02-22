using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.data.model;

namespace Web.data.DTO
{
    public class PrintKompaniyaDTO
    {
        public string Nomi { get; set; }
        public string Adress { get; set; }
        public  List<string> mashinalar { get; set; }
    }
}
