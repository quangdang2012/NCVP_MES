using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckProcessWorkDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorksVo inVo = (ProcessWorksVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as WorkCount from m_process_work");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.ProcessWorkCode != null)
            {
                sqlQuery.Append(" and process_work_cd = :processworkcd");
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

            ProcessWorksVo outVo = new ProcessWorksVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["WorkCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
