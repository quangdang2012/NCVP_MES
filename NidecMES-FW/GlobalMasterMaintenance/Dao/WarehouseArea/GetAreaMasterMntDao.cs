using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetAreaMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AreaVo inVo = (AreaVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select ct.area_id, ct.area_cd, ct.area_name, md.location_id, md.location_name ");
            sqlQuery.Append(" from m_area ct ");
            sqlQuery.Append(" inner join m_location md on md.location_id = ct.location_id ");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.AreaCode != null)
            {
                sqlQuery.Append(" and ct.area_cd like :areacd ");
            }

            if (inVo.AreaName != null)
            {
                sqlQuery.Append(" and ct.area_name like :areaname ");
            }

            if (inVo.LocationId != 0)
            {
                sqlQuery.Append(" and md.location_id = :locationid ");
            }

            sqlQuery.Append(" order by ct.area_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.AreaCode != null)
            {
                sqlParameter.AddParameterString("areacd", inVo.AreaCode + "%");
            }

            if (inVo.AreaName != null)
            {
                sqlParameter.AddParameterString("areaname", inVo.AreaName + "%");
            }
            if (inVo.LocationId != 0)
            {
                sqlParameter.AddParameterInteger("locationid", inVo.LocationId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            AreaVo outVo = new AreaVo();

            while (dataReader.Read())

            {
                AreaVo currOutVo = new AreaVo
                {
                    AreaId = Convert.ToInt32(dataReader["area_id"]),
                    AreaCode = dataReader["area_cd"].ToString(),
                    AreaName = dataReader["area_name"].ToString(),
                    LocationId = Convert.ToInt32(dataReader["location_id"]),
                    LocationName = dataReader["location_name"].ToString()
                };
                outVo.AreaListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
