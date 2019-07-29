using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Framework_Batch
{
    internal class DefaultUnhandledBatchExceptionHandler : UnhandledExceptionHandler
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultUnhandledBatchExceptionHandler));

        /// <summary>
        /// private constructor
        /// </summary>
        private DefaultUnhandledBatchExceptionHandler()
        {
        }

        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly DefaultUnhandledBatchExceptionHandler instance
                                                = new DefaultUnhandledBatchExceptionHandler();

        /// <summary>
        /// returns the current instance
        /// </summary>
        /// <returns></returns>
        internal static DefaultUnhandledBatchExceptionHandler GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// handle unhandled exception occured in the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void HandleException(object sender, UnhandledExceptionEventArgs e)
        {
            if (e == null || e.ExceptionObject == null)
            {
                return;
            }
            try
            {
                Exception ex = e.ExceptionObject as Exception;

                //will exit the application during unhandled exception occured
                HandleException(ex);
            }
            catch (Exception unExpectedExcepiton)
            {
                //logging only
                MessageData messageData = new MessageData("fbce00017", Properties.Resources.fbce00017, unExpectedExcepiton.Message);
                logger.Error(messageData, unExpectedExcepiton);

                //exit application if exception occured in the normal handleexception exit application
                ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_EXCEPTION_HANDLER_UNEXPECTED_EXCEPTION); //failed and set the status in task scheduler
            }
            finally
            {
                try
                {
                    //if failed to exit in normal case, will do exit here
                    ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_EXCEPTION_HANDLER_EXCEPTION_IN_ABNORMAL_EXIT);
                }
                catch (Exception unExpectedExcepiton)
                {
                    //logging only
                    MessageData messageData = new MessageData("fbce00018", Properties.Resources.fbce00018, unExpectedExcepiton.Message);
                    logger.Error(messageData, unExpectedExcepiton);
                }
            }
        }

        /// <summary>
        /// popup for particular exception
        /// </summary>
        /// <param name="unhandledException"></param>
        private void HandleException(Exception unhandledException)
        {
            MessageData messageData = new MessageData("fbce00016", Properties.Resources.fbce00016, unhandledException.Message);
            logger.Error(messageData, unhandledException);

            if (unhandledException is Framework.ApplicationException)
            {
                ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_EXCEPTION_HANDLER_APPLICATION_EXCEPTION);
            }
            else if (unhandledException is Framework.SystemException)
            {
                ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_EXCEPTION_HANDLER_SYSTEM_EXCEPTION);
            }
            else
            {
                ExitApplication(Properties.Settings.Default.SCHED_RETURN_IN_EXCEPTION_HANDLER_EXCEPTION);
            }
        }

        /// <summary>
        /// Method to exit the batch application and update status in task scheduler
        /// </summary>
        private void ExitApplication(int errorCode)
        {
            try
            {
                //exit application with errorcode parameter
                Environment.Exit(errorCode);
            }
            catch (Exception exitEx)
            {
                MessageData messageData = new MessageData("fbce00038", Properties.Resources.fbce00038);
                logger.Error(messageData, exitEx);

                //if exception occured in exit application do again
                Environment.Exit(Properties.Settings.Default.SCHED_RETURN_IN_EXCEPTION_HANDLER_EXCEPTION_IN_EXIT_APPLICATION);
            }
        }
    }
}
