using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class GetPurchaseOrderForMaterialCbm : CbmController
    {
        private readonly DataAccessObject getPurchaseOrderForMaterialDao = new GetPurchaseOrderForMaterialDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getPurchaseOrderForMaterialDao.Execute(trxContext, vo);

        }
    }
}
