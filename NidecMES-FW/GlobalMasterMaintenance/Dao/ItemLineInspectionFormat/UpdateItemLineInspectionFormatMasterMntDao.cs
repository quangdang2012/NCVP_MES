using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateItemLineInspectionFormatMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemLineInspectionFormatVo inVo = (ItemLineInspectionFormatVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_item_line_inspection_format");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" sap_matnr_item_cd = :itemcd, ");
            sqlQuery.Append(" line_id = :lineid, ");
            sqlQuery.Append(" inspection_format_id = :inspectionformatid ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" item_line_inspection_format_id = :itemlineinspectionformatid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("itemlineinspectionformatid", inVo.ItemLineInspectionFormatId);
            sqlParameter.AddParameterString("itemcd", inVo.SapItemCode);
            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            ItemLineInspectionFormatVo outVo = new ItemLineInspectionFormatVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
