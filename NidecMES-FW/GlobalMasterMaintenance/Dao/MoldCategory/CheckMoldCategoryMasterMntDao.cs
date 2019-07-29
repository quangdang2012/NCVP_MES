using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckMoldCategoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldCategoryVo inVo = (MoldCategoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as MoldCategoryCount,");
            sqlQuery.Append(" mold_category_cd, ");
            sqlQuery.Append(" mold_category_id ");
            sqlQuery.Append(" from m_mold_category ");

            sqlQuery.Append(" where factory_cd = :factorycode ");

            if (inVo.MoldCategoryCode != null)
            {
                sqlQuery.Append(" and UPPER(mold_category_cd) = UPPER(:moldCategorycd) ");
            }

            sqlQuery.Append(" group by mold_category_cd,mold_category_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);
            if (inVo.MoldCategoryCode != null)
            {
                sqlParameter.AddParameterString("moldCategorycd", inVo.MoldCategoryCode);
            }           

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<MoldCategoryVo> outVo = new ValueObjectList<MoldCategoryVo> ();

            while (dataReader.Read())
            {

                MoldCategoryVo currOutVo = new MoldCategoryVo
                {
                    MoldCategoryId = Convert.ToInt32(dataReader["mold_category_id"]),
                    MoldCategoryCode = dataReader["mold_category_cd"].ToString(),
                };

                outVo.add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
