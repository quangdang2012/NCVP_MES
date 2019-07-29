using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetPaletteMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            PaletteVo inVo = (PaletteVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select ct.palette_id, ct.palette_cd, ct.palette_name, md.area_id, md.area_name ");
            sqlQuery.Append(" from m_palette ct ");
            sqlQuery.Append(" inner join m_area md on md.area_id = ct.area_id ");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.PaletteCode != null)
            {
                sqlQuery.Append(" and ct.palette_cd like :palettecd ");
            }

            if (inVo.PaletteName != null)
            {
                sqlQuery.Append(" and ct.palette_name like :palettename ");
            }

            if (inVo.AreaId != 0)
            {
                sqlQuery.Append(" and md.area_id = :areaid ");
            }

            sqlQuery.Append(" order by ct.palette_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.PaletteCode != null)
            {
                sqlParameter.AddParameterString("palettecd", inVo.PaletteCode + "%");
            }

            if (inVo.PaletteName != null)
            {
                sqlParameter.AddParameterString("palettename", inVo.PaletteName + "%");
            }
            if (inVo.AreaId != 0)
            {
                sqlParameter.AddParameterInteger("areaid", inVo.AreaId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            PaletteVo outVo = new PaletteVo();

            while (dataReader.Read())

            {
                PaletteVo currOutVo = new PaletteVo
                {
                    PaletteId = Convert.ToInt32(dataReader["palette_id"]),
                    PaletteCode = dataReader["palette_cd"].ToString(),
                    PaletteName = dataReader["palette_name"].ToString(),
                    AreaId = Convert.ToInt32(dataReader["area_id"]),
                    AreaName = dataReader["area_name"].ToString()
                };
                outVo.PaletteListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
