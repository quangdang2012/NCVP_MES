using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetDrawingDao : AbstractDataAccessObject
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
            sql.Append(@"SELECT distinct b.draw_cd from m_draw b, t_draw a where a.draw_id = b.draw_id and draw_type = :draw_type and model_id = :model_id order by draw_cd");

            sqlParameter.AddParameterString("draw_type", inVo.DrawType);
            sqlParameter.AddParameterInteger("model_id", inVo.ModelId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DrawingVo outVo = new DrawingVo
                {
                    DrawCode = dataReader["draw_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}