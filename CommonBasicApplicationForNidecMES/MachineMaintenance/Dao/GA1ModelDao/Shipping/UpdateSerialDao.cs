using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class UpdateSerialDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update t_product_serial set serialno = :serialno, line = :line, thurst = :thurst, noise = :noise, lot = :lot, thurst_mc = :thurst_mc, noise_mc = :noise_mc where serialno = '" + inVo.A90Barcode + "'");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("serialno", inVo.ReplaceSerial);
            sqlParameter.AddParameterString("line", inVo.LineCode);
            sqlParameter.AddParameterString("thurst", inVo.A90ThurstStatus);
            sqlParameter.AddParameterString("noise", inVo.A90NoiseStatus);
            sqlParameter.AddParameterString("lot", inVo.Lot);
            sqlParameter.AddParameterString("thurst_mc", inVo.Thurst_MC);
            sqlParameter.AddParameterString("noise_mc", inVo.Noise_eq_id);

            //execute SQL

            GA1ModelVo outVo = new GA1ModelVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}