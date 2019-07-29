using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetLineRateNGDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RateNGVo inVo = (RateNGVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<RateNGVo> voList = new ValueObjectList<RateNGVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append("select distinct rate_ng_line from m_rate_ng where 1=1");
            if (!string.IsNullOrEmpty(inVo.RateModel))
            {
                sql.Append(" and rate_ng_model = :rate_ng_model");
                sqlParameter.AddParameter("rate_ng_model", inVo.RateModel);
            }
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            //execute SQL
            while (dataReader.Read())
            {
                RateNGVo outVo1 = new RateNGVo
                {
                    RateLine = dataReader["rate_ng_line"].ToString(),
                };
                voList.add(outVo1);
            }
            dataReader.Close();
            return voList;
        }
    }
}