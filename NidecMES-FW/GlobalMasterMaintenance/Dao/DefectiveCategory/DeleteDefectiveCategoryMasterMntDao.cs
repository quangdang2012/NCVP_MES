using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteDefectiveCategoryMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            DefectiveCategoryVo inVo = (DefectiveCategoryVo)arg;        

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_defective_category");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" defective_category_id = :defectiveCategoryid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("defectiveCategoryid", inVo.DefectiveCategoryId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            DefectiveCategoryVo outVo = new DefectiveCategoryVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
