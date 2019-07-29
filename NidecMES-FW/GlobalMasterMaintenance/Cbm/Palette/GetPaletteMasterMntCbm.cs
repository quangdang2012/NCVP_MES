using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class GetPaletteMasterMntCbm : CbmController
    {
        private readonly DataAccessObject getPaletteDao = new GetPaletteMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            return getPaletteDao.Execute(trxContext, vo);

        }
    }
}
