using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckCountryLanguagCheckRelationCbm : CbmController
    {


        private readonly DataAccessObject checkCountryLangRelationDao = new CheckCountryLanguageCheckRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return checkCountryLangRelationDao.Execute(trxContext, vo);

        }
    }
}
