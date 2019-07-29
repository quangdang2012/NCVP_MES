using System;
using System.Collections.Generic;
using System.Data;
using SAP.Middleware.Connector;
using System.Collections;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client
{
    public interface SAPParameterList
    {
        /// <summary>
        /// get and set the parameters
        /// </summary>
        SAPParameter[] Parameters { get; set; }

        /// <summary>
        /// get and set the parameters
        /// </summary>
        SAPParameterList[] ParameterLists { get; set; }

        /// <summary>
        /// method definition for AddParameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void AddParameter(string name, object value);

        /// <summary>
        /// method definition for AddParameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void AddParameterList(SAPParameterList sapParameterList);

    }
}
