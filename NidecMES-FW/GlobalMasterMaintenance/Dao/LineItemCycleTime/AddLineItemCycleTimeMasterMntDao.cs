using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddLineItemCycleTimeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineItemCycleTimeVo inVo = (LineItemCycleTimeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Insert into");
            sqlQuery.Append(" m_line_sap_item ");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" sap_matnr_item_cd, ");
            sqlQuery.Append(" line_id, ");
            sqlQuery.Append(" cycle_time, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append(" Values ");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :sapitemcd, ");
            sqlQuery.Append(" :lineid, ");
            sqlQuery.Append(" :cycletime, ");
            sqlQuery.Append(" :registrationusercd, ");
            sqlQuery.Append(" :registrationdatetime, ");
            sqlQuery.Append(" :factorycd ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("sapitemcd", inVo.SapItemCode);
            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterDecimal("cycletime", inVo.StdCycleTime);
            sqlParameter.AddParameterString("registrationusercd", trxContext.UserData.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
