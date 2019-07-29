using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class AddGA1ModelThurstDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into t_checkpusha90(a90_model, a90_line, a90_barcode, a90_thurst_status, a90_shipping ,a90_user_cd, a90_date, a90_time, a90_factory) ");
                                    sql.Append("values(:a90_model,:a90_line, :a90_barcode, :a90_thurst_status,:a90_shipping,:a90_user_cd,now(),now(),:a90_factory)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();


            sqlParameter.AddParameter("a90_model", inVo.A90Model);
            sqlParameter.AddParameter("a90_line", inVo.A90Line);
            sqlParameter.AddParameter("a90_barcode", inVo.A90Barcode);
            sqlParameter.AddParameter("a90_thurst_status", inVo.A90ThurstStatus);
            sqlParameter.AddParameter("a90_shipping", inVo.A90Shipping);
            //sqlParameter.AddParameter("a90_date", inVo.Date);
            //sqlParameter.AddParameter("a90_time", inVo.Time);
            sqlParameter.AddParameter("a90_user_cd", inVo.RegistrationUserCode);
           // sqlParameter.AddParameter("registration_date_time", inVo.RegistrationDateTime);
            sqlParameter.AddParameter("a90_factory", inVo.FactoryCode);
            //execute SQL

            GA1ModelVo outVo = new GA1ModelVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
