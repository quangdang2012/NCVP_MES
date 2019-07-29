using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckInspectionItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;

            InspectionItemVo outVo = new InspectionItemVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as ItemCnt from m_inspection_item ");

            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.InspectionItemName != null)
            {
                sqlQuery.Append(" and UPPER(inspection_item_name) = UPPER(:inspectionitemname) ");
            }

            if (inVo.InspectionProcessId > 0)
            {
                sqlQuery.Append(" and inspection_process_id = :inspectionitemid ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionItemName != null)
            {
                sqlParameter.AddParameterString("inspectionitemname", inVo.InspectionItemName);
            }

            if (inVo.InspectionProcessId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionProcessId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            outVo.AffectedCount = 0;

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["ItemCnt"].ToString());
            }

            dataReader.Close();

            return outVo;
        }
 
    }
}
