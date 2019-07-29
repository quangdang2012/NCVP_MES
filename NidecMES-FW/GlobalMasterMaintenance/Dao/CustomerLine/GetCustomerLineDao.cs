using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetCustomerLineDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            CustomerLineVo inVo = (CustomerLineVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" SELECT ");
            sqlQuery.Append("  cl.customer_line_id, ");
            sqlQuery.Append("  c.customer_cd, ");
            sqlQuery.Append("  c.customer_name, ");
            sqlQuery.Append("  l.line_cd, ");
            sqlQuery.Append("  l.line_name ");
            sqlQuery.Append(" FROM ");
            sqlQuery.Append("  m_customer_line cl ");
            sqlQuery.Append("  inner join m_customer c on c.customer_id = cl.customer_id ");
            sqlQuery.Append("  inner join m_line l on l.line_id = cl.line_id ");
            sqlQuery.Append(" WHERE ");
            sqlQuery.Append("  c.factory_cd = :factorycode ");
            if (inVo.CustomerId > 0)
            {
                sqlQuery.Append(" AND c.customer_id = :customerid ");
            }
            if (inVo.LineId > 0)
            {
                sqlQuery.Append(" AND l.line_id = :lineid ");
            }


            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            
            if (!string.IsNullOrEmpty(inVo.FactoryCode))
            {
                sqlParameter.AddParameterString("factorycode", inVo.FactoryCode);
            }
            else
            {
                sqlParameter.AddParameterString("factorycode", UserData.GetUserData().FactoryCode);
            }
            if (inVo.CustomerId > 0)
            {

                sqlParameter.AddParameterInteger("customerid", inVo.CustomerId);
            }
            if (inVo.LineId > 0)
            {

                sqlParameter.AddParameterInteger("lineid", inVo.LineId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            CustomerLineVo outVo = new CustomerLineVo();

            while (dataReader.Read())
            {
                CustomerLineVo currOutVo = new CustomerLineVo();
                currOutVo.CustomerLineId = ConvertDBNull<int>(dataReader, "customer_line_id");
               // currOutVo.CustomerCd = ConvertDBNull<string>(dataReader, "customer_cd");
                currOutVo.CustomerName = ConvertDBNull<string>(dataReader, "customer_name");
              //  currOutVo.LineCd = ConvertDBNull<string>(dataReader, "line_cd");
                currOutVo.LineName = ConvertDBNull<string>(dataReader, "line_name");
                outVo.customerLineListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
