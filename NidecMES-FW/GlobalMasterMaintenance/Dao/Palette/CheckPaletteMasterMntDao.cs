using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckPaletteMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            PaletteVo inVo = (PaletteVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as paletteCount from m_palette ");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.PaletteCode != null)
            {
                sqlQuery.Append(" and UPPER(palette_cd) = UPPER(:palettecd) ");
            }

            //if (inVo.AreaId > 0)
            //{
            //    sqlQuery.Append(" and area_id = :areaid ");
            //}

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.PaletteCode != null)
            {
                sqlParameter.AddParameterString("palettecd", inVo.PaletteCode);
            }

            //if (inVo.AreaId > 0)
            //{
            //    sqlParameter.AddParameterInteger("areaid", inVo.AreaId);
            //}

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            PaletteVo outVo = new PaletteVo {AffectedCount = 0};

            while (dataReader.Read())
            {
              outVo.AffectedCount = Convert.ToInt32(dataReader["paletteCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
