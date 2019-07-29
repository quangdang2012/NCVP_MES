using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetInspectionFormatLastRecordforSerailNoMasterDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            InspectionFormatVo inVo = (InspectionFormatVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Select ");
            sqlQuery.Append(" inspection_format_cd ");
            sqlQuery.Append(" From ");
            sqlQuery.Append(" m_inspection_format if ");
            sqlQuery.Append(" inner join ");
            sqlQuery.Append(" m_item_line_inspection_format ilf ");
            sqlQuery.Append(" on if.inspection_format_id  = ilf.inspection_format_id ");
            sqlQuery.Append(" where if.factory_cd = :factorycode ");
            sqlQuery.Append(" and ilf.sap_matnr_item_cd = :sapitemcd ");
            sqlQuery.Append(" and ilf.line_id = :lineid ");
            sqlQuery.Append(" order by if.inspection_format_id desc ");
            sqlQuery.Append(" limit 1");
           
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("sapitemcd", inVo.SapItemCode);
            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionFormatVo outVo = new InspectionFormatVo();

            while (dataReader.Read())
            {
                outVo.InspectionFormatCode = ConvertDBNull<string>(dataReader, "inspection_format_cd");
            }
            dataReader.Close();            
            return outVo;
        }
    }
}
