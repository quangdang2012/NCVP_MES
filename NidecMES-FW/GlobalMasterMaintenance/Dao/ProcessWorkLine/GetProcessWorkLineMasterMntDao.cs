using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetProcessWorkLineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkLineVo inVo = (ProcessWorkLineVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select pwm.process_work_id, pwm.line_id,ls.line_cd,ls.line_name");
            sqlQuery.Append(" from m_processwork_line pwm ");
            sqlQuery.Append(" inner join m_line ls on ls.line_id = pwm.line_id ");
            sqlQuery.Append(" where pwm.factory_cd = :faccd ");


            if (inVo.LineId > 0)
            {
                sqlQuery.Append(" and pwm.line_id = :lineid ");
            }

            if (inVo.ProcessWorkId > 0)
            {
                sqlQuery.Append(" and pwm.process_work_id = :processworkid ");
            }
            if (inVo.LineName != null)
            {
                sqlQuery.Append(" and line_name like :linename ");
            }
            if (inVo.LineCode != null)
            {
                sqlQuery.Append(" and line_cd like :linecode ");
            }

            sqlQuery.Append(" order by line_name ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (!string.IsNullOrEmpty(inVo.FactoryCode))
            {
                sqlParameter.AddParameterString("faccd", inVo.FactoryCode);
            }
            else
            {
                sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            }
            

            if (inVo.LineId > 0)
            {
                sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            }

            if (inVo.ProcessWorkId > 0)
            {
                sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
            }
            if (inVo.LineName != null)
            {
                sqlParameter.AddParameterString("linename", inVo.LineName + "%");
            }
            if (inVo.LineCode != null)
            {
                sqlParameter.AddParameterString("linecode", inVo.LineCode + "%");
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessWorkLineVo outVo = new ProcessWorkLineVo();

            while (dataReader.Read())
            {
                ProcessWorkLineVo currOutVo = new ProcessWorkLineVo
                {
                    ProcessWorkId = Convert.ToInt32(dataReader["process_work_id"]),
                    LineId = Convert.ToInt32(dataReader["line_id"]),
                    LineCode = dataReader["line_cd"].ToString(),
                    LineName = dataReader["line_name"].ToString(),
                };

                outVo.ProcessWorkLineListVo.Add(currOutVo);

            }
            dataReader.Close();

            return outVo;
        } 
    }
}
