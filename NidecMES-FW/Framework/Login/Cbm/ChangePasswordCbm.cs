
namespace Com.Nidec.Mes.Framework.Login
{
    class ChangePasswordCbm : CbmController
    {

        /// <summary>
        /// initialize ChangePasswordDao
        /// </summary>
        private readonly ChangePasswordDao changePwdDao = new ChangePasswordDao();

        /// <summary>
        /// Execute the dao
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return changePwdDao.Execute(trxContext, vo);
        }
    }
}
