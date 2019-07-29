using System;
using System.Net;
using System.DirectoryServices.Protocols;
using Com.Nidec.Mes.Framework.Login;

namespace Com.Nidec.Mes.Framework
{
    internal class LocalUserAuthentificateStrategy : UserAuthentificateStrategy
    {
        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static CommonLogger logger = CommonLogger.GetInstance(typeof(LocalUserAuthentificateStrategy));


        /// <summary>
        /// initialize PopUpMessageController
        /// </summary>
        private readonly PopUpMessageController popUpMessage = new PopUpMessageController();


        /// <summary>
        /// local user authentication
        /// </summary>
        /// <param name="user"></param>
        /// <param name="pass"></param>
        /// <returns></returns>
        public Boolean Authentificate(string user, string pass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrEmpty(pass))
            {
                return false;
            }

            EncryptDecrypt encryptDecrypt = new EncryptDecrypt();

            LoginInVo inVo = new LoginInVo
            {
                InputUserId = user,
                InputPassword = encryptDecrypt.Encrypt(pass)
            };
            try
            {
                LoginOutVo loginOutVo = (LoginOutVo)DefaultCbmInvoker.Invoke(new CheckLoginCbm(), inVo);
                if (loginOutVo.ResultCount > 0) return true;
            }
            catch (ApplicationException exception)//password error.
            {
                logger.Error(exception.GetMessageData(), exception);
                throw exception;
            }
            return false;

        }
    }
}