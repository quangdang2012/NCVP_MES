using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckItemProcessWorkMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkVo inVo = (ProcessWorkVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as WorkCount from m_process_work");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.ProcessWorkCode != null)
            {
                sqlQuery.Append(" and UPPER(process_work_cd) = UPPER(:processworkcd)");
            }
           
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.ProcessWorkCode != null)
            {
                sqlParameter.AddParameterString("processworkcd", inVo.ProcessWorkCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessWorkVo outVo = new ProcessWorkVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["WorkCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
