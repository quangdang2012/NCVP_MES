using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class CheckInspectionFormatExitInTransactionDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)vo;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select count(ir.inspection_report_id) as duplicate_report ");
            sqlQuery.Append(" from sap_item si ");
            sqlQuery.Append(" inner join m_item_line_inspection_format ilif on ilif.sap_matnr_item_cd = si.sap_matnr_item_cd ");
            sqlQuery.Append(" inner join m_line  ml on ilif.line_id = ml.line_id ");
            sqlQuery.Append(" inner join t_inspection_report ir on ir.item_line_inspection_format_id = ilif.item_line_inspection_format_id ");
            
            sqlQuery.Append(" where ir.factory_cd = :faccd ");
            
            if (inVo.InspectionFormatId > 0)
            {
                sqlQuery.Append(" and ilif.inspection_format_id = :inspectionformatid ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            UpdateResultVo outVo = new UpdateResultVo();

            while (dataReader.Read())

            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["duplicate_report"]);
            }
            dataReader.Close();

            return outVo;
        }
    }
}


