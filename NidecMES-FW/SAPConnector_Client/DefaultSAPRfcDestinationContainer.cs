using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SAP.Middleware.Connector;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;

namespace Com.Nidec.Mes.SAPConnector_Client
{
    internal class DefaultSAPRfcDestinationContainer
    {

        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly DefaultSAPRfcDestinationContainer instance = new DefaultSAPRfcDestinationContainer();

        /// <summary>
        /// store the rfcdestination in cachememory for each usersessionid
        /// </summary>
        internal static readonly Dictionary<string, List<object>> cacheDestinations;

        /// <summary>
        /// instance for logger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultSAPRfcDestinationContainer));

        /// <summary>
        /// get the thread instance for clear cache memory
        /// </summary>
        private static Thread cacheCleanerThread;

        /// <summary>
        /// static constructor / start the thread to clear the cache memory
        /// </summary>
        static DefaultSAPRfcDestinationContainer()
        {
            cacheDestinations = new Dictionary<string, List<object>>();

            string intervalValue = ServerConfigurationDataTypeEnum.DEFAULT_CACHE_CLEANER_THREAD_MILLISECONDS_INTERVAL.GetValue();

            int interval;
            try
            {
                interval = Convert.ToInt32(intervalValue);
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("scce00028", Properties.Resources.scce00028, intervalValue);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData, ex);
            }

            cacheCleanerThread = new Thread(() => CacheCleanControlFacade(interval));
            cacheCleanerThread.Start();
        }


        /// <summary>
        /// instance of the GetSapUserMasterMntCbm
        /// </summary>
        private GetSapUserMasterMntCbm sapUserCbm = new GetSapUserMasterMntCbm();

        /// <summary>
        /// private constructor
        /// </summary>
        private DefaultSAPRfcDestinationContainer()
        {
        }

        /// <summary>
        /// returns the current instance 
        /// </summary>
        /// <returns></returns>
        public static DefaultSAPRfcDestinationContainer GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// get sapuser data
        /// </summary>
        /// <param name="userSessionId">sessionid to get the sapuser</param>
        /// <returns>SapUserVo</returns>
        internal SapUserVo GetSapUser(string userSessionId)
        {
            if (string.IsNullOrWhiteSpace(userSessionId))
            {
                MessageData messageData = new MessageData("scce00031", Properties.Resources.scce00031);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }

            List<object> sapSessionValue = SetAndGetSapUserAndDestinationInCacheDestination(userSessionId); ;

            if (sapSessionValue == null)
            {
                MessageData messageData = new MessageData("scce00032", Properties.Resources.scce00032);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }

            return (SapUserVo)sapSessionValue[0];
        }

        /// <summary>
        /// get the rfcdestination and store in cache memory
        /// </summary>
        /// <param name="userSessionId">userSessionId as string from client userdata</param>
        /// <returns>RfcDestination</returns>
        internal RfcDestination GetRfcDestination(string userSessionId)
        {
            if (string.IsNullOrWhiteSpace(userSessionId))
            {
                MessageData messageData = new MessageData("scce00029", Properties.Resources.scce00026);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }

            List<object> sapSessionValue = SetAndGetSapUserAndDestinationInCacheDestination(userSessionId);

            if (sapSessionValue == null)
            {
                MessageData messageData = new MessageData("scce00027", Properties.Resources.scce00027);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }

            RfcDestination sapRfcDestination = (RfcDestination)sapSessionValue[1];
            return sapRfcDestination;
        }

        /// <summary>
        /// set and get the cache memory
        /// </summary>
        /// <param name="userSessionId">pass login user sessionid</param>
        /// <returns>List<object> cache memory</returns>
        private List<object> SetAndGetSapUserAndDestinationInCacheDestination(string userSessionId)
        {
            if (string.IsNullOrWhiteSpace(userSessionId))
            {
                MessageData messageData = new MessageData("scce00026", Properties.Resources.scce00026);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }

            List<object> sapSessionValue = null;
            lock (cacheDestinations) //lock the cachedestination dictionary to during access the instance
            {
                if (cacheDestinations.ContainsKey(userSessionId))
                {
                    //get from cache but need check dest is obsolete or note.
                    sapSessionValue = cacheDestinations[userSessionId];
                }
            }

            if (sapSessionValue == null)
            {
                //private get session value
                sapSessionValue = GetUserSapDestination(userSessionId);

                lock (cacheDestinations) //lock the cachedestination dictionary to during access the instance
                {
                    cacheDestinations.Add(userSessionId, sapSessionValue); //add the destination detail to the cache memory of the current sessionid
                }
            }
            else
            {
                //check the get the session details from the cache memory
                sapSessionValue = RefreshUserSapDestinationAsRequired(userSessionId, sapSessionValue);

                lock (cacheDestinations) //lock the cachedestination dictionary to during access the instance
                {
                    cacheDestinations.Remove(userSessionId); //remove the destination cache memory for the current sessionid
                    cacheDestinations.Add(userSessionId, sapSessionValue); //add the destination detail to the cache memory of the current sessionid
                }
            }

            return sapSessionValue;
        }

        /// <summary>
        /// get the rfcdestination , bind sapuser and rfcdestination in list of the cache
        /// </summary>
        /// <returns>List<object> contains SapUserVo and RfcDestination</returns>
        private List<object> GetUserSapDestination(string userSessionId)
        {

            SapUserVo sapUserVo = GetSapUser(); //Get SapUserVo
            RfcDestination sapRfcDestination = CreateRfcDestination(userSessionId, sapUserVo); // Create Destination

            List<object> destinationValue = new List<object>();
            destinationValue.Add(sapUserVo); //set SapUserVo to cache session in 0
            destinationValue.Add(sapRfcDestination); //set RfcDestination to cache session in 1

            return destinationValue;
        }

        /// <summary>
        /// get the rfcdestination for rfcdestination isshutdown or not use , bind sapuser and rfcdestination in list of the cache
        /// </summary>
        /// <param name="sapSessionValue">sapuser and rfcdestination of the current usersession in cache memory</param>
        /// <returns>List<object> contains SapUserVo and RfcDestination</returns>
        private List<object> RefreshUserSapDestinationAsRequired(string userSessionId, List<object> sapSessionValue)
        {
            if (sapSessionValue == null)
            {
                MessageData messageData = new MessageData("scce00025", Properties.Resources.scce00025);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }

            RfcDestination sapRfcDestination = (RfcDestination)sapSessionValue[1]; // get RfcDestination from cache session in 1

            //destination is obsolete
            if (sapRfcDestination.IsShutDown)
            {
                List<object> newSapSessionValue = new List<object>();

                SapUserVo sapUserVo = (SapUserVo)sapSessionValue[0]; // get SapUserVo from cache session in 0
                sapRfcDestination = CreateRfcDestination(userSessionId, sapUserVo); // Create Destination

                newSapSessionValue[0] = sapUserVo;  //set SapUserVo to cache session in 0
                newSapSessionValue[1] = sapRfcDestination; //set RfcDestination to cache session in 1

                sapSessionValue = null; //explicitly give null to old sap session.

                return newSapSessionValue;
            }
            else
            {
                return sapSessionValue;
            }
        }


        /// <summary>
        /// create and get the RfcDestination
        /// </summary>
        /// <param name="userSessionId">userSessionId as string</param>
        /// <param name="sapUserVo">sapUserVo as SapUserVo</param>
        /// <returns>RfcDestination</returns>
        private RfcDestination CreateRfcDestination(string userSessionId, SapUserVo sapUserVo)
        {

            RfcDestination sapRfcDestination;

            //set rfcconfigparameters
            RfcConfigParameters configParameters = SetConnectionParameters(userSessionId, sapUserVo);
            try
            {
                sapRfcDestination = RfcDestinationManager.GetDestination(configParameters);

                MessageData messageData = new MessageData("scci00001", Properties.Resources.scci00001, sapRfcDestination.Name.ToString());
                logger.Info(messageData);

            }
            catch (Exception ex)
            {
                //cannot serialize sap rfc exception hence passing exception name and message to the messagedata
                MessageData messageData = new MessageData("scce00008", Properties.Resources.scce00008, ex.GetType().Name.ToString(), ex.Message);
                logger.Error(messageData, ex);
                throw new Framework.SystemException(messageData);
            }

            if (sapRfcDestination == null)
            {
                MessageData messageData = new MessageData("scce00012", Properties.Resources.scce00012);
                Exception causeException = new NullReferenceException();
                logger.Error(messageData, causeException);
                throw new Framework.SystemException(messageData, causeException);
            }

            return sapRfcDestination;
        }

        /// <summary>
        /// get the sap user login detail
        /// </summary>
        /// <returns>sap user vo</returns>
        private SapUserVo GetSapUser()
        {

            SapUserVo outVo = null;

            try
            {
                outVo = (SapUserVo)DefaultCbmInvoker.Invoke(sapUserCbm, null);
            }
            catch (Framework.ApplicationException ex)
            {
                MessageData messagedata = new MessageData("scce00002", Properties.Resources.scce00002);
                logger.Error(messagedata, ex);

                throw new Framework.ApplicationException(messagedata, ex);
            }
            catch (Framework.SystemException ex)
            {
                MessageData messagedata = new MessageData("scce00010", Properties.Resources.scce00010);
                logger.Error(messagedata, ex);

                throw new Framework.SystemException(messagedata, ex);
            }
            catch (Exception ex)
            {
                MessageData messagedata = new MessageData("scce00011", Properties.Resources.scce00011);
                logger.Error(messagedata, ex);

                throw new Framework.SystemException(messagedata, ex);
            }

            if (outVo == null)
            {
                MessageData messagedata = new MessageData("scce00001", Properties.Resources.scce00001, UserData.GetUserData().UserCode);
                Exception causeException = new NullReferenceException();
                logger.Error(messagedata, causeException);

                throw new Framework.SystemException(messagedata, causeException);
            }
            return outVo;
        }


        /// <summary>
        /// Set the connection parameter for the rfcconfigparameters
        /// </summary>
        /// <param name="userSessionId">usersessionid</param>
        /// <param name="userVo">SapUserVo</param>
        /// <returns>RfcConfigParameters</returns>
        private RfcConfigParameters SetConnectionParameters(string userSessionId, SapUserVo userVo)
        {
            string destName = ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_NAME.GetValue() + userSessionId;

            RfcConfigParameters rfcParams = new RfcConfigParameters();
            rfcParams.Add(RfcConfigParameters.Name, destName);
            rfcParams.Add(RfcConfigParameters.LogonGroup, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_LOGON_GROUP.GetValue());            
            //rfcParams.Add(RfcConfigParameters.AppServerHost, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_MESSAGE_SERVER_HOST.GetValue());
            rfcParams.Add(RfcConfigParameters.MessageServerHost, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_MESSAGE_SERVER_HOST.GetValue());
            rfcParams.Add(RfcConfigParameters.SystemID, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_SYSTEM_ID.GetValue());
            rfcParams.Add(RfcConfigParameters.SystemNumber, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_SYSTEM_NUMBER.GetValue());
            rfcParams.Add(RfcConfigParameters.User, userVo.SapUser);
            rfcParams.Add(RfcConfigParameters.Password, userVo.SapPassWord);
            rfcParams.Add(RfcConfigParameters.Client, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_CLIENT.GetValue());
            rfcParams.Add(RfcConfigParameters.Language, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_LANGUAGE.GetValue());
            rfcParams.Add(RfcConfigParameters.PoolSize, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_POOL_SIZE.GetValue());
            rfcParams.Add(RfcConfigParameters.PeakConnectionsLimit, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_PEAK_CONNECTIONS_LIMIT.GetValue());
            rfcParams.Add(RfcConfigParameters.IdleTimeout, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_IDLE_TIMEOUT.GetValue());
            rfcParams.Add(RfcConfigParameters.IdleCheckTime, ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_IDLE_CHECKTIME.GetValue());

            return rfcParams;
        }

        /// <summary>
        /// loop implementation to call remove session detail
        /// </summary>
        /// <param name="sleepTimeMilliSecond">milliseconds to make the thread sleep</param>
        private static void CacheCleanControlFacade(int sleepTimeMilliSecond)
        {
            while (true)
            {
                RemoveObsoleteSessionDestination();
                Thread.Sleep(sleepTimeMilliSecond);
            }
        }

        /// <summary>
        /// implementation to remove session detail from the cache memory
        /// </summary>
        private static void RemoveObsoleteSessionDestination()
        {
            // Loop over pairs with foreach of cache memory.
            foreach (KeyValuePair<string, List<object>> pair in cacheDestinations)
            {

                bool sessionInvalidFlg = false;

                List<object> sapSessionValue = pair.Value;

                if (sapSessionValue == null || sapSessionValue.Count < 2 || sapSessionValue[1] == null) //invalid value;
                {
                    sessionInvalidFlg = true;

                    //logging  abnormal case
                    if (logger.IsInfoEnabled())
                    {
                        MessageData messageData = new MessageData("scci00004", Properties.Resources.scci00004, pair.Key);
                        logger.Info(messageData);
                    }
                }
                else
                {
                    RfcDestination sapRfcDestination = (RfcDestination)sapSessionValue[1]; // get RfcDestination from cache session in 1
                    if (sapRfcDestination == null || sapRfcDestination.IsShutDown)
                    {
                        sessionInvalidFlg = true;
                    }
                }

                if (sessionInvalidFlg) //if session value is not invalid, remove from cache.
                {
                    lock (cacheDestinations) //lock only while removing.
                    {
                        cacheDestinations.Remove(pair.Key);
                    }

                    if (logger.IsInfoEnabled())
                    {
                        //logging the remove sessiondetail of the usersession
                        MessageData messageData = new MessageData("scci00003", Properties.Resources.scci00003, pair.Key);
                        logger.Info(messageData);
                    }

                }
            }
        }
    }
}
