
namespace Com.Nidec.Mes.Framework.Login
{
    public class CheckLoginCbm : CbmController
    {

        /// <summary>
        /// initialize LoginDao
        /// </summary>
        private readonly CheckLoginDao loginDao = new CheckLoginDao();

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
