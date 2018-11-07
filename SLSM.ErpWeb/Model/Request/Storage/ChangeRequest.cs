using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SLSM.ErpWeb.Model.Request.Storage
{
    public class ChangeRequest
    {
        /// <summary>
        /// 库存Id
        /// </summary>
        public int storageId { get; set; }
        /// <summary>
        /// 改变数量
        /// </summary>
        public int ChangeCount { get; set; }
        /// <summary>
        /// 仓库ID
        /// </summary>
        public int WarehouseId { get; set; }
        /// <summary>
        /// 原材料ID
        /// </summary>
        public int RawmaterialsId { get; set; }
        /// <summary>
        /// SKU编码
        /// </summary>
        public string SKU { get; set; }
        /// <summary>
        ///  调整原因
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "请填写调整理由")]
        public string ChangeContext { get; set; }
        /// <summary>
        /// 增加还是减少
        /// </summary>
        [Required(AllowEmptyStrings = false, ErrorMessage = "请选择类型")]
        public string ChangeCountType { get; set; }



    }
}