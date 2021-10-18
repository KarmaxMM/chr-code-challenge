using Microsoft.VisualStudio.TestTools.UnitTesting;
using CHR;
using System;
using System.Collections.Generic;
using System.Text;

namespace CHR.Tests
{
    [TestClass()]
    public class GoodsServiceTests
    {
        /// <summary>
        /// 测试入口
        /// </summary>
        [TestMethod()]
        public void GetGoodsPriceWithTaxTest()
        {
            var service = new GoodsService();

            #region Input 1

            var goods = new List<Goods>
            {
                new Goods("book", false, GoodsType.Books, 1, 12.49m),
                new Goods("music CD", false, GoodsType.Normal, 1, 14.99m),
                new Goods("chocolate bar", false, GoodsType.Food, 1, 0.85m)
            };
            var result = service.GetGoodsPriceWithTax(goods);
            PrintResult(1, goods, result);
            Assert.AreEqual(1.50m, result.SalesTaxes);
            Assert.AreEqual(29.83m, result.Total);

            #endregion

            #region Input 2
            goods = new List<Goods>
            {
                new Goods("imported box of chocolates", true, GoodsType.Food, 1, 10.00m),
                new Goods("imported bottle of perfume", true, GoodsType.Normal, 1, 47.50m)
            };
            result = service.GetGoodsPriceWithTax(goods);
            PrintResult(2, goods, result);
            Assert.AreEqual(7.65m, result.SalesTaxes);
            Assert.AreEqual(65.15m, result.Total);

            #endregion

            #region Input 3

            goods = new List<Goods>
            {
                new Goods("imported bottle of perfume", true, GoodsType.Normal, 1, 27.99m),
                new Goods("bottle of perfume", false, GoodsType.Normal, 1, 18.99m),
                new Goods("packet of headache pills", false, GoodsType.MedicalProducts, 1, 9.75m),
                new Goods("box of imported chocolates", true, GoodsType.Food, 1, 11.25m)
            };
            result = service.GetGoodsPriceWithTax(goods);
            PrintResult(3, goods, result);
            Assert.AreEqual(6.70m, result.SalesTaxes);
            Assert.AreEqual(74.68m, result.Total);

            #endregion
        }

        /// <summary>
        /// 结果打印
        /// </summary>
        /// <param name="index"></param>
        /// <param name="goods"></param>
        /// <param name="result"></param>
        private void PrintResult(int index, List<Goods> goods, GoodsPriceWithTaxOutput result)
        {
            Console.WriteLine(string.Format("Output {0}:", index));

            goods.ForEach(p =>
            {
                Console.WriteLine(string.Format("{0} {1}: {2}", p.Quantity, p.Name, p.PriceWithTax));
            });

            Console.WriteLine(string.Format("Sales Taxes: {0}", result.SalesTaxes));
            Console.WriteLine(string.Format("Total: {0}", result.Total));

            Console.WriteLine("");
        }
    }
}