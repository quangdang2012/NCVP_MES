using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckInspectionProcessRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionProcessVo inVo = (InspectionProcessVo)arg;
            
            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" Select ip.inspection_process_id as inspectionprocessid, ");            
            sqlQuery.Append(" iitm.inspection_process_id as inspectionitemprocessid from m_inspection_process ip ");
            sqlQuery.Append(" left join m_inspection_item iitm on ");
            sqlQuery.Append(" iitm.inspection_process_id = ip.inspection_process_id ");
            sqlQuery.Append(" where ip.factory_cd = :faccd ");
            
            if (inVo.InspectionProcessCode != null)
            {
                sqlQuery.Append(" and UPPER(ip.inspection_process_cd) = UPPER(:inspectionprocesscd)");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.InspectionProcessCode != null)
            {
                sqlParameter.AddParameterString("inspectionprocesscd", inVo.InspectionProcessCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionProcessVo outVo = new InspectionProcessVo { AffectedCount = 0 };

            while (dataReader.Read())
            {
                if (outVo == null)
                {
                    outVo = new InspectionProcessVo();
                }
                outVo.InspectionProcessId = ConvertDBNull<int>(dataReader, "inspectionitemprocessid");
            }
            dataReader.Close();

            return outVo;
        }
    }
}
