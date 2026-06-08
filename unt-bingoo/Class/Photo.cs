using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
    public class Photo
    {
        [Browsable(false)]
        [JsonProperty("url")] 
        public string Url { get; set; } = string.Empty;

      

        public Image DetailImage { get; set; }
    }
}