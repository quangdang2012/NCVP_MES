using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetBuildingMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            BuildingVo inVo = (BuildingVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select ct.building_id, ct.building_cd, ct.building_name, ");
            sqlQuery.Append(" ct.factory_cd from m_building ct ");           

            sqlQuery.Append(" where ct.factory_cd = :faccd ");

            if (inVo.BuildingCode != null)
            {
                sqlQuery.Append(" and ct.building_cd like :buildingcd ");
            }

            if (inVo.BuildingName != null)
            {
                sqlQuery.Append(" and ct.building_name like :buildingname ");
            }

            if (inVo.BuildingId > 0)
            {
                sqlQuery.Append(" and ct.building_id = :buildingid ");
            }

            if (inVo.FactoryCode != null)
            {
                sqlQuery.Append(" and factory_cd = :factorycd ");
            }

            sqlQuery.Append(" order by ct.building_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.BuildingCode != null)
            {
                sqlParameter.AddParameterString("buildingcd", inVo.BuildingCode + "%");
            }
            if (inVo.BuildingId > 0)
            {
                sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            }
            if (inVo.BuildingName != null)
            {
                sqlParameter.AddParameterString("buildingname", inVo.BuildingName + "%");
            }
            if (inVo.FactoryCode != null)
            {
                sqlParameter.AddParameterString("factorycd",inVo.FactoryCode);
            }
         
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            BuildingVo outVo = new BuildingVo();

            while (dataReader.Read())

            {
                BuildingVo currOutVo = new BuildingVo
                {
                    BuildingId = Convert.ToInt32(dataReader["building_id"]),
                    BuildingCode = dataReader["building_cd"].ToString(),
                    BuildingName = dataReader["building_name"].ToString(),
                    FactoryCode = dataReader["factory_cd"].ToString()

                };
                outVo.BuildingListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
