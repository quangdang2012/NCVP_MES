using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchProductionExportDataDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerGA1Vo inVo = (ProductionControllerGA1Vo)vo;
            StringBuilder sql = new StringBuilder();
            ProductionControllerGA1Vo voList = new ProductionControllerGA1Vo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(" select a.process, a.inspect,a.sum inspectdata from (");
            sql.Append("select a.process, b.inspect, sum(b.inspectdata) from " + inVo.TableName + " a left join " + inVo.TableName + "data b on a.serno = b.serno where a.inspectdate >= :datefrom and a.inspectdate <= :dateto and a.model = :model and line =:line and a.process not in ('FA_IP','GC_IP') group by a.process, b.inspect");
            sql.Append(" union ");
            sql.Append("select 'FA_IP' process, 'Input Frame' inspect, sum(b.inspectdata) from " + inVo.TableName + " a left join " + inVo.TableName + "data b on a.serno = b.serno where a.inspectdate >= :datefrom and a.inspectdate <= :dateto and a.process in ('FA_IP') and a.model = :model and line =:line");
            sql.Append(" union ");
            sql.Append("select 'GC_IP' process, 'Input Gear' inspect, sum(b.inspectdata) from " + inVo.TableName + " a left join " + inVo.TableName + "data b on a.serno = b.serno where a.inspectdate >= :datefrom and a.inspectdate <= :dateto and a.process in ('GC_IP') and a.model = :model and line =:line");
            sql.Append(" union ");
            sql.Append("select 'TOTAL_F' process, 'Toal NG Frame' inspect, sum(b.inspectdata) from " + inVo.TableName + " a left join " + inVo.TableName + "data b on a.serno = b.serno where a.inspectdate >= :datefrom and a.inspectdate <= :dateto and a.process in ('FA_APP', 'FA_BallB', 'FA_Caulk') and a.model = :model and line =:line");
            sql.Append(" union ");
            sql.Append("select 'TOTAL_G' process, 'Toal NG Gear' inspect, sum(b.inspectdata) from " + inVo.TableName + " a left join " + inVo.TableName + "data b on a.serno = b.serno where a.inspectdate >= :datefrom and a.inspectdate <= :dateto and a.process in ('GC_Bear','GC_OSW','GC_PD','GC_C','GC_PU','GC_FGASS','GC_FGCHK')  and a.model = :model and line =:line");
            sql.Append(" union ");
            sql.Append("Select 'TOTAL_M' process, 'Toal NG Motor' inspect, sum(b.inspectdata) from " + inVo.TableName + " a left join " + inVo.TableName + "data b on a.serno = b.serno  where a.inspectdate >= :datefrom and a.inspectdate <= :dateto and a.process in ('MC_FPC','MC_FWCHK','MC_Mark','MC_NOICHK','MC_STMASS')  and a.model = :model and line =:line");
            sql.Append(" union ");
            sql.Append("select 'OUTPUT' process, 'OP3' inspect, cast(0 as double precision) sum ");
            sql.Append(" union ");
            sql.Append("select 'MC_THUCHK' process, 'THU_NG' inspect, cast(0 as double precision) sum ");

            sql.Append(") a left join processtbl c on a.process = c.process where c.line = :line order by c.stopmark, a.inspect ");

            sqlParameter.AddParameter("model", inVo.ModelCode);
            sqlParameter.AddParameter("line", inVo.LineCode);
            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //execute SQL

            ProductionControllerGA1Vo outVo1 = new ProductionControllerGA1Vo
            {
                dt = ds.Tables[0],
            };

            return outVo1;

        }
    }
}