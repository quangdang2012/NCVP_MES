using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckMoldDetailMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldDetailVo inVo = (MoldDetailVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as MoldCount from m_mold ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.MoldCode != null)
            {
                sqlQuery.Append(" and UPPER(mold_cd) = UPPER(:moldcd) ");
            }


            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.MoldCode != null)
            {
                sqlParameter.AddParameterString("moldcd", inVo.MoldCode);
            }


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            MoldDetailVo outVo = new MoldDetailVo { AffectedCount = 0};

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["MoldCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
