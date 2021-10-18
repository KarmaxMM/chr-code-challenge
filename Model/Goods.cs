using System;

namespace CHR
{
    /// <summary>
    /// 商品
    /// </summary>
    public class Goods
    {
        /// <summary>
        /// 初始化商品
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="isImport">是否进口</param>
        /// <param name="goodsType">商品类型</param>
        /// <param name="quantity">数量</param>
        /// <param name="price">单价</param>
        public Goods(string name, bool isImport, GoodsType goodsType, decimal quantity, decimal price)
        {
            Name = name;
            IsImport = isImport;
            GoodsType = goodsType;
            Quantity = quantity;
            Price = price;
        }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { set; get; }

        /// <summary>
        /// 是否进口
        /// </summary>
        public bool IsImport { set; get; }

        /// <summary>
        /// 商品类型
        /// </summary>
        public GoodsType GoodsType { set; get; }

        /// <summary>
        /// 数量
        /// </summary>
        public decimal Quantity { set; get; }

        /// <summary>
        /// 单价
        /// </summary>
        public decimal Price { set; get; }

        /// <summary>
        /// 含税价
        /// </summary>
        public decimal PriceWithTax { get; set; }
    }
}
