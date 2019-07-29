using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Framework_Batch
{
    /// <summary>
    /// Caution!!!
    /// must set configurationreader using SetConfigurationReader method before calling GetValue
    /// </summary>
    internal class BatchConfigurationDataTypeEnum
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(BatchConfigurationDataTypeEnum));

        /// <summary>
        /// to store keyname
        /// </summary>
        private string keyName;

        /// <summary>
        /// instance for DefaultStaticCachedConfigurationReader
        /// </summary>
        private static ConfigurationReader configurationReader;

        /// <summary>
        /// Caution!!!
        /// must set configurationreader using SetConfigurationReader method before calling GetValue
        /// </summary>
        /// <param name="m_configurationReader"></param>
        internal static void SetConfigurationReader(ConfigurationReader m_configurationReader)
        {
            if (m_configurationReader == null)
            {
                //implement system exception
                MessageData messageData = new MessageData("fbce00051", Properties.Resources.fbce00051);
                Exception nullEx = new NullReferenceException();
                logger.Error(messageData, nullEx);

                throw new Framework.SystemException(messageData, nullEx);
            }

            configurationReader = m_configurationReader;
        }

        /// <summary>
        /// constructor of this class
        /// </summary>
        /// <param name="keyName"></param>
        private BatchConfigurationDataTypeEnum(string keyName)
        {
            this.keyName = keyName;
        }


        /// <summary>
        /// Caution!!!
        /// must set configurationreader using SetConfigurationReader method before calling GetValue
        /// get the value give in the settings
        /// throw exception is the keyName is not available in the settings
        /// </summary>
        /// <returns>value in the settings</returns>
        internal string GetValue()
        {
            if (configurationReader == null)
            {
                //implement system exception
                MessageData messageData = new MessageData("fbce00053", Properties.Resources.fbce00053);
                Exception nullEx = new NullReferenceException();
                logger.Error(messageData, nullEx);

                throw new Framework.SystemException(messageData, nullEx);

            }
            return configurationReader.GetValue(this.keyName);
        }

        //common config parameter
        internal static readonly BatchConfigurationDataTypeEnum CONNECTION_STRING = new BatchConfigurationDataTypeEnum("CONNECTION_STRING");
        internal static readonly BatchConfigurationDataTypeEnum SERVER_TIME_ZONE = new BatchConfigurationDataTypeEnum("SERVER_TIME_ZONE");
        internal static readonly BatchConfigurationDataTypeEnum APPLICATION_ENVIRONMENT_SETTINGS = new BatchConfigurationDataTypeEnum("APPLICATION_ENVIRONMENT_SETTINGS");

        //batch user parameter
        internal static readonly BatchConfigurationDataTypeEnum DEFAULT_BATCH_USER = new BatchConfigurationDataTypeEnum("DEFAULT_BATCH_USER");
        internal static readonly BatchConfigurationDataTypeEnum DEFAULT_BATCH_FACTORYCODE = new BatchConfigurationDataTypeEnum("DEFAULT_BATCH_FACTORYCODE");

        //batchmain class parameter
        internal static readonly BatchConfigurationDataTypeEnum BATCH_MAIN_CLASS = new BatchConfigurationDataTypeEnum("BATCH_MAIN_CLASS");

        //batch normal execution parameters
        internal static readonly BatchConfigurationDataTypeEnum BATCH_EXECUTION_TYPE = new BatchConfigurationDataTypeEnum("BATCH_EXECUTION_TYPE");
        internal static readonly BatchConfigurationDataTypeEnum BATCH_EXECUTION_WAIT_INTERVAL = new BatchConfigurationDataTypeEnum("BATCH_EXECUTION_WAIT_INTERVAL");

        //batch exception retry parameters
        internal static readonly BatchConfigurationDataTypeEnum BATCH_EXECUTION_RETRY_COUNT_ON_EXCEPTION = new BatchConfigurationDataTypeEnum("BATCH_EXECUTION_RETRY_COUNT_ON_EXCEPTION");
        internal static readonly BatchConfigurationDataTypeEnum BATCH_EXECUTION_RETRY_WAIT_INTERVAL_ON_EXCEPTION = new BatchConfigurationDataTypeEnum("BATCH_EXECUTION_RETRY_WAIT_INTERVAL_ON_EXCEPTION");

        //batch multiple invoke parameters
        internal static readonly BatchConfigurationDataTypeEnum PREVENT_MULTIPLE_INVOKE = new BatchConfigurationDataTypeEnum("PREVENT_MULTIPLE_INVOKE");
        internal static readonly BatchConfigurationDataTypeEnum PREVENT_MULTIPLE_INVOKE_RETRY_COUNT = new BatchConfigurationDataTypeEnum("PREVENT_MULTIPLE_INVOKE_RETRY_COUNT");
        internal static readonly BatchConfigurationDataTypeEnum PREVENT_MULTIPLE_INVOKE_WAIT_INTERVAL = new BatchConfigurationDataTypeEnum("PREVENT_MULTIPLE_INVOKE_WAIT_INTERVAL");
    }
}
