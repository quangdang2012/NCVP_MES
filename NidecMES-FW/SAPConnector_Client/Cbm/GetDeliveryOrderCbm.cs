using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class GetDeliveryOrderCbm : CbmController
    {
        private readonly DataAccessObject getDeliveryOrderDao = new GetDeliveryOrderDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getDeliveryOrderDao.Execute(trxContext, vo);

        }
    }
}
