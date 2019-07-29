using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetModelRateNGDao : AbstractDataAccessObject
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

            sql.Append("select distinct rate_ng_model from m_rate_ng where 1=1");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            //execute SQL
            while (dataReader.Read())
            {
                RateNGVo outVo1 = new RateNGVo
                {
                    RateModel = dataReader["rate_ng_model"].ToString(),
                };
                voList.add(outVo1);
            }
            dataReader.Close();
            return voList;
        }
    }
}