using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Vo;
using System;

namespace Com.Nidec.Mes.Framework_Batch.Dao
{
    internal class AddBatchProcessDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AddBatchProcessVo inVo = (AddBatchProcessVo)arg;
           
            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into t_batch_process");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" batch_process_cd, ");
            sqlQuery.Append(" is_stop_requested, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :batchprocesscd, ");
            sqlQuery.Append(" :isstoprequested, ");
            sqlQuery.Append(" :registrationusercd, ");
            sqlQuery.Append(" :registrationdatetime, ");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ) ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
           
            sqlParameter.AddParameterString("batchprocesscd", inVo.BatchProcessCode);
            sqlParameter.AddParameter("isstoprequested", inVo.IsStopRequested);
            if (string.IsNullOrEmpty( inVo.RegistrationUserCode))
                sqlParameter.AddParameterString("registrationusercd", trxContext.UserData.UserCode);
            else sqlParameter.AddParameterString("registrationusercd", inVo.RegistrationUserCode);
            if (inVo.RegistrationDateTime == DateTime.MinValue)
                sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            else sqlParameter.AddParameterDateTime("registrationdatetime", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
