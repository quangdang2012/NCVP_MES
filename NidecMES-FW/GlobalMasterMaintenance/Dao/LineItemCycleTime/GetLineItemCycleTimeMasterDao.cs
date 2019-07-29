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
    public class GetLineItemCycleTimeMasterDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineItemCycleTimeVo inVo = (LineItemCycleTimeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" select ");
            sqlQuery.Append(" sap_matnr_item_cd, ");
            sqlQuery.Append(" cycle_time, ");
            sqlQuery.Append(" line_sap_item_id, ");
            sqlQuery.Append(" line_id ");
            sqlQuery.Append(" from  m_line_sap_item ");
            sqlQuery.Append(" where ");
            sqlQuery.Append(" factory_cd = :factorycode ");
            sqlQuery.Append(" and line_id = :lineid ");

            if(inVo.SapItemCode != null)
            {
                sqlQuery.Append(" and sap_matnr_item_cd = :sapMatnrItemCd ");
            }

            sqlQuery.Append(" ORDER BY sap_matnr_item_cd, cycle_time");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);
            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterString("sapMatnrItemCd", inVo.SapItemCode);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<LineItemCycleTimeVo> lineItemCycleTimeVo = null;

            while (dataReader.Read())
            {
                LineItemCycleTimeVo currVo = new LineItemCycleTimeVo();
                currVo.LineId = ConvertDBNull<int>(dataReader, "line_id");
                currVo.SapItemCode = ConvertDBNull<string>(dataReader, "sap_matnr_item_cd");
                if(dataReader["cycle_time"] != null)
                {
                    currVo.StdCycleTimeNull = ConvertDBNull<decimal>(dataReader, "cycle_time");
                }
                currVo.LineItemCycleTimeId = ConvertDBNull<int>(dataReader, "line_sap_item_id");

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
