using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckDefectiveCategoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            DefectiveCategoryVo inVo = (DefectiveCategoryVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as DefectiveCategoryCount from m_defective_category ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.DefectiveCategoryCode != null)
            {
                sqlQuery.Append(" and UPPER(defective_category_cd) = UPPER(:defectiveCategorycd)");
            }
                        
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.DefectiveCategoryCode != null)
            {
                sqlParameter.AddParameterString("defectiveCategorycd", inVo.DefectiveCategoryCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            DefectiveCategoryVo outVo = new DefectiveCategoryVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["DefectiveCategoryCount"]);
            }

            dataReader.Close();

            return outVo;
        } 
    }
}
