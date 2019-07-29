using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckLocationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LocationVo inVo = (LocationVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as locationCount from m_location ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.LocationCode != null)
            {
                sqlQuery.Append(" and UPPER(location_cd) = UPPER(:locationcd) ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.LocationCode != null)
            {
                sqlParameter.AddParameterString("locationcd", inVo.LocationCode);
            }

            //if (inVo.BuildingId > 0)
            //{
            //    sqlParameter.AddParameterInteger("buildingid", inVo.BuildingId);
            //}

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            LocationVo outVo = new LocationVo {AffectedCount = 0};

            while (dataReader.Read())
            {
              outVo.AffectedCount = Convert.ToInt32(dataReader["locationCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
