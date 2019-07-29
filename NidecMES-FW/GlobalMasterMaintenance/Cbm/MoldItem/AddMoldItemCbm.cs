using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    class AddMoldItemCbm : CbmController
    {

        private readonly DataAccessObject addmoldItemDao = new AddMoldItemDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addmoldItemDao.Execute(trxContext, vo);

        }
    }
}
