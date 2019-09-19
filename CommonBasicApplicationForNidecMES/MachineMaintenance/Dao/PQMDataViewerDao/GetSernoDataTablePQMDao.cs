using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetSernoDataTablePQMDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            PQMDataViewerVo InVo = (PQMDataViewerVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //ADD COMMAND
            foreach (string table in InVo.SernoDBList)
            {
                sql.Append(@"select serno, lot, model, site, factory, line, process, inspectdate from " + table + " where 1=1");
                if (!string.IsNullOrEmpty(InVo.SernoList))
                {
                    sql.Append(@" and serno in (:sernolist) ");
                    sqlParameter.AddParameterString("sernolist", InVo.SernoList);
                }
                else
                {
                    sql.Append(@" and inspectdate > :datetimefrom and inspectdate < :datetimeto ");
                    sqlParameter.AddParameterString("datetimefrom", InVo.DateTimeFrom.ToString("yyyy-MM-dd HH:mm:ss"));
                    sqlParameter.AddParameterString("datetimeto", InVo.DateTimeTo.ToString("yyyy-MM-dd HH:mm:ss"));
                }
                sql.Append(@"order by inspectdate asc");
                sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
                //EXECUTE TO DATASET
                DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);
                DataTable temp = ds.Tables[0];
                InVo.SernoDataTable.Merge(temp);
            }
            return InVo;
        }
    }
}
