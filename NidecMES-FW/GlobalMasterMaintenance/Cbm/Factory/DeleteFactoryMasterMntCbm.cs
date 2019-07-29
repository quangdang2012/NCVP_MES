using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class DeleteFactoryMasterMntCbm : CbmController
    {

        private readonly DataAccessObject deleteFactoryDao = new DeleteFactoryMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

           return deleteFactoryDao.Execute(trxContext, vo);

        }
    }
}
