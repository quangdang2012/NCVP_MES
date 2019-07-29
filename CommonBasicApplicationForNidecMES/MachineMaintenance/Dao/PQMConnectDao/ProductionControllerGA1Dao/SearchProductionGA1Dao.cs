using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchProductionGA1Dao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerGA1Vo inVo = (ProductionControllerGA1Vo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProductionControllerGA1Vo> voList = new ValueObjectList<ProductionControllerGA1Vo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select a.process,case when sum(inspectdata) = null then 0 else sum(inspectdata) end inspectdata from " + inVo.TableName + " a left join " + inVo.TableName + "data b on a.serno = b.serno where ");
            sql.Append(@" a.inspectdate >= :datefrom and a.inspectdate <= :dateto and inspectdata != 0 and b.inspectdate >= :datefrom and b.inspectdate <= :dateto and a.inspectdate = b.inspectdate ");
            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);
            
            if (!string.IsNullOrEmpty(inVo.LineCode))
            {
                sql.Append(@" and a.line  =:line");
                sqlParameter.AddParameterString("line", inVo.LineCode);
            }

            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(@" and a.model  =:model ");
                sqlParameter.AddParameterString("model", inVo.ModelCode);
            }
            sql.Append("group by a.process order by a.process");
            //if (!string.IsNullOrEmpty(inVo.ProcessName))
            //{
            //    sql.Append(@" and a.process  =:process");
            //    sqlParameter.AddParameterString("process", inVo.ProcessName);
            //}
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerGA1Vo outVo = new ProductionControllerGA1Vo
                {
                    ProcessName = dataReader["process"].ToString(),
                    InspecData = dataReader["inspectdata"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;

        }
    }
}