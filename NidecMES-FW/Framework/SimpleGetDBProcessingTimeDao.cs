using System;
using System.Text;
using System.Data;

namespace Com.Nidec.Mes.Framework
{
    internal class SimpleGetDBProcessingTimeDao : AbstractDataAccessObject
    {

        /// <summary>
        /// Execute the query
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select now() currentdatetime ");

            TimeVo outVo = new TimeVo();

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DateTime currentServerDateTime = Convert.ToDateTime(dataReader["currentdatetime"]);
                string timeZoneString = ConfigurationDataTypeEnum.SERVER_TIME_ZONE.GetValue();
                outVo.CurrentDateTime = TimeZoneInfo.ConvertTime(currentServerDateTime,
                                        TimeZoneInfo.FindSystemTimeZoneById(timeZoneString));

            }


            dataReader.Close();
            return outVo;
        }
    }
}
