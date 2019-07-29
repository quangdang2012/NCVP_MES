using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchJigRepairInformationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            JigRepairInformationVo inVo = (JigRepairInformationVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<JigRepairInformationVo> voList = new ValueObjectList<JigRepairInformationVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT a.jig_repair_id, a.jig_repair_cd, c.model_name, c.model_cd, b.line_name, g.process_name, e.jig_cause_name, f.jig_response_name,
a.time_from, a.time_to, a.jig_current_status, a.jig_after_repair_status, a.repair_result, a.place,b.line_cd,a.registration_user_cd,a.registration_date_time,a.factory_cd
from t_jig_repair_info a 

left join m_line b on b.line_id = a.line_id
left join m_model c on c.model_id = a.model_id
left join m_process g on g.process_id = a.process_id
left join m_jig_cause e on e.jig_cause_id = a.jig_cause_id
left join m_jig_response f on f.jig_response_id = a.jig_response_id
 WHERE  ");


            sql.Append(@"time_from >= :starttime and  time_from <= :endtime"); //
            sqlParameter.AddParameterDateTime("starttime", inVo.TimeFrom);
            sqlParameter.AddParameterDateTime("endtime", inVo.TimeTo.AddDays(1));

            if (!String.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(" and model_cd =:model_cd ");
                sqlParameter.AddParameterString("model_cd", inVo.ModelCode);
            }
            if (!String.IsNullOrEmpty(inVo.ProcessName))
            {
                sql.Append(" and process_name =:process_name ");
                sqlParameter.AddParameterString("process_name", inVo.ProcessName);
            }
            if (!String.IsNullOrEmpty(inVo.LineCode))
            {
                sql.Append(" and line_cd =:line_cd ");
                sqlParameter.AddParameterString("line_cd", inVo.LineCode);
            }
            if (!String.IsNullOrEmpty(inVo.JigRepairCode))
            {
                sql.Append(" and jig_repair_cd =:jig_repair_cd ");
                sqlParameter.AddParameterString("jig_repair_cd", inVo.JigRepairCode);
            }
            if (!String.IsNullOrEmpty(inVo.JigCauseName))
            {
                sql.Append(" and jig_cause_name = :jig_cause_name ");
                sqlParameter.AddParameterString("jig_cause_name", inVo.JigCauseName);
            }
            if (!String.IsNullOrEmpty(inVo.JigResponseName))
            {
                sql.Append(" and jig_response_name=  :jig_response_name ");
                sqlParameter.AddParameterString("jig_response_name",  inVo.JigResponseName);
            }


            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());



            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                JigRepairInformationVo outVo = new JigRepairInformationVo
                {
                    //  , h., i., k., o.prodution_work_content_name
                    JigRepairId = int.Parse(dataReader["jig_repair_id"].ToString()),
                    JigRepairCode = dataReader["jig_repair_cd"].ToString(),
                    ProcessName = dataReader["process_name"].ToString(),
                    LineCode = dataReader["line_cd"].ToString(),
                    JigCauseName = dataReader["jig_cause_name"].ToString(),
                    JigResponseName = dataReader["jig_response_name"].ToString(),               
                    TimeTo = DateTime.Parse(dataReader["time_to"].ToString()),
                    TimeFrom = DateTime.Parse(dataReader["time_from"].ToString()),
                    ModelName = dataReader["model_name"].ToString(),
                    ModelCode = dataReader["model_cd"].ToString(),
                    JigCurrentStatus = dataReader["jig_current_status"].ToString(),                  
                    JigAfterRepairStatus =(dataReader["jig_after_repair_status"].ToString()),

                    JigRepairResult = dataReader["repair_result"].ToString(),
                    JigPlace = dataReader["place"].ToString(),
                    RegistrationUserCode = dataReader["registration_user_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }


}
