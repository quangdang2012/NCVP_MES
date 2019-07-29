using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddInvertoryTimeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InvertoryVo inVo = (InvertoryVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into m_invertory_time(invertory_time_cd, invertory_time_name, registration_user_cd, registration_date_time, factory_cd) ");
            sql.Append("values(:invertory_time_cd,:invertory_time_name, :registration_user_cd,now(),:factory_cd)");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("invertory_time_cd", inVo.InvertoryTimeCode);
            sqlParameter.AddParameterString("invertory_time_name", inVo.InvertoryTimeName);
        
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            InvertoryVo outVo = new InvertoryVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
