using System.Text;
using Com.Nidec.Mes.Framework;

using System.Data;
using Com.Nidec.Mes.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetProcessWorkDataDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProcessWorksVo  inVo = (ProcessWorksVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProcessWorksVo> voList = new ValueObjectList<ProcessWorksVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select pw.process_work_id, pw.process_work_cd, pw.process_work_name, md.model_cd, pr.process_name, mc.machine_name from m_process_work pw left join m_process pr on pr.process_id = pw.process_id left join m_machine mc on mc.machine_id = pw.machine_id left join m_model md on md.model_id = pw.model_id order by pw.process_work_id");

         //   sqlParameter.AddParameterInteger("model_id", inVo.LineId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            //while (dataReader.Read())
            //{
            //    LineVo outVo = new LineVo
            //    {
            //        LineId = int.Parse(dataReader["line_id"].ToString()),
            //        LineCode = dataReader["line_cd"].ToString()
            //    };
            //    voList.add(outVo);
            //}
            dataReader.Close();
            return voList;
        }

    }

}
