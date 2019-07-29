using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddPaletteMasterMntCbm : CbmController
    {

        private readonly DataAccessObject addPaletteDao = new AddPaletteMasterMntDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return addPaletteDao.Execute(trxContext, vo);
        }
    }
}
