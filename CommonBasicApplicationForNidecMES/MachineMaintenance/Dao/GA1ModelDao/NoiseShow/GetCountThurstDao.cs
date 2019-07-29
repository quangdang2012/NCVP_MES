using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetCountThurstDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            GA1ModelVo outVo = new GA1ModelVo();
            StringBuilder sql = new StringBuilder();
            StringBuilder sqlUpdate = new StringBuilder();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT count(*) FROM t_checkpusha90 WHERE oid IN (select MAX(oid) from t_checkpusha90 where a90_date +a90_time > :datefrom and a90_date +a90_time < :dateto AND a90_factory  =:a90_factory GROUP BY a90_barcode) and a90_line =:a90_line  ");
            sqlParameter.AddParameter("a90_factory ", inVo.Noise_eq_id);
            sqlParameter.AddParameter("datefrom ", inVo.DateFrom);
            sqlParameter.AddParameter("dateto ", inVo.DateTo);
            sqlParameter.AddParameter("a90_line", inVo.LineCode);
            if (!inVo.Status)//status = false => search output || status = true => search input
            {
                sql.Append(@" AND a90_thurst_status  = 'OK'");
            }
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            int rowCount = int.Parse(sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString());
            
            outVo = new GA1ModelVo
            {
                AffectedCount = rowCount,
            };

            return outVo;
        }
    }
}