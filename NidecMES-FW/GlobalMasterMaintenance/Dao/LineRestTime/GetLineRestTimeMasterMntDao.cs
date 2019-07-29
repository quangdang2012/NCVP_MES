using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetLineRestTimeMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineRestTimeVo inVo = (LineRestTimeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append(" select "); 
            sqlQuery.Append(" line_rest_time_id, ");
            sqlQuery.Append(" line_id, ");
            sqlQuery.Append(" shift, ");
            sqlQuery.Append(" plan_rest_minutes  ");
            sqlQuery.Append(" from m_line_rest_time ");
            sqlQuery.Append(" where ");
            sqlQuery.Append(" factory_cd = :factorycode ");

            if (inVo.LineId > 0)
            {
                sqlQuery.Append(" and line_id = :lineid ");
            }

            sqlQuery.Append(" ORDER BY shift");
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);
            
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<LineRestTimeVo> lineRestTimeVo = null;

            while (dataReader.Read())
            {
                LineRestTimeVo currVo = new LineRestTimeVo();
                currVo.LineRestTimeId = ConvertDBNull<int>(dataReader, "line_rest_time_id");
                currVo.LineId = ConvertDBNull<int>(dataReader, "line_id");
                currVo.Shift = ConvertDBNull<int>(dataReader, "shift");
                if(dataReader["plan_rest_minutes"] != null)
                {
                    currVo.PlanRestMinutes = ConvertDBNull<int>(dataReader, "plan_rest_minutes");
                }
                
                if (lineRestTimeVo == null)
                {
                    lineRestTimeVo = new ValueObjectList<LineRestTimeVo>();
                }
                lineRestTimeVo.add(currVo);
            }

            dataReader.Close();

            return lineRestTimeVo;
        }
    }
}
