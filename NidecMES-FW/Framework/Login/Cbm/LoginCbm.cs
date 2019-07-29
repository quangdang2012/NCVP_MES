
namespace Com.Nidec.Mes.Framework.Login
{
    public class LoginCbm : CbmController
    {

        /// <summary>
        /// initialize LoginDao
        /// </summary>
        private readonly LoginDao loginDao = new LoginDao();

        /// <summary>
        /// Execute the dao
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            //DAO
            ValueObject outVo = loginDao.Execute(trxContext, vo);

            return outVo;

        }
    }
}
