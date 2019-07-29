using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckInspectionFormatExitInTransactionCbm : CbmController
    {
        private readonly DataAccessObject checkInspectionFormatExitInTransactionDao = new CheckInspectionFormatExitInTransactionDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkInspectionFormatExitInTransactionDao.Execute(trxContext, vo);

        }
    }
}
