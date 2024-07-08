using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domon1.ENtityes
{
     public class Gropkala
    {
        public virtual int id { get; set; }
        public virtual string name_grop { get; set; }
        //ارتباط ها
        public virtual List<kala> kala1 { get; set; }
    }
}
