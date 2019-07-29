using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchExportNoiseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            GA1ModelVo voList = new GA1ModelVo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select model,line, eq_id machine,barcode, serial_id , id, date_check, judgment, l1_v_cw, l1_v_ccw, e1_v_cw, e2_v_cw, e3_v_cw, e4_v_cw, e5_v_cw, e1_v_ccw, e2_v_ccw, e3_v_ccw, e4_v_ccw, e5_v_ccw, registration_user_cd, registration_date_time, factory_cd from t_noisecheck_a90 where ");
            sql.Append(@" registration_date_time >= :datefrom and registration_date_time <= :dateto ");
            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);
            if (!string.IsNullOrEmpty(inVo.Noise_eq_id))
            {
                sql.Append(" and eq_id = :eq_id ");
                sqlParameter.AddParameter("eq_id", inVo.Noise_eq_id);
            }
            sql.Append("order by eq_id,date_check");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //execute SQL

            GA1ModelVo outVo1 = new GA1ModelVo
            {
                dt = ds.Tables[0],
            };

            return outVo1;

        }
    }
}