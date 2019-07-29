using System;
using System.Data;
using SAP.Middleware.Connector;

using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client
{
   public interface SAPFunction
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        IRfcFunction Invoke(RfcDestination rfcDestination, IRfcFunction rfcFuntion);

        string GetSAPValue(string name);

        string GetSAPValue(int index);

        DataTable GetSAPTable(string tableName);

    }
}
