using unt_bingoo.Class.ProductScal;

namespace unt_bingoo.Tests
{
    /// <summary>
    /// ProductPricingCalculator drives the profit-% and buy-in figures shown
    /// in guiProductOutlet and used for purchasing. These lock in the current,
    /// already-working formulas (including the existing divide-by-zero guards)
    /// so a future edit to this file can't silently change a percentage or
    /// produce Infinity/NaN without a test failing.
    /// </summary>
    public class ProductPricingCalculatorTests
    {
        [Fact]
        public void UnitPercentage_computes_profit_percent_from_average_cost_per_case()
        {
            // average cost 120 over a case of 12 -> buy-in 10 per unit, sold at 15.
            var result = ProductPricingCalculator.UnitPercentage(average: 120, qtyPerCase: 12, unitPrice: 15);

            Assert.Equal(33.33f, result, 2);
        }

        [Fact]
        public void UnitPercentage_guards_against_divide_by_zero_on_qtyPerCase()
        {
            var result = ProductPricingCalculator.UnitPercentage(average: 120, qtyPerCase: 0, unitPrice: 15);

            Assert.Equal(0f, result);
        }

        [Fact]
        public void UnitPercentage_guards_against_divide_by_zero_on_unitPrice()
        {
            var result = ProductPricingCalculator.UnitPercentage(average: 120, qtyPerCase: 12, unitPrice: 0);

            Assert.Equal(0f, result);
        }

        [Fact]
        public void PackPercentage_computes_profit_percent_for_a_partial_case()
        {
            // 6 units out of a 12-unit case, average cost 120 -> buy-in 60 for the pack, sold at 70.
            var result = ProductPricingCalculator.PackPercentage(average: 120, qtyPerCase: 12, qtyPerPack: 6, packPrice: 70);

            Assert.Equal(14.29f, result, 2);
        }

        [Fact]
        public void PackPercentage_guards_against_divide_by_zero_on_qtyPerCase()
        {
            var result = ProductPricingCalculator.PackPercentage(average: 120, qtyPerCase: 0, qtyPerPack: 6, packPrice: 70);

            Assert.Equal(0f, result);
        }

        [Fact]
        public void PackPercentage_guards_against_divide_by_zero_on_packPrice()
        {
            var result = ProductPricingCalculator.PackPercentage(average: 120, qtyPerCase: 12, qtyPerPack: 6, packPrice: 0);

            Assert.Equal(0f, result);
        }

        [Fact]
        public void CasePercentage_computes_profit_percent_for_the_whole_case()
        {
            var result = ProductPricingCalculator.CasePercentage(buyIn: 120, casePrice: 150);

            Assert.Equal(20f, result, 2);
        }

        [Fact]
        public void CasePercentage_does_not_divide_by_zero_when_casePrice_is_zero()
        {
            // denom falls back to 1 rather than dividing by the zero case price.
            var result = ProductPricingCalculator.CasePercentage(buyIn: 5, casePrice: 0);

            Assert.Equal(-500f, result, 2);
            Assert.False(float.IsNaN(result));
            Assert.False(float.IsInfinity(result));
        }

        [Fact]
        public void CasePrice_applies_the_case_discount_across_the_full_case_quantity()
        {
            // unit price 15, 10% case discount, 12 units per case.
            var result = ProductPricingCalculator.CasePrice(unitPrice: 15, caseDiscountPercent: 10, qtyPerCase: 12);

            Assert.Equal(162.0, result, 4);
        }

        [Fact]
        public void CasePrice_with_zero_discount_equals_unit_price_times_quantity()
        {
            var result = ProductPricingCalculator.CasePrice(unitPrice: 15, caseDiscountPercent: 0, qtyPerCase: 12);

            Assert.Equal(180.0, result, 4);
        }

        [Fact]
        public void CbmPerCtn_converts_centimetre_dimensions_to_cubic_metres()
        {
            var result = ProductPricingCalculator.CbmPerCtn(widthCm: 50, lengthCm: 40, heightCm: 30);

            Assert.Equal(0.06, result, 6);
        }

        [Fact]
        public void TotalBuyin_applies_discount_excise_public_lighting_and_vat_in_sequence()
        {
            var result = ProductPricingCalculator.TotalBuyin(
                buyin: 1000,
                discountPercent: 5,
                vatPercent: 10,
                exciseTaxPercent: 20,
                publicLightingTaxPercent: 3,
                rate: 4000);

            Assert.Equal(0.322905, result, 6);
        }

        [Fact]
        public void TotalBuyin_treats_a_zero_exchange_rate_as_1_instead_of_dividing_by_zero()
        {
            var result = ProductPricingCalculator.TotalBuyin(
                buyin: 100,
                discountPercent: 0,
                vatPercent: 0,
                exciseTaxPercent: 0,
                publicLightingTaxPercent: 0,
                rate: 0);

            Assert.Equal(100.0, result, 4);
            Assert.False(double.IsInfinity(result));
            Assert.False(double.IsNaN(result));
        }

        [Fact]
        public void TotalBuyin_with_no_taxes_or_discount_returns_buyin_over_rate()
        {
            var result = ProductPricingCalculator.TotalBuyin(
                buyin: 4000,
                discountPercent: 0,
                vatPercent: 0,
                exciseTaxPercent: 0,
                publicLightingTaxPercent: 0,
                rate: 4000);

            Assert.Equal(1.0, result, 4);
        }
    }
}
