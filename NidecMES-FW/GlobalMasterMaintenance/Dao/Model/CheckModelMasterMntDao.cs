using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckModelMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ModelVo inVo = (ModelVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as ModelCount, model_id, model_cd from m_model ");

            sqlQuery.Append(" where factory_cd = :factorycode ");

            if (inVo.ModelCode != null)
            {
                sqlQuery.Append(" and UPPER(model_cd) = UPPER(:modelcd) ");
            }

            sqlQuery.Append(" group by model_id, model_cd ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("factorycode", trxContext.UserData.FactoryCode);

            if (inVo.ModelCode != null)
            {
                sqlParameter.AddParameterString("modelcd", inVo.ModelCode);
            }

           

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ValueObjectList<ModelVo> outVo = null;

            while (dataReader.Read())
            {
                ModelVo currOutVo = new ModelVo();
                currOutVo.AffectedCount = Convert.ToInt32(dataReader["ModelCount"]);
                currOutVo.ModelId = Convert.ToInt32(dataReader["model_id"]);
                currOutVo.ModelCode = dataReader["model_cd"].ToString();

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
