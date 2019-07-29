using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemVo inVo = (ItemVo)arg;

            ItemVo outVo = new ItemVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_local_item");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" item_cd, ");
            sqlQuery.Append(" item_name, ");
            sqlQuery.Append(" unit_type,");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :itemcode ,");
            sqlQuery.Append(" :itemname ,");
            sqlQuery.Append(" :unittype ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ) returning item_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("itemcode", inVo.ItemCode);
            sqlParameter.AddParameterString("itemname", inVo.ItemName);
            sqlParameter.AddParameterInteger("unittype", inVo.UnitType);
            sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

            outVo.ItemId = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;

            if (outVo.ItemId > 0)
            {
                outVo.AffectedCount = 1;
            }

            return outVo;
        }
    }
}
