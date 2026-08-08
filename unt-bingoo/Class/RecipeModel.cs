using System;
using System.Collections.Generic;

namespace unt_bingoo.Class
{
    public class RecipeModel
    {
        public int RecipeId { get; set; }
        public string ProNumY { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public string Remark { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public List<RecipeItemModel> RecipeItems { get; set; } = new List<RecipeItemModel>();

        // UI-only, filled in from the loaded product list (not part of the API payload).
        public string ProductName { get; set; }
    }

    public class RecipeItemModel
    {
        public int RecipeItemId { get; set; }
        public int RecipeId { get; set; }
        public string IngredientProNumY { get; set; }
        public decimal Qty { get; set; }
        public string Remark { get; set; }

        // UI-only
        public string IngredientName { get; set; }

        // UI-only — the ingredient's unit of measure (e.g. "KG", "L", "PCS"),
        // filled in from TblProductsScale.UOMCode, so Qty isn't shown as a
        // bare number with no idea what it's a quantity of.
        public string Unit { get; set; }

        // UI-only — filled in from the ingredient's TPRProducts.ProImpPri
        // (cost/buy-in price) so the grid and summary can show a live cost
        // without the server needing to compute or store one.
        public decimal UnitCost { get; set; }

        public decimal Subtotal => Qty * UnitCost;

        // UI-only — 1-based display position, renumbered whenever the grid changes.
        public int RowNo { get; set; }
    }
}
