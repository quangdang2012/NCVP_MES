using System;
using System.Diagnostics;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Framework_Server
{
    public class InitializationServerSystemExceptionHandler
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(InitializationServerSystemExceptionHandler));

        /// <summary>
        /// private constructor
        /// </summary>
        private InitializationServerSystemExceptionHandler()
        {
        }

        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly InitializationServerSystemExceptionHandler instance
                                                = new InitializationServerSystemExceptionHandler();

        /// <summary>
        /// returns the current instance
        /// </summary>
        /// <returns></returns>
        public static InitializationServerSystemExceptionHandler GetInstance()
        {
            return instance;
        }


        /// <summary>
        /// popup for particular exception
        /// </summary>
        /// <param name="unhandledException"></param>
        public void HandleException(Framework.SystemException sysException)
        {

            logger.Error(sysException.GetMessageData(), sysException);
            ShowMessage(sysException.GetMessageData());

            AbnormalEnd();
        }

        private void ShowMessage(MessageData messageData)
        {
            InitializationErrorMessageForm messageForm = new InitializationErrorMessageForm(messageData);
            messageForm.ShowDialog();

        }
        /// <summary>
        /// Method to call the kill current process
        /// </summary>
        private void AbnormalEnd()
        {
            KillProcess(Process.GetCurrentProcess());
        }

        /// <summary>
        /// kill the running process
        /// </summary>
        /// <param name="targetProcess"></param>
        private void KillProcess(Process targetProcess)
        {
            try
            {
                targetProcess.Kill();
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                MessageData messageData = new MessageData("fsce00037", Properties.Resources.fsce00037, ex.Message);
                ShowMessage(messageData);
                logger.Error(messageData, ex);
            }
            catch (NotSupportedException ex)
            {
                MessageData messageData = new MessageData("fsce00037", Properties.Resources.fsce00037, ex.Message);
                ShowMessage(messageData);
                logger.Error(messageData, ex);
            }
            catch (InvalidOperationException ex)
            {
                MessageData messageData = new MessageData("fsce00037", Properties.Resources.fsce00037, ex.Message);
                ShowMessage(messageData);
                logger.Error(messageData, ex);
            }
        }
    }
}
