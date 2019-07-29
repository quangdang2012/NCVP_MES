using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdatePaletteMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            PaletteVo inVo = (PaletteVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_palette");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" palette_name = :palettename, ");
            sqlQuery.Append(" area_id = :areaid ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" palette_id = :paletteid ;");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("paletteid", inVo.PaletteId);
            sqlParameter.AddParameterString("palettename", inVo.PaletteName);
            sqlParameter.AddParameterInteger("areaid", inVo.AreaId);

            PaletteVo outVo = new PaletteVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo;
        }

  


    }
}
