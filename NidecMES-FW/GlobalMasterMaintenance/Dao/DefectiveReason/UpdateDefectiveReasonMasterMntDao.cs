using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateDefectiveReasonMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            DefectiveReasonVo inVo = (DefectiveReasonVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_defective_reason");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" defective_reason_name = :defectivereasonname, ");
            sqlQuery.Append(" defective_category_id = :defectivecategoryid, ");
            sqlQuery.Append(" display_order = :displayorder");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" defective_reason_id = :defectivereasonid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("defectivereasonid", inVo.DefectiveReasonId);
            sqlParameter.AddParameterString("defectivereasonname", inVo.DefectiveReasonName);
            sqlParameter.AddParameterInteger("defectivecategoryid", inVo.DefectiveCategoryId);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            DefectiveReasonVo outVo = new DefectiveReasonVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
