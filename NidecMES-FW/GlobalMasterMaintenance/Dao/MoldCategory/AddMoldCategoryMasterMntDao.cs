using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddMoldCategoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldCategoryVo inVo = (MoldCategoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_mold_category");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" mold_category_cd, ");
            sqlQuery.Append(" mold_category_name, ");
            sqlQuery.Append(" display_order, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");
            sqlQuery.Append(" :moldcategorycd ,");
            sqlQuery.Append(" :moldcategoryname ,");
            sqlQuery.Append(" :displayorder ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" :registrationdatetime ,");
            sqlQuery.Append(" :factorycode ");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("RETURNING  mold_category_id;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("moldcategorycd", inVo.MoldCategoryCode);
            sqlParameter.AddParameterString("moldcategoryname", inVo.MoldCategoryName);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            sqlParameter.AddParameterString("registrationusercode", trxContext.UserData.UserCode);
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);

            //execute SQL
            int outId = (int?)sqlCommandAdapter.ExecuteScalar(sqlParameter) ?? 0;

            MoldCategoryVo outVo = null;
            if (outId > 0)
            {
                outVo = new MoldCategoryVo();
                outVo.MoldCategoryId = outId;
            }

            return outVo;
        }


 
    }
}
