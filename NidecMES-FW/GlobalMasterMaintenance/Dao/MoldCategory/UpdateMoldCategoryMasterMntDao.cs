using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateMoldCategoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldCategoryVo inVo = (MoldCategoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_mold_category");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" mold_category_name = :moldcategoryname, ");
            sqlQuery.Append(" display_order = :displayorder ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" factory_cd = :factorycode and mold_category_id = :moldcategoryid;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);
            sqlParameter.AddParameterInteger("moldcategoryid", inVo.MoldCategoryId);
            sqlParameter.AddParameterString("moldcategoryname", inVo.MoldCategoryName);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);

            MoldCategoryVo outVo = new MoldCategoryVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
