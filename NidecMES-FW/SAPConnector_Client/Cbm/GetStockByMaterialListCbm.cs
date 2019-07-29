using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class GetStockByMaterialListCbm : CbmController
    {

        private readonly DataAccessObject getStockByMaterialListDao = new GetStockByMaterialListDao();
 
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getStockByMaterialListDao.Execute(trxContext, vo);

        }
    }
}
