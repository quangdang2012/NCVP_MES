using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.SAPConnector_Client.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.SAPConnector_Client.Cbm
{
   public  class SubmitOutBoundCbm : CbmController
    {
        private readonly DataAccessObject submitOutBoundDao = new SubmitOutBoundDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return submitOutBoundDao.Execute(trxContext, vo);
        }
    }
}
