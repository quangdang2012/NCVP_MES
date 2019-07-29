using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckFactoryRelationCbm : CbmController
    {

        private readonly DataAccessObject checkFactoryRelationDao = new CheckFactoryRelationDao();


        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkFactoryRelationDao.Execute(trxContext, vo);

        }
    }
}
