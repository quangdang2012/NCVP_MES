using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetParentInspectionItemIdMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionItemVo inVo = (InspectionItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select * from m_inspection_item ");

            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.InspectionProcessId > 0)
            {
                sqlQuery.Append(" and inspection_process_id = :inspectionprocessid ");
            }

            if (inVo.InspectionItemId > 0)
            {
                sqlQuery.Append(" and inspection_item_id != :inspectionitemid ");
            }

            if (inVo.InspectionItemCode != null)
            {
                sqlQuery.Append(" and UPPER(inspection_item_cd) like UPPER(:inspectionitemcd) ");
            }

            if (inVo.InspectionItemName != null)
            {
                sqlQuery.Append(" and UPPER(inspection_item_name) like UPPER(:inspectionitemname) ");
            }
            sqlQuery.Append(" order by display_order, inspection_item_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionProcessId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionprocessid", inVo.InspectionProcessId);
            }

            if (inVo.InspectionItemId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            }

            if (inVo.InspectionItemCode != null)
            {
                sqlParameter.AddParameterString("Insprocesscd", inVo.InspectionItemCode + "%");
            }

            if (inVo.InspectionItemName != null)
            {
                sqlParameter.AddParameterString("Insprocessname", inVo.InspectionItemName + "%");
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionItemVo> outVo = null;

            while (dataReader.Read())
            {
                InspectionItemVo currOutVo = new InspectionItemVo
                {
                   InspectionItemCode  = ConvertDBNull<string>(dataReader, "inspection_item_cd"),
                    InspectionItemId = ConvertDBNull<int>(dataReader, "inspection_item_id"),
                    InspectionItemName = ConvertDBNull<string>(dataReader, "inspection_item_name"),
                    ParentInspectionItemId= ConvertDBNull<int>(dataReader, "inspection_process_id"),
                };
                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionItemVo>();
                    outVo.add(new InspectionItemVo());
                }
                outVo.add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }


    }
}
