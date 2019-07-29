using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetLineBuildingMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LineBuildingVo inVo = (LineBuildingVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select");
            sqlQuery.Append(" lb.line_building_id,");
            sqlQuery.Append(" lb.building_id,");
            sqlQuery.Append(" lb.line_id,");
            sqlQuery.Append(" b.building_cd,");
            sqlQuery.Append(" b.building_name,");
            sqlQuery.Append(" l.line_cd,");
            sqlQuery.Append(" l.line_name");
            sqlQuery.Append(" from m_line_building lb");
            sqlQuery.Append(" inner join m_line l on lb.line_id = l.line_id");
            sqlQuery.Append(" inner join m_building b on lb.building_id = b.building_id");
            sqlQuery.Append(" where lb.factory_cd = :faccd ");

            if (inVo.BuildingId  > 0)
            {
                sqlQuery.Append(" and lb.building_id = :buildingid");
            }

            if (inVo.LineId > 0)
            {
                sqlQuery.Append(" and lb.line_id = :lid");
            }

            if (inVo.LineCode != null)
            {
                sqlQuery.Append(" and l.line_cd = :lcd");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            sqlParameter.AddParameterInteger("lid", inVo.LineId);
            sqlParameter.AddParameterString("lcd", inVo.LineCode);

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<LineBuildingVo> outVo = null;

            while (dataReader.Read())
            {
                LineBuildingVo currOutVo = new LineBuildingVo
                {
                    LineBuildingId  = Convert.ToInt32(dataReader["line_building_id"]),
                    BuildingId  = Convert.ToInt32(dataReader["building_id"]),
                    LineId = Convert.ToInt32(dataReader["line_id"]),
                    LineCode = dataReader["line_cd"].ToString(),
                    LineName = dataReader["line_name"].ToString(),
                    BuildingCode  = dataReader["building_cd"].ToString(),
                    BuildingName  = dataReader["building_name"].ToString()
                };
                if (outVo == null)
                {
                    outVo = new ValueObjectList<LineBuildingVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
