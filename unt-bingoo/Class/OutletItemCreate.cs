using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
  public  class OutletItemCreate
    {
        public int Id { get; set; }
        public string OutletCode { get; set; } = string.Empty;
        public string OutletName { get; set; } = string.Empty;
        public string Province { get; set; }
        public int? ProvinceId { get; set; }
        public string Phone { get; set; }
        public string Manager { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public bool HeadOffice { get; set; }
        public bool IsActive { get; set; }
        public string PhotoPath { get; set; }
        public string VATNumber { get; set; }
        public int FranchiseId { get; set; }
        public string Position { get; set; }
        public List<string> PhotoPaths { get; set; } = new List<string>();
        public DateTime GrandOpeningDate { get; set; }
        public Image ProductImage { get; set; }
    }
}
