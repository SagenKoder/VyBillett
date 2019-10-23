using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DbUser
    {
        [Key]
        public string Username { get; set; }
        public byte[] Password { get; set; }

        public byte[] Salt { get; set; }
    }
}
