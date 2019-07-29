using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
   public class AddLineRestTimeMasterMntCbm : CbmController
    {
        private readonly DataAccessObject addLineRestTimeMasterMntDao = new AddLineRestTimeMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addLineRestTimeMasterMntDao.Execute(trxContext, vo);

        }
    }
}
