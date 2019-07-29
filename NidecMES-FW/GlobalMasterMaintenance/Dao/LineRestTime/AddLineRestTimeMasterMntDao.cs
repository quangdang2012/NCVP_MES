using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddLineRestTimeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineRestTimeVo inVo = (LineRestTimeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Insert into");
            sqlQuery.Append(" m_line_rest_time ");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" line_id, ");
            sqlQuery.Append(" shift, ");
            sqlQuery.Append(" plan_rest_minutes, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append(" Values ");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :lineid, ");
            sqlQuery.Append(" :shift, ");
            sqlQuery.Append(" :planrestminutes, ");
            sqlQuery.Append(" :registrationusercd, ");
            sqlQuery.Append(" :registrationdatetime, ");
            sqlQuery.Append(" :factorycd ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterInteger("shift", inVo.Shift);
            sqlParameter.AddParameter("planrestminutes", inVo.PlanRestMinutes);
            sqlParameter.AddParameterString("registrationusercd", trxContext.UserData.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
