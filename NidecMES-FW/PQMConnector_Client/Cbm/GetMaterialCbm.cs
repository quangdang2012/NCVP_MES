using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.PQMConnector_Client.Dao;

namespace Com.Nidec.Mes.PQMConnector_Client.Cbm
{
    public class GetMaterialCbm : CbmController
    {
        private readonly DataAccessObject getModelDao = new GetMaterialDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getModelDao.Execute(trxContext, vo);
        }
    }
}
