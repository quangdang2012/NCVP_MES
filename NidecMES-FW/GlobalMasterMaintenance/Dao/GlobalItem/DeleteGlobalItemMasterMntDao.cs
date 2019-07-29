using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteGlobalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            GlobalItemVo inVo = (GlobalItemVo)arg;        

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_global_item ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" global_item_id = :globalitemid ");
            sqlQuery.Append(" and factory_cd = :faccd ");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            GlobalItemVo outVo = new GlobalItemVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
