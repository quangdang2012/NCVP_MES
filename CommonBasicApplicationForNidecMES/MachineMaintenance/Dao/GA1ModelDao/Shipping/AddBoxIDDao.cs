using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class AddBoxIDDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into t_box_id(boxid, printdate, user_cd, child_model) ");
            sql.Append("values(:boxid, now(), :user_cd, :child_model)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameter("boxid", inVo.BoxID);
            sqlParameter.AddParameter("printdate", inVo.PrintDate);
            sqlParameter.AddParameter("user_cd", inVo.User);
            sqlParameter.AddParameter("child_model", inVo.ModelCode);

            //execute SQL

            GA1ModelVo outVo = new GA1ModelVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };
            
            return outVo;
        }
    }
}
