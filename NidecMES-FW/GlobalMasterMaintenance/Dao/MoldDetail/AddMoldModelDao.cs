using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Text;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class AddMoldModelDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldModelVo inVo = (MoldModelVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_gtrs_mold_model");
            sqlQuery.Append(" ( ");
            sqlQuery.Append("   mold_id, ");
            sqlQuery.Append("   model_id, ");
            sqlQuery.Append("   registration_user_cd, ");
            sqlQuery.Append("   registration_date_time, ");
            sqlQuery.Append("   factory_cd ) ");
            sqlQuery.Append(" values (");
            sqlQuery.Append("   :moldid , ");
            sqlQuery.Append("   :modelid , ");
            sqlQuery.Append("   :registrationusercode , ");
            sqlQuery.Append("   :registrationdatetime , ");
            sqlQuery.Append("   :factorycode );  ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            sqlParameter.AddParameterInteger("modelid", inVo.ModelId);

            UserData userdata = trxContext.UserData;
            sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            MoldModelVo outVo = new MoldModelVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
