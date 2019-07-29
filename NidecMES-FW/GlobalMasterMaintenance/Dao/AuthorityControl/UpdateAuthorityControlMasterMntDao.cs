using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateAuthorityControlMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AuthorityControlVo inVo = (AuthorityControlVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_authority_control");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" authority_control_name = :authcontname ");

            //if (inVo.ParentControlCode != null)
            //{
                sqlQuery.Append(" , ");
                sqlQuery.Append(" parent_control_cd = :parentcontcd ");
            //}
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" authority_control_cd = :authcontcd ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("authcontcd", inVo.AuthorityControlCode);
            sqlParameter.AddParameterString("authcontname", inVo.AuthorityControlName);

            if (inVo.ParentControlCode != null)
            {
                sqlParameter.AddParameterString("parentcontcd", inVo.ParentControlCode);
            }
            else
            {
                sqlParameter.AddParameter("parentcontcd", DBNull.Value);
            }

            AuthorityControlVo outVo = new AuthorityControlVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };
            return outVo;
        }
    }
}
