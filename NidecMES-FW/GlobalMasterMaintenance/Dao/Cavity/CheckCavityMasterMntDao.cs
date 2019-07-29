using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckCavityMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CavityVo inVo = (CavityVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as CavityCount from m_cavity ");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.CavityCode != null)
            {
                sqlQuery.Append(" and UPPER(cavity_cd) = UPPER(:cavitycd) ");
            }

            if (inVo.MoldId > 0)
            {
                sqlQuery.Append(" and mold_id = :moldid ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);


            if (inVo.CavityCode != null)
            {
                sqlParameter.AddParameterString("cavitycd", inVo.CavityCode);
            }

            if (inVo.MoldId > 0)
            {
                sqlParameter.AddParameterInteger("moldid", inVo.MoldId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            CavityVo outVo = new CavityVo {AffectedCount = 0};

            while (dataReader.Read())
            {
              outVo.AffectedCount = Convert.ToInt32(dataReader["CavityCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
