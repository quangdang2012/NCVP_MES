using System;
using System.Collections.Generic;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.PQMConnector_Client.Vo;
using System.Globalization;

namespace Com.Nidec.Mes.PQMConnector_Client.Dao
{
    class GetMaterialDao : AbstractPQMDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            PqmMaterialVo inVo = (PqmMaterialVo)vo;

            //create command
            PQMCommandAdapter pqmCommandAdapter = base.GetPQMCommandAdaptor(trxContext, ServerConfigurationDataTypeEnum.DEFAULT_PQM_CONFIG_URL.GetValue()); // "http://10.78.224.21/pqmv4-mes/mes");// PQMWebServiceNameEnum.SAMPLE_SERVICE_MODEL.GetValue());

            PQMParameterList pqmParameter = pqmCommandAdapter.CreateParameterList();
            pqmParameter.AddParameter("cmd", "MT01");  //inVo.Cmd);
            pqmParameter.AddParameter("model", inVo.Model); // "model01");
            pqmParameter.AddParameter("mo", inVo.MONumber); // "M01P11C1001");
            pqmParameter.AddParameter("line", "%2A"); //inVo.Line);
            pqmParameter.AddParameter("partno", "%2A"); // inVo.PartNo);
            pqmParameter.AddParameter("from", inVo.StartTime.ToString("yyyyMMddHHmmss")); // "20170101000000");
            pqmParameter.AddParameter("to", inVo.FinishTime.ToString("yyyyMMddHHmmss")); // "20181231235959");
            pqmParameter.AddParameter("ex", "1");

            DataTable pqmTable = pqmCommandAdapter.Execute(trxContext, pqmParameter);


            PqmMaterialVo outVo = new PqmMaterialVo();

            foreach (DataRow dr in pqmTable.Rows)
            {
                PqmMaterialVo currOutVo = new PqmMaterialVo();
                currOutVo.Model = ConvertNull<string>(dr, "model");
                currOutVo.MONumber = ConvertNull<string>(dr, "mo");
                currOutVo.Line = ConvertNull<string>(dr, "line");
                currOutVo.PartNo = ConvertNull<string>(dr, "partno");
                currOutVo.LotNo = ConvertNull<string>(dr, "lotno");
                currOutVo.Quantity = Convert.ToInt32(ConvertNull<string>(dr, "num"));
                currOutVo.StartTime = inVo.StartTime;
                currOutVo.FinishTime = inVo.FinishTime;
                currOutVo.InputTime = DateTime.ParseExact(dr["firstintime"].ToString(), "yyyyMMddHHmmss", CultureInfo.InvariantCulture);
                outVo.PqmMaterialListVo.Add(currOutVo);
            }

            return outVo;

        }
    }
}
