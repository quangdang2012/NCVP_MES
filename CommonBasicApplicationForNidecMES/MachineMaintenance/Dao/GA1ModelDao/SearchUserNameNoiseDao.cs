using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchUserNameNoiseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            GA1ModelVo outVo = new GA1ModelVo();
            StringBuilder sql = new StringBuilder();
            StringBuilder sqlUpdate = new StringBuilder();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select case when (select count(*) from m_user_location where user_location_cd = :user_location_cd)=1 then (select user_location_name from m_user_location where user_location_cd = :user_location_cd) else 'User ID not found' end ");

            sqlParameter.AddParameterString("user_location_cd", inVo.UserCd);
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            string user = sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString();

            outVo = new GA1ModelVo
            {
                UserName = user,
            };

            return outVo;
        }
    }
}