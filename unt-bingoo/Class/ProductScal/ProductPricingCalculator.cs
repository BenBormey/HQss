using System;
using unt_bingoo.Diagnostics;

namespace unt_bingoo.Class.ProductScal
{
    /// <summary>
    /// Pure pricing / profit calculations for a product.
    /// No UI, no database access -> easy to reuse and unit-test.
    /// All "percent" inputs are whole numbers (e.g. 12 means 12%).
    /// </summary>
    public static class ProductPricingCalculator
    {
        /// <summary>Unit selling profit % based on average cost spread over a case.</summary>
        public static float UnitPercentage(double average, double qtyPerCase, double unitPrice)
        {
            // Guard against divide-by-zero (original code already did this for unit).
            if (qtyPerCase == 0 || unitPrice == 0)
                return 0;

            double buyIn = average / qtyPerCase;
            double percent = ((unitPrice - buyIn) / unitPrice) * 100;
            return (float)Math.Round(percent, 2);
        }

        /// <summary>Pack selling profit %.</summary>
        public static float PackPercentage(double average, double qtyPerCase, double qtyPerPack, double packPrice)
        {
            // FIX: original divided by qtyPerCase with no zero-guard -> could return Infinity / NaN.
            if (qtyPerCase == 0 || packPrice == 0)
                return 0;

            double buyInPack = (average / qtyPerCase) * qtyPerPack;
            double percent = ((packPrice - buyInPack) / packPrice) * 100;
            return (float)Math.Round(percent, 2);
        }

        /// <summary>Case selling profit % (buyIn can be average cost OR total buy-in cost).</summary>
        public static float CasePercentage(double buyIn, double casePrice)
        {
            double denom = casePrice == 0 ? 1 : casePrice;
            double percent = ((casePrice - buyIn) / denom) * 100;
            return (float)Math.Round(percent, 2);
        }

        /// <summary>Derived wholesale/case price from unit price + case discount %.</summary>
        public static double CasePrice(double unitPrice, double caseDiscountPercent, double qtyPerCase)
        {
            double discountFactor = (100 - caseDiscountPercent) / 100.0;
            return unitPrice * discountFactor * qtyPerCase;
        }

        /// <summary>Cubic metres per carton from cm dimensions.</summary>
        public static double CbmPerCtn(double widthCm, double lengthCm, double heightCm)
        {
            return (widthCm / 100.0) * (lengthCm / 100.0) * (heightCm / 100.0);
        }

        /// <summary>
        /// Final landed buy-in cost after FX rate, discount, excise tax,
        /// public-lighting tax and VAT.
        /// </summary>
        public static double TotalBuyin(
            double buyin,
            double discountPercent,
            double vatPercent,
            double exciseTaxPercent,
            double publicLightingTaxPercent,
            double rate)
        {
            try
            {
                if (rate == 0) rate = 1;
                double discountFactor = (100 - discountPercent) / 100.0;
                double vatFactor = (vatPercent / 100.0) + 1;
                double exciseFactor = (100 + exciseTaxPercent) / 100.0;
                double publicLightFactor = (100 + publicLightingTaxPercent) / 100.0;


                double total = ((buyin / rate) * discountFactor) * exciseFactor * publicLightFactor * vatFactor;
                return total;
            }
            catch (Exception ex)
            {
                // Debug.WriteLine only reaches a debugger, never a real deployment -
                // now that CrashLogger exists, use it so a bad TotalBuyin result
                // (silently returned as 0) is actually traceable after the fact.
                CrashLogger.Log(ex, CrashSource.UiThread, CrashSeverity.Recoverable, "Recoverable - TotalBuyin returned 0");
                return 0;
            }
        }
    }
}