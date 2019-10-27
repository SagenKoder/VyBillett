using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class LineStation
    {
        public int LineStationId { get; set; }

        public virtual Line Line { get; set; }

        

        public virtual Station Station { get; set; }
        public int Minutes { get; set; }
    }
}
