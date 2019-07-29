using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class GetManufacturingOrderCompletelyCbm : CbmController
    {
        private readonly DataAccessObject getManufacturingOrderCompltelyDao = new GetManufacturingOrderCompletelyDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getManufacturingOrderCompltelyDao.Execute(trxContext, vo);
        }
    }
}
