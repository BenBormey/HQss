using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
   public class HourOperationItem
    {
        public int Id { get; set; }

        //public string HourName { get; set; }

        public TimeSpan OpenTime { get; set; }

        public TimeSpan CloseTime { get; set; }

        public bool Is24Hours { get; set; }

        public bool Status { get; set; }
        public string Display
        {
            get
            {
                return $"{OpenTime:hh\\:mm} - {CloseTime:hh\\:mm}";
            }
        }

    }
}
