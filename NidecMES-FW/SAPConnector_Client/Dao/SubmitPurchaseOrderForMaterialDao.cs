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
    class SubmitPurchaseOrderForMaterialDao : AbstractSAPDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            PoGoodReceiptVo inVo = (PoGoodReceiptVo)vo;

            List<PoGoodReceiptVo> pos = inVo.PoGoodReceiptList;

            //create command
            SAPCommandAdapter sapCommandAdapter = base.GetSAPCommandAdaptor(trxContext, "ZGTMMFG39_MES_TO_SAP"); // SAPRFCNameEnum.RFC_DELIVERY_ORDER.GetValue());

            //create parameter for table IT_WERKS
            SAPParameterList sapParameterTableList = sapCommandAdapter.CreateParameterList();

            SAPParameterList sapParameterTable;

            ////multiple PO details set
            //foreach (PoGoodReceiptVo m in pos)
            //{
            //    sapParameterTable = sapCommandAdapter.CreateParameterList();

            //    //DOCU_DATE:DATE, POSTING_DATE:DATE, DELIV_NOTE:CHAR16, BATCH:CHAR10, PO_NUM:CHAR10, ITEM:NUM(5), MATERIAL:CHAR18, QUAN:BCD[7:3], VENDRBATCH:CHAR15
            //    sapParameterTable.AddParameter("DOCU_DATE", m.DocumentDate); //Document date
            //    sapParameterTable.AddParameter("POSTING_DATE", m.PostingDate); //Posting date
            //    sapParameterTable.AddParameter("DELIV_NOTE", m.DeliveryNote); //Delivery Note
            //    sapParameterTable.AddParameter("BATCH", m.Batch); //Batch
            //    sapParameterTable.AddParameter("PO_NUM", m.PurchaseOrderNumber); //PO Number
            //    sapParameterTable.AddParameter("ITEM", m.POItem); //PO Item
            //    sapParameterTable.AddParameter("MATERIAL", m.Material); //Material
            //    sapParameterTable.AddParameter("QUAN", m.Quantity); //Quantity in Unit of Entry
            //    sapParameterTable.AddParameter("VENDRBATCH", m.SupplierLotNo); //Vendor Batch

            //    sapParameterTableList.AddParameterList(sapParameterTable);

            //}

            for (int ii = pos.Count - 1; ii >= 0; ii--)
            {
                sapParameterTable = sapCommandAdapter.CreateParameterList();

                sapParameterTable.AddParameter("DOCU_DATE", pos[ii].DocumentDate); //Document date
                sapParameterTable.AddParameter("POSTING_DATE", pos[ii].PostingDate); //Posting date
                sapParameterTable.AddParameter("DELIV_NOTE", pos[ii].DeliveryNote); //Delivery Note
                sapParameterTable.AddParameter("BATCH", pos[ii].Batch); //Batch
                sapParameterTable.AddParameter("PO_NUM", pos[ii].PurchaseOrderNumber); //PO Number
                sapParameterTable.AddParameter("ITEM", pos[ii].POItem); //PO Item
                sapParameterTable.AddParameter("MATERIAL", pos[ii].Material); //Material
                sapParameterTable.AddParameter("QUAN", pos[ii].Quantity); //Quantity in Unit of Entry
                sapParameterTable.AddParameter("VENDRBATCH", pos[ii].SupplierLotNo); //Vendor Batch

                sapParameterTableList.AddParameterList(sapParameterTable);

            }

            SAPParameterList sapParameter = sapCommandAdapter.CreateParameterList();
            sapParameter.AddParameter("IM_PLANT", ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE.GetValue());
            sapParameter.AddParameter("TB_INPUT", sapParameterTableList);

            SAPFunction sapFuntion = sapCommandAdapter.Execute(trxContext, sapParameter);

            List<SapMessageVo> messageList = new List<SapMessageVo>();
            DataTable sapTable = sapFuntion.GetSAPTable("TB_RETURN");

            PoGoodReceiptVo resultVo = new Vo.PoGoodReceiptVo();

            //get the Return Message data
            resultVo.PoGoodReceiptResultMessageList = new List<SapMessageVo>();

            //if (sapTable != null && sapTable.Rows.Count > 0)
            //{
            //    DataView dv = sapTable.DefaultView;
            //    dv.Sort = "ROW desc";
            //    sapTable = dv.ToTable();
            //}

            foreach (DataRow dr in sapTable.Rows)
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

                message.Parameter = ConvertNull<string>(dr, "PARAMETER");
                message.Row = ConvertNull<string>(dr, "ROW");
                message.Field = ConvertNull<string>(dr, "FIELD");
                message.System = ConvertNull<string>(dr, "SYSTEM");

                resultVo.PoGoodReceiptResultMessageList.Add(message);
            }

            return resultVo;
        }
    }
}
