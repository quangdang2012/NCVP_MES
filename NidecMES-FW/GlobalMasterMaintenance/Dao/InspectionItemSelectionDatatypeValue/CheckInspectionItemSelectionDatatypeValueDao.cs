using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class CheckInspectionItemSelectionDatatypeValueDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemSelectionDatatypeValueVo inVo = (InspectionItemSelectionDatatypeValueVo)arg;

            StringBuilder sql = new StringBuilder();

            //create SQL
            sql.Append("Select Count(*) as InspectionItemSelectionDataTypeCount from m_inspection_item_selection_datatype_value");
            sql.Append(" where factory_cd = :faccd ");

            if (inVo.InspectionItemSelectionDatatypeValueText != null)
            {
                sql.Append(" and UPPER(inspection_item_selection_datatype_value_text) = UPPER(:datatypevaluetext)");
            }

            if (inVo.InspectionItemId > 0)
            {
                sql.Append(" and inspection_item_id = :inspectionitemid ;");
            }
            else
            {
                sql.Append(" and inspection_item_id = 0 ;");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionItemSelectionDatatypeValueText != null)
            {
                sqlParameter.AddParameterString("datatypevaluetext", inVo.InspectionItemSelectionDatatypeValueText);
            }

            if (inVo.InspectionItemId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionItemSelectionDatatypeValueVo outVo = new InspectionItemSelectionDatatypeValueVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["InspectionItemSelectionDataTypeCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
