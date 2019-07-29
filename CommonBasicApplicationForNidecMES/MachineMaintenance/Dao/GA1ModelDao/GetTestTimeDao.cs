using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetTestTimeDao : AbstractDataAccessObject
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
            sql.Append("select a.a90_model as Model, a.a90_line as Line, a.a90_thurst_status as Thurst, a.a90_factory as Thurst_MC, a.a90_noise_status as Noise, a90_oqc_data as NG_Thurst,weight from t_checkpusha90 a left join m_machine_thurst b on a.a90_model = b.model and a.a90_line = b.line and a.a90_factory = b.machine where a90_barcode = '" + inVo.A90Barcode + "' order by a90_date + a90_time desc");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            DataSet ds = new DataSet();
            ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);
            //execute SQL
            //IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            GA1ModelVo outVo = new GA1ModelVo
            {
                dt = ds.Tables[0]
            };

            return outVo;
        }
    }
}