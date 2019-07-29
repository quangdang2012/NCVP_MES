using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetProductionRateNGRatioDao : AbstractDataAccessObject
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

            sql.Append("select rate_ng_ratio from m_rate_ng where 1=1 ");

            if (!string.IsNullOrEmpty(inVo.RateModel))
            {
                sql.Append(@" and rate_ng_model  =:rate_ng_model");
                sqlParameter.AddParameterString("rate_ng_model", inVo.RateModel);
            }
            if (!string.IsNullOrEmpty(inVo.RateLine))
            {
                sql.Append(@" and rate_ng_line  =:rate_ng_line");
                sqlParameter.AddParameterString("rate_ng_line", inVo.RateLine);
            }
            if (!string.IsNullOrEmpty(inVo.RateCode))
            {
                sql.Append(@" and rate_ng_cd  =:rate_ng_cd");
                sqlParameter.AddParameterString("rate_ng_cd", inVo.RateCode);
            }

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            string a = sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString();

            RateNGVo outVo = new RateNGVo
            {
                RateRatio = a,
            };
            return outVo;
        }
    }
}