using System;
using System.IO;
using System.Data;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Framework_Server
{
    public class DefaultServerApplicationInitializer : ApplicationInitializer
    {

        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly DefaultServerApplicationInitializer instance = new DefaultServerApplicationInitializer();

        /// <summary>
        /// initialize PopUpMessageController
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();

        /// <summary>
        /// instance for logger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultServerApplicationInitializer));

        /// <summary>
        /// private constructor
        /// </summary>
        private DefaultServerApplicationInitializer()
        {
        }

        /// <summary>
        /// returns the current instance 
        /// </summary>
        /// <returns></returns>
        public static DefaultServerApplicationInitializer GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Initialize methods to be called
        /// </summary>
        public void Init()
        {
            //check mandatory application setting values.
            PreInit();

            // Set the unhandled exception mode to force all Windows Forms errors
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

            // Add the event handler for handling non-UI thread exceptions to the event.
            Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(
                            DefaultUnhandledExceptionHandler.GetInstance().HandleException);

        }

        /// <summary>
        /// check mandatory settings
        /// </summary>
        private void PreInit()
        {

            //connectionstring check
            CheckApplicationMandatorySettings(ConfigurationDataTypeEnum.CONNECTION_STRING, "fsce00013", Properties.Resources.fsce00013);

            //servertimezone check
            CheckApplicationMandatorySettings(ConfigurationDataTypeEnum.SERVER_TIME_ZONE, "fsce00015", Properties.Resources.fsce00015);

            //application environment settings check
            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.APPLICATION_ENVIRONMENT_SETTINGS, "fsce00051", Properties.Resources.fsce00051);

            //mandatory check needed
            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_CACHE_CLEANER_THREAD_MILLISECONDS_INTERVAL, "fsce00054", Properties.Resources.fsce00054);
            ValidateCacheCleanerThreadInterval();

            //sap configuration mandatory check
            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_MANDATORY_CHECK_ON, "fsce00014", Properties.Resources.fsce00014);
            SAPConfigMandatorySettings();

            //pqm configuration mandatory check
            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_PQM_CONFIG_MANDATORY_CHECK_ON, "fsce00055", Properties.Resources.fsce00055);
            PQMConfigMandatorySettings();
        }

        /// <summary>
        /// check mandatory application settings value
        /// </summary>
        /// <param name="settingsdata"></param>
        /// <param name="messageCode"></param>
        /// <param name="message"></param>
        /// <exception cref="SystemException"></exception>
        private void CheckApplicationMandatorySettings(ConfigurationDataTypeEnum settingsdata, string messageCode, string message)
        {
            string settingValue = null;
            try
            {
                settingValue = settingsdata.GetValue();
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData(messageCode, message, Properties.Resources.fsce00017);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);

                InitializationSystemExceptionHandler.GetInstance().HandleException(sysEx);
            }
            CheckMandatorySettings(settingValue, messageCode, message);
        }

        /// <summary>
        /// check mandatory server settings value
        /// </summary>
        /// <param name="settingsdata"></param>
        /// <param name="messageCode"></param>
        /// <param name="message"></param>
        /// <exception cref="SystemException"></exception>
        private void CheckServerMandatorySettings(ServerConfigurationDataTypeEnum settingsdata, string messageCode, string message)
        {
            string settingValue = null;
            try
            {
                settingValue = settingsdata.GetValue();
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData(messageCode, message, Properties.Resources.fsce00057);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);

                InitializationSystemExceptionHandler.GetInstance().HandleException(sysEx);
            }
            CheckMandatorySettings(settingValue, messageCode, message);
        }
        /// <summary>
        /// check mandatory settings value
        /// </summary>
        /// <param name="settingValue"></param>
        /// <param name="messageCode"></param>
        /// <param name="message"></param>
        /// <exception cref="SystemException"></exception>
        private void CheckMandatorySettings(string settingValue,
                                                    string messageCode, string message)
        {
            if (string.IsNullOrWhiteSpace(settingValue))
            {
                MessageData messageData = new MessageData(messageCode, message, Properties.Resources.fsce00016);
                Framework.SystemException sysEx = new Framework.SystemException(messageData);

                InitializationSystemExceptionHandler.GetInstance().HandleException(sysEx);
            }


        }

        /// <summary>
        /// sap configuration mandatory check
        /// </summary>
        private void SAPConfigMandatorySettings()
        {
            String checkValue = ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_MANDATORY_CHECK_ON.GetValue();

            bool checkMandatory = false;
            try
            {
                checkMandatory = Convert.ToBoolean(checkValue);
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("fsce00058", Properties.Resources.fsce00058, checkValue);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);

                InitializationSystemExceptionHandler.GetInstance().HandleException(sysEx);
            }

            if (!checkMandatory)
            {
                return;
            }

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_PLANT_CODE, "fsce00060", Properties.Resources.fsce00060);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_NAME, "fsce00023", Properties.Resources.fsce00023);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_LOGON_GROUP, "fsce00024", Properties.Resources.fsce00024);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_MESSAGE_SERVER_HOST, "fsce00025", Properties.Resources.fsce00025);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_SYSTEM_ID, "fsce00026", Properties.Resources.fsce00026);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_SYSTEM_NUMBER, "fsce00027", Properties.Resources.fsce00027);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_CLIENT, "fsce00030", Properties.Resources.fsce00030);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_LANGUAGE, "fsce00031", Properties.Resources.fsce00031);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_POOL_SIZE, "fsce00033", Properties.Resources.fsce00033);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_PEAK_CONNECTIONS_LIMIT, "fsce00034", Properties.Resources.fsce00034);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_IDLE_TIMEOUT, "fsce00035", Properties.Resources.fsce00035);

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_SAP_CONFIG_IDLE_CHECKTIME, "fsce00036", Properties.Resources.fsce00036);
        }


        /// <summary>
        /// pqm configuration mandatory check
        /// </summary>
        private void PQMConfigMandatorySettings()
        {
            String checkValue = ServerConfigurationDataTypeEnum.DEFAULT_PQM_CONFIG_MANDATORY_CHECK_ON.GetValue();

            bool checkMandatory = false;
            try
            {
                checkMandatory = Convert.ToBoolean(checkValue);
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("fsce00059", Properties.Resources.fsce00059, checkValue);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);

                InitializationSystemExceptionHandler.GetInstance().HandleException(sysEx);
            }

            if (!checkMandatory)
            {
                return;
            }

            CheckServerMandatorySettings(ServerConfigurationDataTypeEnum.DEFAULT_PQM_CONFIG_URL, "fsce00038", Properties.Resources.fsce00038);
        }
        /// <summary>
        /// Validate the DEFAULT_CACHE_CLEANER_THREAD_INTERVAL value provided in the settings file
        /// </summary>
        private void ValidateCacheCleanerThreadInterval()
        {
            String intervalValue = ServerConfigurationDataTypeEnum.DEFAULT_CACHE_CLEANER_THREAD_MILLISECONDS_INTERVAL.GetValue();

            int interval = 0;
            try
            {
                interval = Convert.ToInt32(intervalValue);
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("fsce00056", Properties.Resources.fsce00056, intervalValue);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);

                InitializationSystemExceptionHandler.GetInstance().HandleException(sysEx);
            }
            if (interval <= 0)
            {
                MessageData messageData = new MessageData("fsce00054", Properties.Resources.fsce00054, interval.ToString());
                Framework.SystemException sysEx = new Framework.SystemException(messageData);

                InitializationSystemExceptionHandler.GetInstance().HandleException(sysEx);
            }
        }

    }
}
