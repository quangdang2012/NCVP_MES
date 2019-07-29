using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateLineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineVo inVo = (LineVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_line");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" line_name = :linename ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" line_id = :lineid ");
            sqlQuery.Append(" and factory_cd = :faccd ;");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            sqlParameter.AddParameterString("linename", inVo.LineName);
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            LineVo outVo = new LineVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }
    }
}
