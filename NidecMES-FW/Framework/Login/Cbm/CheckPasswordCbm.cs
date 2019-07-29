
namespace Com.Nidec.Mes.Framework.Login
{
    class CheckPasswordCbm : CbmController
    {

        /// <summary>
        /// initialize CheckPasswordDao
        /// </summary>
        private readonly CheckPasswordDao checkPwdDao = new CheckPasswordDao();

        /// <summary>
        /// Execute the dao
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return checkPwdDao.Execute(trxContext, vo);
        }
    }
}
