using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class AddDrawingDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DrawingVo inVo = (DrawingVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"insert into t_draw(device_cd, draw_id, model_id, machine_id, draw_type,
                        time_record, department, revision, registration_user_cd, 
                        registration_date_time, factory_cd)");
            sql.Append(@"values(:device_cd, :draw_id, :model_id, :machine_id, :draw_type, 
                       now(), :department, :revision, :registration_user_cd, 
                       now(), :factory_cd)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("device_id", inVo.DeviceID);
            sqlParameter.AddParameter("device_cd", inVo.DeviceCode);
            sqlParameter.AddParameter("draw_id", inVo.DrawId);
            sqlParameter.AddParameter("model_id", inVo.ModelId);
            sqlParameter.AddParameter("machine_id", inVo.MachineID);
            sqlParameter.AddParameter("draw_type", inVo.DrawType);
            sqlParameter.AddParameter("time_record", inVo.TimeFrom);
            sqlParameter.AddParameter("department", inVo.Department);
            sqlParameter.AddParameter("revision", inVo.Revision);
            sqlParameter.AddParameter("registration_user_cd", inVo.RegistrationUserCode);
            sqlParameter.AddParameter("registration_date_time", inVo.RegistrationDateTime);
            sqlParameter.AddParameter("factory_cd", inVo.FactoryCode);
            //execute SQL

            DrawingVo outVo = new DrawingVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
