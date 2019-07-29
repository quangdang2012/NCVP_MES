using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetDownTimeDataDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ReportDownTimeVo  inVo = (ReportDownTimeVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ReportDownTimeVo> voList = new ValueObjectList<ReportDownTimeVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT * from public.t_downtime_report");


         //   sqlParameter.AddParameterInteger("model_id", inVo.LineId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());



            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            //while (dataReader.Read())
            //{
            //    LineVo outVo = new LineVo
            //    {
            //        LineId = int.Parse(dataReader["line_id"].ToString()),
            //        LineCode = dataReader["line_cd"].ToString()
            //    };
            //    voList.add(outVo);
            //}
            dataReader.Close();
            return voList;
        }

    }

}
