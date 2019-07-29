using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetRoleDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            TransferVo inVo = (TransferVo)vo;
            StringBuilder sql = new StringBuilder();
            TransferVo voNoList = new TransferVo();

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT role_cd FROM m_mes_user_role WHERE user_cd = :user_cd");
            sqlParameter.AddParameterString("user_cd", inVo.RegistrationUserCode);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            string user_cd = sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString();
            inVo.RegistrationUserCode = user_cd;

            return inVo;
        }
    }
}