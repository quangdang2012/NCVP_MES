using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateDetailPositionDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DetailPositionVo inVo = (DetailPositionVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update m_detail_postion set detail_postion_cd=:detail_postion_cd,detail_postion_name=:detail_postion_name, location_id=:location_id");
            sql.Append(" where detail_postion_id =:detail_postion_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("detail_postion_cd", inVo.DetailPositionCode);
            sqlParameter.AddParameterString("detail_postion_name", inVo.DetailPositionName);
            sqlParameter.AddParameterInteger("detail_postion_id", inVo.DetailPositionId);
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
