using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetLineMoDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            LineVo  inVo = (LineVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<LineVo> voList = new ValueObjectList<LineVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT b.line_id, b.line_cd from m_line b, m_model_line a where a.line_id = b.line_id and model_id = :model_id order by line_id");


            sqlParameter.AddParameterInteger("model_id", inVo.LineId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());



            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                LineVo outVo = new LineVo
                {
                     LineId = int.Parse(dataReader["line_id"].ToString()),
                     LineCode = dataReader["line_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }

}
