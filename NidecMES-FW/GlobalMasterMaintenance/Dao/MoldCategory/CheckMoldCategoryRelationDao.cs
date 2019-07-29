using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckMoldCategoryRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldCategoryVo inVo = (MoldCategoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("select count(mc.mold_category_cd) as CategoryCount from m_mold_detail md");
            sqlQuery.Append(" inner join m_mold_category mc on mc.mold_category_id = md.mold_category_id");
            sqlQuery.Append(" where mc.factory_cd = :factorycode ");

            if (inVo.MoldCategoryCode != null)
            {
                sqlQuery.Append(" and UPPER(mold_category_cd) = UPPER(:moldcategorycd) ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);
            if (inVo.MoldCategoryCode != null)
            {
                sqlParameter.AddParameterString("moldcategorycd", inVo.MoldCategoryCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            MoldCategoryVo outVo = new MoldCategoryVo();

            while (dataReader.Read())
            {
              outVo.AffectedCount = Convert.ToInt32("0" + dataReader["CategoryCount"]);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
