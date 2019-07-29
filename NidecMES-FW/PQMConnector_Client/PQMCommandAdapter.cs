using System;
using System.Data;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.PQMConnector_Client
{
    internal interface PQMCommandAdapter
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        DataTable Execute(TransactionContext trxContext, PQMParameterList parameterList);

        /// <summary>
        /// method definition for CreateParameterList
        /// </summary>
        /// <returns></returns>
        PQMParameterList CreateParameterList();
    }
}
