using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckMoldTypeRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldTypeVo inVo = (MoldTypeVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select Count(mo.mold_cd) as MoldCount from m_mold_type mt");
            sqlQuery.Append(" inner join m_mold mo on mt.mold_type_id = mo.mold_type_id");
            sqlQuery.Append(" where mt.factory_cd = :faccd ");

            if (inVo.MoldTypeCode != null)
            {
                sqlQuery.Append(" and UPPER(mt.mold_type_cd) = UPPER(:moldtypecd)");
            }
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.MoldTypeCode != null)
            {
                sqlParameter.AddParameterString("moldtypecd", inVo.MoldTypeCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            MoldTypeVo outVo = new MoldTypeVo();

            while (dataReader.Read())
            {
               outVo.AffectedCount = Convert.ToInt32("0" + dataReader["MoldCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
