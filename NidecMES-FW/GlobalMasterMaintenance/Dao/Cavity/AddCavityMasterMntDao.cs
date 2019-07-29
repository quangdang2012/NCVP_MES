using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddCavityMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CavityVo inVo = (CavityVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_cavity");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" cavity_cd, ");
            sqlQuery.Append(" cavity_name, ");
            sqlQuery.Append(" mold_id, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :cavitycd ,");
            sqlQuery.Append(" :cavityname ,");
            sqlQuery.Append(" :moldid ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :regdatetime ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ); ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("cavitycd", inVo.CavityCode);
            sqlParameter.AddParameterString("cavityname", inVo.CavityName);
            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);

            UserData userdata = trxContext.UserData;

            sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            sqlParameter.AddParameterDateTime("regdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            CavityVo outVo = new CavityVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }


 
    }
}
