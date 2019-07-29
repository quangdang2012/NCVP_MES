using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckPermissionDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ReportDownTimeVo inVo = (ReportDownTimeVo)vo;
            StringBuilder sql = new StringBuilder();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("SELECT count(role_cd) as RoleCount from m_mes_user_role where user_cd = :user_cd and role_cd = 'dwntfix'");

            sqlParameter.AddParameterString("user_cd", inVo.RegistrationUserCode);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ReportDownTimeVo outVo = new ReportDownTimeVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["RoleCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }

}
