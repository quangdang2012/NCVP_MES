using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class CancelMoConfirmationCbm : CbmController
    {
        private readonly DataAccessObject cancelMoConfirmationDao = new Dao.CancelMoConfirmationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return cancelMoConfirmationDao.Execute(trxContext, vo);   

        }
    }
}
