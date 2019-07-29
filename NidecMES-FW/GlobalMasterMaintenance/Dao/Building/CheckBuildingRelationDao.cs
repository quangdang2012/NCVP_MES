using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckBuildingRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            BuildingVo inVo = (BuildingVo)arg;

            BuildingVo outVo = new BuildingVo();

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("select count(bdg.building_cd) as RoleCount from m_building bdg");
            sqlQuery.Append(" inner join m_location ltn on ltn.building_id = bdg.building_id");

            sqlQuery.Append(" where bdg.factory_cd = :faccd ");

            if (inVo.BuildingId >0)
            {
                sqlQuery.Append(" and bdg.building_id = :buildingid ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.BuildingId >0)
            {
                sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            outVo.AffectedCount = 0;

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32("0" + dataReader["RoleCount"].ToString());
            }

            dataReader.Close();

            return outVo;
        }
 
    }
}
