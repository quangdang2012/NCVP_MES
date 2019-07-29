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
    class GetPurchaseOrderDao : AbstractSAPDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            PurchaseOrderInVo inVo = (PurchaseOrderInVo)vo;

            //create command
            SAPCommandAdapter sapCommandAdapter = base.GetSAPCommandAdaptor(trxContext, "ZGTMMFG38_MES_SAP_INBOUND"); // SAPRFCNameEnum.RFC_DELIVERY_ORDER.GetValue());

            SAPParameterList sapParameterTableInput = sapCommandAdapter.CreateParameterList();

            SAPParameterList sapParameter;

            //create parameter for TABLES TB_LIFNR: STRUCTURE ZGTMMS62,
            if (inVo.LIFNRValueList != null && inVo.LIFNRValueList.Count > 0)
            {
                SAPParameterList sapParameterTableLIFNR = sapCommandAdapter.CreateParameterList();
                foreach (String value in inVo.LIFNRValueList)
                {
                    sapParameter = sapCommandAdapter.CreateParameterList();
                    sapParameter.AddParameter("LIFNR", value);

                    sapParameterTableLIFNR.AddParameterList(sapParameter);
                }
                sapParameterTableInput.AddParameter("TB_LIFNR", sapParameterTableLIFNR);
            }



            //create parameter for TABLES TB_EBELN: STRUCTURE ZGTMMS63,
            if (inVo.EBELNValueList != null && inVo.EBELNValueList.Count > 0)
            {
                SAPParameterList sapParameterTableEBELN = sapCommandAdapter.CreateParameterList();
                foreach (String value in inVo.EBELNValueList)
                {
                    sapParameter = sapCommandAdapter.CreateParameterList();
                    sapParameter.AddParameter("EBELN", value);

                    sapParameterTableEBELN.AddParameterList(sapParameter);
                }
                sapParameterTableInput.AddParameter("TB_EBELN", sapParameterTableEBELN);
            }

            //create parameter for TABLES TB_MATNR: STRUCTURE ZGTMMS64,
            if (inVo.MATNRValueList != null && inVo.MATNRValueList.Count > 0)
            {
                SAPParameterList sapParameterTableMATNR = sapCommandAdapter.CreateParameterList();
                foreach (String value in inVo.MATNRValueList)
                {
                    sapParameter = sapCommandAdapter.CreateParameterList();
                    sapParameter.AddParameter("MATNR", value);

                    sapParameterTableMATNR.AddParameterList(sapParameter);
                }
                sapParameterTableInput.AddParameter("TB_MATNR", sapParameterTableMATNR);
            }

            //create parameter for TABLES TB_BEDAT_RANGE:STRUCTURE ZGTMMS65,
            if (!string.IsNullOrEmpty(inVo.BEFromDate) && !string.IsNullOrEmpty(inVo.BEToDate))
            {
                SAPParameterList sapParameterTableBEDATRANGE = sapCommandAdapter.CreateParameterList();
                sapParameterTableBEDATRANGE.AddParameter("SIGN", "I");
                sapParameterTableBEDATRANGE.AddParameter("OPTION", "BT");
                sapParameterTableBEDATRANGE.AddParameter("LOW", inVo.BEFromDate);
                sapParameterTableBEDATRANGE.AddParameter("HIGH", inVo.BEToDate);
                sapParameterTableInput.AddParameter("TB_BEDAT_RANGE", sapParameterTableBEDATRANGE);
            }
            //create parameter for TABLES TB_EINDT_RANGE: STRUCTURE ZGTMMS65,
            if (!string.IsNullOrEmpty(inVo.EINFromDate) && !string.IsNullOrEmpty(inVo.EINToDate))
            {
                SAPParameterList sapParameterTableEINDTRANGE = sapCommandAdapter.CreateParameterList();
                sapParameterTableEINDTRANGE.AddParameter("SIGN", "I");
                sapParameterTableEINDTRANGE.AddParameter("OPTION", "BT");
                sapParameterTableEINDTRANGE.AddParameter("LOW", inVo.EINFromDate);
                sapParameterTableEINDTRANGE.AddParameter("HIGH", inVo.EINToDate);
                sapParameterTableInput.AddParameter("TB_EINDT_RANGE", sapParameterTableEINDTRANGE);
            }

            sapParameterTableInput.AddParameter("IM_WERKS", ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE.GetValue());
            sapParameterTableInput.AddParameter("IM_STATUS", inVo.Status);

            SAPFunction sapFuntion = sapCommandAdapter.Execute(trxContext, sapParameterTableInput);

            //PO Count Value
            string POCount = sapFuntion.GetSAPValue("EX_COUNT");

            //PO INFO table data
            DataTable headerTable = sapFuntion.GetSAPTable("TB_OUTDATA");

            // result message table data
            DataTable resultMessageTable = sapFuntion.GetSAPTable("TB_RETURN");

            PurchaseOrderDataVo outVo = new PurchaseOrderDataVo();

            // get the Header data
            foreach (DataRow dr in headerTable.Rows)
            {
                PurchaseOrderDataVo curroutVo = new PurchaseOrderDataVo();
                curroutVo.AFNAM = ConvertNull<string>(dr, "AFNAM");
                curroutVo.AMTLC = decimal.Parse(string.IsNullOrEmpty((ConvertNull<string>(dr, "AMTLC")).ToString().Trim()) ? "0" : (ConvertNull<string>(dr, "AMTLC")).ToString().Replace(",", ""));
                try
                {
                    curroutVo.BEDAT = DateTime.Parse(ConvertNull<string>(dr, "BEDAT"));
                }
                catch
                {
                    curroutVo.BEDAT = DateTime.MinValue;
                }
                curroutVo.BISMT = ConvertNull<string>(dr, "BISMT");
                try
                {
                    curroutVo.BUDAT = DateTime.Parse(ConvertNull<string>(dr, "BUDAT"));
                }
                catch
                {
                    curroutVo.BUDAT = DateTime.MinValue;
                }
                curroutVo.EBELN = ConvertNull<string>(dr, "EBELN");
                curroutVo.EBELP = ConvertNull<string>(dr, "EBELP");
                try
                {
                    curroutVo.EINDT = DateTime.Parse(ConvertNull<string>(dr, "EINDT"));
                }
                catch
                {
                    curroutVo.EINDT = DateTime.MinValue;
                }
                curroutVo.EKNAM = ConvertNull<string>(dr, "EKNAM");
                curroutVo.ESTKZ_DESC = ConvertNull<string>(dr, "ESTKZ_DESC");
                curroutVo.LGPBE = ConvertNull<string>(dr, "LGPBE");
                curroutVo.LIFNR = ConvertNull<string>(dr, "LIFNR");
                curroutVo.MAKTX = ConvertNull<string>(dr, "MAKTX");
                curroutVo.MATNR = ConvertNull<string>(dr, "MATNR");
                curroutVo.MEINS = ConvertNull<string>(dr, "MEINS");
                curroutVo.MENGE = decimal.Parse(string.IsNullOrEmpty((ConvertNull<string>(dr, "MENGE")).ToString().Trim()) ? "0" : (ConvertNull<string>(dr, "MENGE")).ToString().Replace(",", ""));
                curroutVo.NAME1 = ConvertNull<string>(dr, "NAME1");
                curroutVo.NETWR = decimal.Parse(string.IsNullOrEmpty((ConvertNull<string>(dr, "NETWR")).ToString().Trim()) ? "0" : (ConvertNull<string>(dr, "NETWR")).ToString().Replace(",", ""));
                curroutVo.OPENQ = decimal.Parse(string.IsNullOrEmpty((ConvertNull<string>(dr, "OPENQ")).ToString().Trim()) ? "0" : (ConvertNull<string>(dr, "OPENQ")).ToString().Replace(",", ""));
                curroutVo.OPNAMTLC = decimal.Parse(string.IsNullOrEmpty((ConvertNull<string>(dr, "OPNAMTLC")).ToString().Trim()) ? "0" : (ConvertNull<string>(dr, "OPNAMTLC")).ToString().Replace(",", ""));
                curroutVo.PEINH = decimal.Parse(string.IsNullOrEmpty((ConvertNull<string>(dr, "PEINH")).ToString().Trim()) ? "0" : (ConvertNull<string>(dr, "PEINH")).ToString().Replace(",", ""));
                curroutVo.STATUS = ConvertNull<string>(dr, "STATUS");
                curroutVo.UNITP = decimal.Parse(string.IsNullOrEmpty((ConvertNull<string>(dr, "UNITP")).ToString().Trim()) ? "0" : (ConvertNull<string>(dr, "UNITP")).ToString().Replace(",", ""));
                curroutVo.VERSG = ConvertNull<string>(dr, "VERSG");
                curroutVo.WAERS = ConvertNull<string>(dr, "WAERS");
                curroutVo.WAERS_L  = ConvertNull<string>(dr, "WAERS_L");
                curroutVo.WEMNG = decimal.Parse(string.IsNullOrEmpty((ConvertNull<string>(dr, "WEMNG")).ToString().Trim()) ? "0" : (ConvertNull<string>(dr, "WEMNG")).ToString().Replace(",", ""));
                curroutVo.WRBTR = decimal.Parse(string.IsNullOrEmpty((ConvertNull<string>(dr, "WRBTR")).ToString().Trim()) ? "0" : (ConvertNull<string>(dr, "WRBTR")).ToString().Replace(",", ""));
                curroutVo.XBLNR = ConvertNull<string>(dr, "XBLNR");
                curroutVo.ZAD_NAME = ConvertNull<string>(dr, "ZAD_NAME");

                if (outVo.PurchaseOrderDataList == null)
                {
                    outVo.PurchaseOrderDataList = new List<PurchaseOrderDataVo>();
                }
                outVo.PurchaseOrderDataList.Add(curroutVo);
            }

            //get the Return Message data
            outVo.PurchaseOrderResultMessageList = new List<SapMessageVo>();
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

                message.Parameter = ConvertNull<string>(dr, "PARAMETER");
                message.Row = ConvertNull<string>(dr, "ROW");
                message.Field = ConvertNull<string>(dr, "FIELD");
                message.System = ConvertNull<string>(dr, "SYSTEM");

                outVo.PurchaseOrderResultMessageList.Add(message);
            }
            return outVo;
        }
    }
}
