using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetMachineModelDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DrawingVo inVo = (DrawingVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<DrawingVo> voList = new ValueObjectList<DrawingVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT distinct b.machine_name from m_machine b, t_draw a where a.machine_id = b.machine_id and model_id = :model_id");

            sqlParameter.AddParameterInteger("model_id", inVo.ModelId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());



            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DrawingVo outVo = new DrawingVo
                {
                    //DrawId = int.Parse(dataReader["draw_id"].ToString()),
                    //DrawCode = dataReader["draw_cd"].ToString(),
                    MachineName = dataReader["machine_name"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }

}
