using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.ThirdParty.KdGold.Model
{
    public class KdApiEOrderModel
    {
        //"{'OrderCode': '012657700222'," +
        //                        "'ShipperCode':'SF'," +
        //                         "'PayType':1," +
        //                         "'ExpType':1," +
        //                         "'Cost':1.0," +
        //                         "'OtherCost':1.0," +
        //                         "'Sender':" +
        //                         "{" +
        //                         "'Company':'LV','Name':'Taylor','Mobile':'15018442396','ProvinceName':'上海','CityName':'上海','ExpAreaName':'青浦区','Address':'明珠路73号'}," +
        //                         "'Receiver':" +
        //                         "{" +
        //                         "'Company':'GCCUI','Name':'Yann','Mobile':'15018442396','ProvinceName':'北京','CityName':'北京','ExpAreaName':'朝阳区','Address':'三里屯街道雅秀大厦'}," +
        //                         "'Commodity':" +
        //                         "[{" +
        //                         "'GoodsName':'鞋子','Goodsquantity':1,'GoodsWeight':1.0}]," +
        //                         "'Weight':1.0," +
        //                         "'Quantity':1," +
        //                         "'Volume':0.0," +
        //                         "'Remark':'小心轻放'," +
        //                         "'IsReturnPrintTemplate':1}"
        /// <summary>
        /// 订单编号(自定义，不可重复)
        /// </summary>
        public string OrderCode { get; set; }
        /// <summary>
        /// 快递公司编码
        /// </summary>
        public string ShipperCode { get; set; }
        /// <summary>
        /// 邮费支付方式:1-现付，2-到付，3-月结，4-第三方支付(仅SF支持)
        /// </summary>
        public int PayType { get; set; }
        /// <summary>
        /// 快递类型：1-标准快件 ,详细快递类型参考《快递公司快递业务类型.xlsx》
        /// </summary>
        public int ExpType { get; set; }
        /// <summary>
        /// 快递运费
        /// </summary>
        public decimal Cost { get; set; }
        /// <summary>
        /// 其他费用
        /// </summary>
        public decimal OtherCost { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public KdApiEOrderReceiverModel Receiver { get; set; }
        /// <summary>
        /// 送货人
        /// </summary>
        public KdApiEOrderSenderModel Sender { get; set; }
        /// <summary>
        /// 商品模型
        /// </summary>
        public List<KdApiEOrderCommodityModel> Commodity { get; set; }
        /// <summary>
        /// 包裹总重量kg 当为快运的订单时必填，不填时快递鸟将根据各个快运公司要求传对应的默认值
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// 包裹数(最多支持30件) 一个包裹对应一个运单号，如果是大于1个包裹，返回则按照子母件的方式返回母运单号和子运单号
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// 包裹总体积m3 当为快运的订单时必填，不填时快递鸟将根据各个快运公司要求传对应的默认值
        /// </summary>
        public double Volume { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 返回电子面单模板：0-不需要；1-需要
        /// </summary>
        public string IsReturnPrintTemplate { get; set; }
    }

    /// <summary>
    /// 收件人模型
    /// </summary>
    public class KdApiEOrderReceiverModel
    {
        /// <summary>
        /// 收件人公司
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 收件人
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电话与手机，必填一个 
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 电话与手机，必填一个 
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 收件人邮编
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 收件省(如广东省，不要缺少“省”；如是直辖市，请直接传北京、上海等； 如是自治区，请直接传广西壮族自治区等) R
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 收件市(如深圳市，不要缺少“市”； 如果是市辖区，请直接传北京市、上海市等)  R
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 收件区/县(如福田区，不要缺少“区”或“县”) R
        /// </summary>
        public string ExpAreaName { get; set; }
        /// <summary>
        /// 收件人详细地址 R
        /// </summary>
        public string Address { get; set; }
    }

    /// <summary>
    /// 送货人模型
    /// </summary>
    public class KdApiEOrderSenderModel
    {
        /// <summary>
        /// 发件人公司
        /// </summary>
        public string Company { get; set; }
        /// <summary>
        /// 发件人
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 电话与手机，必填一个 
        /// </summary>
        public string Tel { get; set; }
        /// <summary>
        /// 电话与手机，必填一个 
        /// </summary>
        public string Mobile { get; set; }
        /// <summary>
        /// 发件地邮编(ShipperCode为EMS、YZPY、YZBK时必填)
        /// </summary>
        public string PostCode { get; set; }
        /// <summary>
        /// 发件省(如广东省，不要缺少“省”；如是直辖市，请直接传北京、上海等； 如是自治区，请直接传广西壮族自治区等) R
        /// </summary>
        public string ProvinceName { get; set; }
        /// <summary>
        /// 发件市(如深圳市，不要缺少“市”； 如果是市辖区，请直接传北京市、上海市等)  R
        /// </summary>
        public string CityName { get; set; }
        /// <summary>
        /// 发件区/县(如福田区，不要缺少“区”或“县”) R
        /// </summary>
        public string ExpAreaName { get; set; }
        /// <summary>
        /// 发件人详细地址
        /// </summary>
        public string Address { get; set; }
    }

    /// <summary>
    /// 商品模型
    /// </summary>
    public class KdApiEOrderCommodityModel
    {
        /// <summary>
        /// 商品名称
        /// </summary>
        public string GoodsName { get; set; }
        /// <summary>
        /// 商品编码
        /// </summary>
        public string GoodsCode { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int Goodsquantity { get; set; }
        /// <summary>
        /// 商品价格
        /// </summary>
        public decimal GoodsPrice { get; set; }
        /// <summary>
        /// 商品重量kg
        /// </summary>
        public string GoodsWeight { get; set; }
        /// <summary>
        /// 商品描述
        /// </summary>
        public string GoodsDesc { get; set; }
        /// <summary>
        /// 商品体积m3
        /// </summary>
        public string GoodsVol { get; set; }
    }
}
