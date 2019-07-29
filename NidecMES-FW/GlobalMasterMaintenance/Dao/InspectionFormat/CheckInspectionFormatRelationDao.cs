using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckInspectionFormatRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)arg;
            
            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" Select if.inspection_format_id, ip.inspection_format_id as inspectionprocessid ");            
            sqlQuery.Append(" from m_inspection_format if ");
            sqlQuery.Append(" left join m_inspection_process ip on ");
            sqlQuery.Append(" ip.inspection_format_id = if.inspection_format_id ");
            //sqlQuery.Append(" left join m_item_line_inspection_format ilif on ");
            //sqlQuery.Append(" ilif.inspection_format_id = if.inspection_format_id ");
            sqlQuery.Append(" where if.factory_cd = :faccd ");
            
            if (inVo.InspectionFormatCode != null)
            {
                sqlQuery.Append(" and UPPER(if.inspection_format_cd) = UPPER(:inspectionformatcd)");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.InspectionFormatCode != null)
            {
                sqlParameter.AddParameterString("inspectionformatcd", inVo.InspectionFormatCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionFormatVo outVo = null;

            while (dataReader.Read())
            {
                if (outVo == null)
                {
                    outVo = new InspectionFormatVo();
                }
                outVo.InspectionFormatId = ConvertDBNull<int>(dataReader, "inspectionprocessid");                
            }
            dataReader.Close();

            return outVo;
        }
    }
}
