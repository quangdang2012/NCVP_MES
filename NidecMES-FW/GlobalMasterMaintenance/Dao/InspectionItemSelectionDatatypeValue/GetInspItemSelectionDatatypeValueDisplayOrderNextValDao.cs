using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspItemSelectionDatatypeValueDisplayOrderNextValDao : AbstractDataAccessObject 
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemSelectionDatatypeValueVo inVo = (InspectionItemSelectionDatatypeValueVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select  max(display_order)+1 display_order ");
            sqlQuery.Append(" from m_inspection_item_selection_datatype_value ");
            sqlQuery.Append(" where factory_cd = :factcd");

            sqlQuery.Append(" and inspection_item_id = :inspectionitemid");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionItemSelectionDatatypeValueVo outVo = new InspectionItemSelectionDatatypeValueVo();

            while (dataReader.Read())
            {
                outVo.DisplayOrder = ConvertDBNull<int>(dataReader, "display_order");
            }
            dataReader.Close();

            return outVo;
        }
    }
}
