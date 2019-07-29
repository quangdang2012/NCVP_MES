using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class DeleteInvertoryTimeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InvertoryVo inVo = (InvertoryVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  m_invertory_time Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.InvertoryTimeId > 0)
            {
                sql.Append(" and invertory_time_id = :invertory_time_id ");
                sqlParameter.AddParameterInteger("invertory_time_id", inVo.InvertoryTimeId);
            }
            if (!string.IsNullOrEmpty(inVo.InvertoryTimeCode))
            {
                sql.Append(" and invertory_time_cd = :invertory_time_cd ");
                sqlParameter.AddParameterString("invertory_time_cd", inVo.InvertoryTimeCode);
            }
            if (!string.IsNullOrEmpty(inVo.InvertoryTimeName))
            {
                sql.Append(" and invertory_time_name = :invertory_time_name ");
                sqlParameter.AddParameterString("invertory_time_name", inVo.InvertoryTimeName);
            }

           

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            InvertoryVo outVo = new InvertoryVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
