using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionItemSelectionDatatypeValueSeqDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemSelectionDatatypeValueVo inVo = (InspectionItemSelectionDatatypeValueVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select");
            sqlQuery.Append(" inspection_item_selection_datatype_value_cd");
            sqlQuery.Append(" from m_inspection_item_selection_datatype_value");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_item_id = :inspectionitemid ");
            sqlQuery.Append(" order by inspection_item_selection_datatype_value_id desc ");
            sqlQuery.Append(" limit 1 ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionItemSelectionDatatypeValueVo currOutVo = new InspectionItemSelectionDatatypeValueVo();

            while (dataReader.Read())
            {
                currOutVo.InspectionItemSelectionDatatypeValueCode = ConvertDBNull<string>(dataReader, "inspection_item_selection_datatype_value_cd");                
            }
            dataReader.Close();

            return currOutVo;
        }
    }
}
