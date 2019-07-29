using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionFormatMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Select ");
            sqlQuery.Append(" if.inspection_format_id, ");
            sqlQuery.Append(" inspection_format_cd, ");
            sqlQuery.Append(" inspection_format_name, ");
            sqlQuery.Append(" sap_maktx_item_name, ");
            sqlQuery.Append(" line_name, ");
            sqlQuery.Append(" processtable.inspection_process_id, ");
            sqlQuery.Append(" mit.item_line_inspection_format_id, ");
            sqlQuery.Append(" si.sap_matnr_item_cd, ");
            sqlQuery.Append(" si.sap_matkl_material_grp_id, ");
            sqlQuery.Append(" lin.line_cd ");
            sqlQuery.Append(" from m_inspection_format if ");
            sqlQuery.Append(" inner join ");
            sqlQuery.Append(" m_item_line_inspection_format  mit ");
            sqlQuery.Append(" on mit.inspection_format_id = if.inspection_format_id ");
            sqlQuery.Append(" inner join ");
            sqlQuery.Append(" v_sap_item si ");
            sqlQuery.Append(" on si.sap_matnr_item_cd = mit.sap_matnr_item_cd ");
            sqlQuery.Append(" inner join  ");
            sqlQuery.Append(" m_line lin ");
            sqlQuery.Append(" on lin.line_id = mit.line_id ");           
            sqlQuery.Append(" left join (");
            sqlQuery.Append("           select max(inspection_process_id) as inspection_process_id, ");
            sqlQuery.Append("          inspection_format_id from m_inspection_process ");
            sqlQuery.Append("           group by  inspection_format_id ");
            sqlQuery.Append("           ) processtable ");
            sqlQuery.Append(" on processtable.inspection_format_id = if.inspection_format_id ");
            sqlQuery.Append(" where if.factory_cd = :faccd and if.is_deleted = :isdeleted ");

            if (inVo.InspectionFormatCode != null)
            {
                sqlQuery.Append(" and UPPER(inspection_format_cd) like UPPER(:inspectionformatcd) ");
            }

            if (inVo.InspectionFormatName != null)
            {
                sqlQuery.Append(" and UPPER(inspection_format_name) like UPPER(:inspectionformatname) ");
            }
            if (inVo.SapItemCode != null)
            {
                sqlQuery.Append(" and si.sap_matnr_item_cd = :itemcode ");
            }
            if (inVo.LineCode != null)
            {
                sqlQuery.Append(" and lin.line_cd = :linecode ");
            }
            sqlQuery.Append(" order by inspection_format_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();


            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterString("inspectionformatcd", inVo.InspectionFormatCode + "%");
            sqlParameter.AddParameterString("inspectionformatname", inVo.InspectionFormatName + "%");
            sqlParameter.AddParameterString("linecode", inVo.LineCode);
            sqlParameter.AddParameterString("itemcode", inVo.SapItemCode);
            sqlParameter.AddParameterString("isdeleted", GlobalMasterDataTypeEnum.FLAG_OFF.GetValue().ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionFormatVo> outVo = null;

            while (dataReader.Read())

            {
                InspectionFormatVo currOutVo = new InspectionFormatVo();
                currOutVo.InspectionFormatId = ConvertDBNull<Int32>(dataReader, "inspection_format_id");
                currOutVo.InspectionFormatCode = ConvertDBNull<string>(dataReader, "inspection_format_cd");
                currOutVo.InspectionFormatName = ConvertDBNull<string>(dataReader, "inspection_format_name");
                currOutVo.InspectionItemLineName = ConvertDBNull<string>(dataReader, "sap_maktx_item_name") + '-' + ConvertDBNull<string>(dataReader, "line_name");
                currOutVo.SapItemName = ConvertDBNull<string>(dataReader, "sap_maktx_item_name");
                currOutVo.SapItemCode = ConvertDBNull<string>(dataReader, "sap_matnr_item_cd");
                currOutVo.SapMaterialGroupId = ConvertDBNull<string>(dataReader, "sap_matkl_material_grp_id");
                currOutVo.LineName = ConvertDBNull<string>(dataReader, "line_name");
                currOutVo.LineCode = ConvertDBNull<string>(dataReader, "line_cd");
                currOutVo.InspectionItemLineFormatId = ConvertDBNull<int>(dataReader, "item_line_inspection_format_id");
                currOutVo.InspectionProcessId = ConvertDBNull<int>(dataReader, "inspection_process_id");
                if (outVo == null)
                {
                    outVo = new ValueObjectList<InspectionFormatVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
