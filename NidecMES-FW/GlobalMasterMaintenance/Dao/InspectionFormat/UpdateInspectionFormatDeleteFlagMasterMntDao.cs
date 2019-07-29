using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateInspectionFormatDeleteFlagMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_inspection_format");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" is_deleted = :isdeleted ");            
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" inspection_format_id = :inspectionformatid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);            
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("isdeleted", Convert.ToInt32(GlobalMasterDataTypeEnum.FLAG_ON.GetValue()));

            UpdateResultVo outVo = new UpdateResultVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
