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
    public class DeleteModelProcessDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ModelProcessVo inVo = (ModelProcessVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from public.m_model_process Where 1=1 ");

            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.ModelID > 0)
            {
                sql.Append(" and model_id = :model_id ");
                sqlParameter.AddParameterInteger("model_id", inVo.ModelID);
            }
            if (inVo.ProcessID > 0)
            {
                sql.Append(" and process_id = :process_id ");
                sqlParameter.AddParameterInteger("process_id", inVo.ProcessID);
            }
            if (inVo.ModelProcessID > 0)
            {
                sql.Append(" and model_process_id = :model_process_id ");
                sqlParameter.AddParameterInteger("model_process_id", inVo.ModelProcessID);
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
