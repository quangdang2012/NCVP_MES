using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class CheckInspectionProcessMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            InspectionProcessVo inVo = (InspectionProcessVo)arg;

            StringBuilder sql = new StringBuilder();

            //create SQL
            sql.Append("Select Count(*) as InspectionProcessCount from m_inspection_process");
            sql.Append(" where factory_cd = :faccd ");

            if (inVo.InspectionProcessName != null)
            {
                sql.Append(" and UPPER(inspection_process_name) = UPPER(:inspectionprocessname)");
            }

            if (inVo.InspectionFormatId > 0)
            {
                sql.Append(" and inspection_format_id = :inspectionformatid ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionProcessName != null)
            {
                sqlParameter.AddParameterString("inspectionprocessname", inVo.InspectionProcessName);
            }

            if (inVo.InspectionFormatId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionProcessVo outVo = new InspectionProcessVo { AffectedCount = 0 };

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["InspectionProcessCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
