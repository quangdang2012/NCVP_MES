using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInspectionProcessMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionProcessVo inVo = (InspectionProcessVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inspection_process");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" inspection_process_cd = :inspectionprocesscd, ");
            sqlQuery.Append(" inspection_process_name = :inspectionprocessname, ");
            sqlQuery.Append(" inspection_format_id = :inspectionformatid, ");
            sqlQuery.Append(" display_order = :displayorder ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" inspection_process_id = :inspectionprocessid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inspectionprocessid", inVo.InspectionProcessId);
            sqlParameter.AddParameterString("inspectionprocesscd", inVo.InspectionProcessCode);
            sqlParameter.AddParameterString("inspectionprocessname", inVo.InspectionProcessName);
            sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            InspectionProcessVo outVo = new InspectionProcessVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }  


    }
}
