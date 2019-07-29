using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateGlobalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            GlobalItemVo inVo = (GlobalItemVo)arg;

            GlobalItemVo outVo = new GlobalItemVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_global_item ");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" global_item_name = :globalitemname ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" global_item_id = :globalitemid ");
            sqlQuery.Append(" and factory_cd = :faccd");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            sqlParameter.AddParameterString("globalitemname", inVo.GlobalItemName);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            //execute SQL
            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
