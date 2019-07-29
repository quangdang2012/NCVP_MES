using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetDetailPositionDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DetailPositionVo inVo = (DetailPositionVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<DetailPositionVo> voList = new ValueObjectList<DetailPositionVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select dt.detail_postion_id,l.location_cd, dt.detail_postion_cd, dt.detail_postion_name, dt.registration_user_cd,dt.registration_date_time,dt.factory_cd 
            from  m_detail_postion dt left join m_location l on dt.location_id = l.location_id 
            Where 1=1 ");
        
            if (inVo.DetailPositionId > 0)
            {
                sql.Append(" and dt.detail_postion_id = :detail_postion_id ");
                sqlParameter.AddParameterInteger("detail_postion_id", inVo.DetailPositionId);
            }
            if (!string.IsNullOrEmpty(inVo.DetailPositionCode))
            {
                sql.Append(" and dt.detail_postion_cd = :detail_postion_cd ");
                sqlParameter.AddParameterString("detail_postion_cd", inVo.DetailPositionCode);
            }
            if (!string.IsNullOrEmpty(inVo.DetailPositionName))
            {
                sql.Append(" and dt.detail_postion_name = :detail_postion_name ");
                sqlParameter.AddParameterString("detail_postion_name", inVo.DetailPositionName);
            }
            if (!string.IsNullOrEmpty(inVo.LocationCd))
            {
                sql.Append(" and l.location_cd = :location_cd ");
                sqlParameter.AddParameterString("location_cd", inVo.LocationCd);
            }


            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DetailPositionVo outVo = new DetailPositionVo
                {
                    DetailPositionCode = dataReader["detail_postion_cd"].ToString(),
                    DetailPositionId = int.Parse(dataReader["detail_postion_id"].ToString()),
                    DetailPositionName = dataReader["detail_postion_name"].ToString(),
                    LocationCd = dataReader["location_cd"].ToString(),
                    RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    FactoryCode = dataReader["factory_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
