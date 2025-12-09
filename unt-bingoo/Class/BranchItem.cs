using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
   public class BranchItem
    {
        public string BranchCode { get; set; }
        public string BranchName { get; set; }
        public string Phone { get; set; }
        public string Province { get; set; }
        public string Address { get; set; }
        public bool MainBranch { get; set; }
        public bool Active { get; set; }
        public string Remark { get; set; }
    }
}
