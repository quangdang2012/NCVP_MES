using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckCountryLanguageMasterMntCbm : CbmController
    {


        private readonly DataAccessObject checkCountryLangDao = new CheckCountryLanguageMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkCountryLangDao.Execute(trxContext, vo);

        }
    }
}
