using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionItemMasterDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select");
            sqlQuery.Append(" inspection_item_id,");
            sqlQuery.Append(" inspection_item_cd,");
            sqlQuery.Append(" inspection_item_name,");
            sqlQuery.Append(" parent_inspection_item_id,");
            sqlQuery.Append(" inspection_process_id,");
            sqlQuery.Append(" is_inspection_item_mandatory");
            sqlQuery.Append(" from m_inspection_item");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.InspectionItemCode != null)
            {
                sqlQuery.Append(" and UPPER(inspection_item_cd) like UPPER(:inspectionitemcd) ");
            }

            if (inVo.InspectionItemName != null)
            {
                sqlQuery.Append(" and UPPER(inspection_item_name) like UPPER(:inspectionitemname) ");
            }

            if (inVo.InspectionProcessId > 0)
            {
                sqlQuery.Append(" and inspection_process_id = :inspectionprocessid ");
            }

            sqlQuery.Append(" order by display_order, inspection_item_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionItemCode != null)
            {
                sqlParameter.AddParameterString("inspectionitemcd", inVo.InspectionItemCode + "%");
            }

            if (inVo.InspectionItemName != null)
            {
                sqlParameter.AddParameterString("inspectionitemname", inVo.InspectionItemName + "%");
            }

            if (inVo.InspectionProcessId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionprocessid", inVo.InspectionProcessId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionItemVo> outVo = null;

            while (dataReader.Read())

            {
                InspectionItemVo currOutVo = new InspectionItemVo();
                currOutVo.InspectionItemId = ConvertDBNull<Int32>(dataReader, "inspection_item_id");
                currOutVo.InspectionItemCode = ConvertDBNull<string>(dataReader, "inspection_item_cd");
                currOutVo.InspectionItemName = ConvertDBNull<string>(dataReader, "inspection_item_name");
                currOutVo.ParentInspectionItemId = ConvertDBNull<Int32>(dataReader, "parent_inspection_item_id");
                currOutVo.InspectionItemMandatory = ConvertDBNull<Int32>(dataReader, "is_inspection_item_mandatory");
                currOutVo.InspectionProcessId = ConvertDBNull<Int32>(dataReader, "inspection_process_id");
                
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
