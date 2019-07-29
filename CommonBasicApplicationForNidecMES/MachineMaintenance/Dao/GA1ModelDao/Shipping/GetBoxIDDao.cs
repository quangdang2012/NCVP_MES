using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using System;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetBoxIDDao : AbstractDataAccessObject
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
            sql.Append("select boxid, printdate, user_cd as User, shipdate, child_model from t_box_id where 1 = 1");

            DateTime nextdate = inVo.PrintDate.AddDays(1);
            sql.Append(" and printdate >= '" + inVo.PrintDate + "' and printdate < '" + nextdate + "'");
            //sqlParameter.AddParameterDateTime("printdate", inVo.PrintDate);
            //sqlParameter.AddParameterDateTime("printdate1", inVo.PrintDate.AddDays(1));

            sql.Append(" order by boxid");

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