using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
    public class GetPurchaseOrderCbm : CbmController
    {
        private readonly DataAccessObject getPurchaseOrderDao = new GetPurchaseOrderDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getPurchaseOrderDao.Execute(trxContext, vo);
        }
    }
}
