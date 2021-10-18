using System;
using System.Collections.Generic;

namespace CHR
{
    public class GoodsService
    {
        /// <summary>
        /// 基本税
        /// </summary>
        const decimal BasicSalesTax = 0.1m;

        /// <summary>
        /// 进口附加销售税
        /// </summary>
        const decimal ImportDuty = 0.05m;

        /// <summary>
        /// 计算商品含税价
        /// </summary>
        /// <param name="goods">商品</param>
        /// <returns></returns>
        public decimal ComputePriceWithTax(Goods goods)
        {
            decimal result = 0;
            if (goods != null)
            {
                // 对于进口商品 =》附加销售税
                if (goods.IsImport)
                {
                    decimal tax = goods.Price * goods.Quantity * ImportDuty;
                    // result += FormatTax(tax);
                    result += tax;
                }

                // 书籍、食品、药品除外，需要征收基础税
                if (!(goods.GoodsType == GoodsType.Books
                    || goods.GoodsType == GoodsType.Food
                    || goods.GoodsType == GoodsType.MedicalProducts))
                {
                    decimal tax = goods.Price * goods.Quantity * BasicSalesTax;
                    // result += FormatTax(tax);
                    result += tax;
                }
                result = FormatTax(result);
                // 计算最终价
                result += goods.Price * goods.Quantity;
            }

            return result;
        }

        /// <summary>
        /// 格式化税额
        /// </summary>
        /// <returns></returns>
        private decimal FormatTax(decimal tax)
        {
            var tmpTax = tax / 0.05m;
            if (tmpTax.ToString().IndexOf(".") != -1)
            {
                tax = Math.Ceiling(tmpTax) * 0.05m;
            }
            return tax;
        }

        /// <summary>
        /// 获取商品含税价及税额
        /// </summary>
        /// <param name="goods">商品列表</param>
        /// <returns></returns>
        public GoodsPriceWithTaxOutput GetGoodsPriceWithTax(List<Goods> goods)
        {
            // 不含税总价
            decimal totalPrice = 0;
            // 含税总价
            decimal totalPriceWithTax = 0;
            goods.ForEach(p =>
            {
                totalPrice += p.Price * p.Quantity;
                p.PriceWithTax = ComputePriceWithTax(p);
                totalPriceWithTax += p.PriceWithTax;
            });
            return new GoodsPriceWithTaxOutput(totalPriceWithTax - totalPrice, totalPriceWithTax);
        }
    }
}
