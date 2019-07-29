using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetMoldCategoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldCategoryVo inVo = (MoldCategoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select ct.mold_category_id, ct.mold_category_cd, ct.mold_category_name,ct.display_order ");
            sqlQuery.Append(" from m_mold_category ct ");           

            sqlQuery.Append(" where factory_cd = :factorycode ");

            if (inVo.MoldCategoryCode != null)
            {
                sqlQuery.Append(" and ct.mold_category_cd like :moldcategorycd ");
            }

            if (inVo.MoldCategoryName != null)
            {
                sqlQuery.Append(" and ct.mold_category_name like :moldcategoryname ");
            }

            sqlQuery.Append(" order by ct.display_order");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);
            if (inVo.MoldCategoryCode != null)
            {
                sqlParameter.AddParameterString("moldcategorycd", inVo.MoldCategoryCode + "%");
            }

            if (inVo.MoldCategoryName != null)
            {
                sqlParameter.AddParameterString("moldcategoryname", inVo.MoldCategoryName + "%");
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<MoldCategoryVo> outVo = null;

            while (dataReader.Read())

            {
                MoldCategoryVo currOutVo = new MoldCategoryVo
                {
                    MoldCategoryId = Convert.ToInt32(dataReader["mold_category_id"]),
                    MoldCategoryCode = dataReader["mold_category_cd"].ToString(),
                    MoldCategoryName = dataReader["mold_category_name"].ToString(),
                    DisplayOrder = Convert.ToInt32(dataReader["display_order"]),
                    
                };
                if(outVo == null)
                {
                    outVo = new ValueObjectList<MoldCategoryVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
