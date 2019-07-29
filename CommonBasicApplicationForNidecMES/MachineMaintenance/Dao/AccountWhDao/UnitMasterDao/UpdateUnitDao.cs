using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateUnitDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UnitVo inVo = (UnitVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update m_unit set unit_cd=:unit_cd,unit_name=:unit_name");
            sql.Append(" where unit_id =:unit_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("unit_cd", inVo.UnitCode);
            sqlParameter.AddParameterString("unit_name", inVo.UnitName);
            sqlParameter.AddParameterInteger("unit_id", inVo.UnitId);
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            UnitVo outVo = new UnitVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
