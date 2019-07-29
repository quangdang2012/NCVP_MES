using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class UpdateLineItemCycleTimeMasterMntCbm : CbmController
    {
        private readonly DataAccessObject updateLineItemCycleTimeMasterMntCbm = new UpdateLineItemCycleTimeMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return updateLineItemCycleTimeMasterMntCbm.Execute(trxContext, vo);

        }
    }
}
