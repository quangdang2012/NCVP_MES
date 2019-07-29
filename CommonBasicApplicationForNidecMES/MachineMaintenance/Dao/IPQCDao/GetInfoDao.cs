using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetInfoDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            IPQCVo inVo = (IPQCVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<IPQCVo> voList = new ValueObjectList<IPQCVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select upper, lower, clm_set, row_set, instrument from tbl_measure_item where model = '" + inVo.Model + "' and inspect = '" + inVo.Inspect + "' and process = '" + inVo.Process + "'");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                IPQCVo outVo = new IPQCVo
                {
                    Upper = double.Parse(dataReader["upper"].ToString()),
                    Lower = double.Parse(dataReader["lower"].ToString()),
                    Instrument = dataReader["instrument"].ToString(),
                    ClmSet = int.Parse(dataReader["clm_set"].ToString()),
                    RowSet = int.Parse(dataReader["row_set"].ToString())
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}