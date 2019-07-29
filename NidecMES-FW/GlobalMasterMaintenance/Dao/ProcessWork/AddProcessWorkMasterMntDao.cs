using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddProcessWorkMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkVo inVo = (ProcessWorkVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_process_work");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" process_work_cd, ");
            sqlQuery.Append(" process_work_name, ");
            sqlQuery.Append(" process_id, ");
            sqlQuery.Append(" is_phantom,");
            sqlQuery.Append(" line_machine_selection ,");
            sqlQuery.Append(" display_order ,");
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
            sqlQuery.Append(" :linemachineselection ,");
            sqlQuery.Append(" :displayorder ,");
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
            sqlParameter.AddParameterInteger("processid", inVo.ProcessId);
            sqlParameter.AddParameterString("isphantom", inVo.IsPhantom);
            sqlParameter.AddParameterInteger("linemachineselection", inVo.LineMachineSelection);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            sqlParameter.AddParameterString("registrationusercode", inVo.RegistrationUserCode);
            //sqlParameter.AddParameterDateTime("registrationdatetime", inVo.RegistrationDateTime);
            sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);

            ProcessWorkVo outVo = new ProcessWorkVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
