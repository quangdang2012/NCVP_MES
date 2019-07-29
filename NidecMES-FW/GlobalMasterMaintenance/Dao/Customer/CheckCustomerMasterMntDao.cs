using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckCustomerMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CustomerVo inVo = (CustomerVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as CuCount from m_customer ");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.CustomerCode != null)
            {
                sqlQuery.Append(" and UPPER(customer_cd) = UPPER(:cucode) ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.CustomerCode != null)
            {
                sqlParameter.AddParameterString("cucode", inVo.CustomerCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            CustomerVo outVo = new CustomerVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["CuCount"]);
            }

            dataReader.Close();

            return outVo; 
        }
    }
}
