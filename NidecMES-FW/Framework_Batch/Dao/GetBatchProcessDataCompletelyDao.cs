using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Vo;
using System.Data;
using System;

namespace Com.Nidec.Mes.Framework_Batch.Dao
{
    internal class GetBatchProcessDataCompletelyDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            AddBatchProcessVo inVo = (AddBatchProcessVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("SELECT ");
            sqlQuery.Append(" batch_process_id,");
            sqlQuery.Append(" batch_process_cd,is_stop_requested, ");
            sqlQuery.Append(" registration_user_cd,");
            sqlQuery.Append(" registration_date_time ");
            sqlQuery.Append(" FROM t_batch_process ");
            sqlQuery.Append(" WHERE factory_cd = :factorycd ");
            sqlQuery.Append(" order by is_stop_requested, batch_process_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //sqlParameter.AddParameterString("batchprocesscd", inVo.BatchProcessCode);
            sqlParameter.AddParameterString("factorycd", trxContext.UserData.FactoryCode);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<AddBatchProcessVo> outVo = new ValueObjectList<AddBatchProcessVo>();

            while (dataReader.Read())
            {
                AddBatchProcessVo imVo = new AddBatchProcessVo();
                imVo.BatchProcessId = ConvertDBNull<int>(dataReader, "batch_process_id");
                imVo.BatchProcessCode = ConvertDBNull<string>(dataReader, "batch_process_cd");
                imVo.IsStopRequested = ConvertDBNull<bool>(dataReader, "is_stop_requested");
                imVo.RegistrationUserCode = ConvertDBNull<string>(dataReader, "registration_user_cd");
                imVo.RegistrationDateTime = ConvertDBNull<DateTime>(dataReader, "registration_date_time");
                outVo.add(imVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
