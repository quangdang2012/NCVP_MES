using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class AddLineItemCycleTimeMasterMntCbm : CbmController
    {
        private readonly DataAccessObject addLineItemCycleTimeMasterMntDao = new AddLineItemCycleTimeMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addLineItemCycleTimeMasterMntDao.Execute(trxContext, vo);

        }
    }
}
