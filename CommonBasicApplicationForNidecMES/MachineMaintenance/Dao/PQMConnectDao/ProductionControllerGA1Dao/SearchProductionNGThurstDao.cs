using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchProductionNGThurstDao : AbstractDataAccessObject
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
            sql.Append("select count(*) datas from (select * from ");
            sql.Append("(select a90_barcode bar,max(oid) oid from t_checkpusha90 where a90_date+a90_time >= :datefrom and a90_date+a90_time <= :dateto  ");
            if (!string.IsNullOrEmpty(inVo.LineCode))
            {
                sql.Append(" and a90_line = :a90_line ");
                sqlParameter.AddParameter("a90_line", inVo.LineCode);
            }
            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(" and a90_model = :a90_model ");
                sqlParameter.AddParameter("a90_model", inVo.ModelCode);
            }

            sql.Append(" group by a90_barcode) a left join t_checkpusha90 b on a.oid = b.oid where  b.a90_oqc_data = 'NG') b");
            sqlParameter.AddParameter("datefrom", inVo.DateFrom);
            sqlParameter.AddParameter("dateto", inVo.DateTo);
            //group by a90_barcode) a left join t_checkpusha90 b on a.oid = b.oid where  b.a90_oqc_data = 'NG') b
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            //DataSet ds = sqlCommandAdapter.ExecuteScalar(sqlParameter);
            IDataReader reader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            //execute SQL
            while (reader.Read())
            {
                ProductionControllerGA1Vo outVo = new ProductionControllerGA1Vo
                {
                    //LineCode = dataReader["line"].ToString() inspectdata
                    InspecData = reader["datas"].ToString()
                };
                voList.add(outVo);
            }
            
            reader.Close();

            return voList;

        }
    }
}