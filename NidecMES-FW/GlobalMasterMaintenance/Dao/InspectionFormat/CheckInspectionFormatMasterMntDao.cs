using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckInspectionFormatMasterMntDao : AbstractDataAccessObject 
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as InspectionFormatCount from m_inspection_format ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            //if (inVo.InspectionFormatCode != null)
            //{
            //    sqlQuery.Append(" and UPPER(inspection_format_cd) Like UPPER(:inspectionformatcd) ");
            //}

            if (inVo.InspectionFormatName != null)
            {
                sqlQuery.Append(" and UPPER(inspection_format_name) = UPPER(:inspectionformatname) ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionFormatName != null)
            {
                sqlParameter.AddParameterString("inspectionformatname", inVo.InspectionFormatName );
            }
                    
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionFormatVo outVo = new InspectionFormatVo {AffectedCount = 0};

            while (dataReader.Read())
            {
              outVo.AffectedCount = Convert.ToInt32(dataReader["InspectionFormatCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
