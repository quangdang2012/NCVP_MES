using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateUserLocationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UserLocationVo inVo = (UserLocationVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update m_user_location set user_location_cd=:user_location_cd,user_location_name=:user_location_name, dept_cd=:dept_cd");
            sql.Append(" where user_location_id =:user_location_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("user_location_cd", inVo.UserLocationCode);
            sqlParameter.AddParameterString("user_location_name", inVo.UserLocationName);
            sqlParameter.AddParameterInteger("user_location_id", inVo.UserLocationId);
            sqlParameter.AddParameterString("dept_cd", inVo.DeptCode);
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            UserLocationVo outVo = new UserLocationVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
