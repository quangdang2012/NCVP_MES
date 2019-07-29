using System.Text;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchtabMainDGVDao : AbstractDataAccessObject
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

            sql.Append("select 'INPUT' inspect, ");
            sql.Append(select(inVo.TableName,inVo.ModelCode, inVo.LineCode, inVo.DateFrom, inVo.DateTo, "FRAME", "IP") + " FRAME,");
            sql.Append(select(inVo.TableName, inVo.ModelCode, inVo.LineCode, inVo.DateFrom, inVo.DateTo, "GEAR", "IP") + " GEAR,");
            sql.Append(select(inVo.TableName, inVo.ModelCode, inVo.LineCode, inVo.DateFrom, inVo.DateTo, "MOTOR", "IP") + " MOTOR ");

            sql.Append("union ");

            sql.Append("select 'OUTPUT' inspect, ");
            sql.Append(select(inVo.TableName, inVo.ModelCode, inVo.LineCode, inVo.DateFrom, inVo.DateTo, "FRAME", "OP") + " FRAME,");
            sql.Append(select(inVo.TableName, inVo.ModelCode, inVo.LineCode, inVo.DateFrom, inVo.DateTo, "GEAR", "OP") + " GEAR,");
            sql.Append(select(inVo.TableName, inVo.ModelCode, inVo.LineCode, inVo.DateFrom, inVo.DateTo, "MOTOR", "OP") + " MOTOR ");

            sql.Append("union ");

            sql.Append("select 'TOTAL NG' inspect, ");
            sql.Append(select(inVo.TableName, inVo.ModelCode, inVo.LineCode, inVo.DateFrom, inVo.DateTo, "FRAME", "NG") + " FRAME, ");
            sql.Append(select(inVo.TableName, inVo.ModelCode, inVo.LineCode, inVo.DateFrom, inVo.DateTo, "GEAR", "NG") + " GEAR, ");
            sql.Append(select(inVo.TableName, inVo.ModelCode, inVo.LineCode, inVo.DateFrom, inVo.DateTo, "MOTOR", "NG") + " MOTOR ");

            sql.Append("order by inspect ");

            //sqlParameter.AddParameter("model", inVo.ModelCode);
            //sqlParameter.AddParameter("line", inVo.LineCode);
            //sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            //sqlParameter.AddParameter("dateto", inVo.DateTo);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            DataSet ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //execute SQL

            ProductionControllerGA1Vo outVo1 = new ProductionControllerGA1Vo
            {
                dt = ds.Tables[0],
            };

            return outVo1;

        }
        public string select(string tablename,string model, string line, DateTime dateFrom, DateTime dateTo, string process, string group)
        {
            string sqlSelect = "(select sum(inspectdata) from "+ tablename + " c left join " + tablename + "data a on c.serno = a.serno and c.inspectdate = a.inspectdate left join rule_processtbl b on a.inspect = b.inspect where c.model = '" + model + "' and c.line = '" + line + "' and c.inspectdate >= '" + dateFrom.ToString() + "' and c.inspectdate <= '" + dateTo.ToString() + "' and b.process = '" + process + "' and process_group = '" + group + "')";
            return sqlSelect;
        } 
    }
}