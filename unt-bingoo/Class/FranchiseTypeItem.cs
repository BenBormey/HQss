using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
    public class FranchiseTypeItem
    {
        // ត្រូវប្រើប្រាស់ public ដើម្បីឱ្យ DevExpress Grid អាចទាញយកទៅបង្ហាញបាន
        public int Id { get; set; }
        public string TypeName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }

        // បន្ថែម ToString() នេះ ងាយស្រួលនៅពេលលោកអ្នកយក Class នេះទៅញាត់ចូល ComboBox 
        // វានឹងបង្ហាញឈ្មោះ TypeName មកលើ UI ឱ្យស្អាតស្វ័យប្រវត្ត
        public override string ToString()
        {
            return TypeName;
        }
    }
}