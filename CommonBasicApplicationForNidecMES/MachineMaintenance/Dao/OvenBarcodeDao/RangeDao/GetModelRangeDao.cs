using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetModelRangeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            RangeVo inVo = (RangeVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<RangeVo> voList = new ValueObjectList<RangeVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select distinct model from t_ovenmachine order by model ");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                RangeVo outVo = new RangeVo
                {
                    Model = dataReader["model"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
