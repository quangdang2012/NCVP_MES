using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteInspectionSpecificationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionSpecificationVo inVo = (InspectionSpecificationVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_inspection_specification");
            sqlQuery.Append(" Where	");
            if (inVo.InspectionItemId > 0)
            {
                sqlQuery.Append(" inspection_item_id = :inspectionitemid ");
            }
            else
            {
                sqlQuery.Append(" inspection_specification_id = :inspectionspecificationid ");
            }

            sqlQuery.Append(" and factory_cd = :faccd ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inspectionspecificationid", inVo.InspectionSpecificationId);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            InspectionSpecificationVo outVo = new InspectionSpecificationVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
