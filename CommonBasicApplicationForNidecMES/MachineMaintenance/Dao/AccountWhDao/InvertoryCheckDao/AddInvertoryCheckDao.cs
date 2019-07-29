using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddInvertoryCheckDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InvertoryVo inVo = (InvertoryVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into t_invertory_equipments(warehouse_main_id, location_id, invertory_time_id,invertory_value, registration_user_cd, registration_date_time, factory_cd) ");
            sql.Append("values(:warehouse_main_id,:location_id,:invertory_time_id,:invertory_value, :registration_user_cd,now(),:factory_cd)");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("warehouse_main_id", inVo.WarehouseMainId);
            sqlParameter.AddParameterInteger("invertory_time_id", inVo.InvertoryTimeId);
            sqlParameter.AddParameter("invertory_value",bool.Parse( inVo.InvertoryValue.ToString()));
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            sqlParameter.AddParameterInteger("location_id", inVo.LocationID);
            //execute SQL

            InvertoryVo outVo = new InvertoryVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
