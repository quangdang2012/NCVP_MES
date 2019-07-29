using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchProductionoOutputMotorDao : AbstractDataAccessObject
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

            sql.Append("select count(*) datas from (");
            sql.Append("select * from (");
            sql.Append("select a90_barcode bar,max(a90_date+a90_time) from t_checkpusha90 ");
            sql.Append("where  a90_date+a90_time >= :datefrom and a90_date+a90_time <= :dateto ");
            if (!string.IsNullOrEmpty(inVo.LineCode))
            {
                sql.Append(@" and a90_line  =:line");
                sqlParameter.AddParameterString("line", inVo.LineCode);
            }
            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(@" and a90_model  =:a90_model");
                sqlParameter.AddParameterString("a90_model", inVo.ModelCode);
            }
            sql.Append(" group by a90_barcode) a left join t_checkpusha90 b on a.bar = b.a90_barcode and a.max = b.a90_date+b.a90_time ) tbl ");
            sql.Append("where 1=1 and bar not like ''");
            if (inVo.change)
            {
                sql.Append(@" and a90_thurst_status = 'OK' ");
            }
            else
            {
                sql.Append(@" and a90_thurst_status = 'NG' ");
            }

            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerGA1Vo outVo = new ProductionControllerGA1Vo
                {
                    InspecData = dataReader["datas"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;

        }
    }
}