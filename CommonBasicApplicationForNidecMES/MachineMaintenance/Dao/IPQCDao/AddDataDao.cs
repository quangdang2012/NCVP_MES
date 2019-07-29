using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class AddDataDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            IPQCVo inVo = (IPQCVo)vo;

            //Delete
            StringBuilder sqlDel = new StringBuilder();
            sqlDel.Append("delete from tbl_measure_history where model = :model and inspect = :inspect and lot = :lot and inspectdate = :inspectdate and line = :line");

            DbCommandAdaptor sqlCommandAdapterDel = base.GetDbCommandAdaptor(trxContext, sqlDel.ToString());

            DbParameterList sqlParameterDel = sqlCommandAdapterDel.CreateParameterList();
            sqlParameterDel.AddParameter("model", inVo.Model);
            sqlParameterDel.AddParameter("inspect", inVo.Inspect);
            sqlParameterDel.AddParameter("lot", inVo.Lot);
            sqlParameterDel.AddParameter("inspectdate", inVo.Inspectdate);
            sqlParameterDel.AddParameter("line", inVo.Line);

            sqlCommandAdapterDel.ExecuteNonQuery(sqlParameterDel);

            if (inVo.ins == 1)
            {
                //Insert
                StringBuilder sql = new StringBuilder();
                sql.Append("insert into tbl_measure_history(model, process, inspect, lot, inspectdate, line, qc_user, status, row_set, m1, m2, m3, m4, m5, x, r) VALUES (:model, :process , :inspect, :lot, :inspectdate, :line ,:qc_user, :status, :row_set, :m1, :m2, :m3, :m4, :m5, :x, :r)");

                DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

                DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
                sqlParameter.AddParameter("model", inVo.Model);
                sqlParameter.AddParameter("process", inVo.Process);
                sqlParameter.AddParameter("inspect", inVo.Inspect);
                sqlParameter.AddParameter("lot", inVo.Lot);
                sqlParameter.AddParameter("inspectdate", inVo.Inspectdate);
                sqlParameter.AddParameter("line", inVo.Line);
                sqlParameter.AddParameter("status", inVo.Status);

                int k = 1;
                for (int i = 0; i < inVo.dt.Rows.Count; i++)
                {
                    sqlParameter.AddParameter("qc_user", inVo.dt.Rows[i]["qc_user"]);
                    sqlParameter.AddParameter("row_set", k);
                    sqlParameter.AddParameter("m1", inVo.dt.Rows[i]["m1"]);
                    sqlParameter.AddParameter("m2", inVo.dt.Rows[i]["m2"]);
                    sqlParameter.AddParameter("m3", inVo.dt.Rows[i]["m3"]);
                    sqlParameter.AddParameter("m4", inVo.dt.Rows[i]["m4"]);
                    sqlParameter.AddParameter("m5", inVo.dt.Rows[i]["m5"]);
                    sqlParameter.AddParameter("x", inVo.dt.Rows[i]["x"]);
                    sqlParameter.AddParameter("r", inVo.dt.Rows[i]["r"]);

                    sqlCommandAdapter.ExecuteNonQuery(sqlParameter);
                    k++;
                }
            }

            IPQCVo outVo = new IPQCVo
            {
                AffectedCount = 1
            };

            return outVo;
        }
    }
}
