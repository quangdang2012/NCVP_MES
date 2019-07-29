using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class GetManufacturingOrderCbm : CbmController
    {
        private readonly DataAccessObject getManufacturingOrderDao = new GetManufacturingOrderDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getManufacturingOrderDao.Execute(trxContext, vo);

        }
    }
}
