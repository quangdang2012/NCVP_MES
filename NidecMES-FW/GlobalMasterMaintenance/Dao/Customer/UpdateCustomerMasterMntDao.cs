using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateCustomerMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CustomerVo inVo = (CustomerVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_customer");
            sqlQuery.Append(" Set ");
            sqlQuery.Append(" customer_name = :cuname,");
            sqlQuery.Append(" address1 = :add1, ");
            sqlQuery.Append(" address2 = :add2, ");
            sqlQuery.Append(" phone_no = :phno, ");
            sqlQuery.Append(" email = :email, ");
            sqlQuery.Append(" remarks = :rem ");
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" customer_id = :cuid ");           

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter= sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterInteger("cuid", inVo.CustomerId);
            sqlParameter.AddParameterString("cuname", inVo.CustomerName);
            sqlParameter.AddParameterString("add1", inVo.Address1);
            sqlParameter.AddParameterString("add2 ", inVo.Address2);
            sqlParameter.AddParameterString("email ", inVo.EmailId);
            sqlParameter.AddParameterString("rem ", inVo.Remarks);
            sqlParameter.AddParameterString("phno ", inVo.PhoneNo);

            CustomerVo outVo = new CustomerVo {AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo; 
        }
    }
}
