using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace VyBillett.Models
{
    public class LineStation
    {
        public int LineId { get; set; }
        public virtual Line Line { get; set; }
        public int StationId { get; set; }
        public virtual Station Station { get; set; }
        public int minutes { get; set; }

        
    }
}