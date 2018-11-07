using System;

namespace DbOpertion.Models
{
    [Serializable]
    public class Receive_Order_View
    {
        /// <summary>
        /// 生产领料表Id
        /// </summary>
        public Int32 Id { get; set; }
        /// <summary>
        /// 生产管理表Id
        /// </summary>
        public Int32? ProductionId { get; set; }
        /// <summary>
        /// 状态(待申请,待出库,已出库,已取消)
        /// </summary>
        public String receiveStatus { get; set; }
        /// <summary>
        /// 出库时间
        /// </summary>
        public DateTime? receiveOutTime { get; set; }
        /// <summary>
        /// 申领时间
        /// </summary>
        public DateTime? receiveTime { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public String receiveContext { get; set; }
        /// <summary>
        /// 制单人
        /// </summary>
        public String receiveSinglePerson { get; set; }
        /// <summary>
        /// 制单时间
        /// </summary>
        public DateTime? receiveSingleTime { get; set; }
        /// <summary>
        /// 订单表
        /// </summary>
        public Int32? order_detailId { get; set; }
        /// <summary>
        /// 数量
        /// </summary>
        public Int32? Amount { get; set; }
        /// <summary>
        /// 订单编号
        /// </summary>
        public String OrderNo { get; set; }
        /// <summary>
        /// 生产管理单编号
        /// </summary>
        public String ProductionNo { get; set; }

    }
}
