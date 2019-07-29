using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionSelectionDataTypeListDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ValueObjectList<ValueObjectList<ValueObject>> inVo = (ValueObjectList<ValueObjectList<ValueObject>>)arg;
            List<int> ItemList = new List<int>();

            foreach (ValueObjectList<ValueObject> getItemVo in inVo.GetList())
            {
                if ((((InspectionItemVo)getItemVo.GetList()[0]).InspectionItemId) != 0)
                {
                    ItemList.Add(((InspectionItemVo)getItemVo.GetList()[0]).InspectionItemId);
                }
            }

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select * ");
            sqlQuery.Append(" from m_inspection_item_selection_datatype_value");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_item_id = ANY (:inspectionItemId) ");

            sqlQuery.Append(" order by inspection_item_selection_datatype_value_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameter("inspectionItemId", ItemList);

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
