using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteDefectiveReasonMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            DefectiveReasonVo inVo = (DefectiveReasonVo)arg;       

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_defective_reason");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" defective_reason_id = :defectivereasonid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("defectivereasonid", inVo.DefectiveReasonId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            DefectiveReasonVo outVo = new DefectiveReasonVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
