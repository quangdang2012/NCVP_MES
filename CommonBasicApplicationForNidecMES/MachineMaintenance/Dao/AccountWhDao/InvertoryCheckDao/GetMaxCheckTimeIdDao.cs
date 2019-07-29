using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetMaxCheckTimeIdDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InvertoryVo inVo = (InvertoryVo)vo;
            StringBuilder sql = new StringBuilder();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select max(invertory_time_id) maxid from m_invertory_time ");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //IDataReader dataReader = sqlCommandAdapter.ExecuteScalar(sqlParameter);

            InvertoryVo outVo = new InvertoryVo
            {
                InvertoryTimeId = int.Parse(sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString()),
            };
          
            //dataReader.Close();
            return outVo;
        }

    }
}
