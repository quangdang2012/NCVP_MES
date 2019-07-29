using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddUserLocationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UserLocationVo inVo = (UserLocationVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into m_user_location(user_location_cd, user_location_name, dept_cd,  registration_user_cd, registration_date_time, factory_cd) ");
            sql.Append("values(:user_location_cd,:user_location_name, :dept_cd, :registration_user_cd,now(),:factory_cd)");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("user_location_cd", inVo.UserLocationCode);
            sqlParameter.AddParameterString("user_location_name", inVo.UserLocationName);
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
