using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
    public class OutletItem
    {
        public int Id { get; set; }

        public string OutletCode { get; set; }
        public string OutletName { get; set; }

        public string Province { get; set; }

        public string Phone { get; set; }
        public string Manager { get; set; }

        public bool HeadOffice { get; set; }

        public bool IsActive { get; set; }
    }


}
