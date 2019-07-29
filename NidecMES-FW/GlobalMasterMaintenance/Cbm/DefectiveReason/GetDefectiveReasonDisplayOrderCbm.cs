using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetDefectiveReasonDisplayOrderCbm : CbmController
    {
        private readonly DataAccessObject getDefectiveReasonDisplayOrderDao = new GetDefectiveReasonDisplayOrderDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getDefectiveReasonDisplayOrderDao.Execute(trxContext, vo);

        }
    }
    
}
