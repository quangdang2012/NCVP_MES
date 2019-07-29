using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class DeleteUnitDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UnitVo inVo = (UnitVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  m_unit Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.UnitId > 0)
            {
                sql.Append(" and unit_id = :unit_id ");
                sqlParameter.AddParameterInteger("unit_id", inVo.UnitId);
            }
            if (!string.IsNullOrEmpty(inVo.UnitCode))
            {
                sql.Append(" and unit_cd = :unit_cd ");
                sqlParameter.AddParameterString("unit_cd", inVo.UnitCode);
            }
            if (!string.IsNullOrEmpty(inVo.UnitName))
            {
                sql.Append(" and unit_name = :unit_name ");
                sqlParameter.AddParameterString("unit_name", inVo.UnitName);
            }

           

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            UnitVo outVo = new UnitVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
