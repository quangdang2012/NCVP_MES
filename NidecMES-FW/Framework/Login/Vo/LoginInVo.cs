using System;
namespace Com.Nidec.Mes.Framework.Login
{
    [Serializable]
    public class LoginInVo : ValueObject
    {
        /// <summary>
        /// get and set the userid
        /// </summary>
        public string InputUserId { get; set; }

        /// <summary>
        /// get and set password
        /// </summary>
        public string InputPassword { get; set; }

        /// <summary>
        /// get and set password
        /// </summary>
        public string AuthentificateFlag { get; set; }
    }
}
