using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetCountNoiseDao : AbstractDataAccessObject
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
            sql.Append(@"SELECT count(*) FROM t_noisecheck_a90 WHERE noise_id IN (select MAX(noise_id) from t_noisecheck_a90 where registration_date_time > :datefrom and registration_date_time < :dateto AND eq_id  = :eq_id GROUP BY BARCODE)  ");
            sqlParameter.AddParameter("eq_id ", inVo.Noise_eq_id);
            sqlParameter.AddParameter("datefrom ", inVo.DateFrom);
            sqlParameter.AddParameter("dateto ", inVo.DateTo);
            if (!inVo.Status)//status = false => search output || status = true => search input
            {
                sql.Append(@" AND SUBSTRING(judgment,0,3)  = 'OK'");
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