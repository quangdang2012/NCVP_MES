using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetAllProcessWorkDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorksVo inVo = (ProcessWorksVo)arg;
            StringBuilder sqlQuery = new StringBuilder();
            ValueObjectList<ProcessWorksVo> voList = new ValueObjectList<ProcessWorksVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlQuery.Append("Select pw.process_work_id, pw.process_work_cd, pw.process_work_name, md.model_cd, pr.process_name, mc.machine_name from m_process_work pw left join m_process pr on pr.process_id = pw.process_id left join m_machine mc on mc.machine_id = pw.machine_id left join m_model md on md.model_id = pw.model_id where 1 = 1");

            if (!String.IsNullOrEmpty(inVo.ProcessWorkCode))
            {
                sqlQuery.Append(" and pw.process_work_cd like :processworkcd ");
                sqlParameter.AddParameterString("processworkcd", "%" + inVo.ProcessWorkCode + "%");
            }

            if (!String.IsNullOrEmpty(inVo.ProcessWorkName))
            {
                sqlQuery.Append(" and pw.process_work_name like :processworkname ");
                sqlParameter.AddParameterString("processworkname", "%" + inVo.ProcessWorkName + "%");
            }
            if (inVo.MachineID != 0)
            {
                sqlQuery.Append(" and mc.machine_id = :machine_id ");
                sqlParameter.AddParameterInteger("machine_id", inVo.MachineID);
            }
            sqlQuery.Append(" order by pw.process_work_id");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
           
            while (dataReader.Read())
            {
                ProcessWorksVo OutVo = new ProcessWorksVo();
                {
                    OutVo.ProcessWorkId = ConvertDBNull<int>(dataReader, "process_work_id");
                    OutVo.ProcessWorkCode = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["process_work_cd"]);
                    OutVo.ProcessWorkName = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["process_work_name"]);
                    OutVo.Assy = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["process_name"]);
                    OutVo.Model = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["model_cd"]);
                    OutVo.Machine = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["machine_name"]);
                }
                voList.add(OutVo);
            }
            dataReader.Close();
            return voList;
        } 
    }
}
