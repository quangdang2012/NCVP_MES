using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionProcessMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionProcessVo inVo = (InspectionProcessVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select");
            sqlQuery.Append("   ip.inspection_process_id,");
            sqlQuery.Append("   ip.inspection_process_cd,");
            sqlQuery.Append("   ip.inspection_process_name,");
            sqlQuery.Append("   ip.display_order,");
            sqlQuery.Append("   ip.inspection_format_id,");
            sqlQuery.Append("   if.inspection_format_name,");
            sqlQuery.Append("   itemtable.inspection_item_id ");
            //sqlQuery.Append("   inspection_item_cd,");
            //sqlQuery.Append("   inspection_item_name");
            sqlQuery.Append(" from m_inspection_process ip");
            sqlQuery.Append(" inner join m_inspection_format if on ip.inspection_format_id = if.inspection_format_id");
            sqlQuery.Append(" left join (");
            sqlQuery.Append("           select max(inspection_item_id) as inspection_item_id, inspection_process_id from m_inspection_item ");
            sqlQuery.Append("           group by  inspection_process_id ");
            sqlQuery.Append("           ) itemtable ");
            sqlQuery.Append(" on itemtable.inspection_process_id = ip.inspection_process_id ");
            sqlQuery.Append(" where ip.factory_cd = :faccd ");

            if (inVo.InspectionProcessCode != null)
            {
                sqlQuery.Append(" and ip.inspection_process_cd like :inspectionprocesscd ");
            }

            if (inVo.InspectionProcessName != null)
            {
                sqlQuery.Append(" and ip.inspection_process_name like :inspectionprocessname ");
            }

            if (inVo.InspectionFormatId > 0)
            {
                sqlQuery.Append(" and ip.inspection_format_id = :inspectionformatid ");
            }

            sqlQuery.Append(" order by ip.display_order, ip.inspection_process_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterString("inspectionprocesscd", inVo.InspectionProcessCode + "%");
            sqlParameter.AddParameterString("inspectionprocessname", inVo.InspectionProcessName + "%");
            sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionProcessVo> outVo = null;

            while (dataReader.Read())

            {
                InspectionProcessVo currOutVo = new InspectionProcessVo();
                currOutVo.InspectionProcessId = ConvertDBNull<int>(dataReader, "inspection_process_id");
                currOutVo.InspectionProcessCode = ConvertDBNull<string>(dataReader, "inspection_process_cd");
                currOutVo.InspectionProcessName = ConvertDBNull<string>(dataReader, "inspection_process_name");
                currOutVo.InspectionFormatId = ConvertDBNull<int>(dataReader, "inspection_format_id");
                currOutVo.InspectionFormatName = ConvertDBNull<string>(dataReader, "inspection_format_name");
                currOutVo.InspectionItemId = ConvertDBNull<int>(dataReader, "inspection_item_id");
                currOutVo.DisplayOrder = ConvertDBNull<int>(dataReader, "display_order");
                //currOutVo.InspectionItemCode = ConvertDBNull<string>(dataReader, "inspection_item_cd");
                //currOutVo.InspectionItemName = ConvertDBNull<string>(dataReader, "inspection_item_name");

                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionProcessVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
