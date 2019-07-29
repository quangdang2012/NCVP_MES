using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteAuthorityControlMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AuthorityControlVo inVo = (AuthorityControlVo)arg;          

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_authority_control");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" authority_control_cd = :authcontcd ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("authcontcd", inVo.AuthorityControlCode);

            AuthorityControlVo outVo = new AuthorityControlVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };
            return outVo;
        }
    }
}
