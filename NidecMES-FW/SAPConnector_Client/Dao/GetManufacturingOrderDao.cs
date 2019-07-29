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
    class GetManufacturingOrderDao : AbstractSAPDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            ManufacturingOrderVo inVo = (ManufacturingOrderVo)vo;

            List<MRPControllerRangeVo> mrpControllers = inVo.MRPControllerRangeListVo;
            //create command
            SAPCommandAdapter sapCommandAdapter = base.GetSAPCommandAdaptor(trxContext, "Z_GTPPFG1201_MO_OUT");// SAPRFCNameEnum.RFC_MANUFACTURING_ORDER.GetValue());

            //create parameter
            SAPParameterList sapParameter = sapCommandAdapter.CreateParameterList();
            sapParameter.AddParameter("IM_PLANT", ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE.GetValue()); // inVo.PlantCode);

            if (!string.IsNullOrEmpty(inVo.FromDate))
            {
                sapParameter.AddParameter("IM_FROM_DATE", inVo.FromDate);
            }

            if (!string.IsNullOrEmpty(inVo.ToDate))
            {
                sapParameter.AddParameter("IM_TO_DATE", inVo.ToDate); //"20160323"
            }

            if (!string.IsNullOrEmpty(inVo.OrderType))
            {
                sapParameter.AddParameter("IM_ORDERTYPE", inVo.OrderType);//ZP01
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
                currOutVo.GoodsReceipt = ConvertNull<string>(dr, "GOODS_RECIPIENT");
                if (sapMODetailTable != null && sapMODetailTable.Rows.Count > 0)
                {
                    DataRow[] drDetail = sapMODetailTable.Select("ORDER_NUMBER = '" + ConvertNull<string>(dr, "ORDER_NUMBER") + "'");
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
                            detailOutVo.Quantity = Convert.ToDecimal(ConvertNull<string>(currdrdetail, "QUANTITY"));
                            detailOutVo.Unit = ConvertNull<string>(currdrdetail, "UNIT");
                            detailOutVo.MovementType = ConvertNull<string>(currdrdetail, "MOVETYPE");

                            currOutVo.MoConfirmationMaterialListVo.Add(detailOutVo);
                        }

                    }
                }

                outVo.ManufacturingOrderListVo.Add(currOutVo);
            }

            if (inVo.Source == "2")
            {
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
                    detailOutVo.Quantity = Convert.ToDecimal(ConvertNull<string>(currdrdetail, "QUANTITY"));
                    detailOutVo.Unit = ConvertNull<string>(currdrdetail, "UNIT");
                    detailOutVo.MovementType = ConvertNull<string>(currdrdetail, "MOVETYPE");

                    outVo.MoConfirmationMaterialListVo.Add(detailOutVo);
                }
            }

            //MoConfirmationMaterialVo moConfirmationMaterialOutVo;

            //foreach (DataRow dr in orderDetailTable.Rows)
            //{
            //    moConfirmationMaterialOutVo = new MoConfirmationMaterialVo();

            //    moConfirmationMaterialOutVo.OrderNumber = ConvertNull<string>(dr, "ORDER_NUMBER").TrimStart('0');
            //    moConfirmationMaterialOutVo.MaterialNumber = ConvertNull<string>(dr, "MATERIAL").TrimStart('0');
            //    moConfirmationMaterialOutVo.MaterialOld = ConvertNull<string>(dr, "MATERIAL_OLD").TrimStart('0');
            //    moConfirmationMaterialOutVo.AlternateGroup = ConvertNull<string>(dr, "ALT_GROUP");
            //    moConfirmationMaterialOutVo.SapBatchNumber = ConvertNull<string>(dr, "BATCH");
            //    moConfirmationMaterialOutVo.VendorBatchNumber = ConvertNull<string>(dr, "VENDOR_BATCH");
            //    moConfirmationMaterialOutVo.SapVendor = ConvertNull<string>(dr, "VENDOR");
            //    moConfirmationMaterialOutVo.StorageLocation = ConvertNull<string>(dr, "LGORT");
            //    moConfirmationMaterialOutVo.Quantity = (int) Convert.ToDecimal(ConvertNull<string>(dr, "QUANTITY"));
            //    moConfirmationMaterialOutVo.Unit = ConvertNull<string>(dr, "UNIT");
            //    moConfirmationMaterialOutVo.MovementType = ConvertNull<string>(dr, "MOVETYPE");

            //    outVo.MoConfirmationMaterialListVo.Add(moConfirmationMaterialOutVo);

            //}

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
