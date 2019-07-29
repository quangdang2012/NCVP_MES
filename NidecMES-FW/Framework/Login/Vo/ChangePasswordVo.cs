namespace Com.Nidec.Mes.Framework.Login
{
    class ChangePasswordVo : ValueObject
    {
        /// <summary>
        /// get and set password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// get and set usercode
        /// </summary>
        public string UserCode { get; set; }

        /// <summary>
        /// store affectedcount
        /// </summary>
        public int AffectedCount = 0;
    }
}
