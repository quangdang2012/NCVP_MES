using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class AddMoConfirmationCbm : CbmController
    {
        private readonly DataAccessObject addMoConfirmationDao = new Dao.AddMoConfirmationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return addMoConfirmationDao.Execute(trxContext, vo);   

        }
    }
}
