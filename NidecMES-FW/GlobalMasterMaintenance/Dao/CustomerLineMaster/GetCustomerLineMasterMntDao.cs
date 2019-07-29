using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetCustomerLineMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CustomerLineVo inVo = (CustomerLineVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select");
            sqlQuery.Append(" cl.customer_line_id,");
            sqlQuery.Append(" cl.customer_id,");
            sqlQuery.Append(" cl.line_id,");
            sqlQuery.Append(" c.customer_name,");
            sqlQuery.Append(" l.line_name");
            sqlQuery.Append(" from m_customer_line cl");
            sqlQuery.Append(" inner join m_customer c on cl.customer_id = c.customer_id");
            sqlQuery.Append(" inner join m_line l on cl.line_id = l.line_id");
            sqlQuery.Append(" where cl.factory_cd = :faccd ");

            if (inVo.LineId > 0)
            {
                sqlQuery.Append(" and cl.line_id = :lineid");
            }

            if (inVo.CustomerId > 0)
            {
                sqlQuery.Append(" and cl.customer_id = :customerid");
            }
                        
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);
            if (inVo.LineId > 0)
            {
                sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            }

            if (inVo.CustomerId > 0)
            {
                sqlParameter.AddParameterInteger("customerid", inVo.CustomerId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            CustomerLineVo outVo = new CustomerLineVo();

            while (dataReader.Read())
            {
                CustomerLineVo currOutVo = new CustomerLineVo
                {
                    CustomerLineId = Convert.ToInt32(dataReader["customer_line_id"]),
                    LineId = Convert.ToInt32(dataReader["line_id"]),
                    CustomerId = Convert.ToInt32(dataReader["customer_id"]),
                    CustomerName = dataReader["customer_name"].ToString(),
                    LineName = dataReader["line_name"].ToString()
                };

                outVo.customerLineListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
