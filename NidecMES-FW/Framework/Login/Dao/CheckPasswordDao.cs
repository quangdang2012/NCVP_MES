using System.Text;
using System.Data;
using System;

namespace Com.Nidec.Mes.Framework.Login
{
    public class CheckPasswordDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            ChangePasswordVo inVo = (ChangePasswordVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select count(user_cd) as UserCount from m_login_password");
            sqlQuery.Append(" Where	user_cd = :usercode ");
            sqlQuery.Append(" and ");
            sqlQuery.Append(" password = :password ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter= sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("password", inVo.Password);
            sqlParameter.AddParameterString("usercode", inVo.UserCode);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ChangePasswordVo outVo = new ChangePasswordVo();

            outVo.AffectedCount = 0;

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["UserCount"].ToString());
            }

            dataReader.Close();

            return outVo;
        }
    }
}
