using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.OvenBarcodeLS12Cbm.RangeLS12Cbm
{
    public class GetModelRangeLS12Cbm : CbmController
    {
        private static readonly DataAccessObject getDao = new GetModelRangeLS12Dao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            if (vo == null)
            {
                return null;
            }
            return getDao.Execute(trxContext, vo);
        }
    }
}