using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteGlobalLocalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            GlobalLocalItemVo inVo = (GlobalLocalItemVo)arg;        

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_global_local_item ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" local_item_id = :localitemid ");
            sqlQuery.Append(" and factory_cd = :faccd ");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("localitemid", inVo.LocalItemId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            GlobalLocalItemVo outVo = new GlobalLocalItemVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
