using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Vo;

namespace Com.Nidec.Mes.SAPConnector_Client.Dao
{
    class GetManufacturingOrderCompletelyDao : AbstractSAPDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            string DEFAULT_DATE_FORMAT = "0000-00-00";
            string DEFAULT_TIME_FORMAT = "00:00:00";

            ManufacturingOrderVo inVo = (ManufacturingOrderVo)vo;
            List<MRPControllerRangeVo> mrpControllers = inVo.MRPControllerRangeListVo;

            //create command
            SAPCommandAdapter sapCommandAdapter = base.GetSAPCommandAdaptor(trxContext, "Z_GTPPFG1201_MO_OUT");// SAPRFCNameEnum.RFC_MANUFACTURING_ORDER.GetValue());

            //create parameter
            SAPParameterList sapParameter = sapCommandAdapter.CreateParameterList();
            sapParameter.AddParameter("IM_PLANT", ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE.GetValue());

            if (!string.IsNullOrEmpty(inVo.FromDate))
            {
                sapParameter.AddParameter("IM_FROM_DATE", inVo.FromDate);
            }

            if (!string.IsNullOrEmpty(inVo.ToDate))
            {
                sapParameter.AddParameter("IM_TO_DATE", inVo.ToDate); 
            }

            if (!string.IsNullOrEmpty(inVo.OrderType))
            {
                sapParameter.AddParameter("IM_ORDERTYPE", inVo.OrderType);
            }

            if (!string.IsNullOrEmpty(inVo.WorkCenter))
            {
                sapParameter.AddParameter("IM_WORKCENTER", inVo.WorkCenter);
            }

            if (!string.IsNullOrEmpty(inVo.MoNumberFrom))
            {
                sapParameter.AddParameter("IM_FROM_MONO", inVo.MoNumberFrom);
            }

            if (!string.IsNullOrEmpty(inVo.MoNumberTo))
            {
                sapParameter.AddParameter("IM_TO_MONO", inVo.MoNumberTo);
            }

            if (!string.IsNullOrEmpty(inVo.Shift))
            {
                sapParameter.AddParameter("IM_SHIFT", inVo.Shift);
            }

            if (inVo.ActQty != null)
            {
                sapParameter.AddParameter("IM_ACTQTY", inVo.ActQty);
            }
            if (!string.IsNullOrEmpty(inVo.Line))
            {
                sapParameter.AddParameter("IM_LINE", inVo.Line);
            }

            sapParameter.AddParameter("IM_SOURCE", inVo.Source);

            sapParameter.AddParameter("IM_BOM", inVo.IncludeBOM);

            if (!string.IsNullOrEmpty(inVo.IncludeDBSAVE))
            {
                sapParameter.AddParameter("IM_DBSAVE", inVo.IncludeDBSAVE);
            }

            SAPParameterList sapParameterTable;

            SAPParameterList sapParameterTableLists = sapCommandAdapter.CreateParameterList();

            sapParameterTable = sapCommandAdapter.CreateParameterList();

            foreach (MRPControllerRangeVo mrp in mrpControllers)
            {
                sapParameterTable.AddParameter("SIGN", mrp.Sign);
                sapParameterTable.AddParameter("HIGH", mrp.High);
                sapParameterTable.AddParameter("OPTION", mrp.Option);
                sapParameterTable.AddParameter("LOW", mrp.Low);

                sapParameterTableLists.AddParameterList(sapParameterTable);
            }

            sapParameter.AddParameter("TB_MRP_CNTRL_RANGE", sapParameterTableLists);

            SAPFunction sapFuntion = sapCommandAdapter.Execute(trxContext, sapParameter);

            //MO data
            DataTable sapMOTable = sapFuntion.GetSAPTable("TB_MANUFACTURING_ORDER");

            // result BOM data
            DataTable sapMODetailTable = sapFuntion.GetSAPTable("TB_ORDER_DETAIL");

            ManufacturingOrderVo outVo = new ManufacturingOrderVo();
            foreach (DataRow dr in sapMOTable.Rows)
            {
                ManufacturingOrderVo currOutVo = new ManufacturingOrderVo();
                string datetimeval;

                currOutVo.MoNumber = ConvertNull<string>(dr, "ORDER_NUMBER").TrimStart('0');
                currOutVo.ItemCd = ConvertNull<string>(dr, "MATERIAL").TrimStart('0');
                currOutVo.ItemName = ConvertNull<string>(dr, "MATERIAL_TEXT");
                currOutVo.Shift = ConvertNull<string>(dr, "SHIFT");
                currOutVo.TargetQty = ConvertNull<string>(dr, "TARGET_QUANTITY");
                currOutVo.OrderType = ConvertNull<string>(dr, "ORDER_TYPE");
                currOutVo.MrpController = ConvertNull<string>(dr, "MRP_CONTROLLER");
                currOutVo.Status = ConvertNull<string>(dr, "SYSTEM_STATUS");
                currOutVo.WorkCenter = ConvertNull<string>(dr, "WORK_CENTER");
                currOutVo.ProductionDate = ConvertNull<string>(dr, "START_DATE");
                currOutVo.StartTime = ConvertNull<string>(dr, "START_TIME");
                currOutVo.FinishDate = ConvertNull<string>(dr, "FINISH_DATE");
                currOutVo.FinishTime = ConvertNull<string>(dr, "FINISH_TIME");
                currOutVo.GoodsReceipt = ConvertNull<string>(dr, "GOODS_RECIPIENT");//没有数据

                currOutVo.PloductionPlant = ConvertNull<string>(dr, "PRODUCTION_PLANT");

                datetimeval = ConvertNull<string>(dr, "EXPL_DATE");
                if (!string.IsNullOrWhiteSpace(datetimeval) && !string.Equals(datetimeval, DEFAULT_DATE_FORMAT))
                    currOutVo.ExplDate = DateTime.ParseExact(datetimeval, "yyyy-MM-dd", null);
                datetimeval = ConvertNull<string>(dr, "ROUTING_NO");
                if (!string.IsNullOrWhiteSpace(datetimeval))
                    currOutVo.RoutingNo = Convert.ToInt32(datetimeval);
                datetimeval = ConvertNull<string>(dr, "RESERVATION_NUMBER");
                if (!string.IsNullOrWhiteSpace(datetimeval))
                    currOutVo.ReservationNumber = Convert.ToInt32(datetimeval);
                datetimeval = ConvertNull<string>(dr, "ACTUAL_RELEASE_DATE");
                if (!string.IsNullOrWhiteSpace(datetimeval) && !string.Equals(datetimeval, DEFAULT_DATE_FORMAT))
                    currOutVo.ActualReleaseDate = DateTime.ParseExact(datetimeval, "yyyy-MM-dd", null);
                datetimeval = ConvertNull<string>(dr, "PRODUCTION_FINISH_DATE");
                if (!string.IsNullOrWhiteSpace(datetimeval) && !string.Equals(datetimeval, DEFAULT_DATE_FORMAT))
                    currOutVo.ProductionFinishDate = DateTime.ParseExact(datetimeval, "yyyy-MM-dd", null);
                datetimeval = ConvertNull<string>(dr, "PRODUCTION_START_DATE");
                if (!string.IsNullOrWhiteSpace(datetimeval) && !string.Equals(datetimeval, DEFAULT_DATE_FORMAT))
                    currOutVo.ProductionStartDate = DateTime.ParseExact(datetimeval, "yyyy-MM-dd", null);
                datetimeval = ConvertNull<string>(dr, "ACTUAL_START_DATE");
                if (!string.IsNullOrWhiteSpace(datetimeval) && !string.Equals(datetimeval, DEFAULT_DATE_FORMAT))
                    currOutVo.ActualStartDate = DateTime.ParseExact(datetimeval, "yyyy-MM-dd", null);
                datetimeval = ConvertNull<string>(dr, "ACTUAL_FINISH_DATE");
                if (!string.IsNullOrWhiteSpace(datetimeval) && !string.Equals(datetimeval, DEFAULT_DATE_FORMAT))
                    currOutVo.ActualFinishDate = DateTime.ParseExact(datetimeval, "yyyy-MM-dd", null);
                datetimeval = ConvertNull<string>(dr, "SCRAP");
                currOutVo.Scrap = Convert.ToDecimal(datetimeval);
                currOutVo.Unit = ConvertNull<string>(dr, "UNIT");
                currOutVo.EnteredBy = ConvertNull<string>(dr, "ENTERED_BY");
                datetimeval = ConvertNull<string>(dr, "ENTER_DATE");
                if (!string.IsNullOrWhiteSpace(datetimeval) && !string.Equals(datetimeval, DEFAULT_DATE_FORMAT))
                    currOutVo.EnterDate = DateTime.ParseExact(datetimeval, "yyyy-MM-dd", null);
                currOutVo.DeletionFlag = ConvertNull<string>(dr, "DELETION_FLAG");
                datetimeval = ConvertNull<string>(dr, "CONF_NO"); 
                if (!string.IsNullOrWhiteSpace(datetimeval))
                    currOutVo.ConfNo = Convert.ToInt32(datetimeval);
                datetimeval = ConvertNull<string>(dr, "CONF_CNT");
                if (!string.IsNullOrWhiteSpace(datetimeval))
                    currOutVo.ConfCnt = Convert.ToInt32(datetimeval);
                datetimeval = ConvertNull<string>(dr, "SCHED_FIN_TIME");
                if (!string.IsNullOrWhiteSpace(datetimeval) && !string.Equals(datetimeval, DEFAULT_TIME_FORMAT))
                    currOutVo.SchedFinTime = DateTime.ParseExact(ConvertNull<string>(dr, "SCHED_FIN_TIME"), "HH:mm:ss", null);
                datetimeval = ConvertNull<string>(dr, "SCHED_START_TIME");
                if (!string.IsNullOrWhiteSpace(datetimeval) && !string.Equals(datetimeval, DEFAULT_TIME_FORMAT))
                    currOutVo.SchedStartTime = DateTime.ParseExact(ConvertNull<string>(dr, "SCHED_START_TIME"), "HH:mm:ss", null);
                datetimeval = ConvertNull<string>(dr, "ACTUAL_START_TIME");
                if (!string.IsNullOrWhiteSpace(datetimeval) && !string.Equals(datetimeval, DEFAULT_TIME_FORMAT))
                    currOutVo.ActualStartTime = DateTime.ParseExact(ConvertNull<string>(dr, "ACTUAL_START_TIME"), "HH:mm:ss", null);
                datetimeval = ConvertNull<string>(dr, "CONFIRMED_QUANTITY");
                if (!string.IsNullOrWhiteSpace(datetimeval))
                    currOutVo.ConfirmedQuantity = Convert.ToDecimal(datetimeval);
                currOutVo.PlanPlant = ConvertNull<string>(dr, "PLAN_PLANT");
                currOutVo.Batch = ConvertNull<string>(dr, "BATCH");
                currOutVo.PVersion = ConvertNull<string>(dr, "P_VERSION");
                currOutVo.WKName = ConvertNull<string>(dr, "WK_NAMAE");
                currOutVo.CostName = ConvertNull<string>(dr, "COST_NAME");
                currOutVo.CostCenter = ConvertNull<string>(dr, "COST_CENTER");
                currOutVo.Wempf = ConvertNull<string>(dr, "GOODS_RECIPIENT");//Not Exist in RFC but Exist in DB
                currOutVo.rowsall = sapMODetailTable.Rows.Count;

                if (sapMODetailTable != null && sapMODetailTable.Rows.Count > 0)
                {
                    DataRow[] drDetail = sapMODetailTable.Select("ORDER_NUMBER = '" + ConvertNull<string>(dr, "ORDER_NUMBER") + "'");
                    currOutVo.rows = drDetail.Length;
                    if (drDetail.Length > 0)
                    {
                        currOutVo.MoConfirmationMaterialListVo = new List<MoConfirmationMaterialVo>();

                        foreach (DataRow currdrdetail in drDetail)
                        {
                            MoConfirmationMaterialVo detailOutVo = new MoConfirmationMaterialVo();

                            detailOutVo.OrderNumber = ConvertNull<string>(currdrdetail, "ORDER_NUMBER").TrimStart('0');
                            detailOutVo.MaterialNumber = ConvertNull<string>(currdrdetail, "MATERIAL").TrimStart('0');
                            detailOutVo.MaterialOld = ConvertNull<string>(currdrdetail, "MATERIAL_OLD").TrimStart('0');
                            detailOutVo.AlternateGroup = ConvertNull<string>(currdrdetail, "ALT_GROUP");
                            detailOutVo.SapBatchNumber = ConvertNull<string>(currdrdetail, "BATCH");
                            detailOutVo.ProcureType = ConvertNull<string>(currdrdetail, "PROCURE_TYPE");
                            detailOutVo.VendorBatchNumber = ConvertNull<string>(currdrdetail, "VENDOR_BATCH");
                            detailOutVo.SapVendor = ConvertNull<string>(currdrdetail, "VENDOR");
                            detailOutVo.StorageLocation = ConvertNull<string>(currdrdetail, "LGORT");
                            detailOutVo.Quantity = (string.IsNullOrEmpty(ConvertNull<string>(currdrdetail, "QUANTITY")) ? 0M : Convert.ToDecimal(ConvertNull<string>(currdrdetail, "QUANTITY")));
                            detailOutVo.Unit = ConvertNull<string>(currdrdetail, "UNIT");
                            detailOutVo.MovementType = ConvertNull<string>(currdrdetail, "MOVETYPE");
                            currOutVo.MoConfirmationMaterialListVo.Add(detailOutVo);
                        }
                    }
                }
                outVo.ManufacturingOrderListVo.Add(currOutVo);
            }

            foreach (DataRow currdrdetail in sapMODetailTable.Rows)
            {
                MoConfirmationMaterialVo detailOutVo = new MoConfirmationMaterialVo();

                detailOutVo.OrderNumber = ConvertNull<string>(currdrdetail, "ORDER_NUMBER").TrimStart('0');
                detailOutVo.MaterialNumber = ConvertNull<string>(currdrdetail, "MATERIAL").TrimStart('0');
                detailOutVo.MaterialOld = ConvertNull<string>(currdrdetail, "MATERIAL_OLD").TrimStart('0');
                detailOutVo.AlternateGroup = ConvertNull<string>(currdrdetail, "ALT_GROUP");
                detailOutVo.SapBatchNumber = ConvertNull<string>(currdrdetail, "BATCH");
                detailOutVo.ProcureType = ConvertNull<string>(currdrdetail, "PROCURE_TYPE");
                detailOutVo.VendorBatchNumber = ConvertNull<string>(currdrdetail, "VENDOR_BATCH");
                detailOutVo.SapVendor = ConvertNull<string>(currdrdetail, "VENDOR");
                detailOutVo.StorageLocation = ConvertNull<string>(currdrdetail, "LGORT");
                detailOutVo.Quantity = (string.IsNullOrEmpty(ConvertNull<string>(currdrdetail, "QUANTITY")) ? 0M : Convert.ToDecimal(ConvertNull<string>(currdrdetail, "QUANTITY")));
                detailOutVo.Unit = ConvertNull<string>(currdrdetail, "UNIT");
                detailOutVo.MovementType = ConvertNull<string>(currdrdetail, "MOVETYPE");

                outVo.MoConfirmationMaterialListVo.Add(detailOutVo);
            }

            outVo.SapMessageListVo = new List<SapMessageVo>();
            DataTable sapMessageTable = sapFuntion.GetSAPTable("TB_RETURN");
            foreach (DataRow dr in sapMessageTable.Rows)
            {
                SapMessageVo message = new SapMessageVo
                {
                    MessageType = ConvertNull<string>(dr, "TYPE"),
                    MessageClassId = ConvertNull<string>(dr, "ID"),
                    MessageNumber = ConvertNull<string>(dr, "NUMBER"),
                    LogNumber = ConvertNull<string>(dr, "MESSAGE"),
                    LogMessageNumber = ConvertNull<string>(dr, "LOG_NO"),
                    MessageVariable1 = ConvertNull<string>(dr, "MESSAGE_V1"),
                    MessageVariable2 = ConvertNull<string>(dr, "MESSAGE_V2"),
                    MessageVariable3 = ConvertNull<string>(dr, "MESSAGE_V3"),
                    MessageVariable4 = ConvertNull<string>(dr, "MESSAGE_V4")
                };
                outVo.SapMessageListVo.Add(message);
            }

            return outVo;
        }
    }
}
