using System;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Framework_Server
{
    public class DefaultRemoteCbmInvokerProxy : MarshalByRefObject, RemoteCbmInvokerProxy
    {

        /// <summary>
        /// cbmcontainer instance
        /// </summary>
        private readonly CbmContainer cbmContainer = DefaultXmlCbmContainer.GetInstance();

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultRemoteCbmInvokerProxy));

        /// <summary>
        /// to check is remoting server running
        /// </summary>
        /// <returns>returns true/flase</returns>
        public bool IsServerRunning()
        {
            return true;
        }

        /// <summary>
        /// execute cbm using cbm id
        /// </summary>
        /// <param name="cbm">cbm  to be executed</param>
        /// <param name="userdata">userdata information for cbm invoker</param>
        /// <param name="vo">input vo for the cbm</param>
        /// <exception cref="Com.Nidec.Mes.Framework.SystemException">exception handled in cbm getting cbm instance for cbmid</exception>
        /// <exception cref="System.Exception">unhandledexception handled in cbm getting cbm instance for cbmid and throws Com.Nidec.Mes.Framework.SystemException</exception>
        /// <exception cref="Com.Nidec.Mes.Framework.ApplicationException">exception handled in cbm invoke</exception>
        /// <exception cref="Com.Nidec.Mes.Framework.SystemException">exception handled in cbm invoke</exception>
        /// <exception cref="System.Exception">unhandledexception handled in cbm invoke and throws Com.Nidec.Mes.Framework.SystemException</exception>
        /// <returns>output vo will be returned/ exception will be thrown for error cases</returns>
        public ValueObject Execute(string CbmId, UserData userdata, ValueObject vo)
        {
            UserData usr = UserData.GetUserData();
            usr.UserCode = userdata.UserCode;
            usr.FactoryCode = userdata.FactoryCode;

            CbmController cbm;

            ///get cbm instance
            try
            {
                cbm = cbmContainer.GetCbm(CbmId);
            }
            catch (Framework.SystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                MessageData message = new MessageData("fsce00041", Properties.Resources.fsce00041, ex.Message);
                logger.Error(message, ex);

                throw new Framework.SystemException(message, ex);
            }

            try
            {
                return DefaultCbmInvoker.Invoke(cbm, vo, userdata, UserDataSpecifiedTransactionContextFactory.GetInstance());
            }
            catch (Framework.ApplicationException ex)
            {
                throw ex;
            }
            catch (Framework.SystemException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                MessageData message = new MessageData("fsce00050", Properties.Resources.fsce00050, ex.Message);
                logger.Error(message, ex);

                throw new Framework.SystemException(message, ex);
            }
        }
    }
}
