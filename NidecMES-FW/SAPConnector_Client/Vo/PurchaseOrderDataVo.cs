using Com.Nidec.Mes.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class PurchaseOrderDataVo : ValueObject
    {
        /// <summary>
        /// 采购组描述
        /// </summary>
        public string EKNAM { get; set; }

        /// <summary>
        /// 申请者名称
        /// </summary>
        public string AFNAM { get; set; }

        /// <summary>
        ///  PO纳期
        /// </summary>
        public DateTime EINDT { get; set; }

        /// <summary>
        ///采购凭证号  
        /// </summary>
        public string EBELN { get; set; }

        /// <summary>
        ///创建标识
        /// </summary>
        public string ESTKZ_DESC { get; set; }

        /// <summary>
        ///采购订单项目   
        /// </summary>
        public string EBELP { get; set; }

        /// <summary>
        ///供应商   
        /// </summary>
        public string LIFNR { get; set; }

        /// <summary>
        ///供应商名称   
        /// </summary>
        public string NAME1 { get; set; }

        /// <summary>
        ///图番号   
        /// </summary>
        public string BISMT { get; set; }

        /// <summary>
        ///物料号   
        /// </summary>
        public string MATNR { get; set; }

        /// <summary>
        ///物料名称   
        /// </summary>
        public string MAKTX { get; set; }

        /// <summary>
        ///库存地点   
        /// </summary>
        public string LGPBE { get; set; }

        /// <summary>
        ///订单数量   
        /// </summary>
        public decimal  MENGE { get; set; }

        /// <summary>
        ///未收货数量   
        /// </summary>
        public decimal  OPENQ { get; set; }

        /// <summary>
        ///已接收数量   
        /// </summary>
        public decimal  WEMNG { get; set; }

        /// <summary>
        ///采购订单计量单位   
        /// </summary>
        public string MEINS { get; set; }

        /// <summary>
        ///单价   
        /// </summary>
        public decimal  UNITP { get; set; }

        /// <summary>
        ///价格单位   
        /// </summary>
        public decimal  PEINH { get; set; }

        /// <summary>
        ///货币   
        /// </summary>
        public string WAERS { get; set; }

        /// <summary>
        ///订单货币中的净值   
        /// </summary>
        public decimal  NETWR { get; set; }

        /// <summary>
        ///本位币金额   
        /// </summary>
        public decimal  AMTLC { get; set; }

        /// <summary>
        ///注残本位币金额   
        /// </summary>
        public decimal OPNAMTLC { get; set; }

        /// <summary>
        ///本位币   
        /// </summary>
        public string WAERS_L { get; set; }

        /// <summary>
        ///物料统计组   
        /// </summary>
        public string VERSG { get; set; }

        /// <summary>
        ///购买者名称   
        /// </summary>
        public string ZAD_NAME { get; set; }

        /// <summary>
        ///采购凭证日期   
        /// </summary>
        public DateTime BEDAT { get; set; }

        /// <summary>
        ///PO状态    
        /// </summary>
        public string STATUS { get; set; }

        /// <summary>
        ///收货日期    
        /// </summary>
        public DateTime BUDAT { get; set; }

        /// <summary>
        ///收货发票号    
        /// </summary>
        public string XBLNR { get; set; }

        /// <summary>
        ///收货金额    
        /// </summary>
        public decimal WRBTR { get; set; }

        public List<PurchaseOrderDataVo> PurchaseOrderDataList { get; set; }

        public List<SapMessageVo> PurchaseOrderResultMessageList { get; set; }
    }
}
