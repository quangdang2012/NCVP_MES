using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class SubmitPurchaseOrderForMaterialCbm : CbmController
    {
        private readonly DataAccessObject submitPurchaseOrderForMaterialDao = new SubmitPurchaseOrderForMaterialDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return submitPurchaseOrderForMaterialDao.Execute(trxContext, vo);

        }
    }
}
