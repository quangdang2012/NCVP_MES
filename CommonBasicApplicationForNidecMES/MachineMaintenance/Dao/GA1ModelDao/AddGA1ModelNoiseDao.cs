using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class AddGA1ModelNoiseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into t_noisecheck_a90(eq_id , model ,line , serial_id , id ,date_check ,judgment ,l1_v_cw , l1_v_ccw , e1_v_cw , e2_v_cw , e3_v_cw , e4_v_cw , e5_v_cw , e1_v_ccw ,e2_v_ccw , e3_v_ccw ,e4_v_ccw , e5_v_ccw ,  barcode , registration_user_cd , registration_date_time , factory_cd) ");
                                    sql.Append("values(:eq_id , :model ,:line , :serial_id , :id ,:date_check ,:judgment ,:l1_v_cw , :l1_v_ccw , :e1_v_cw , :e2_v_cw , :e3_v_cw , :e4_v_cw , :e5_v_cw , :e1_v_ccw ,:e2_v_ccw , :e3_v_ccw ,:e4_v_ccw , :e5_v_ccw , :barcode , :registration_user_cd , now() , :factory_cd)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameter("eq_id ", inVo.Noise_eq_id);
            sqlParameter.AddParameter("model ", inVo.Noise_model);
            sqlParameter.AddParameter("line ", inVo.Noise_line);
            sqlParameter.AddParameter("serial_id", inVo.Noise_serial_id);
            sqlParameter.AddParameter("id ", inVo.Noise_id);
            sqlParameter.AddParameter("date_check", inVo.Noise_date_check);
            sqlParameter.AddParameter("judgment ", inVo.Noise_judgment);
            sqlParameter.AddParameter("l1_v_cw", inVo.Noise_l1_v_cw);
            sqlParameter.AddParameter("l1_v_ccw ", inVo.Noise_l1_v_ccw);
            sqlParameter.AddParameter("e1_v_cw ", inVo.Noise_e1_v_cw);
            sqlParameter.AddParameter("e2_v_cw ", inVo.Noise_e2_v_cw);
            sqlParameter.AddParameter("e3_v_cw ", inVo.Noise_e3_v_cw);
            sqlParameter.AddParameter("e4_v_cw ", inVo.Noise_e4_v_cw);
            sqlParameter.AddParameter("e5_v_cw ", inVo.Noise_e5_v_cw);
            sqlParameter.AddParameter("e1_v_ccw ", inVo.Noise_e1_v_ccw);
            sqlParameter.AddParameter("e2_v_ccw ", inVo.Noise_e2_v_ccw);
            sqlParameter.AddParameter("e3_v_ccw ", inVo.Noise_e3_v_ccw);
            sqlParameter.AddParameter("e4_v_ccw ", inVo.Noise_e4_v_ccw);
            sqlParameter.AddParameter("e5_v_ccw ", inVo.Noise_e5_v_ccw);
            sqlParameter.AddParameter("barcode", inVo.Noise_barcode);
            sqlParameter.AddParameter("registration_user_cd ", inVo.Noise_registration_user_cd);
            //sqlParameter.AddParameter("registration_date_time", inVo.Noise_registration_date_time);
            sqlParameter.AddParameter("factory_cd", inVo.Noise_factory_cd);

            //execute SQL

            GA1ModelVo outVo = new GA1ModelVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
