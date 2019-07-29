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
    class GetDeliveryOrderDao : AbstractSAPDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            DeliveryOrderVo inVo = (DeliveryOrderVo)vo;

            //create command
            SAPCommandAdapter sapCommandAdapter = base.GetSAPCommandAdaptor(trxContext, "Z_GTSDFG7301_DELIVERY_RFC"); // SAPRFCNameEnum.RFC_DELIVERY_ORDER.GetValue());

            //create parameter for table IT_WERKS
            SAPParameterList sapParameterTable1 = sapCommandAdapter.CreateParameterList();
            sapParameterTable1.AddParameter("SIGN", "I"); //value set from invo
            sapParameterTable1.AddParameter("OPTION", "EQ");
            sapParameterTable1.AddParameter("PLANT_LOW", ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE.GetValue()); // "1100");
            sapParameterTable1.AddParameter("PLANT_HIGH", "");

            //create parameter for table IT_VBELN
            SAPParameterList sapParameterTable2 = sapCommandAdapter.CreateParameterList();
            sapParameterTable2.AddParameter("SIGN", "I"); //value set from invo
            sapParameterTable2.AddParameter("OPTION", "EQ");
            sapParameterTable2.AddParameter("DELIV_NUMB_LOW", inVo.DoNo); //"0081110720"
            sapParameterTable2.AddParameter("DELIV_NUMB_HIGH", inVo.DoNo); //"0081110720"

            //create parameter for table Z_GTSDFG7301_DELIVERY_RFC
            SAPParameterList sapParameter = sapCommandAdapter.CreateParameterList();
            sapParameter.AddParameter("IT_WERKS", sapParameterTable1);
            sapParameter.AddParameter("IT_VBELN", sapParameterTable2);

            SAPFunction sapFuntion = sapCommandAdapter.ExecuteTable(trxContext, sapParameter);

            //Header table data
            DataTable headerTable = sapFuntion.GetSAPTable("ET_HEADER");

            //detail table data
            DataTable itemTable = sapFuntion.GetSAPTable("ET_ITEM");

            // result message table data
            DataTable resultMessageTable = sapFuntion.GetSAPTable("ET_RETURN");

            DeliveryOrderVo outVo = new DeliveryOrderVo();

            // get the Header data
            foreach (DataRow dr in headerTable.Rows)
            {
                outVo.CreationDate = DateTime.ParseExact(ConvertNull<string>(dr, "ERDAT"), "yyyy-MM-dd", null);
                outVo.DoumentDate = DateTime.ParseExact(ConvertNull<string>(dr, "AUDAT"), "yyyy-MM-dd", null);
                outVo.Status = ConvertNull<string>(dr, "GBSTK");
                outVo.PickedQuantity = Convert.ToInt32(Convert.ToDecimal(ConvertNull<string>(dr, "PIKMG")));
                outVo.DoNo = ConvertNull<string>(dr, "VBELN");
                outVo.CustomerPoNumber = ConvertNull<string>(dr, "BSTNK");
                outVo.CustomerNumber = ConvertNull<string>(dr, "KUNNR").TrimStart('0');
                outVo.CustomerName = ConvertNull<string>(dr, "NAME1");
                outVo.SoNo = ConvertNull<string>(dr, "VBELN_SALES").TrimStart('0');
                outVo.Amount = Convert.ToInt32(Convert.ToDecimal(ConvertNull<string>(dr, "MENGE")));
                outVo.DeliveryDate = DateTime.ParseExact(ConvertNull<string>(dr, "BLDAT"), "yyyy-MM-dd", null);
                outVo.DocumentType = ConvertNull<string>(dr, "AUART");
            }

            //get the Item data
            outVo.DeliveryOrderDtlList = new List<DeliveryOrderDtlVo>();
            foreach (DataRow dr in itemTable.Rows)
            {
                DeliveryOrderDtlVo dtlOutVo = new DeliveryOrderDtlVo();

                dtlOutVo.SoNumber = ConvertNull<string>(dr, "VGBEL");
                dtlOutVo.SoItem = ConvertNull<string>(dr, "VGPOS");
                dtlOutVo.OrderQuantity = Convert.ToInt32(Convert.ToDecimal(ConvertNull<string>(dr, "KWMENG")));
                dtlOutVo.QuantityStock = Convert.ToInt32(Convert.ToDecimal(ConvertNull<string>(dr, "LGMNG")));
                dtlOutVo.DoNo = ConvertNull<string>(dr, "VBELN");
                dtlOutVo.DeliveryItemNumber = ConvertNull<string>(dr, "POSNR");
                dtlOutVo.BatchNo = ConvertNull<string>(dr, "CHARG");
                dtlOutVo.MaterialNumber = ConvertNull<string>(dr, "MATNR");
                dtlOutVo.MaterialType = ConvertNull<string>(dr, "MTART");
                dtlOutVo.MaterialTypeDesc = ConvertNull<string>(dr, "MTBEZ");
                dtlOutVo.MaterialDesc = ConvertNull<string>(dr, "MAKTX");
                dtlOutVo.MaterialStatisticsGroup = ConvertNull<string>(dr, "VERSG");
                dtlOutVo.MaterialStatisticsGroupDesc = ConvertNull<string>(dr, "BEZEI20");
                dtlOutVo.MaterialGroup = ConvertNull<string>(dr, "MATKL");
                dtlOutVo.MaterialGroupDesc = ConvertNull<string>(dr, "WGBEZ");
                dtlOutVo.QuantitySales = Convert.ToInt32(Convert.ToDecimal(ConvertNull<string>(dr, "LFIMG")));
                if (!string.Equals(ConvertNull<string>(dr, "ERDAT"), "0000-00-00"))
                {
                    dtlOutVo.PickingDate = DateTime.ParseExact(ConvertNull<string>(dr, "ERDAT"), "yyyy-MM-dd", null);
                }

                //dtlOutVo.PickingTime = DateTime.ParseExact(ConvertNull<string>(dr, "ERZET"), "HH:mm:ss", null);
                dtlOutVo.StorageLocation = ConvertNull<string>(dr, "LGORT");

                outVo.DeliveryOrderDtlList.Add(dtlOutVo);

            }

            //get the Return Message data
            outVo.DeliveryOrderResultMessageList = new List<SapMessageVo>();
            foreach (DataRow dr in resultMessageTable.Rows)
            {
                SapMessageVo message = new SapMessageVo();
                message.MessageType = ConvertNull<string>(dr, "TYPE");
                message.MessageClassId = ConvertNull<string>(dr, "ID");
                message.MessageNumber = ConvertNull<string>(dr, "NUMBER");
                message.Message = ConvertNull<string>(dr, "MESSAGE");
                message.LogNumber = ConvertNull<string>(dr, "LOG_NO");
                message.LogMessageNumber = ConvertNull<string>(dr, "LOG_MSG_NO");
                message.MessageVariable1 = ConvertNull<string>(dr, "MESSAGE_V1");
                message.MessageVariable2 = ConvertNull<string>(dr, "MESSAGE_V2");
                message.MessageVariable3 = ConvertNull<string>(dr, "MESSAGE_V3");
                message.MessageVariable4 = ConvertNull<string>(dr, "MESSAGE_V4");

                outVo.DeliveryOrderResultMessageList.Add(message);
            }
            return outVo;
        }
    }
}
