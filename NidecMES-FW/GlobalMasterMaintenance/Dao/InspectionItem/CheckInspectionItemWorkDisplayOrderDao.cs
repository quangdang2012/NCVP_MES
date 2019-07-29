using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckInspectionItemWorkDisplayOrderDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as DisplayCount from m_inspection_item");
            sqlQuery.Append(" where factory_cd = :factcd ");

            if (inVo.DisplayOrder > 0)
            {
                sqlQuery.Append(" and display_order = :displayorder");
            }

            if (inVo.InspectionProcessId > 0)
            {
                sqlQuery.Append(" and inspection_process_id = :inspectionprocessid");
            }
            if (inVo.ParentInspectionItemId > 0)
            {
                sqlQuery.Append(" and parent_inspection_item_id = :parentinspectionitemid");
            }
            else
            {
                sqlQuery.Append(" and COALESCE(parent_inspection_item_id,0 )= 0");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("parentinspectionitemid", inVo.ParentInspectionItemId);

            sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);

            sqlParameter.AddParameterInteger("inspectionprocessid", inVo.InspectionProcessId);


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionItemVo outVo = new InspectionItemVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["DisplayCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
