using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetDefectiveCategoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            DefectiveCategoryVo inVo = (DefectiveCategoryVo)arg;

            DefectiveCategoryVo outVo = new DefectiveCategoryVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select * from m_defective_category ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.DefectiveCategoryCode != null)
            {
                sqlQuery.Append(" and defective_category_cd like :defectiveCategorycd ");
            }

            if (inVo.DefectiveCategoryName != null)
            {
                sqlQuery.Append(" and defective_category_name like :defectiveCategoryname ");
            }

            sqlQuery.Append(" order by defective_category_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (!string.IsNullOrEmpty(inVo.FactoryCode))
            {
                sqlParameter.AddParameterString("faccd", inVo.FactoryCode);
            }
            else
            {
                sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            }
            

            if (inVo.DefectiveCategoryCode != null)
            {
                sqlParameter.AddParameterString("defectiveCategorycd", inVo.DefectiveCategoryCode + "%");
            }

            if (inVo.DefectiveCategoryName != null)
            {
                sqlParameter.AddParameterString("defectiveCategoryname", inVo.DefectiveCategoryName + "%");
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DefectiveCategoryVo currOutVo = new DefectiveCategoryVo();
                {
                    currOutVo.DefectiveCategoryId = Convert.ToInt32(dataReader["defective_category_id"]);
                    currOutVo.DefectiveCategoryCode = dataReader["defective_category_cd"].ToString();
                    currOutVo.DefectiveCategoryName = dataReader["defective_category_name"].ToString();
                };

                outVo.DefectiveCategoryListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
