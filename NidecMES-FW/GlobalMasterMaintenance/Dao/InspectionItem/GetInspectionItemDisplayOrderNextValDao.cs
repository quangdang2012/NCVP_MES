using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionItemDisplayOrderNextValDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select  max(display_order)+1 display_order ");
            sqlQuery.Append(" from m_inspection_item ");
            sqlQuery.Append(" where factory_cd = :factcd");

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
                sqlQuery.Append(" and COALESCE(parent_inspection_item_id,0) = 0 ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);


            sqlParameter.AddParameterInteger("inspectionprocessid", inVo.InspectionProcessId);
            sqlParameter.AddParameterInteger("parentinspectionitemid", inVo.ParentInspectionItemId);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionItemVo outVo = null;

            while (dataReader.Read())
            {
                outVo = new InspectionItemVo();
                outVo.DisplayOrder = ConvertDBNull<int>(dataReader, "display_order");
            }
            dataReader.Close();

            return outVo;
        }
    }
}
