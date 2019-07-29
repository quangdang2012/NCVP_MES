using System.Collections.Generic;
using System.Data;
using System;
using SAP.Middleware.Connector;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.SAPConnector_Client
{
    partial class DefaultSAPParameterList : SAPParameterList
    {

        /// <summary>
        /// initialize parameterlist
        /// </summary>
        private List<SAPParameter> parameterList = new List<SAPParameter>();

        /// <summary>
        /// initialize parameterlist
        /// </summary>
        private List<SAPParameterList> parameterLists = new List<SAPParameterList>();

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultSAPParameterList));

        public DefaultSAPParameterList()
        { }

        public DefaultSAPParameterList(string tablename)
        { }

        /// <summary>
        /// get and set  parameter
        /// </summary>
        public SAPParameter[] Parameters
        {
            get
            { return parameterList?.ToArray(); }

            set
            {
                if (value == null) parameterList = null;
                if (value != null) parameterList = new List<SAPParameter>(value);
            }
        }

        /// <summary>
        /// get and set  parameter
        /// </summary>
        public SAPParameterList[] ParameterLists
        {
            get
            { return parameterLists?.ToArray(); }

            set
            {
                if (value == null) parameterLists = null;
                if (value != null) parameterLists = new List<SAPParameterList>(value);
            }
        }

        /// <summary>
        /// create IDataparamter with parameter details
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        /// <returns></returns>
        private SAPParameter CreateParameter(string name, object value)
        {
            SAPParameter dataparameter = null;

            if (name == null)
            {
                MessageData messageData = new MessageData("scce00019", Properties.Resources.scce00019);
                logger.Error(messageData, new NullReferenceException());
                throw new Framework.SystemException(messageData, new NullReferenceException());
            }

            dataparameter = new SAPParameter();

            dataparameter.SetValue(name, value);

            return dataparameter;
        }

        /// <summary>
        /// add  parameter without datatype
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddParameter(string name, object value)
        {
            SAPParameter dataparameter = CreateParameter(name, value);

            parameterList.Add(dataparameter);
        }

        /// <summary>
        /// add  parameterlists
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        public void AddParameterList(SAPParameterList sapParameterList)
        {
            parameterLists.Add(sapParameterList);
        }

    }
}
