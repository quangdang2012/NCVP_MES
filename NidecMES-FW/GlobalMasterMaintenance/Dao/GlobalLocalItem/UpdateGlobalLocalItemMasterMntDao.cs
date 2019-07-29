using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateGlobalLocalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            GlobalLocalItemVo inVo = (GlobalLocalItemVo)arg;

            GlobalLocalItemVo outVo = new GlobalLocalItemVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_global_local_item ");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" global_item_id = :globalitemid ");
             sqlQuery.Append(" Where factory_cd = :faccd ");

            if (inVo.GlobalLocalItemId > 0)
            {
                sqlQuery.Append(" and global_local_item_id = :globallocalitemid ");
            }

            if (inVo.LocalItemId > 0)
            {
                sqlQuery.Append(" and local_item_id = :localitemid ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.GlobalLocalItemId > 0)
            {
                sqlParameter.AddParameterInteger("globallocalitemid", inVo.GlobalLocalItemId);
            }

            if (inVo.LocalItemId > 0)
            {
                sqlParameter.AddParameterInteger("localitemid", inVo.LocalItemId);
            }

            sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            //execute SQL
            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
