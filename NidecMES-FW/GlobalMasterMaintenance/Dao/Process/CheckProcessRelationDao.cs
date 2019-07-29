using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckProcessRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessVo inVo = (ProcessVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select pr.process_cd, pw.process_work_id"); // up.process_id as UserProcessId, 
            sqlQuery.Append(" from m_process pr");
            //sqlQuery.Append(" left outer join m_user_process up on up.process_id = pr.process_id");
            sqlQuery.Append(" left outer join m_process_work pw on pw.process_id = pr.process_id");
            sqlQuery.Append(" where pr.factory_cd = :factcd ");

            if (inVo.ProcessCode != null)
            {
                sqlQuery.Append(" and UPPER(process_cd) = UPPER(:processcd)");
            }
                        
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            if (inVo.ProcessCode != null)
            {
                sqlParameter.AddParameterString("processcd", inVo.ProcessCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessVo outVo = new ProcessVo();

            while (dataReader.Read())
            {
                //outVo.UserProcessId = Convert.ToInt32("0" + dataReader["UserProcessId"]);
                outVo.ProcessWorkId = Convert.ToInt32("0" + dataReader["process_work_id"]);
            }

            dataReader.Close();

            return outVo;
        } 
    }
}
