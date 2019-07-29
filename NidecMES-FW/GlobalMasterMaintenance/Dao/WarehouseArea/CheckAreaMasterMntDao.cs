using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckAreaMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AreaVo inVo = (AreaVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as areaCount from m_area ");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.AreaCode != null)
            {
                sqlQuery.Append(" and UPPER(area_cd) = UPPER(:areacd) ");
            }

            //if (inVo.locationId > 0)
            //{
            //    sqlQuery.Append(" and location_id = :locationid ");
            //}

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.AreaCode != null)
            {
                sqlParameter.AddParameterString("areacd", inVo.AreaCode);
            }

            //if (inVo.locationId > 0)
            //{
            //    sqlParameter.AddParameterInteger("locationid", inVo.LocationId);
            //}

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            AreaVo outVo = new AreaVo {AffectedCount = 0};

            while (dataReader.Read())
            {
              outVo.AffectedCount = Convert.ToInt32(dataReader["areaCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
