using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteProcessWorkMoldMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteProcessWorkMoldMoldDao = new DeleteProcessWorkMoldMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return deleteProcessWorkMoldMoldDao.Execute(trxContext, vo);

        }
    }
}
