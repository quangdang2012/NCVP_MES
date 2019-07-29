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
    class SubmitDispatchReportDao : AbstractSAPDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            int totalQty = 0;
            int imCount = 0;

            ValueObjectList<DispatchReportItemDtlVo> LIST = new ValueObjectList<DispatchReportItemDtlVo>();

            //if (vo is ValueObjectList<DispatchReportItemDtlVo>)
            //{
            //    LIST = (ValueObjectList<DispatchReportItemDtlVo>)vo;
            //}
            //else
            //{
            //    LIST.add((DispatchReportItemDtlVo)vo);
            //}

            //create command
            SAPCommandAdapter sapCommandAdapter = base.GetSAPCommandAdaptor(trxContext, "Z_GTSDFG7401_SCAN_DELIVERY"); // SAPRFCNameEnum.RFC_PICKING_LIST.GetValue());

            SAPParameterList sapParameterTableLists = sapCommandAdapter.CreateParameterList();

            DispatchReportItemDtlVo inVo = (DispatchReportItemDtlVo)vo;
            //foreach (DispatchReportItemDtlVo inVo in LIST.GetList())
            //{
            //int pickedQuantity = 0;
            //foreach (DispatchReportItemDtlVo currVo in inVo.DipatchReportItemDetailsList)
            //{
            //    pickedQuantity += currVo.ItemQuantity;
            //}

            //create parameter for table IT_LIPS
            SAPParameterList sapParameterTable = sapCommandAdapter.CreateParameterList();
            //sapParameterTable.AddParameter("SIGN", "I"); //value set from invo
            //sapParameterTable.AddParameter("OPTION", "EQ");
            sapParameterTable.AddParameter("VBELN", ("0000000000" + inVo.DeliveryOrderNo.ToString().Trim()).Substring(("0000000000" + inVo.DeliveryOrderNo.ToString().Trim()).Length - 10, 10));
            sapParameterTable.AddParameter("POSNR", inVo.DeliveryOrderUnit.ToString());
            sapParameterTable.AddParameter("PIKMG", inVo.ItemQuantity.ToString());  // picked quantity
            sapParameterTable.AddParameter("CHARG", inVo.LotNo);  // picked quantity
            sapParameterTable.AddParameter("WADAT_IST", inVo.ActualDeliveryDate.ToString("yyyyMMdd"));  // picked quantity
            sapParameterTable.AddParameter("LGORT", inVo.StorageLocation);  // picked quantity

            sapParameterTableLists.AddParameterList(sapParameterTable);

            //totalQty += pickedQuantity;
            imCount++;
            //}

            //create parameter for table Z_GTSDFG7301_DELIVERY_RFC
            SAPParameterList sapParameter = sapCommandAdapter.CreateParameterList();
            sapParameter.AddParameter("IM_PLANT", ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE.GetValue()); // "1100");
            sapParameter.AddParameter("IM_COUNT", 1);
            sapParameter.AddParameter("IM_TOTAL", inVo.ItemQuantity.ToString());

            sapParameter.AddParameter("IT_LIPS", sapParameterTableLists);

            SAPFunction sapFuntion = sapCommandAdapter.Execute(trxContext, sapParameter);

            DataTable resultMessageTable = sapFuntion.GetSAPTable("ET_RETURN");

            DispatchReportItemDtlVo outVo = new DispatchReportItemDtlVo();
            //             outVo.DeliveryOrderResultMessageList = new List<DeliveryOrderResultMessageVo>();
            outVo.DispatchReportResultMessageList = new List<SapMessageVo>();
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

                outVo.DispatchReportResultMessageList.Add(message);
            }
            return outVo;
        }
    }
}
