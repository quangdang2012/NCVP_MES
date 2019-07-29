using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetInspectItemDao : AbstractDataAccessObject
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
            sql.Append("select no, model, process, inspect, description, instrument from tbl_measure_item where model='"
                + inVo.Model + "' order by no, process, inspect");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                IPQCVo outVo = new IPQCVo
                {
                    No = dataReader["no"].ToString(),
                    Model = dataReader["model"].ToString(),
                    Process = dataReader["process"].ToString(),
                    Inspect = dataReader["inspect"].ToString(),
                    Description = dataReader["description"].ToString(),
                    Instrument = dataReader["instrument"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}