using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteAreaMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteAreaDao = new DeleteAreaMasterMntDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return deleteAreaDao.Execute(trxContext, vo);

        }
    }
}
