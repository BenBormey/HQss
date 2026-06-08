using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
    public class OutletResponse
    {
        public int id { get; set; }
        public string outletCode { get; set; }
        public string outletName { get; set; }
        public string province { get; set; }
        public string phone { get; set; }
        public string manager { get; set; }
        public bool isActive { get; set; }
        public string photoPath { get; set; }
        public string vatNumber { get; set; }
        public List<string> photos { get; set; }
    }
}
