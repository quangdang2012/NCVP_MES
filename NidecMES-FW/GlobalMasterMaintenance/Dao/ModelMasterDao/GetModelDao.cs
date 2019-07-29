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
    public class GetModelDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ModelVo inVo = (ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ModelVo> voList = new ValueObjectList<ModelVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select model_id,model_cd,model_name, registration_user_cd,registration_date_time,factory_cd from  public.m_model");
            sql.Append(" Where 1=1 ");
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
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ModelVo outVo = new ModelVo
                {
                    ModelCode = dataReader["model_cd"].ToString(),
                    ModelId = int.Parse(dataReader["model_id"].ToString()),
                    ModelName =dataReader["model_name"].ToString(),

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
