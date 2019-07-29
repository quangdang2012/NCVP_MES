using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteDrawDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DrawVo inVo = (DrawVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  public.m_draw Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.DrawId > 0)
            {
                sql.Append(" and draw_id = :draw_id ");
                sqlParameter.AddParameterInteger("draw_id", inVo.DrawId);
            }
            if (!string.IsNullOrEmpty(inVo.DrawCode))
            {
                sql.Append(" and draw_cd = :draw_cd ");
                sqlParameter.AddParameterString("draw_cd", inVo.DrawCode);
            }
            if (!string.IsNullOrEmpty(inVo.DrawName))
            {
                sql.Append(" and draw_name = :draw_name ");
                sqlParameter.AddParameterString("draw_name", inVo.DrawName);
            }

           

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            DrawVo outVo = new DrawVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
