using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddGlobalLocalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            GlobalLocalItemVo inVo = (GlobalLocalItemVo)arg;

            GlobalLocalItemVo outVo = new GlobalLocalItemVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_global_local_item");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" global_item_id, ");
            sqlQuery.Append(" local_item_id, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append(" VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :globalitemid, ");
            sqlQuery.Append(" :localitemid, ");
            sqlQuery.Append(" :registrationusercode, ");
            sqlQuery.Append(" :registrationdatetime, ");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ) ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            sqlParameter.AddParameterInteger("localitemid", inVo.LocalItemId);
            sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);

            outVo.AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            return outVo;
        }
    }
}
