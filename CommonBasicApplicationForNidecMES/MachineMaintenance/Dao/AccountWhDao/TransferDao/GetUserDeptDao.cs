using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetUserDeptDao : AbstractDataAccessObject
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
            sql.Append(@"select dept_cd from m_user_location where user_location_name = :user_location_name");
            sqlParameter.AddParameterString("user_location_name", inVo.UserName);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            string dept_cd = sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString();
            inVo.DeptCD = dept_cd;

            return inVo;
        }
    }
}