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
    public class DeleteModelDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ModelVo inVo = (ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  public.m_model Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.ModelId > 0)
            {
                sql.Append(" and model_id = :model_id ");
                sqlParameter.AddParameterInteger("model_id", inVo.ModelId);
            }
            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(" and model_cd = :model_cd ");
                sqlParameter.AddParameterString("model_cd", inVo.ModelCode);
            }
            if (!string.IsNullOrEmpty(inVo.ModelName))
            {
                sql.Append(" and model_name = :model_name ");
                sqlParameter.AddParameterString("model_name", inVo.ModelName);
            }

           

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            ModelVo outVo = new ModelVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
