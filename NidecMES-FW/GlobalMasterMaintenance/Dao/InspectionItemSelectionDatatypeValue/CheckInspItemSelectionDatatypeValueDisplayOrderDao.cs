using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckInspectionItemSelectionDatatypeValueDisplayOrderDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemSelectionDatatypeValueVo inVo = (InspectionItemSelectionDatatypeValueVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as DisplayCount from m_inspection_item_selection_datatype_value");
            sqlQuery.Append(" where factory_cd = :factcd ");

            if (inVo.DisplayOrder > 0)
            {
                sqlQuery.Append(" and display_order = :displayorder");
            }
            sqlQuery.Append(" and inspection_item_id = :inspectionitemid");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            if (inVo.DisplayOrder > 0)
            {
                sqlParameter.AddParameterInteger("displayorder", inVo.DisplayOrder);
            }

            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionItemSelectionDatatypeValueVo outVo = new InspectionItemSelectionDatatypeValueVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["DisplayCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
