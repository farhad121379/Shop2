using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domon1.ENtityes
{
    public class kala
    {
        public virtual int ID { get; set; }
     
        public virtual string name { get; set; }
        public virtual string ghimat { get; set; }
        public virtual string mojodi { get; set; }
        ///ارتباط ها 
        public virtual Gropkala grop_Kala1 { get; set; }

       
    }
}
