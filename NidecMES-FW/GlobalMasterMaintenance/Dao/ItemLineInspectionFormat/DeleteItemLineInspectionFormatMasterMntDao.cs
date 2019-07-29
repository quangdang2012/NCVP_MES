using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteItemLineInspectionFormatMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemLineInspectionFormatVo inVo = (ItemLineInspectionFormatVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Delete From m_item_line_inspection_format");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" inspection_format_id = :inspectionformatid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
