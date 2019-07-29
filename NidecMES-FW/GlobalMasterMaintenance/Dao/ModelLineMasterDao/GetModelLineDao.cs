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
    public class GetModelLineDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ModelLineVo inVo = (ModelLineVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ModelLineVo> voList = new ValueObjectList<ModelLineVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select model_line_id, model_id, line_id, registration_user_cd,registration_date_time,factory_cd from  public.m_model_line");
            sql.Append(" Where 1=1 ");

            //
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
            if (inVo.LineID > 0)
            {
                sql.Append(" and line_id = :line_id ");
                sqlParameter.AddParameterInteger("line_id", inVo.LineID);
            }
            if (inVo.ModelLineID > 0)
            {
                sql.Append(" and model_line_id = :model_line_id ");
                sqlParameter.AddParameterInteger("model_line_id", inVo.ModelLineID);
            }


            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ModelLineVo outVo = new ModelLineVo
                {
                    //convert
               ModelLineID = int.Parse(dataReader["model_line_id"].ToString()),
                    ModelID = int.Parse(dataReader["model_id"].ToString()),
                    LineID = int.Parse(dataReader["line_id"].ToString()),

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
