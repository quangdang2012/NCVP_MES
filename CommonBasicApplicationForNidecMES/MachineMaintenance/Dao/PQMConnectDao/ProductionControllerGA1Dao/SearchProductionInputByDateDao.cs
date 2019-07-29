using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchProductionInputByDateDao : AbstractDataAccessObject
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
            string line = "";
            string grline = "";
            if (!string.IsNullOrEmpty(inVo.LineCode))
            {
                line = ",a.line";
                grline = ",a.line";
            }
            else { line = ",cast ('All Line' as character varying) line"; grline = ",line"; }
            sql.Append(@"select id,model, line,dates, process, sum(inspectdata) inspectdata from (select cast(dense_rank() over(partition by line order by process) as int ) id, a.model" + line + ", a.process,cast (a.inspectdate as date) dates, a.serno, sum(inspectdata) inspectdata from  " + inVo.TableName);
            sql.Append(" a left join " + inVo.TableName + "data b on a.serno = b.serno where a.inspectdate = b.inspectdate ");
            sql.Append(@" and a.inspectdate >= :datefrom and a.inspectdate <= :dateto ");
            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);

            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(@" and a.model  =:model");
                sqlParameter.AddParameterString("model", inVo.ModelCode);
            }
            if (!string.IsNullOrEmpty(inVo.LineCode))
            {
                sql.Append(@" and a.line  =:line");
                sqlParameter.AddParameterString("line", inVo.LineCode);
            }
            if (!string.IsNullOrEmpty(inVo.ProcessCode))
            {
                sql.Append(@" and a.process  =:process");
                sqlParameter.AddParameterString("process", inVo.ProcessCode);
            }
            sql.Append(@" group by process" + grline + ",a.model,a.serno,a.inspectdate order by a.inspectdate ) tbl ");
            sql.Append(@" group by id,dates, model,line, process order by dates");

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