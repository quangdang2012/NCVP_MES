using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class GetSapItemForMESItemCbm : CbmController
    {
        private readonly DataAccessObject getSapItemForMESItemDao = new GetSapItemForMESItemDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getSapItemForMESItemDao.Execute(trxContext, vo);
        }
    }
}
