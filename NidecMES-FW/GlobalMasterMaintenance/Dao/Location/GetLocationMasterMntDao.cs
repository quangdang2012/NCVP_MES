using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetLocationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LocationVo inVo = (LocationVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select ct.location_id, ct.location_cd, ct.location_name, md.building_id, md.building_name ");
            sqlQuery.Append(" from m_location ct ");
            sqlQuery.Append(" inner join m_building md on md.building_id = ct.building_id ");

            sqlQuery.Append(" where ct.factory_cd = :faccd ");

            if (inVo.LocationCode != null)
            {
                sqlQuery.Append(" and ct.location_cd like :locationcd ");
            }

            if (inVo.LocationName != null)
            {
                sqlQuery.Append(" and ct.location_name like :locationname ");
            }

            if (inVo.BuildingId != 0)
            {
                sqlQuery.Append(" and md.building_id = :buildingid ");
            }

            sqlQuery.Append(" order by ct.location_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.LocationCode != null)
            {
                sqlParameter.AddParameterString("locationcd", inVo.LocationCode + "%");
            }

            if (inVo.LocationName != null)
            {
                sqlParameter.AddParameterString("locationname", inVo.LocationName + "%");
            }
            if (inVo.BuildingId != 0)
            {
                sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            LocationVo outVo = new LocationVo();

            while (dataReader.Read())

            {
                LocationVo currOutVo = new LocationVo
                {
                    LocationId = Convert.ToInt32(dataReader["location_id"]),
                    LocationCode = dataReader["location_cd"].ToString(),
                    LocationName = dataReader["location_name"].ToString(),
                    BuildingId = Convert.ToInt32(dataReader["building_id"]),
                    BuildingName = dataReader["building_name"].ToString()
                };
                outVo.LocationListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
