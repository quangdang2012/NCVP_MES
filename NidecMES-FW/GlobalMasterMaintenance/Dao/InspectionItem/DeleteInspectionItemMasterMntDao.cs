using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteInspectionItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;          

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_inspection_item");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_item_id = :inspectionitemid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);

            InspectionItemVo outVo = new InspectionItemVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };
            return outVo;
        }
    }
}
