using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemVo inVo = (ItemVo)arg;

            ItemVo outVo = new ItemVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_local_item");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" item_name = :itemname, ");
            sqlQuery.Append(" unit_type = :unittype ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" item_id = :itemid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("itemid", inVo.ItemId);
            sqlParameter.AddParameterString("itemname", inVo.ItemName);
            sqlParameter.AddParameterInteger("unittype", inVo.UnitType);

            //execute SQL
            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
