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
            DataTable temp = new DataTable();
            DataTable dt = new DataTable();
            //CREATE SQL ADAPTER AND PARAMETER LIST
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //ADD COMMAND
            foreach (string table in InVo.SernoDBList)
            {
                sql.Append("select serno, lot, model, site, factory, line, process, inspectdate from " + table + " where 1=1");
                if (InVo.SernoList.Length > 0)
                {
                    sql.Append(" and serno in (" + InVo.SernoList.ToString() + ")");
                }
                else
                {
                    sql.Append(" and inspectdate >= '" + InVo.DateTimeFrom.ToString("yyyy-MM-dd HH:mm:ss")
                        + "' and inspectdate <= '" + InVo.DateTimeTo.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                }
                sql.Append("order by inspectdate asc");
                sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
                sql.Clear();
                //EXECUTE READER FROM COMMAND
                IDataReader datareader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
                //GET DATATABLE FROM SQL
                temp.Load(datareader);
                dt.Merge(temp);
                temp.Clear();
            }
            PQMDataViewerVo OutVo = new PQMDataViewerVo
            {
                SernoDataTable = dt
            };
            return OutVo;
        }
    }
}
