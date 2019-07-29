using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddModelMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ModelVo inVo = (ModelVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_model");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" model_cd, ");
            sqlQuery.Append(" model_name, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :modelcd ,");
            sqlQuery.Append(" :modelname ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("RETURNING  model_id;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("modelcd", inVo.ModelCode);
            sqlParameter.AddParameterString("modelname", inVo.ModelName);

            UserData userdata = trxContext.UserData;
            sqlParameter.AddParameterString("registrationusercode", userdata.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", userdata.FactoryCode);

            //execute SQL
            int outId = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;

            ModelVo outVo = null;
            if (outId > 0)
            {
                outVo = new ModelVo();
                outVo.ModelId = outId;
            }

            return outVo;
        }


 
    }
}
