using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm.DefectiveReason
{
    class CheckWorkCenterReasonCbm : CbmController
    {
        private readonly DataAccessObject checkWorkCenterReasonDao = new Dao.DefectiveReason.CheckWorkCenterReasonDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return checkWorkCenterReasonDao.Execute(trxContext, vo);
        }
    }
}
