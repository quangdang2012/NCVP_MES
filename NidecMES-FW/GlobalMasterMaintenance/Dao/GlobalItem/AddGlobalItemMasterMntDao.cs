using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddGlobalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            GlobalItemVo inVo = (GlobalItemVo)arg;

            GlobalItemVo outVo = null;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_global_item");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" global_item_cd, ");
            sqlQuery.Append(" global_item_name, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append(" VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :globalitemcd, ");
            sqlQuery.Append(" :globalitemname, ");
            sqlQuery.Append(" :registrationusercode, ");
            sqlQuery.Append(" :registrationdatetime, ");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append(" RETURNING global_item_id;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("globalitemcd", inVo.GlobalItemCode);
            sqlParameter.AddParameterString("globalitemname", inVo.GlobalItemName);
            sqlParameter.AddParameterString("registrationusercode", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);


            //execute SQL
            int outId = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;
           
            if (outId > 0)
            {
                outVo = new GlobalItemVo();
                outVo.GlobalItemId = outId;
            }

            return outVo;
        }
    }
}
