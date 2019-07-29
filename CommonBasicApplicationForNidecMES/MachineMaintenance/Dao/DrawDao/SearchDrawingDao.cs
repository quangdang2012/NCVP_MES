using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchDrawingDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DrawingVo inVo = (DrawingVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<DrawingVo> voList = new ValueObjectList<DrawingVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT a.device_id, a.device_cd, b.draw_cd, c.model_cd, d.machine_name, a.time_record,
a.department, a.revision, a.registration_user_cd,a.registration_date_time, a.registration_user_cd, a.factory_cd 
from t_draw a 

left join m_draw b on b.draw_id = a.draw_id
left join m_model c on c.model_id = a.model_id
left join m_machine d on d.machine_id = a.machine_id
 WHERE ");


            sql.Append(@"time_record >= :timefrom");
            sqlParameter.AddParameterDateTime("timefrom", inVo.TimeFrom);

            sql.Append(" and time_record <= :timeto");
            sqlParameter.AddParameterDateTime("timeto", inVo.TimeTo);

            if (!String.IsNullOrEmpty(inVo.DeviceCode))
            {
                sql.Append(" and device_cd =:device_cd ");
                sqlParameter.AddParameterString("device_cd", inVo.DeviceCode);
            }
            if (!String.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(" and model_cd =:model_cd ");
                sqlParameter.AddParameterString("model_cd", inVo.ModelCode);
            }
            if (!String.IsNullOrEmpty(inVo.DrawCode))
            {
                sql.Append(" and draw_cd =:draw_cd ");
                sqlParameter.AddParameterString("draw_cd", inVo.DrawCode);
            }
            if (!String.IsNullOrEmpty(inVo.MachineName))
            {
                sql.Append(" and machine_name =:machine_name ");
                sqlParameter.AddParameterString("machine_name", inVo.MachineName);
            }
            if (!String.IsNullOrEmpty(inVo.Department))
            {
                sql.Append(" and department =:department ");
                sqlParameter.AddParameterString("department", inVo.Department);
            }
            if (!String.IsNullOrEmpty(inVo.Revision))
            {
                sql.Append(" and revision =:revision ");
                sqlParameter.AddParameterString("revision", inVo.Revision);
            }
            if (!String.IsNullOrEmpty(inVo.DrawType))
            {
                sql.Append(" and draw_type =:draw_type ");
                sqlParameter.AddParameterString("draw_type", inVo.DrawType);
            }
            if (!String.IsNullOrEmpty(inVo.RegistrationUserCode))
            {
                sql.Append(" and a.registration_user_cd =:registration_user_cd ");
                sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            }

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());



            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DrawingVo outVo = new DrawingVo
                {
                    //  , h., i., k., o.prodution_work_content_name
                    DeviceID = int.Parse(dataReader["device_id"].ToString()),
                    DeviceCode = dataReader["device_cd"].ToString(),
                    DrawCode = dataReader["draw_cd"].ToString(),
                    MachineName = dataReader["machine_name"].ToString(),
                    Department = dataReader["department"].ToString(),
                    RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                    TimeFrom = DateTime.Parse(dataReader["time_record"].ToString()),
                    ModelCode = dataReader["model_cd"].ToString(),                 
                    Revision = dataReader["revision"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }


}
