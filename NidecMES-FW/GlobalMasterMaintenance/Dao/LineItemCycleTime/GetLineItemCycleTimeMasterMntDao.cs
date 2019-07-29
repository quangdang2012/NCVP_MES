using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetLineItemCycleTimeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineItemCycleTimeVo inVo = (LineItemCycleTimeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" select "); //lin.line_id, 
            //sqlQuery.Append(" lin.line_name, ");
            sqlQuery.Append(" si.sap_matnr_item_cd, ");
            sqlQuery.Append(" si.sap_maktx_item_name, ");
            sqlQuery.Append(" subQry.cycle_time,  ");
            sqlQuery.Append(" subQry.line_sap_item_id,  ");
            sqlQuery.Append(" subQry.line_id ");
            sqlQuery.Append(" from  sap_item si ");

            sqlQuery.Append("left join(select sap_matnr_item_cd, cycle_time, line_sap_item_id,line_id");
            sqlQuery.Append(" from m_line_sap_item li where li.line_id = :lineid) as subQry");

            //sqlQuery.Append(" right join m_line lin on lin.line_id = ct.line_id ");
            //sqlQuery.Append(" right join sap_item si on si.sap_matnr_item_cd = ct.sap_matnr_item_cd ");

            sqlQuery.Append(" on si.sap_matnr_item_cd = subQry.sap_matnr_item_cd ");

            sqlQuery.Append(" where ");
            sqlQuery.Append(" si.factory_cd = :factorycode ");

            //if (inVo.LineId > -1)
            //{
            //    sqlQuery.Append(" and ct.Line_id = :lineid ");
            //}
            if (inVo.SapItemCode != null)
            {
                sqlQuery.Append(" and si.sap_matnr_item_cd = :sapMatnrItemCd ");
            }
            sqlQuery.Append(" ORDER BY si.sap_matnr_item_cd,subQry.cycle_time");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            //sqlParameter.AddParameterInteger("lineId", inVo.LineId);
            //if (inVo.SapItemCode != null)
            //{
                sqlParameter.AddParameterInteger("lineid", inVo.LineId);
                sqlParameter.AddParameterString("sapMatnrItemCd", inVo.SapItemCode);
            //}
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);

            //sqlQuery.Append(" order by gi.global_item_id ");
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<LineItemCycleTimeVo> lineItemCycleTimeVo = null;

            while (dataReader.Read())
            {
                LineItemCycleTimeVo currVo = new LineItemCycleTimeVo
                {
                    LineId = ConvertDBNull<int>(dataReader, "Line_id"),
                    //LineName = ConvertDBNull<string>(dataReader, "line_name"),
                    SapItemCode = ConvertDBNull<string>(dataReader, "sap_matnr_item_cd"),
                    SapItemName = ConvertDBNull<string>(dataReader, "sap_maktx_item_name"),
                    StdCycleTime = ConvertDBNull<decimal>(dataReader, "cycle_time"),
                    LineItemCycleTimeId = ConvertDBNull<int>(dataReader, "line_sap_item_id")
                };
                if (lineItemCycleTimeVo == null)
                {
                    lineItemCycleTimeVo = new ValueObjectList<LineItemCycleTimeVo>();
                }
                lineItemCycleTimeVo.add(currVo);
            }

            dataReader.Close();

            return lineItemCycleTimeVo;
        }
    }
}
