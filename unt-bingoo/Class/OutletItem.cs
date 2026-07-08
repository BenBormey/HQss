using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
    public class OutletItem
    {
        public int Id { get; set; }
        public string OutletCode { get; set; } = string.Empty;
        public string OutletName { get; set; } = string.Empty;
        public string Province { get; set; }
        public int? provinceId { get; set; }
        public string FrancisePhone { get; set; }
        public string Manager { get; set; }
        public string Address { get; set; } 
        public string Email { get; set; }   
        public bool HeadOffice { get; set; }
        public bool IsActive { get; set; }
        public int HourOperationId { get; set; }
        public string PhotoPath { get; set; }
        public string VATNumber { get; set; }
        public int FranchiseId { get; set; }
        public string position { get; set; }
        public string OutletPhone { get; set; }
        public bool Is24Hours { get; set; }
        [Browsable(false)]
        public List<Photo> Photos { get; set; } = new List<Photo>();

        public List<Photo> ShopPhoto
        {
            get { return Photos; }
        }


        public List<citizetionPhoto> citizenshipPhotos { get; set; } = new List<citizetionPhoto>();
        public DateTime grandOpeningDate { get; set; }
        public string typeName { get; set; }
        public Image ProductImage { get; set; }
        public int hourOperationId { get; set; }
        public string hourOperation { get; set; }
        public string ProvinceNameEN { get; set; }

    }


}
