using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetCountryLanguageMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getCountryLangDao = new GetCountryLanguageMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return getCountryLangDao.Execute(trxContext, vo);

        }
    }
}
