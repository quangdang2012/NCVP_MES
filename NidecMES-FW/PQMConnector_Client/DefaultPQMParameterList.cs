using System.Collections.Generic;
using System.Data;
using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.PQMConnector_Client
{
    partial class DefaultPQMParameterList : PQMParameterList
    {

        /// <summary>
        /// initialize parameterlist
        /// </summary>
        private List<PQMParameter> parameterList = new List<PQMParameter>();


        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultPQMParameterList));

        /// <summary>
        /// get and set  parameter
        /// </summary>
        public PQMParameter[] Parameters
        {
            get
            { return parameterList?.ToArray(); }

            set
            {
                if (value == null) parameterList = null;
                if (value != null) parameterList = new List<PQMParameter>(value);
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
        private PQMParameter CreateParameter(string name, object value)
        {
            PQMParameter dataparameter = null;

            if (name == null)
            {
                MessageData messageData = new MessageData("pcce00010", Properties.Resources.pcce00010, null);
                logger.Error(messageData, new NullReferenceException());
                throw new Framework.SystemException(messageData, new NullReferenceException());
            }

            dataparameter = new PQMParameter();

            dataparameter.SetValue(name, value);

            return dataparameter;
        }

        /// <summary>
        /// add  parameter without datatype
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="direction"></param>
        /// <param name="size"></param>
        public void AddParameter(string name, object value)
        {
            PQMParameter dataparameter = CreateParameter(name, value);

            parameterList.Add(dataparameter);
        }



    }
}
