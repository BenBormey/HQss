using System;

namespace unt_bingoo.Class
{
    public class CreateOutlet
    {
        public int Id { get; set; }
        public string OutletCode { get; set; }
        public string OutletName { get; set; }
        public string Province { get; set; }
        public string Phone { get; set; }
        public string Manager { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public int ProvinceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string PhotoPath { get; set; }
        public string VATNumber { get; set; }
        public bool HeadOffice { get; set; }
        public int CreatedBy { get; set; }
    }
}