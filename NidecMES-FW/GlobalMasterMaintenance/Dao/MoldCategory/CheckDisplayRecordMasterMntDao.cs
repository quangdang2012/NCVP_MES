using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckDisplayRecordMasterMntsDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldCategoryVo inVo = (MoldCategoryVo)arg;

            MoldCategoryVo outVo = new MoldCategoryVo();

            StringBuilder sqlQuery = new StringBuilder();
            
            //create SQL query
             
            sqlQuery.Append("Select Count(*) DefRsnCount from m_mold_category ");

            sqlQuery.Append(" where factory_cd = :factorycode ");

            if (inVo.DisplayOrder != 0)
            {
                sqlQuery.Append(" and display_order = :displayorder");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);
            if (inVo.DisplayOrder != 0)
            {
                sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            outVo.AffectedCount = 0;

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["DefRsnCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
