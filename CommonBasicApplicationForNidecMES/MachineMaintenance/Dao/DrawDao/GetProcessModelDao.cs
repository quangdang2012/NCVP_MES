using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetProcessModelDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProcessVo inVo = (ProcessVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProcessVo> voList = new ValueObjectList<ProcessVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT b.process_id, b.process_name from m_process b, m_model_process a where a.process_id = b.process_id and model_id = :model_id order by process_id");


            sqlParameter.AddParameterInteger("model_id", inVo.ProcessId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());



            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProcessVo outVo = new ProcessVo
                {
                    ProcessId = int.Parse(dataReader["process_id"].ToString()),
                    ProcessName = dataReader["process_name"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}