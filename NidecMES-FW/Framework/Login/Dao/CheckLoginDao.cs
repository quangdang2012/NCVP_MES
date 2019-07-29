using System;
using System.Text;
using System.Data;

namespace Com.Nidec.Mes.Framework.Login
{
    class CheckLoginDao : AbstractDataAccessObject
    {

        /// <summary>
        /// Execute the query
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            LoginInVo inVo = (LoginInVo)vo;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" select Count(*) userCount");
            sqlQuery.Append(" from m_login_password lp");
            sqlQuery.Append(" inner join m_mes_user usr on usr.user_cd = lp.user_cd ");
            sqlQuery.Append(" inner join m_user_factory usrfac on usr.user_cd = usrfac.user_cd ");
            sqlQuery.Append(" inner join m_factory fac on usrfac.factory_cd = fac.factory_cd ");
            sqlQuery.Append(" where usr.user_cd = :usercode ");
            sqlQuery.Append(" and lp.password = :password ; ");

            LoginOutVo outVo = new LoginOutVo();

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("usercode", inVo.InputUserId);
            sqlParameter.AddParameter("password", inVo.InputPassword);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext,sqlParameter);

            while (dataReader.Read())
            {
                outVo.ResultCount = Convert.ToInt32(dataReader["userCount"]);

            }

            dataReader.Close();
            return outVo;
        }
    }
}
