using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Vo;
using System.Data;

namespace Com.Nidec.Mes.SAPConnector_Client.Dao
{
    public  class SubmitOutBoundDao : AbstractSAPDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            SubmitOutBoundVo inVo = (SubmitOutBoundVo)vo;
            inVo.SubmitOutBoundVoMessageList = new List<SapMessageVo>();
            SubmitOutBoundVo outVo = new SubmitOutBoundVo();
            outVo = inVo;
            outVo.SubmitOutBoundVoMessageList = new List<SapMessageVo>();

            List<SubmitOutBoundVo> pos = new List<SubmitOutBoundVo>();
            pos = inVo.SubmitOutBoundVoList;

            SAPCommandAdapter sapCommandAdapter = base.GetSAPCommandAdaptor(trxContext, "Z_GTPPFG2301_GOODSMVT_CREATE");

            SAPParameterList sapParameterTableList = sapCommandAdapter.CreateParameterList();
            SAPParameterList sapParameterTable;
            //for (int ii = inVo.SubmitOutBoundVoList.Count - 1; ii >= 0; ii--)
            //{
            foreach (SubmitOutBoundVo curVo in pos)
            {
                sapParameterTable = sapCommandAdapter.CreateParameterList();
                sapParameterTable.AddParameter("MATERIAL", curVo.MATERIAL);
                sapParameterTable.AddParameter("PLANT", ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE.GetValue());
                sapParameterTable.AddParameter("STGE_LOC", curVo.STGE_LOC);
                sapParameterTable.AddParameter("BATCH", curVo.BATCH);
                sapParameterTable.AddParameter("MOVE_TYPE", curVo.MOVE_TYPE);
                sapParameterTable.AddParameter("ENTRY_QNT", curVo.ENTRY_QNT);
                sapParameterTable.AddParameter("ENTRY_UOM", curVo.ENTRY_UOM);
                sapParameterTable.AddParameter("MOVE_STLOC", curVo.MOVE_STLOC);
                sapParameterTable.AddParameter("ZROW", curVo.ZROW);
                sapParameterTableList.AddParameterList(sapParameterTable);
            }
            //}
            SAPParameterList sapParameter = sapCommandAdapter.CreateParameterList();
            sapParameter.AddParameter("IM_GOODSMVT_CODE", inVo.IM_GOODSMVT_CODE);
            sapParameter.AddParameter("IM_PSTNG_DATE", inVo.IM_PSTNG_DATE);
            sapParameter.AddParameter("IM_PR_UNAME", trxContext.UserData.UserCode);
            sapParameter.AddParameter("IM_HEADER_TXT", inVo.IM_HEADER_TXT);

            SAPFunction sapFuntion = sapCommandAdapter.Execute(trxContext, sapParameter);

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
                    MessageVariable4 = ConvertNull<string>(dr, "MESSAGE_V4"),
                    Row = ConvertNull<string>(dr, "ROW")
                };
                outVo.SubmitOutBoundVoMessageList.Add(message);
            }

            SapMessageVo message1 = new SapMessageVo();
            message1.Message = sapCommandAdapter.ToString();
            outVo.SubmitOutBoundVoMessageList.Add(message1);

            return outVo;

        }
    }
}
