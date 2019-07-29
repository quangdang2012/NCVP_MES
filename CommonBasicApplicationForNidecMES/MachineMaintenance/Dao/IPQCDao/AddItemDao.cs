using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class AddItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            IPQCVo inVo = (IPQCVo)vo;

            //Insert
            StringBuilder sql = new StringBuilder();
            sql.Append("INSERT INTO tbl_measure_item(no, model, process, inspect, description, upper, lower, instrument, clm_set, row_set) VALUES (:no, :model, :process, :inspect, :description, :upper, :lower, :instrument, :clm_set, :row_set)");

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameter("no", inVo.No);
            sqlParameter.AddParameter("model", inVo.Model);
            sqlParameter.AddParameter("process", inVo.Process);
            sqlParameter.AddParameter("inspect", inVo.Inspect);
            sqlParameter.AddParameter("description", inVo.Description);
            sqlParameter.AddParameter("upper", inVo.Upper);
            sqlParameter.AddParameter("lower", inVo.Lower);
            sqlParameter.AddParameter("instrument", inVo.Instrument);
            sqlParameter.AddParameter("clm_set", inVo.ClmSet);
            sqlParameter.AddParameter("row_set", inVo.RowSet);

            IPQCVo outVo = new IPQCVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
