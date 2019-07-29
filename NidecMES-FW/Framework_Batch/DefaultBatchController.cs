using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Vo;
using Com.Nidec.Mes.Framework_Batch.Cbm;

namespace Com.Nidec.Mes.Framework_Batch
{
    public class DefaultBatchController : BatchController
    {
        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultBatchController));

        /// <summary>
        /// store the instance of CheckIsStopRequestedCbm
        /// </summary>
        private readonly CheckIsStopRequestedCbm checkIsStopRequestedCbm = new CheckIsStopRequestedCbm();

        /// <summary>
        /// constructor
        /// </summary>
        public DefaultBatchController(string batchMainSettingsFileName)
        {
            if (string.IsNullOrWhiteSpace(batchMainSettingsFileName))
            {
                //implement system exception
                MessageData messageData = new MessageData("fbce00050", Properties.Resources.fbce00050);
                Exception nullEx = new NullReferenceException();
                logger.Error(messageData, nullEx);

                throw new Framework.SystemException(messageData, nullEx);
            }

            ConfigurationReader batchConfigReader;
            try
            {
                batchConfigReader = new Framework.BatchStaticCachedConfigurationReader(batchMainSettingsFileName);
            }
            catch (Exception readerEx)
            {
                //implement system exception
                MessageData messageData = new MessageData("fbce00052", Properties.Resources.fbce00052);
                logger.Error(messageData, readerEx);

                throw new Framework.SystemException(messageData, readerEx);
            }

            //set the
            BatchConfigurationDataTypeEnum.SetConfigurationReader(batchConfigReader);


            //check the settings file values and logg
            try
            {
                DefaultBatchApplicationInitializer.GetInstance().Init();
            }
            catch (Exception ex)
            {
                if (ex is Framework.SystemException) //systemexception throw from mandatory check in initializer
                {
                    Framework.SystemException sysEx = (Framework.SystemException)ex;
                    logger.Error(sysEx.GetMessageData(), ex);
                    ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_APPLICATION_INITIALIZER_SYSTEM_EXCEPTION);
                }
                else                                //unhandledexception throw from mandatory check in initializer
                {
                    MessageData messageData = new MessageData("fbce00043", Properties.Resources.fbce00043);
                    logger.Error(messageData, ex);
                    ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_APPLICATION_INITIALIZER_UNHANDLED_EXCEPTION);
                }
            }
        }

        /// <summary>
        /// int method to execute batch
        /// </summary>
        /// <param name="batchMain"></param>
        public void Init(BatchMain batchMain)
        {
            //userdata creation
            UserDataFactory userDataFactory = DefaultBatchUserfactory.GetInstance();
            UserData usrdata = userDataFactory.CreateUserData(null);

            //check the batchmain instance available
            if (batchMain == null)
            {
                MessageData messageData = new MessageData("fbce00023", Properties.Resources.fbce00023);
                Exception ex = new NullReferenceException();
                logger.Error(messageData, ex);

                ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_BATCH_MAIN_INSTANCE_NOT_AVAILABLE);
            }

            //Get Batch Prameters for batchexecution
            string batchExecutionTypeParam = BatchConfigurationDataTypeEnum.BATCH_EXECUTION_TYPE.GetValue();
            TimeSpan batchExecutionWaitIntervalParam = TimeSpan.Parse(BatchConfigurationDataTypeEnum.BATCH_EXECUTION_WAIT_INTERVAL.GetValue());

            //Get Batch Prameters for batchexecution retry on exception
            int batchExecutionRetryCountParam = Convert.ToInt32(BatchConfigurationDataTypeEnum.BATCH_EXECUTION_RETRY_COUNT_ON_EXCEPTION.GetValue());
            TimeSpan batchExecutionRetryWaitIntervalParam = TimeSpan.Parse(BatchConfigurationDataTypeEnum.BATCH_EXECUTION_RETRY_WAIT_INTERVAL_ON_EXCEPTION.GetValue());

            //Get Batch Prameters for preventmultipleinvoke
            bool preventMultipleInvokeParam = Convert.ToBoolean(BatchConfigurationDataTypeEnum.PREVENT_MULTIPLE_INVOKE.GetValue());
            TimeSpan preventMultipleInvokeWaitIntervalParam = TimeSpan.Parse(BatchConfigurationDataTypeEnum.PREVENT_MULTIPLE_INVOKE_WAIT_INTERVAL.GetValue());
            int preventMultipleInvokeRetryCountParam = Convert.ToInt32(BatchConfigurationDataTypeEnum.PREVENT_MULTIPLE_INVOKE_RETRY_COUNT.GetValue());

            //counter to chcek retry count on exception case
            int exceptionRetryCounter = 0;

            //to check whether the batch has been started to avoid checking multipleinvoker everytime
            bool batchStarted = false;

            //1.start batch process to do continous execution in while loop
            while (true)
            {
                //3.1 prevent multiple invoke based on the settings file value and start the batch program
                if (preventMultipleInvokeParam && !batchStarted)
                {
                    //counter to check multipleinvoke retry
                    int preventMultipleInvokeRetryCounter = 0;

                    while (true)
                    {
                        bool continueBatchExecution;
                        try
                        {
                            continueBatchExecution = PreventMultipleInvokeCheckForBatchExecution(batchMain.GetName());
                        }
                        catch (Exception multipleInvokeEx)
                        {
                            //logging for retry on exception
                            MessageData multipleInvokeExMessageData = new MessageData("fbce00029", Properties.Resources.fbce00029);
                            logger.Error(multipleInvokeExMessageData, multipleInvokeEx);

                            ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_MULTIPLE_INVOKE_EXCEPTION);
                            return;
                        }

                        //if continuebatchexecution flag is true, exit the loop and do batch execuion
                        if (continueBatchExecution)
                        {
                            //update the flag once batch started
                            batchStarted = true;
                            break;
                        }

                        //if retrycount=0, complete the batch application
                        if (preventMultipleInvokeRetryCountParam == 0)
                        {
                            ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_MULTIPLE_INVOKE_EXCEPTION_NO_RETRY);
                            return;
                        }

                        //increase the counter to check multipleinvokeretry count
                        preventMultipleInvokeRetryCounter++;

                        //Wait interval for execution retry
                        try
                        {
                            MultipleInvokeExecutionRetryWait(preventMultipleInvokeRetryCounter, preventMultipleInvokeWaitIntervalParam);
                        }
                        catch (Exception ex)
                        {
                            MessageData messagedata = new MessageData("fbce00027", Properties.Resources.fbce00027);
                            logger.Error(messagedata, ex);

                            ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_MULTIPLE_INVOKE_RETRY_THREAD_WAIT_EXCEPTION);
                            return;
                        }

                        //exception throws after retry counts reached maximum retry count in the settings file
                        if (preventMultipleInvokeRetryCounter >= preventMultipleInvokeRetryCountParam)
                        {
                            MessageData messageData = new MessageData("fbce00022", Properties.Resources.fbce00022);
                            logger.Error(messageData);

                            ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_MULTIPLE_INVOKE_RETRY_REACHED_MAX_COUNT);
                            return;
                        }
                    }
                }

                //1.execute the batch
                try
                {
                    logger.Debug(new MessageData("fbcd00001", Properties.Resources.fbcd00001));

                    batchMain.Execute();

                    logger.Debug(new MessageData("fbcd00002", Properties.Resources.fbcd00002));

                    exceptionRetryCounter = 0;
                }
                catch (Exception batchExecutionEx)
                {
                    MessageData batchExceptionMessagedata = new MessageData("fbce00034", Properties.Resources.fbce00034);
                    logger.Error(batchExceptionMessagedata, batchExecutionEx);

                    //if retrycount=0, complete the batch application
                    if (batchExecutionRetryCountParam == 0)
                    {
                        CompleteBatchExecution(batchMain.GetName(), Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_EXECUTION_EXCEPTION_NO_RETRY);
                        return;
                    }

                    //2.1 do retry execution based on settings parameter count
                    exceptionRetryCounter++;

                    //2.2 wait for next execution retry on exception case, if wait interval time specified in settings file
                    try
                    {
                        BatchExecutionRetryWaitOnException(exceptionRetryCounter, batchExecutionRetryWaitIntervalParam);
                    }
                    catch (Exception batchRetryEx)
                    {
                        MessageData messagedata = new MessageData("fbce00026", Properties.Resources.fbce00026);
                        logger.Error(messagedata, batchRetryEx);

                        CompleteBatchExecution(batchMain.GetName(), Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_RETRY_EXECUTION_ON_EXCEPTION_THREAD_WAIT_EXCEPTION);
                        return;
                    }

                    //if the retry count reached the max, exit the batch application
                    if (exceptionRetryCounter >= batchExecutionRetryCountParam)
                    {
                        CompleteBatchExecution(batchMain.GetName(), Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_RETRY_EXECUTION_ON_EXCEPTION_REACHED_MAX_COUNT);
                        return;
                    }
                    continue;
                }

                //1.1batch execution stops if batchexecutiontype :  0 - onetime execution / 1 - infinity loop
                if ("0".Equals(batchExecutionTypeParam))
                {
                    //3.update the batch process flag to set '2' as completed
                    CompleteBatchExecution(batchMain.GetName(), Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_BATCH_EXECUTION_SUCCESS);
                    return;
                }


                //check isstoprequested flag after each execution
                //if "1" remove the batchprocessdata and exit the application
                if (CheckIsStopRequestedForApplication(batchMain.GetName()))
                {
                    MessageData messagedata = new MessageData("fbci00014", Properties.Resources.fbci00014);
                    logger.Info(messagedata);

                    //complete with success in the taskscheduler after stop requested by administrator
                    CompleteBatchExecution(batchMain.GetName(), Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_BATCH_EXECUTION_SUCCESS);
                    return;
                }

                //1.2.wait for next execution, if wait interval time specified in settings file
                try
                {
                    BatchExecutionWait(batchExecutionWaitIntervalParam);
                }
                catch (Exception batchExecutionWaitEx)
                {
                    MessageData messagedata = new MessageData("fbce00025", Properties.Resources.fbce00025);
                    logger.Error(messagedata, batchExecutionWaitEx);

                    CompleteBatchExecution(batchMain.GetName(), Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_EXECUTION_THREAD_WAIT_EXCEPTION);
                    return;
                }
            }
        }

        /// <summary>
        /// waiting for execution for timeinterval
        /// </summary>
        private void BatchExecutionWait(TimeSpan batchWaitInterval)
        {
            if (batchWaitInterval == TimeSpan.Parse("0"))
            {
                return;
            }
            //logging for waiting time interval
            MessageData messagedata = new MessageData("fbci00004", Properties.Resources.fbci00004, batchWaitInterval.ToString());
            logger.Info(messagedata);

            Console.WriteLine(messagedata);

            //thread to sleep the batch process for interval specified in settings files
            System.Threading.Thread.Sleep(batchWaitInterval);
        }

        /// <summary>
        /// waiting for execution for timeinterval
        /// </summary>
        private void BatchExecutionRetryWaitOnException(int retryCount, TimeSpan batchWaitInterval)
        {
            if (batchWaitInterval == TimeSpan.Parse("0"))
            {
                return;
            }
            //logging for retry on exception
            MessageData messageData = new MessageData("fbci00005", Properties.Resources.fbci00005, retryCount.ToString());
            logger.Info(messageData);

            Console.WriteLine(messageData);

            //logging for waiting time interval
            MessageData messagedata = new MessageData("fbci00006", Properties.Resources.fbci00006, batchWaitInterval.ToString());
            logger.Info(messagedata);

            Console.WriteLine(messagedata);

            //thread to sleep the batch process for interval specified in settings files
            System.Threading.Thread.Sleep(batchWaitInterval);
        }

        /// <summary>
        /// insert new data for batchmainname
        /// </summary>
        private bool PreventMultipleInvokeCheckForBatchExecution(string batchMainName)
        {
            ///exceut batchprocess start
            AddBatchProcessVo inVo = new AddBatchProcessVo();
            inVo.BatchProcessCode = batchMainName;
            inVo.IsStopRequested = false;
            CheckBatchProcessVo outVo;
            try
            {
                outVo = (CheckBatchProcessVo)DefaultCbmInvoker.Invoke(new CheckBatchProcessCbm(), inVo);
            }
            catch (Exception ex)
            {
                //logging for retry on exception
                MessageData messageData = new MessageData("fbce00029", Properties.Resources.fbce00029);
                logger.Error(messageData, ex);

                ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_MULTIPLE_INVOKE_EXCEPTION);
                return false; ;
            }

            //if batchprocess data not found /insert, exit the application
            if (outVo == null)
            {
                MessageData message = new MessageData("fbci00009", Properties.Resources.fbci00009);
                logger.Info(message);

                ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_MULTIPLE_INVOKE_DATA_NOT_FOUND);
                return false;
            }

            //if started, logg message and continue
            if (outVo.IsBatchStarted)
            {
                MessageData message = new MessageData("fbci00001", Properties.Resources.fbci00001);
                logger.Info(message);

                Console.WriteLine(message);
                return true;
            }
            else
            {
                //if batch is already running do retry based on the retrycount specified in configuration
                MessageData message = new MessageData("fbci00002", Properties.Resources.fbci00002);
                logger.Info(message);

                //increase the retry count if occurs continously
                return false;
            }
        }

        /// <summary>
        /// delete record for batchmainname, isstoprequested="1"
        /// </summary>
        private bool CheckIsStopRequestedForApplication(string batchMainName)
        {
            ///exceut batchprocess start
            AddBatchProcessVo inVo = new AddBatchProcessVo();
            inVo.BatchProcessCode = batchMainName;
            AddBatchProcessVo outVo;
            try
            {
                outVo = (AddBatchProcessVo)DefaultCbmInvoker.Invoke(checkIsStopRequestedCbm, inVo);
            }
            catch (Exception ex)
            {
                //logging for retry on exception
                MessageData messageData = new MessageData("fbce00055", Properties.Resources.fbce00055, ex.Message);
                logger.Error(messageData, ex);

                ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_EXECUTION_COMPLETE_AFTER_STOP_REQUEST_EXCEPTION);
                return false; ;
            }

            //if batchprocess data not found /insert, exit the application
            if (outVo == null)
            {
                MessageData message = new MessageData("fbci00012", Properties.Resources.fbci00012);
                logger.Info(message);

                ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_EXECUTION_COMPLETE_AFTER_STOP_REQUEST_DATA_NOT_FOUND);
                return false;
            }

            return outVo.IsStopRequested;
        }

        /// <summary>
        /// waiting for multipleinvokeretryexecution for timeinterval
        /// </summary>
        private void MultipleInvokeExecutionRetryWait(int retryCount, TimeSpan batchWaitInterval)
        {
            //Wait interval for execution retry
            if (batchWaitInterval == TimeSpan.Parse("0"))
            {
                return;
            }

            //logging for retry on exception
            MessageData messageData = new MessageData("fbci00007", Properties.Resources.fbci00007, retryCount.ToString());
            logger.Info(messageData);
            Console.WriteLine(messageData);

            //logging for waiting time interval
            MessageData messagedata = new MessageData("fbci00008", Properties.Resources.fbci00008, batchWaitInterval.ToString());
            logger.Info(messagedata);

            Console.WriteLine(messagedata);

            //thread to sleep the batch process for interval specified in settings files
            System.Threading.Thread.Sleep(batchWaitInterval);
        }

        /// <summary>
        /// update the batch process flag = '0'
        /// </summary>
        private void CompleteBatchExecution(string batchMainName, int errorCode)
        {
            AddBatchProcessVo inVo = new AddBatchProcessVo();
            inVo.BatchProcessCode = batchMainName;

            try
            {
                DefaultCbmInvoker.Invoke(new DeleteBatchProcessCbm(), inVo);
            }
            catch (Exception completeEx)
            {
                MessageData completeExMessageData = new MessageData("fbce00024", Properties.Resources.fbce00024);
                logger.Error(completeExMessageData, completeEx);

                ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_EXECUTION_COMPLETE_EXCEPTION);
                return;
            }

            MessageData completeMessageData = new MessageData("fbci00003", Properties.Resources.fbci00003, errorCode.ToString());
            logger.Info(completeMessageData);

            ExitApplication(errorCode);
        }

        /// <summary>
        /// Method to exit the batch application and update status in task scheduler
        /// </summary>
        private void ExitApplication(int errorCode)
        {
            try
            {
                Environment.Exit(errorCode);
            }
            catch (Exception exitEx)
            {
                MessageData messageData = new MessageData("fbce00039", Properties.Resources.fbce00039);
                logger.Error(messageData, exitEx);

                Environment.Exit(Properties.Settings.Default.SCHED_RETURN_IN_BATCH_CONTROLLER_EXCEPTION_IN_EXIT_APPLICATION);
            }
        }
    }
}
