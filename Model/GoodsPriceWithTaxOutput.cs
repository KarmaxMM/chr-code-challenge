namespace CHR
{
    /// <summary>
    /// 商品
    /// </summary>
    public class GoodsPriceWithTaxOutput
    {
        /// <summary>
        /// 税
        /// </summary>
        public decimal SalesTaxes { get; set; }

        /// <summary>
        /// 合计
        /// </summary>
        public decimal Total { get; set; }

        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="salesTaxes"></param>
        /// <param name="total"></param>
        public GoodsPriceWithTaxOutput(decimal salesTaxes, decimal total)
        {
            SalesTaxes = salesTaxes;
            Total = total;
        }
    }
}
