using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckBuildingMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            BuildingVo inVo = (BuildingVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as BuildingCount from m_building ");

            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.BuildingCode != null)
            {
                sqlQuery.Append(" and UPPER(building_cd) = UPPER(:buildingcd) ");
            }
                     

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.BuildingCode != null)
            {
                sqlParameter.AddParameterString("buildingcd", inVo.BuildingCode);
            }

           

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            BuildingVo outVo = new BuildingVo {AffectedCount = 0};

            while (dataReader.Read())
            {
              outVo.AffectedCount = Convert.ToInt32(dataReader["BuildingCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
