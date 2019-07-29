using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteItemProcessWorkMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteItemProcessWorkDao = new DeleteItemProcessWorkMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteItemProcessWorkDao.Execute(trxContext, vo);

        }
    }
}
