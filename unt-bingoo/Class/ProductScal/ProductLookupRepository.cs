using System;
using System.Data;
using System.Data.SqlClient;

namespace unt_bingoo.Class.ProductScal
{
    /// <summary>
    /// Direct ADO.NET lookups used by the product form (ShelfLife / Currency / UOM).
    /// Keeps raw SQL out of the form and makes parameterisation consistent.
    /// </summary>
    public class ProductLookupRepository
    {
        private readonly string _connectionString;

        public ProductLookupRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public DataTable GetActiveShelfLife()
        {
            const string query = @"
SELECT ShelfLifeId,
       CAST(ShelfLifeValue AS VARCHAR(20)) + ' ' + ShelfLifeUnit AS ShelfLifeText
FROM [DBJuJuBi].[dbo].[ShelfLife]
WHERE IsActive = 1
ORDER BY ShelfLifeValue;";
            return ExecuteTable(query);
        }

        public DataTable GetAllShelfLife()
        {
            const string query = @"
SELECT ShelfLifeId,
       ShelfLifeName,
       CAST(ShelfLifeValue AS VARCHAR(20)) + ' ' + ShelfLifeUnit AS ShelfLifeText
FROM [DBJuJuBi].[dbo].[ShelfLife]
ORDER BY ShelfLifeName;";
            return ExecuteTable(query);
        }

        public DataTable GetActiveUom()
        {
            const string query = @"
SELECT UOMId, UOMCode, UOMName
FROM [DBJuJuBi].[dbo].[UOM]
WHERE IsActive = 1
ORDER BY UOMName ASC;";
            return ExecuteTable(query);
        }

        public DataTable GetDefaultUSD()
        {

            const string query = @"
SELECT
        CurrencyNo AS CurNumber,
        CurrencyCode AS Currency,
        CurrencyNo + SPACE(3)
            + CurrencyCode + SPACE(3)
            + CONVERT(NVARCHAR(30), BuyRate) AS Display
    FROM [DBJuJuBi].[dbo].[Currency]
    WHERE
        Active = 1
		and CurrencyCode = 'USD'
      ";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
               

                DataTable dt = new DataTable();

                conn.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                return dt;
            }

        }


        public DataTable GetCurrencies(int? supplierId = null)
        {
            const string query = @"
    SELECT
        CurrencyNo AS CurNumber,
        CurrencyCode AS Currency,
        CurrencyNo + SPACE(3)
            + CurrencyCode + SPACE(3)
            + CONVERT(NVARCHAR(30), BuyRate) AS Display
    FROM [DBJuJuBi].[dbo].[Currency]
    WHERE
        Active = 1
        AND (@SupplierId IS NULL OR SupplierId = @SupplierId)
    ORDER BY CurrencyCode;";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.Add("@SupplierId", SqlDbType.Int).Value =
                    supplierId.HasValue
                        ? (object)supplierId.Value
                        : DBNull.Value;

                DataTable dt = new DataTable();

                conn.Open();

                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }

                return dt;
            }
        }

        private DataTable ExecuteTable(string query)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                DataTable dt = new DataTable();
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }
                return dt;
            }
        }
    }
}