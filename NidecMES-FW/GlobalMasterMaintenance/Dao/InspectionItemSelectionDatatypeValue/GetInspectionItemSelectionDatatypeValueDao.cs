using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionItemSelectionDatatypeValueDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemSelectionDatatypeValueVo inVo = (InspectionItemSelectionDatatypeValueVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" Select dtv.inspection_item_selection_datatype_value_id,  ");
            sqlQuery.Append("       dtv.inspection_item_selection_datatype_value_cd,  ");
            sqlQuery.Append("       dtv.inspection_item_selection_datatype_value_text,  ");
            sqlQuery.Append("       it.inspection_item_id,");
            sqlQuery.Append("       it.inspection_item_cd,");
            sqlQuery.Append("       it.inspection_item_name,");
            sqlQuery.Append("       dtv.display_order");
            sqlQuery.Append(" from m_inspection_item_selection_datatype_value dtv ");
            sqlQuery.Append(" left join m_inspection_item it on  it.inspection_item_id = dtv.inspection_item_id  ");
            sqlQuery.Append(" where dtv.factory_cd = :factcd");
            sqlQuery.Append(" and dtv.inspection_item_id = :inspectionitemid ");

            sqlQuery.Append(" order by dtv.display_order,dtv.inspection_item_selection_datatype_value_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            sqlParameter.AddParameterString("factcd", UserData.GetUserData().FactoryCode);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionItemSelectionDatatypeValueVo> outVo = null;

            while (dataReader.Read())
            {
                InspectionItemSelectionDatatypeValueVo currOutVo = new InspectionItemSelectionDatatypeValueVo();

                currOutVo.InspectionItemSelectionDatatypeValueId = ConvertDBNull<int>(dataReader, "inspection_item_selection_datatype_value_id");
                currOutVo.InspectionItemSelectionDatatypeValueCode = ConvertDBNull<string>(dataReader, "inspection_item_selection_datatype_value_cd");
                currOutVo.InspectionItemSelectionDatatypeValueText = ConvertDBNull<string>(dataReader, "inspection_item_selection_datatype_value_text");
                currOutVo.DisplayOrder = ConvertDBNull<int>(dataReader, "display_order");
                currOutVo.InspectionItemId = ConvertDBNull<int>(dataReader, "inspection_item_id");
                currOutVo.InspectionItemCode = ConvertDBNull<string>(dataReader, "inspection_item_cd");
                currOutVo.InspectionItemName = ConvertDBNull<string>(dataReader, "inspection_item_name");


                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionItemSelectionDatatypeValueVo>();
                }
                outVo.add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }


    }
}
