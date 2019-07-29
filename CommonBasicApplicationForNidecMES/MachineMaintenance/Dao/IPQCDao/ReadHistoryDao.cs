using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class ReadHistoryDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            IPQCVo inVo = (IPQCVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<IPQCVo> voList = new ValueObjectList<IPQCVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            sql.Append("select inspect, lot, inspectdate, line, qc_user, status, m1, m2, m3, m4, m5, x, r FROM tbl_measure_history WHERE model = :model AND process = :process AND inspect = :inspect AND lot >= :lot AND lot <= :lotlast AND line = :line order by lot, inspectdate");

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("model", inVo.Model);
            sqlParameter.AddParameter("process", inVo.Process);
            sqlParameter.AddParameter("inspect", inVo.Inspect);
            sqlParameter.AddParameter("lot", inVo.Lot);
            sqlParameter.AddParameter("lotlast", inVo.LotLast);
            sqlParameter.AddParameter("line", inVo.Line);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            DataSet ds = new DataSet();
            ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //execute SQL
            IPQCVo outVo = new IPQCVo
            {
                dt = ds.Tables[0]
            };
            return outVo;
        }
    }
}