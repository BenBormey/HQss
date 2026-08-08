using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace unt_bingoo.Class
{
  
        public class ProductItem
        {
            public int ProID { get; set; }
            public string ProImage { get; set; }
            public string ProNumY { get; set; }
            public string ProNumS { get; set; }
            public string ProNumYP { get; set; }
            public string ProNumYC { get; set; }
        public int? SupplierID { get; set; }
        public string Sup1 { get; set; }
            public string Sup2 { get; set; }

            public string ProName { get; set; }
        public string categoryName { get; set; }
            public string KhmerNameUnicode { get; set; }
            public string KhmerName { get; set; }

            public string ProConsign { get; set; }
            public string ProDes { get; set; }
            public string ProCat { get; set; }

            public string ProPacksize { get; set; }
            public string ProCurr { get; set; }

            public decimal? ProImpPri { get; set; }
            public decimal? ProRecLev { get; set; }
            public decimal? ProRecOrder { get; set; }
        public int categoryId { get; set; }
        public decimal? ProSSec { get; set; }

            public string ProRem { get; set; }

            public string Auto { get; set; }
            public string ProfitAuto { get; set; }

            public int? ProTotQty { get; set; }

            public string ProMadein { get; set; }

            public decimal? ProQtyPCase { get; set; }
            public string ProQtyPPack { get; set; }

            public string ProPckPri { get; set; }

            public float? ProPckDis { get; set; }
            public float? ProPckAllDis { get; set; }

            public decimal? ProRecomLev { get; set; }

            public int? Promotion { get; set; }

            public decimal? FormDLanded { get; set; }

            public decimal? ProUPriBY { get; set; }

        //public float? ProAllowDisW { get; set; }
        //    public float? ProAllowDisU { get; set; }

            public float? ProDis { get; set; }

            public double? ExciseTax { get; set; }
            public double? PublicLightingTax { get; set; }

            public float? ProVAT { get; set; }

            public decimal? ProFinBuyin { get; set; }

            public decimal? ProUPrSE { get; set; }

            public float? ProProPer { get; set; }

            public decimal? ProUPriSeH { get; set; }

            public float? ProHolesaleper { get; set; }

            public float? ProHoleSalePP { get; set; }

            public float? ProRecPer { get; set; }

            public string ProSKU { get; set; }

            public decimal? Average { get; set; }

            public DateTime? BirthDate { get; set; }

            public decimal? AverSalePmonth { get; set; }

            public decimal? WHcode { get; set; }

            public decimal? Sampling { get; set; }

            public string FactoryCurrency { get; set; }

            public string FOB_CIF { get; set; }

            public decimal? FOBCIFCost { get; set; }

            public string ShelfLifeOfProduct { get; set; }

            public decimal? VOP { get; set; }
        public string Status { get; set; }

        // True for raw materials consumed via a Recipe (e.g. Milk, Sugar) —
        // these shouldn't get a MenuItem or be sold directly at POS.
        public bool IsIngredient { get; set; }

        // Stocking unit (e.g. "kg", "L", "pcs") that Recipe.Qty, OutletStock.StockQty,
        // and IngredientStockTransfer.Qty are all expressed in for this product.
        public string ProUnit { get; set; }

        public ProductScaleDto ProductScale { get; set; }

        public string desiplyname
        {
            get
            {
                return $"{ProNumY}  {ProName}";
            }
        }

        // Name first (unlike desiplyname, which leads with the barcode) so a
        // DropDownList combo's built-in type-to-find still matches what the
        // buyer actually types; the code trails behind just for identification.
        public string ProductPickerName
        {
            get
            {
                return string.IsNullOrWhiteSpace(ProNumY)
                    ? ProName
                    : $"{ProName}   [{ProNumY}]";
            }
        }
        }
    }
