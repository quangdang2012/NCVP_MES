using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetCustomerMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            CustomerVo inVo = (CustomerVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select * from m_customer");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.CustomerCode != null) { sqlQuery.Append(" and customer_cd like :cucode ");}

            if (inVo.CustomerId > 0) { sqlQuery.Append(" and customer_id = :cuid "); }

            if (inVo.CustomerName != null) { sqlQuery.Append(" and customer_name Ilike :cuname ");}

            if (inVo.Address1 != null) { sqlQuery.Append(" and address1 like :add1 "); }

            if (inVo.Address2 != null) { sqlQuery.Append(" and address2 like :add2 "); }

            if (inVo.EmailId != null) { sqlQuery.Append(" and email like :email "); }

            if (inVo.PhoneNo != null) { sqlQuery.Append(" and phone_no = :phno "); }

            sqlQuery.Append(" order by customer_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();          

            if (inVo.CustomerCode != null) {  sqlParameter.AddParameterString("cucode", inVo.CustomerCode + "%"); }

            if (inVo.CustomerId > 0) { sqlParameter.AddParameterInteger("cuid", inVo.CustomerId); }

            if (inVo.CustomerName != null) { sqlParameter.AddParameterString("cuname", "%" + inVo.CustomerName + "%"); }

            if (inVo.Address1 != null) { sqlParameter.AddParameterString("add1", inVo.Address1 + "%"); }

            if (inVo.Address2 != null) { sqlParameter.AddParameterString("add2", inVo.Address2 + "%"); }

            if (inVo.EmailId != null) { sqlParameter.AddParameterString("email", inVo.EmailId + "%"); }

            if (inVo.PhoneNo != null)
            {
                sqlParameter.AddParameterString("phno", inVo.PhoneNo);
            }


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            CustomerVo outVo = new CustomerVo();

            while (dataReader.Read())
            {
                CustomerVo currOutVo = new CustomerVo();
  
                currOutVo.CustomerId = Convert.ToInt32(dataReader["customer_id"]);
                currOutVo.CustomerCode = ConvertDBNull<string>(dataReader,"customer_cd");
                currOutVo.CustomerName = ConvertDBNull<string>(dataReader,"customer_name");
                currOutVo.Address1 = ConvertDBNull<string>(dataReader,"address1");
                currOutVo.Address2 = ConvertDBNull<string>(dataReader,"address2");
                currOutVo.EmailId = ConvertDBNull<string>(dataReader,"email");
                currOutVo.Remarks = ConvertDBNull<string>(dataReader,"remarks");
                currOutVo.PhoneNo = ConvertDBNull<string>(dataReader,"phone_no");
                outVo.CustomerListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo; 
        }
    }
}
