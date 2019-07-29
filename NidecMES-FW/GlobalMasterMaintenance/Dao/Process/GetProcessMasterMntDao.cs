using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetProcessMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessVo inVo = (ProcessVo)arg;

            ProcessVo outVo = new ProcessVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select * from m_process ");
            sqlQuery.Append(" where factory_cd = :factcd ");

            if (inVo.ProcessCode != null)
            {
                sqlQuery.Append(" and process_cd like :processcd ");
            }

            if (inVo.ProcessName != null)
            {
                sqlQuery.Append(" and process_name like :processname ");
            }
            //if (inVo.NextPocessCode != null)
            //{
            //    sqlQuery.Append(" and next_process_cd like :nextprocesscd ");
            //}
            sqlQuery.Append(" order by process_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            if (inVo.ProcessCode != null)
            {
                sqlParameter.AddParameterString("processcd", inVo.ProcessCode + "%");
            }

            if (inVo.ProcessName != null)
            {
                sqlParameter.AddParameterString("processname", inVo.ProcessName + "%");
            }

            //if (inVo.NextPocessCode != null)
            //{
            //    sqlParameter.AddParameterString("nextprocesscd", inVo.NextPocessCode + "%");
            //}

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProcessVo currOutVo = new ProcessVo
                {
                    ProcessId = Convert.ToInt32(dataReader["process_id"]),
                    ProcessCode = dataReader["process_cd"].ToString(),
                    ProcessName = dataReader["process_name"].ToString()
                    //NextPocessCode = dataReader["next_process_cd"].ToString()
                };

                outVo.ProcessListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
