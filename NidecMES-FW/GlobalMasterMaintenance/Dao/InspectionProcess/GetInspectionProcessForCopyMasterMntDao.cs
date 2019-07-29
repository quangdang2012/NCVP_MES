using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionProcessForCopyMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionProcessVo inVo = (InspectionProcessVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Select   ");
            sqlQuery.Append(" sap_maktx_item_name, ");
            sqlQuery.Append(" line_name, ");
            sqlQuery.Append(" ip.inspection_process_id ,    ");
            sqlQuery.Append(" ip.inspection_process_cd,     ");
            sqlQuery.Append(" ip.inspection_process_name,     ");
            sqlQuery.Append(" if.inspection_format_name         ");
            sqlQuery.Append(" from m_inspection_process ip ");
            sqlQuery.Append(" inner join  ");
            sqlQuery.Append(" m_inspection_format if  ");
            sqlQuery.Append(" on ip.inspection_format_id = if.inspection_format_id ");
            sqlQuery.Append(" inner join  ");
            sqlQuery.Append(" m_item_line_inspection_format  mit  ");
            sqlQuery.Append(" on mit.inspection_format_id = if.inspection_format_id  ");
            sqlQuery.Append(" inner join  ");
            sqlQuery.Append(" v_sap_item si  ");
            sqlQuery.Append(" on si.sap_matnr_item_cd = mit.sap_matnr_item_cd  ");
            sqlQuery.Append(" inner join   ");
            sqlQuery.Append(" m_line lin ");
            sqlQuery.Append(" on lin.line_id = mit.line_id     ");
            sqlQuery.Append(" where if.factory_cd = :faccd ");
            sqlQuery.Append(" and if.is_deleted = '0' ");

            if (inVo.InspectionProcessCode != null)
            {
                sqlQuery.Append(" and UPPER(inspection_process_cd) like UPPER(:inspectionprocesscd) ");
            }

            if (inVo.InspectionFormatName != null)
            {
                sqlQuery.Append(" and UPPER(inspection_process_name) like UPPER(:inspectionprocessname) ");
            }
            if (inVo.ItemCode != null)
            {
                sqlQuery.Append(" and si.sap_matnr_item_cd = :itemcode ");
            }
            if (inVo.LineCode != null)
            {
                sqlQuery.Append(" and lin.line_cd = :linecode ");
            }
            sqlQuery.Append(" order by ip.display_order, inspection_process_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();


            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterString("inspectionprocesscd", inVo.InspectionProcessCode + "%");
            sqlParameter.AddParameterString("inspectionprocessname", inVo.InspectionProcessName + "%");
            sqlParameter.AddParameterString("linecode", inVo.LineCode);
            sqlParameter.AddParameterString("itemcode", inVo.ItemCode);


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<InspectionProcessVo> outVo = null;

            while (dataReader.Read())

            {
                InspectionProcessVo currOutVo = new InspectionProcessVo();
                //currOutVo.ItemName = ConvertDBNull<string>(dataReader, "global_item_name");
                //currOutVo.LineName = ConvertDBNull<string>(dataReader, "line_name");
                currOutVo.InspectionProcessId = ConvertDBNull<int>(dataReader, "inspection_process_id");
                currOutVo.InspectionProcessName = ConvertDBNull<string>(dataReader, "inspection_process_name");
                currOutVo.InspectionProcessCode = ConvertDBNull<string>(dataReader, "inspection_process_cd");
                currOutVo.InspectionFormatName = ConvertDBNull<string>(dataReader, "inspection_format_name");
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
