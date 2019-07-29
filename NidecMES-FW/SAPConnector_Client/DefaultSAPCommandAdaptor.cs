using System;
using System.Collections.Generic;
using System.Data;
using SAP.Middleware.Connector;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.SAPConnector_Client
{
    internal class DefaultSAPCommandAdaptor : SAPCommandAdapter
    {

        /// <summary>
        /// store IRfcFunction
        /// </summary>
        private readonly IRfcFunction rfcFunction;

        /// <summary>
        /// store RfcDestination
        /// </summary>
        private readonly RfcDestination rfcDestination;

        /// <summary>
        /// instance of the commonlogger class
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultSAPCommandAdaptor));

        /// <summary>
        /// instance of the DefaultSAPRfcDestinationContainer class
        /// </summary>
        private static readonly DefaultSAPRfcDestinationContainer rfcDestinationContainer = DefaultSAPRfcDestinationContainer.GetInstance();

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="trxContext">TransactionContext</param>
        /// <param name="functionName">functionName as string</param>
        internal DefaultSAPCommandAdaptor(TransactionContext trxContext, string functionName)
        {

            if (String.IsNullOrWhiteSpace(functionName.Trim()))
            {
                MessageData messageData = new MessageData("scce00023", Properties.Resources.scce00023);
                logger.Error(messageData, new NullReferenceException());
                throw new Framework.SystemException(messageData, new NullReferenceException());
            }

            if (trxContext == null)
            {
                MessageData messageData = new MessageData("scce00020", Properties.Resources.scce00020);
                logger.Error(messageData, new NullReferenceException());
                throw new Framework.SystemException(messageData, new NullReferenceException());
            }

            UserData userData = trxContext.UserData;

            if (userData == null)
            {
                MessageData messageData = new MessageData("scce00021", Properties.Resources.scce00021);
                logger.Error(messageData, new NullReferenceException());
                throw new Framework.SystemException(messageData, new NullReferenceException());
            }

            if (string.IsNullOrWhiteSpace(userData.SessionId))
            {
                MessageData messageData = new MessageData("scce00022", Properties.Resources.scce00022);
                logger.Error(messageData, new NullReferenceException());
                throw new Framework.SystemException(messageData, new NullReferenceException());
            }

            string sessionId = userData.SessionId;

            //get the rfc destination from the cache memory in DefaultSAPRfcDestinationContainer class
            this.rfcDestination = rfcDestinationContainer.GetRfcDestination(sessionId);

            if (this.rfcDestination == null)
            {
                MessageData messageData = new MessageData("scce00024", Properties.Resources.scce00024);
                logger.Error(messageData, new NullReferenceException());
                throw new Framework.SystemException(messageData, new NullReferenceException());
            }

            //create the instance of the rfc function
            try
            {
                this.rfcFunction = rfcDestination.Repository.CreateFunction(functionName);
            }
            catch (RfcLogonException ex)
            {
                //cannot serialize sap rfc exception hence passing exception name and message to the messagedata
                MessageData messageData = new MessageData("scce00015", Properties.Resources.scce00015, ex.GetType().Name.ToString(), ex.Message);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData);
            }
            catch (RfcInvalidStateException ex)
            {
                //cannot serialize sap rfc exception hence passing exception name and message to the messagedata
                MessageData messageData = new MessageData("scce00013", Properties.Resources.scce00013, ex.GetType().Name.ToString(), ex.Message);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData);
            }
            catch (Exception ex)
            {
                //cannot serialize sap rfc exception hence passing exception name and message to the messagedata
                MessageData messageData = new MessageData("scce00014", Properties.Resources.scce00014, ex.GetType().Name.ToString(), ex.Message);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData);
            }
        }

        /// <summary>
        /// set command parameter values from the dao
        /// </summary>
        /// <param name="parameterList">SAPParameterList</param>
        /// <returns></returns>
        private void SetCommandParameter(SAPParameterList parameterList)
        {
            foreach (SAPParameter parameter in parameterList.Parameters)
            {
                if (parameter.Value == null) continue;

                if (parameter.Value.GetType() == typeof(DefaultSAPParameterList))
                {
                    IRfcTable irfcTable = rfcFunction.GetTable(parameter.Name);

                    SAPParameterList tableParameterList = (SAPParameterList)parameter.Value;
                    if (tableParameterList.ParameterLists.Length > 0)
                    {
                        foreach (SAPParameterList tableParameterLists in tableParameterList.ParameterLists)
                        {
                            irfcTable.Insert();

                            foreach (SAPParameter tableParameter in tableParameterLists.Parameters)
                            {
                                irfcTable.CurrentRow.SetValue(tableParameter.Name, tableParameter.Value);
                            }
                        }
                    }
                    else
                    {
                        irfcTable.Insert();
                        foreach (SAPParameter tableParameter in tableParameterList.Parameters)
                        {
                            irfcTable.SetValue(tableParameter.Name, tableParameter.Value);
                        }
                    }
                }
                else
                {
                    rfcFunction.SetValue(parameter.Name, parameter.Value);
                }
            }

        }

        /// <summary>
        ///  set command parameter values to sap irfc table from the dao
        /// </summary>
        /// <param name="parameterList">SAPParameterList</param>
        /// <returns></returns>
        private void SetCommandParameterTable(SAPParameterList parameterList)
        {
            foreach (SAPParameter parameter in parameterList.Parameters)
            {
                IRfcTable irfcTable = rfcFunction.GetTable(parameter.Name);
                irfcTable.Insert();

                SAPParameterList tableParameterList = (SAPParameterList)parameter.Value;
                foreach (SAPParameter tableParameter in tableParameterList.Parameters)
                {
                    irfcTable.SetValue(tableParameter.Name, tableParameter.Value);
                }

            }

        }

        /// <summary>
        /// execute with ExecuteReader
        /// </summary>
        /// <param name="trxContext">TransactionContext</param>
        /// <param name="parameterList">SAPParameterList</param>
        /// <returns></returns>
        public SAPFunction Execute(TransactionContext trxContext, SAPParameterList parameterList)
        {
            SetCommandParameter(parameterList);

            DefaultSAPFunction sapFunction = new DefaultSAPFunction();
            try
            {
                sapFunction.Invoke(this.rfcDestination, rfcFunction);

                MessageData messageData = new MessageData("scci00002", Properties.Resources.scci00002, this.rfcDestination.Name.ToString());
                logger.Info(messageData);
            }
            catch (RfcAbapRuntimeException ex)
            {
                //cannot serialize sap rfc exception hence passing exception name and message to the messagedata
                MessageData messageData = new MessageData("scce00005", Properties.Resources.scce00005, ex.GetType().Name.ToString(), ex.Message);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData);
            }
            catch (RfcInvalidStateException ex)
            {
                //cannot serialize sap rfc exception hence passing exception name and message to the messagedata
                MessageData messageData = new MessageData("scce00009", Properties.Resources.scce00009, ex.GetType().Name.ToString(), ex.Message);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData);
            }
            catch (Exception ex)
            {
                //cannot serialize sap rfc exception hence passing exception name and message to the messagedata
                MessageData messageData = new MessageData("scce00007", Properties.Resources.scce00007, ex.GetType().Name.ToString(), ex.Message);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData);
            }
            return sapFunction;

        }

        /// <summary>
        /// execute with Executetable
        /// </summary>
        /// <param name="trxContext">TransactionContext</param>
        /// <param name="parameterList">SAPParameterList</param>
        /// <returns></returns>
        public SAPFunction ExecuteTable(TransactionContext trxContext, SAPParameterList parameterList)
        {
            SetCommandParameterTable(parameterList);

            DefaultSAPFunction sapFunction = new DefaultSAPFunction();

            try
            {
                sapFunction.Invoke(this.rfcDestination, rfcFunction);
                MessageData messageData = new MessageData("scci00002", Properties.Resources.scci00002, this.rfcDestination.Name.ToString());
                logger.Info(messageData);
            }
            catch (RfcAbapRuntimeException ex)
            {
                MessageData messageData = new MessageData("scce00016", Properties.Resources.scce00016, ex.GetType().Name.ToString(), ex.Message);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData, ex);
            }
            catch (RfcInvalidStateException ex)
            {
                MessageData messageData = new MessageData("scce00017", Properties.Resources.scce00017, ex.GetType().Name.ToString(), ex.Message);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData, ex);
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("scce00018", Properties.Resources.scce00018, ex.GetType().Name.ToString(), ex.Message);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData);
            }
            return sapFunction;

        }

        /// <summary>
        /// create parameterlist object
        /// </summary>
        /// <returns></returns>
        public SAPParameterList CreateParameterList()
        {
            return new DefaultSAPParameterList();

        }

        /// <summary>
        /// get the sapuservo from cache for the logged in user session
        /// </summary>
        /// <param name="trxContext"></param>
        /// <returns>SapUserVo</returns>
        public SapUserVo GetSapUser(TransactionContext trxContext)
        {

            //Check parameter
            if (trxContext == null)
            {
                //logg
                MessageData messageData = new MessageData("scce00033", Properties.Resources.scce00033);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }
            else if (trxContext.UserData == null)
            {
                //logg
                MessageData messageData = new MessageData("scce00034", Properties.Resources.scce00034);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }
            else if (String.IsNullOrEmpty(trxContext.UserData.SessionId))
            {
                //logg
                MessageData messageData = new MessageData("scce00030", Properties.Resources.scce00030);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }

            SapUserVo sapUser = rfcDestinationContainer.GetSapUser(trxContext.UserData.SessionId);

            if (sapUser == null)
            {
                //logg
                MessageData messageData = new MessageData("scce00035", Properties.Resources.scce00035);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }

            return sapUser;

        }

    }
}
