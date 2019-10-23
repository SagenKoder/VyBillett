using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace VyBillett.Models
{
    public class LineStation
    {
        public int LineStationId { get; set; }
        public virtual Line Line { get; set; }
        public virtual Station Station { get; set; }
        public int Minutes { get; set; }       
    }
}
