using System;
using Com.Nidec.Mes.Framework;
using System.Web.Services.Protocols;

namespace Com.Nidec.Mes.Framework_Server
{
    public class DefaultWebServiceCbmInvokerProxy
    {

        /// <summary>
        /// constant string value for application exception
        /// </summary>
        private const string APPLICATION_EXCEPTION = "ApplicationException";

        /// <summary>
        /// constant string value for system exception
        /// </summary>
        private const string SYSTEM_EXCEPTION = "SystemException";

        /// <summary>
        /// constant string value for unhandled exception
        /// </summary>
        private const string UNHANDLED_EXCEPTION = "UnhandledException";

        /// <summary>
        /// cbmcontainer instance
        /// </summary>
        private static readonly CbmContainer cbmContainer = DefaultXmlCbmContainer.GetInstance();

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultCbmInvoker));

        /// <summary>
        /// Execute cbm with userdataspecifiedtransaction
        /// </summary>
        /// <param name="cbm">cbm  to be executed</param>
        /// <param name="userdata">userdata information for cbm invoker</param>
        /// <param name="vo">input vo for the cbm</param>
        /// <exception cref="Com.Nidec.Mes.Framework.SystemException">exception handled in cbm getting cbm instance for cbmid and throw as new soapexcepion</exception>
        /// <exception cref="System.Exception">unhandledexception handled in cbm getting cbm instance for cbmid and throw as new soapexcepion</exception>
        /// <exception cref="Com.Nidec.Mes.Framework.ApplicationException">exception handled in cbm invoke and throw as new soapexcepion</exception>
        /// <exception cref="Com.Nidec.Mes.Framework.SystemException">exception handled in cbm invoke and throw as new soapexcepion</exception>
        /// <exception cref="System.Exception">unhandledexception handled in cbm invoke and throw as new soapexcepion</exception>
        /// <returns>cbm output as valueobject/ exception as soapexception</returns>
        public static ValueObject Execute(string CbmId, UserData userdata, ValueObject vo)
        {
            if (userdata != null)
            {
                UserData usr = UserData.GetUserData();
                usr.UserCode = userdata.UserCode;
                usr.FactoryCode = userdata.FactoryCode;
                usr.SessionId = userdata.SessionId;
            }

            CbmController cbm;

            ///get cbm instance
            try
            {
                cbm = cbmContainer.GetCbm(CbmId);
            }
            catch (Framework.SystemException ex)
            {
                throw new SoapException(string.Empty, SoapException.ServerFaultCode, SYSTEM_EXCEPTION, ex);
            }
            catch (Exception ex)
            {
                throw new SoapException(string.Empty, SoapException.ServerFaultCode, UNHANDLED_EXCEPTION, ex);
            }

            if(cbm == null)
            {
                MessageData messageData = new MessageData("fsce00052", Properties.Resources.fsce00052);
                logger.Error(messageData, new NullReferenceException());

                throw new Framework.SystemException(messageData, new NullReferenceException()); //throw original exception as sys exception
            }

            ///execute cbm
            try
            {
                return DefaultCbmInvoker.Invoke(cbm, vo, userdata, UserDataSpecifiedTransactionContextFactory.GetInstance());
            }
            catch (Framework.ApplicationException ex)
            {
                throw new SoapException(string.Empty, SoapException.ServerFaultCode, APPLICATION_EXCEPTION, ex);
            }
            catch (Framework.SystemException ex)
            {
                throw new SoapException(string.Empty, SoapException.ServerFaultCode, SYSTEM_EXCEPTION, ex);
            }
            catch (Exception ex)
            {
                throw new SoapException(string.Empty, SoapException.ServerFaultCode, UNHANDLED_EXCEPTION, ex);
            }
        }

    }
}
