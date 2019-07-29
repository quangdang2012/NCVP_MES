using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckModelRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ModelVo inVo = (ModelVo)arg;

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("select count(mm.model_cd) as MoldModelCount from m_model mm");
            sqlQuery.Append(" inner join m_mold_detail mod on mod.mold_model_id = mm.model_id");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.ModelCode != null)
            {
                //sqlQuery.Append(" and UPPER(model_cd) = UPPER(:modelcd) ");
                sqlQuery.Append(" and UPPER(model_cd) = UPPER(:modelcd) ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.ModelCode != null)
            {
                sqlParameter.AddParameterString("modelcd", inVo.ModelCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ModelVo outVo = new ModelVo();

            while (dataReader.Read())
            {
              outVo.AffectedCount = Convert.ToInt32("0" + dataReader["MoldModelCount"]);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
