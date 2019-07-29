using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class UpdateShipdateDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;

            //Update ShipDate
            StringBuilder sql = new StringBuilder();
            sql.Append("update t_box_id set shipdate = :shipdate where boxid = :boxid");

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameter("shipdate", inVo.ShipDate);
            sqlParameter.AddParameter("boxid", inVo.BoxID);

            sqlCommandAdapter.ExecuteNonQuery(sqlParameter);

            //Record Shipment
            if (!inVo.A90Shipping)
            {
                StringBuilder sql_record = new StringBuilder();
                sql_record.Append("INSERT INTO t_shipment_record SELECT boxid, serialno, model, :shipdate, :shipstatus, lot FROM t_product_serial WHERE boxid = :boxid");

                DbCommandAdaptor sqlCommandAdapter1 = base.GetDbCommandAdaptor(trxContext, sql_record.ToString());

                DbParameterList sqlParameter1 = sqlCommandAdapter1.CreateParameterList();

                sqlParameter1.AddParameter("boxid", inVo.BoxID);
                sqlParameter1.AddParameter("shipdate", inVo.ShipDate);
                sqlParameter1.AddParameter("shipstatus", inVo.ShipStatus);

                sqlCommandAdapter1.ExecuteNonQuery(sqlParameter1);

                GA1ModelVo outVo = new GA1ModelVo
                {
                    AffectedCount = 1
                };

                return outVo;
            }
            else
            {
                StringBuilder sql_record = new StringBuilder();
                sql_record.Append("UPDATE t_shipment_record SET ship_date = :shipdate WHERE boxid = :boxid");

                DbCommandAdaptor sqlCommandAdapter1 = base.GetDbCommandAdaptor(trxContext, sql_record.ToString());

                DbParameterList sqlParameter1 = sqlCommandAdapter1.CreateParameterList();

                sqlParameter1.AddParameter("boxid", inVo.BoxID);
                sqlParameter1.AddParameter("shipdate", inVo.ShipDate);

                sqlCommandAdapter1.ExecuteNonQuery(sqlParameter1);

                GA1ModelVo outVo = new GA1ModelVo
                {
                    AffectedCount = 1
                };

                return outVo;
            }
        }
    }
}