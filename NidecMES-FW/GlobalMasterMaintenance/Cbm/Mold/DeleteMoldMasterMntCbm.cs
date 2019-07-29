using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteMoldMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteMoldDao = new DeleteMoldMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return deleteMoldDao.Execute(trxContext, vo);

        }
    }
}
