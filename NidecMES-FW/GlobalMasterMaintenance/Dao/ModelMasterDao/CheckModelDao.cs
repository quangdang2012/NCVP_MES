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
    public class CheckModelDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ModelVo inVo = (ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as ModelCount ");
            sql.Append(" from  public.m_model");
            sql.Append(" Where 1=1 ");
    
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(" and UPPER(model_cd) = UPPER(:model_cd) ");
                sqlParameter.AddParameterString("model_cd", inVo.ModelCode);
            }
            if (inVo.ModelId > 0)
            {
                sql.Append(" and model_id != :model_id "); ///?????
                sqlParameter.AddParameterInteger("model_id", inVo.ModelId);
            }
          

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            ModelVo outVo = new ModelVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["ModelCount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
