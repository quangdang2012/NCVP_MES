using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddProcessWorkDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorksVo inVo = (ProcessWorksVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_process_work");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" process_work_cd, ");
            sqlQuery.Append(" process_work_name, ");
            sqlQuery.Append(" process_id, ");
            sqlQuery.Append(" is_phantom,");
            sqlQuery.Append(" model_id ,");
            sqlQuery.Append(" machine_id ,");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :processworkcd ,");
            sqlQuery.Append(" :processworkname ,");
            sqlQuery.Append(" :processid ,");
            sqlQuery.Append(" :isphantom ,");
            sqlQuery.Append(" :modelid ,");
            sqlQuery.Append(" :machineid ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("processworkcd", inVo.ProcessWorkCode);
            sqlParameter.AddParameterString("processworkname", inVo.ProcessWorkName);
            sqlParameter.AddParameterInteger("processid", inVo.AssyID);
            sqlParameter.AddParameterString("isphantom", inVo.IsPhantom);
            sqlParameter.AddParameterInteger("modelid", inVo.ModelID);
            sqlParameter.AddParameterInteger("machineid", inVo.MachineID);
            sqlParameter.AddParameterString("registrationusercode", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);

            ProcessWorksVo outVo = new ProcessWorksVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
