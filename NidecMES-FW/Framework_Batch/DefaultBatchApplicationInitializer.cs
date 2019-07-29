using System;
using System.Threading;
using Com.Nidec.Mes.Framework;
using System.Collections.Generic;

namespace Com.Nidec.Mes.Framework_Batch
{
    internal class DefaultBatchApplicationInitializer : ApplicationInitializer
    {
        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly DefaultBatchApplicationInitializer instance = new DefaultBatchApplicationInitializer();

        /// <summary>
        /// private constructor
        /// </summary>
        private DefaultBatchApplicationInitializer()
        {
        }

        /// <summary>
        /// returns the current instance 
        /// </summary>
        /// <returns></returns>
        internal static DefaultBatchApplicationInitializer GetInstance()
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

            // Add the event handler for handling non-UI thread exceptions to the event.
            Thread.GetDomain().UnhandledException += new UnhandledExceptionEventHandler(
                            DefaultUnhandledBatchExceptionHandler.GetInstance().HandleException);
        }

        /// <summary>
        /// check mandatory settings
        /// </summary>
        private void PreInit()
        {
            //common parameter mandatory check
            CheckMandatorySettings(BatchConfigurationDataTypeEnum.CONNECTION_STRING, "fbce00001", Properties.Resources.fbce00001);
            CheckMandatorySettings(BatchConfigurationDataTypeEnum.SERVER_TIME_ZONE, "fbce00002", Properties.Resources.fbce00002);
            CheckMandatorySettings(BatchConfigurationDataTypeEnum.APPLICATION_ENVIRONMENT_SETTINGS, "fbce00003", Properties.Resources.fbce00003);

            //batchuserdetail mandatorycheck
            CheckMandatorySettings(BatchConfigurationDataTypeEnum.DEFAULT_BATCH_USER, "fbce00004", Properties.Resources.fbce00004);
            CheckMandatorySettings(BatchConfigurationDataTypeEnum.DEFAULT_BATCH_FACTORYCODE, "fbce00005", Properties.Resources.fbce00005);

            //batch executiontype check => 0 : 1time execution/ 1 : infinity loop           
            CheckMandatorySettings(BatchConfigurationDataTypeEnum.BATCH_EXECUTION_TYPE, "fbce00006", Properties.Resources.fbce00006);
            BatchExecutionMandatorySettings();

            //batchexecution retrycount on exception check
            CheckMandatorySettings(BatchConfigurationDataTypeEnum.BATCH_EXECUTION_RETRY_COUNT_ON_EXCEPTION, "fbce00008", Properties.Resources.fbce00008);
            BatchExecutionRetryMandatorySettings();

            //preventmultipleinvoke flag check True/False
            CheckMandatorySettings(BatchConfigurationDataTypeEnum.PREVENT_MULTIPLE_INVOKE, "fbce00010", Properties.Resources.fbce00010);
            PreventMultipleInvokeMandatorySettings();
        }

        /// <summary>
        /// check mandatory applicationsettings value
        /// </summary>
        private void CheckMandatorySettings(BatchConfigurationDataTypeEnum settingsdata,
                                                    string messageCode, string message)
        {
            try
            {
                string settingValue = settingsdata.GetValue();

                if (string.IsNullOrWhiteSpace(settingValue))
                {
                    MessageData messageData = new MessageData(messageCode, message, Properties.Resources.fbce00014);
                    Framework.SystemException sysEx = new Framework.SystemException(messageData);
                    throw sysEx;
                }
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData(messageCode, message, Properties.Resources.fbce00015);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);
                throw sysEx;
            }
        }

        /// <summary>
        /// if executiontype = "1", need to check executionwaitinterval mandatory
        /// </summary>
        private void BatchExecutionMandatorySettings()
        {
            string batchExecutionType = BatchConfigurationDataTypeEnum.BATCH_EXECUTION_TYPE.GetValue();

            //check the batchExecutionType input value to fix the process
            switch (batchExecutionType)
            {
                case "1":
                    //batchexecution wait interval check
                    CheckMandatorySettings(BatchConfigurationDataTypeEnum.BATCH_EXECUTION_WAIT_INTERVAL, "fbce00007", Properties.Resources.fbce00007);
                    break;
                case "0":
                    break;
                default:
                    MessageData messageData = new MessageData("fbce00035", Properties.Resources.fbce00035);
                    Framework.SystemException sysEx = new Framework.SystemException(messageData, new FormatException());
                    throw sysEx;
            }
        }

        /// <summary>
        /// if retrycount >0, need to check retrywaitinterval mandatory
        /// </summary>
        private void BatchExecutionRetryMandatorySettings()
        {
            int retryCount;
            try
            {
                retryCount = Convert.ToInt32(BatchConfigurationDataTypeEnum.BATCH_EXECUTION_RETRY_COUNT_ON_EXCEPTION.GetValue());
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("fbce00036", Properties.Resources.fbce00036);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);
                throw sysEx;
            }

            if (retryCount == 0)
            {
                return; //normal
            }
            else if (retryCount > 0)    //if retry count > 0 then check wait interval
            {
                //batchexecution retry wait intervl on exception check
                CheckMandatorySettings(BatchConfigurationDataTypeEnum.BATCH_EXECUTION_RETRY_WAIT_INTERVAL_ON_EXCEPTION, "fbce00009", Properties.Resources.fbce00009);

                ExceptionRetryWaitTimeSpanValidation();
            }
            else                        //else throw execption
            {
                MessageData messageData = new MessageData("fbce00040", Properties.Resources.fbce00040);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, new FormatException());
                throw sysEx;
            }

        }

        /// <summary>
        /// to chech the timespan validation
        /// </summary>
        /// <param name="value"></param>
        private void ExceptionRetryWaitTimeSpanValidation()
        {
            //null value check is not necessary, after mandatory check it was called
            string value = BatchConfigurationDataTypeEnum.BATCH_EXECUTION_RETRY_WAIT_INTERVAL_ON_EXCEPTION.GetValue();
            TimeSpan timeSpanValue;

            try
            {
                timeSpanValue = TimeSpan.Parse(value);
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("fbce00044", Properties.Resources.fbce00044);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);
                throw sysEx;
            }

            //value check
            if (timeSpanValue >= TimeSpan.Parse("0")) // if value >= 0 , then return
            {
                return;
            }
            else                                     // else throw system exception
            {
                MessageData messageData = new MessageData("fbce00045", Properties.Resources.fbce00045);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, new FormatException());
                throw sysEx;
            }
        }

        /// <summary>
        /// if preventmultipleinvoke is true, need to check the retrycount and waitinterval mandatory
        /// </summary>
        private void PreventMultipleInvokeMandatorySettings()
        {
            bool preventMultipleInvoke;

            try
            {
                preventMultipleInvoke = Convert.ToBoolean(BatchConfigurationDataTypeEnum.PREVENT_MULTIPLE_INVOKE.GetValue());
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("fbce00037", Properties.Resources.fbce00037);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);
                throw sysEx;
            }

            //if preventmultipleinvoke = false,　return
            if (!preventMultipleInvoke)
            {
                return;
            }

            //preventmultipleinvoke retry count check if already running
            CheckMandatorySettings(BatchConfigurationDataTypeEnum.PREVENT_MULTIPLE_INVOKE_RETRY_COUNT, "fbce00011", Properties.Resources.fbce00011);

            int retryCount;
            try
            {
                retryCount = Convert.ToInt32(BatchConfigurationDataTypeEnum.PREVENT_MULTIPLE_INVOKE_RETRY_COUNT.GetValue());
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("fbce00041", Properties.Resources.fbce00041);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);
                throw sysEx;
            }

            if (retryCount == 0)
            {
                return; //normal
            }
            else if (retryCount > 0)         //if retrycount > 0 then check wait interval
            {
                //preventmultipleinvoke wait interval check if already running
                CheckMandatorySettings(BatchConfigurationDataTypeEnum.PREVENT_MULTIPLE_INVOKE_WAIT_INTERVAL, "fbce00012", Properties.Resources.fbce00012);
                MultpileInvokeRetryWaitTimeSpanValidation();
            }
            else                            //else throw execption
            {
                MessageData messageData = new MessageData("fbce00042", Properties.Resources.fbce00042);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, new FormatException());
                throw sysEx;
            }
        }

        /// <summary>
        /// to chech the timespan validation
        /// </summary>
        /// <param name="value"></param>
        private void MultpileInvokeRetryWaitTimeSpanValidation()
        {
            //null value check is not necessary, after mandatory check it was called
            string value = BatchConfigurationDataTypeEnum.PREVENT_MULTIPLE_INVOKE_WAIT_INTERVAL.GetValue();
            TimeSpan timeSpanValue;

            try
            {
                timeSpanValue = TimeSpan.Parse(value);
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("fbce00046", Properties.Resources.fbce00046);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, ex);
                throw sysEx;
            }

            //value check
            if (timeSpanValue >= TimeSpan.Parse("0")) // if value >= 0 , then return
            {
                return;
            }
            else                                     // else throw system exception
            {
                MessageData messageData = new MessageData("fbce00047", Properties.Resources.fbce00047);
                Framework.SystemException sysEx = new Framework.SystemException(messageData, new FormatException());
                throw sysEx;
            }
        }
    }
}
