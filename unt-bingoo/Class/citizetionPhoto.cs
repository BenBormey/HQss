using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
  public  class citizetionPhoto
    {
        [Browsable(false)]
        [JsonProperty("imageUrl")]
        public string ImageUrl { get; set; }
        public Image CitizenshipImage { get; set; }


    }
}
