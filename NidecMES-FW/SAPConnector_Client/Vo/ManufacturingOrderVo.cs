using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client.Vo
{
    [Serializable]
    public class ManufacturingOrderVo : ValueObject
    {
        //public string PlantCode { get; set; }

        public string ItemCd { get; set; }

        public string ItemName { get; set; }

        public string ItemType { get; set; }

        public string FactoryCd { get; set; }

        public string FromDate { get; set; }

        public string ToDate { get; set; }

        public string MoNumber { get; set; }

        public string MoNumberFrom { get; set; }

        public string MoNumberTo { get; set; }

        public string WorkCenter { get; set; }

        public string Shift { get; set; }

        public string Line { get; set; }

        public decimal? ActQty { get; set; }

        public string OrderType { get; set; }

        public string TargetQty { get; set; }

        public string MrpController { get; set; }

        public string ProductionDate { get; set; }

        public string StartTime { get; set; }

        public string Status { get; set; }

        public string IncludeBOM { get; set; }

        public string Source { get; set; }

        public string FinishDate { get; set; }

        public string FinishTime { get; set; }

        public string GoodsReceipt { get; set; }

        public string MesStatus { get; set; }

        public int RowIndex { get; set; }

        public string PloductionPlant { get; set; }
        public DateTime ExplDate { get; set; }
        public int RoutingNo { get; set; }
        public int ReservationNumber { get; set; }
        public DateTime ActualReleaseDate { get; set; }
        public DateTime ProductionFinishDate { get; set; }
        public DateTime ProductionStartDate { get; set; }
        public DateTime ActualStartDate { get; set; }
        public DateTime ActualFinishDate { get; set; }
        public decimal Scrap { get; set; }
        public string Unit { get; set; }
        public string EnteredBy { get; set; }
        public DateTime EnterDate { get; set; }
        public string DeletionFlag { get; set; }
        public int ConfNo { get; set; }
        public int ConfCnt { get; set; }
        public DateTime SchedFinTime { get; set; }
        public DateTime SchedStartTime { get; set; }
        public DateTime ActualStartTime { get; set; }
        public decimal ConfirmedQuantity { get; set; }
        public string PlanPlant { get; set; }
        public string Batch { get; set; }
        public string PVersion { get; set; }
        public string WKName { get; set; }
        public string CostCenter { get; set; }
        public string CostName { get; set; }
        public string Wempf { get; set; }

        public int rows { get; set; }

        public int rowsall { get; set; }

        public readonly string IM_BOM_NULL = "";

        public readonly string IM_BOM_1 = "1";

        public string IncludeDBSAVE { get; set; }

        public List<ManufacturingOrderVo> ManufacturingOrderListVo = new List<ManufacturingOrderVo>();

        public List<MoConfirmationMaterialVo> MoConfirmationMaterialListVo = new List<MoConfirmationMaterialVo>();

        public List<MRPControllerRangeVo> MRPControllerRangeListVo = new List<MRPControllerRangeVo>();

        public List<SapMessageVo> SapMessageListVo = new List<SapMessageVo>();
    }
}
