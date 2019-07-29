using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateDrawingDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DrawingVo inVo = (DrawingVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update t_draw set device_cd=:device_cd,
                                           draw_id=:draw_id,
                                           model_id=:model_id,
                                           machine_id=:machine_id,
                                           department=:department,
                                           draw_type=:draw_type,
                                           time_record=:time_record,
                                           revision=:revision");
            sql.Append(" where device_id =:device_id");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("device_id", inVo.DeviceID);
            sqlParameter.AddParameter("device_cd", inVo.DeviceCode);
            sqlParameter.AddParameter("draw_id", inVo.DrawId);
            sqlParameter.AddParameter("model_id", inVo.ModelId);
            sqlParameter.AddParameter("machine_id", inVo.MachineID);
            sqlParameter.AddParameter("department", inVo.Department);
            sqlParameter.AddParameter("draw_type", inVo.DrawType);
            sqlParameter.AddParameter("time_record", inVo.TimeFrom);
            sqlParameter.AddParameter("revision", inVo.Revision);
            sqlParameter.AddParameter("registration_user_cd", inVo.RegistrationUserCode);
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