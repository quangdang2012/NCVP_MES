using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInspectionFormatMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inspection_format");
            sqlQuery.Append(" Set ");
            //sqlQuery.Append(" inspection_format_cd = :inspectionformatcd, ");
            sqlQuery.Append(" inspection_format_name = :inspectionformatname ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" inspection_format_id = :inspectionformatid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            sqlParameter.AddParameterString("inspectionformatcd", inVo.InspectionFormatCode);
            sqlParameter.AddParameterString("inspectionformatname", inVo.InspectionFormatName);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            InspectionFormatVo outVo = new InspectionFormatVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
