using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteInspectionItemSelectionDatatypeValueDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemSelectionDatatypeValueVo inVo = (InspectionItemSelectionDatatypeValueVo)arg;          

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_inspection_item_selection_datatype_value");
            sqlQuery.Append(" where factory_cd = :faccd ");
            if (inVo.InspectionItemId > 0)
            {
                sqlQuery.Append(" and inspection_item_id = :inspectionitemid ");
            }

            if (inVo.InspectionItemSelectionDatatypeValueId > 0)
            {
                sqlQuery.Append(" and inspection_item_selection_datatype_value_id = :datatypeid ");
            }            

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("datatypeid", inVo.InspectionItemSelectionDatatypeValueId);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);

            UpdateResultVo outVo = new UpdateResultVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };
            return outVo;
        }
    }
}
