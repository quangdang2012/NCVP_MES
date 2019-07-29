using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionItemListDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            //InspectionProcessVo inspectionProcessVo = (InspectionProcessVo)arg;          

            ValueObjectList<ValueObjectList<ValueObject>> inVo = (ValueObjectList<ValueObjectList<ValueObject>>)arg;
            List<int> ProcessList = new List<int>();

            foreach (ValueObjectList<ValueObject> getItemVo in inVo.GetList())
            {
                if ((((InspectionProcessVo)getItemVo.GetList()[0]).InspectionProcessId) != 0)
                {
                    ProcessList.Add(((InspectionProcessVo)getItemVo.GetList()[0]).InspectionProcessId);
                }
            }

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select * ");
            sqlQuery.Append(" from m_inspection_item");
            sqlQuery.Append(" where factory_cd = :faccd ");
            sqlQuery.Append(" and inspection_process_id = ANY (:inspectionprocessid) ");

            sqlQuery.Append(" order by inspection_item_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameter("inspectionprocessid", ProcessList);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionItemVo> outVo = null;

            while (dataReader.Read())
            {
                InspectionItemVo currOutVo = new InspectionItemVo();

                currOutVo.InspectionItemId = ConvertDBNull<int>(dataReader, "inspection_item_id");
                currOutVo.InspectionItemCode = ConvertDBNull<string>(dataReader, "inspection_item_cd");
                currOutVo.InspectionItemName = ConvertDBNull<string>(dataReader, "inspection_item_name");
                currOutVo.ParentInspectionItemId = ConvertDBNull<int>(dataReader, "parent_inspection_item_id");
                currOutVo.InspectionProcessId = ConvertDBNull<int>(dataReader, "inspection_process_id");
                currOutVo.InspectionItemMandatory = ConvertDBNull<int>(dataReader, "is_inspection_item_mandatory");
                currOutVo.InspectionEmployeeMandatory = ConvertDBNull<int>(dataReader, "is_inspection_employee_mandatory");
                currOutVo.InspectionMachineMandatory = ConvertDBNull<int>(dataReader, "is_inspection_machine_mandatory");
                currOutVo.InspectionItemDataType = ConvertDBNull<int>(dataReader, "inspection_item_data_type");
                currOutVo.InspectionResultItemDecimalDigits = ConvertDBNull<int>(dataReader, "inspection_item_result_input_decimal_digits");
                currOutVo.DisplayOrder = ConvertDBNull<int>(dataReader, "display_order");

                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionItemVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
