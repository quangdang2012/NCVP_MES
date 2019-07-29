using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;


namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.DocumentCbm
{
    public class UpdateDocumentCbm : CbmController
    {
        private static readonly DataAccessObject getDao = new UpdateDocumentDao();
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