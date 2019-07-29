using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateShelfMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ShelfVo inVo = (ShelfVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_shelf");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" shelf_name = :shelfname, ");
            sqlQuery.Append(" area_id = :areaid ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" shelf_id = :shelfid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("shelfid", inVo.ShelfId);
            sqlParameter.AddParameterString("shelfname", inVo.ShelfName);
            sqlParameter.AddParameterInteger("areaid", inVo.AreaId);

            ShelfVo outVo = new ShelfVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
