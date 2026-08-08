namespace unt_bingoo.Class
{
    /// <summary>
    /// One unit this product may be purchased in, as returned by
    /// GET api/PurchaseOrder/purchase-units/{proNumY}.
    ///
    /// The server derives the list rather than storing it per product: it is
    /// every unit that reduces to the same base as the product's own stocking
    /// unit. Coffee stocked in G offers G and KG; a drink stocked in CAN
    /// offers CAN alone, because every countable unit is its own base.
    ///
    /// That is why the buyer can never pick CTN here — not because this form
    /// filters it out, but because no verified carton-to-can quantity exists.
    /// The legacy data disagrees with itself on that (one product records 22
    /// per case beside a label reading "24 can case"), so the server refuses
    /// to derive one and this dropdown simply never receives it.
    /// </summary>
    public class PurchaseUomModel
    {
        public string UOMCode { get; set; }

        public string UOMName { get; set; }

        /// <summary>MASS, VOLUME or COUNT.</summary>
        public string UnitType { get; set; }

        /// <summary>Multiply a quantity in this unit by this to get stocking units. KG to G is 1000.</summary>
        public decimal ConversionFactor { get; set; }

        /// <summary>The product's stocking unit — what stock will actually move in.</summary>
        public string BaseUOMCode { get; set; }

        /// <summary>True for the product's own stocking unit, so it can be preselected.</summary>
        public bool IsBaseUnit { get; set; }

        // Shown in the dropdown: "KG - Kilogram" reads better than a bare code
        // to someone holding a supplier invoice.
        public string Display
        {
            get
            {
                return string.IsNullOrWhiteSpace(UOMName) ? UOMCode : UOMCode + " - " + UOMName;
            }
        }
    }
}
