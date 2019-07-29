using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetItemLineInspectionFormatMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemLineInspectionFormatVo inVo = (ItemLineInspectionFormatVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select");
            sqlQuery.Append(" ilif.item_line_inspection_format_id,");
            sqlQuery.Append(" ilif.item_id,");
            sqlQuery.Append(" si.sap_maktx_item_name,");
            sqlQuery.Append(" ilif.line_id,");
            sqlQuery.Append(" l.line_name,");
            sqlQuery.Append(" ilif.inspection_format_id,");
            sqlQuery.Append(" if.inspection_format_name");
            sqlQuery.Append(" from m_item_line_inspection_format ilif");
            sqlQuery.Append(" inner join sap_item si");
            sqlQuery.Append(" on si.sap_matnr_item_cd = ilif.sap_matnr_item_cd");
            sqlQuery.Append(" inner join m_line l");
            sqlQuery.Append(" on l.line_id = ilif.line_id");
            sqlQuery.Append(" inner join m_inspection_format if");
            sqlQuery.Append(" on if.inspection_format_id = ilif.inspection_format_id");
            sqlQuery.Append(" where ilif.factory_cd = :faccd ");

            if (inVo.SapItemCode !=null )
            {
                sqlQuery.Append(" and ilif.sap_matnr_item_cd = :sapitemcd ");
            }

            if (inVo.LineId > 0)
            {
                sqlQuery.Append(" and ilif.line_id = :lineid ");
            }

            if (inVo.InspectionFormatId > 0)
            {
                sqlQuery.Append(" and ilif.inspection_format_id = :inspectionformatid ");               
            }
            
            sqlQuery.Append(" order by ilif.item_line_inspection_format_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.SapItemCode !=null)
            {
                sqlParameter.AddParameterString("itemid", inVo.SapItemCode);
            }

            if (inVo.LineId > 0)
            {
                sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            }

            if (inVo.InspectionFormatId > 0)
            {
                sqlParameter.AddParameterInteger("inspectionformatid", inVo.InspectionFormatId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<ItemLineInspectionFormatVo> outVo = null;

            while (dataReader.Read())
            {
                ItemLineInspectionFormatVo currOutVo = new ItemLineInspectionFormatVo();
                currOutVo.ItemLineInspectionFormatId = ConvertDBNull<int>(dataReader, "item_line_inspection_format_id");
                currOutVo.SapItemCode = ConvertDBNull<string>(dataReader, "sap_matnr_item_cd");
                currOutVo.SapItemName = ConvertDBNull<string>(dataReader, "sap_maktx_item_name");
                currOutVo.LineId = ConvertDBNull<int>(dataReader, "line_id");
                currOutVo.LineName = ConvertDBNull<string>(dataReader, "line_name");
                currOutVo.InspectionFormatId = ConvertDBNull<int>(dataReader, "inspection_format_id");
                currOutVo.InspectionFormatName = ConvertDBNull<string>(dataReader, "inspection_format_name");
                
                if (outVo == null)
                {
                    outVo = new ValueObjectList<ItemLineInspectionFormatVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
