using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.SAPConnector_Client.Dao
{
   public class GetStockByMaterialListDao : AbstractSAPDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
                                 
            StockVo inVo = (StockVo)vo;

            //create command
            SAPCommandAdapter sapCommandAdapter = base.GetSAPCommandAdaptor(trxContext, SAPRFCNameEnum.RFC_STOCK.GetValue());

            //create parameter
            SAPParameterList sapParameter = sapCommandAdapter.CreateParameterList();
            sapParameter.AddParameter("IM_PLANT", ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE.GetValue()); // inVo.PlantCode);
            sapParameter.AddParameter("IM_LGORT", inVo.StorageLocationCode);

            //create table parameter and set to parameter
            SAPParameterList sapParameterTable = sapCommandAdapter.CreateParameterList();
            foreach (string material in inVo.MaterialList)
            {
                SAPParameterList sapParameterRow = sapCommandAdapter.CreateParameterList();
                sapParameterRow.AddParameter("MATERIAL", material);
                sapParameterTable.AddParameterList(sapParameterRow);
            }
            sapParameter.AddParameter("TB_MATERIAL", sapParameterTable);

            //create function
            SAPFunction sapFuntion = sapCommandAdapter.Execute(trxContext, sapParameter);

            DataTable sapTable = sapFuntion.GetSAPTable("TB_STOCK_DATA");

            StockVo outVo = new StockVo();

            foreach (DataRow dr in sapTable.Rows)
            {
                string stockQty = ConvertNull<string>(dr, "UNRESTRICTED_STCK");
                StockVo currOutVo = new StockVo
                {
                    ItemNumber = ConvertNull<string>(dr, "MATERIAL"),
                    WarehouseCode = ConvertNull<string>(dr, "LGORT"),
                    InternalLot = ConvertNull<string>(dr, "BATCH"),
                    SupplierCode = ConvertNull<string>(dr, "VENDOR"),
                    SupplierName = ConvertNull<string>(dr, "V_DESC"),
                    OrderStr = ConvertNull<string>(dr, "GR_DATE") + ConvertNull<string>(dr, "GR_TIME") + ConvertNull<string>(dr, "BATCH"),
                    SapBatchNumber = ConvertNull<string>(dr, "BATCH"),
                    VendorBatchNumber = ConvertNull<string>(dr, "V_BATCH"),
                    StockQty = (int)Convert.ToDecimal(stockQty),
                    UnrestrictedStock = (int)Convert.ToDecimal(stockQty),
                    PlanToConsume = (int)Convert.ToDecimal(stockQty),
                    StockReserve = (int)Convert.ToDecimal(stockQty),
                    StockReserve2 = (int)Convert.ToDecimal(stockQty)
                };
                outVo.StockListVo.Add(currOutVo);
            }
            
            List<SapMessageVo> messageList = new List<SapMessageVo>();
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
                messageList.Add(message);
            }
            outVo.SapMessageListVo = messageList;

            List<string> errorMaterialList = new List<string>();
            DataTable errorMaterialTable = sapFuntion.GetSAPTable("TB_ERROR_MATERIAL");
            foreach (DataRow dr in errorMaterialTable.Rows)
            {
                string errorMaterial = ConvertNull<string>(dr, "MATERIAL");
                errorMaterialList.Add(errorMaterial);
            }
            outVo.ErrorMaterialList = errorMaterialList;

            return outVo;
        }
    }
}
