using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class UpdateLineItemCycleTimeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineItemCycleTimeVo inVo = (LineItemCycleTimeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Update m_line_sap_item");
            sqlQuery.Append(" Set cycle_time = :stdcycletime, ");
            sqlQuery.Append(" registration_user_cd = :registrationusercd, ");
            sqlQuery.Append(" registration_date_time = :registrationdatetime ");
            sqlQuery.Append(" Where factory_cd = :factcode");
            sqlQuery.Append("   and line_sap_item_id = :lineitemcycletimeid ");
            //sqlQuery.Append("   and line_id = :lineid ");
            //sqlQuery.Append("   and sap_item_cd = :sapitemcd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
           
            sqlParameter.AddParameterDecimal("stdcycletime", inVo.StdCycleTime);
            sqlParameter.AddParameterInteger("lineitemcycletimeid", inVo.LineItemCycleTimeId);
            sqlParameter.AddParameterString("registrationusercd", trxContext.UserData.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factcode", trxContext.UserData.FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
