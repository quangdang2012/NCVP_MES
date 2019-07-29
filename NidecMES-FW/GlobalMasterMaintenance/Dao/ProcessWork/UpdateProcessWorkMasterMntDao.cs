using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateProcessWorkMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkVo inVo = (ProcessWorkVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_process_work");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" process_work_name = :processworkname, ");
            sqlQuery.Append(" process_id = :processid, ");
            sqlQuery.Append(" is_phantom = :isphantom, ");
            sqlQuery.Append(" line_machine_selection  = :linemachineselection, ");
            sqlQuery.Append(" display_order  = :displayorder ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" process_work_id = :processworkid");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            


            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
            sqlParameter.AddParameterString("processworkname", inVo.ProcessWorkName);
            sqlParameter.AddParameterInteger("processid", inVo.ProcessId);
            sqlParameter.AddParameterString("isphantom", inVo.IsPhantom);
            sqlParameter.AddParameterInteger("linemachineselection", inVo.LineMachineSelection);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            ProcessWorkVo outVo = new ProcessWorkVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
