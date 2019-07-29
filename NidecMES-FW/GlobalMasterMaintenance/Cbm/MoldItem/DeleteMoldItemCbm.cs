using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    class DeleteMoldItemCbm : CbmController
    {
        private readonly DataAccessObject deleteMoldItemDao = new DeleteMoldItemDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {          
            return deleteMoldItemDao.Execute(trxContext, vo);
        }
    }
}
