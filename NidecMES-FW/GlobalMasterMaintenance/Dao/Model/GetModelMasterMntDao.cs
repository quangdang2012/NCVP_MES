using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetModelMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ModelVo inVo = (ModelVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select md.model_id, md.model_cd, md.model_name ");
            sqlQuery.Append(" from m_model md ");           

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.ModelCode != null)
            {
                sqlQuery.Append(" and md.model_cd like :modelcd ");
            }

            if (inVo.ModelName != null)
            {
                sqlQuery.Append(" and md.model_name like :modelnm ");
            }

            sqlQuery.Append(" order by md.model_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.ModelCode != null)
            {
                sqlParameter.AddParameterString("modelcd", inVo.ModelCode + "%");
            }

            if (inVo.ModelName != null)
            {
                sqlParameter.AddParameterString("modelnm", inVo.ModelName + "%");
            }
         
            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<ModelVo> outVo = null;

            while (dataReader.Read())

            {
                ModelVo currOutVo = new ModelVo();
                currOutVo.ModelId = Convert.ToInt32(dataReader["model_id"]);
                currOutVo.ModelCode = dataReader["model_cd"].ToString();
                currOutVo.ModelName = dataReader["model_name"].ToString();

                if (outVo == null)
                {
                    outVo = new ValueObjectList<ModelVo>();
                }
                outVo.add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
