using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
   public class ShelfLifeClass
    {
        public int Id { get; set; }
        public string ShelfLifeName { get; set; }
        public bool IsActive { get; set; }
        public int ShelfLifeValue { get; set; }
        public string ShelfLifeUnit { get; set; }

        public string ShelfLifeText => $"{ShelfLifeValue} {ShelfLifeUnit}";
    }
}
