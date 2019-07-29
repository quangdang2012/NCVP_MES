using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetProcessWorkMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ProcessWorkVo inVo = (ProcessWorkVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select pw.process_work_id, pw.process_work_cd, pw.process_work_name, pw.is_phantom, pw.line_machine_selection, pw.display_order, ");
            sqlQuery.Append(" CASE pw.is_phantom WHEN '1' THEN 'Phantom'");
            sqlQuery.Append(" WHEN '0' THEN 'Standard' End as phantom_value, ");
            sqlQuery.Append(" pc.process_id, pc.process_cd, pc.process_name ");
            sqlQuery.Append(" from m_process_work pw ");
            sqlQuery.Append("inner join m_process pc on pc.process_id = pw.process_id ");
            sqlQuery.Append(" where pw.factory_cd = :factcd ");

            if (inVo.ProcessWorkId > 0)
            {
                sqlQuery.Append(" and pw.process_work_id = :processworkid ");
            }

            if (inVo.ProcessWorkCode != null)
            {
                sqlQuery.Append(" and pw.process_work_cd like :processworkcd ");
            }

            if (inVo.ProcessWorkName != null)
            {
                sqlQuery.Append(" and pw.process_work_name like :processworkname ");
            }
            if (inVo.ProcessId != 0)
            {
                sqlQuery.Append(" and pc.process_id = :processid ");
            }
            sqlQuery.Append(" order by pw.process_work_id");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            if (inVo.ProcessWorkId > 0)
            {
                sqlParameter.AddParameterInteger("processworkid", inVo.ProcessWorkId);
            }

            if (inVo.ProcessWorkCode != null)
            {
                sqlParameter.AddParameterString("processworkcd", inVo.ProcessWorkCode + "%");
            }

            if (inVo.ProcessWorkName != null)
            {
                sqlParameter.AddParameterString("processworkname", inVo.ProcessWorkName + "%");
            }

            if (inVo.ProcessId != 0)
            {
                sqlParameter.AddParameterInteger("processid", inVo.ProcessId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ProcessWorkVo outVo = new ProcessWorkVo();

           
            while (dataReader.Read())
            {
                ProcessWorkVo currOutVo = new ProcessWorkVo();
                {
                    currOutVo.ProcessWorkId = ConvertDBNull<int>(dataReader, "process_work_id");
                    currOutVo.ProcessWorkCode = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["process_work_cd"]);
                    currOutVo.ProcessWorkName = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["process_work_name"]);
                    currOutVo.ProcessId = ConvertDBNull<int>(dataReader, "process_id");
                    currOutVo.ProcessCode = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["process_cd"]);
                    currOutVo.ProcessName = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["process_name"]);
                    currOutVo.IsPhantom = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["is_phantom"]);
                    currOutVo.IsPhantomDisplay = DBDataCheckHelper.ConvertDBNullToStringNull(dataReader["phantom_value"]);
                    currOutVo.LineMachineSelection = ConvertDBNull<int>(dataReader, "line_machine_selection");
                    currOutVo.DisplayOrder = ConvertDBNull<int>(dataReader, "display_order");
                }
                outVo.ProcessWorkListVo.Add(currOutVo);

            }
            dataReader.Close();

            return outVo;
        } 
    }
}
