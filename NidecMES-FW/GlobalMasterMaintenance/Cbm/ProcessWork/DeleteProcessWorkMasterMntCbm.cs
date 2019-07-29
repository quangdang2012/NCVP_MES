using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteProcessWorkMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteProcessWorkDao = new DeleteProcessWorkMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteProcessWorkDao.Execute(trxContext, vo);

        }
    }
}
