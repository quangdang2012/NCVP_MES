using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddDetailPositionDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DetailPositionVo inVo = (DetailPositionVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into m_detail_postion(detail_postion_cd, location_id, detail_postion_name, registration_user_cd, registration_date_time, factory_cd) ");
            sql.Append("values(:detail_postion_cd, :location_id, :detail_postion_name, :registration_user_cd,now(),:factory_cd)");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("detail_postion_cd", inVo.DetailPositionCode);
            sqlParameter.AddParameterString("detail_postion_name", inVo.DetailPositionName);
            sqlParameter.AddParameterInteger("location_id", inVo.LocationId);

            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            DetailPositionVo outVo = new DetailPositionVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
