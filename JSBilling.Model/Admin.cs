using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JSBilling.Model
{
    public class Admin
    {
        public int id {  get; set; }
        public string fullname { get; set; }

        public long Phoneno { get; set; }

        public DateOnly CheckIn { get; set; }

        public int Notes { get; set; }

        public int Demo { get; set; }

        public int Project { get; set; }


    }
}
