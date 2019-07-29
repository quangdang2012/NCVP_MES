using System;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao;


namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Cbm.DrawCbm
{
    public class SearchDrawingCbm : CbmController
    {
        private static readonly DataAccessObject getDao = new SearchDrawingDao();
        private readonly CommonLogger logger = CommonLogger.GetInstance(typeof(SearchDrawingCbm));
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            if (vo == null)
            {
                MessageData msdata = new MessageData("vnce00001", Properties.Resources.vnce00001,typeof(SearchDrawingCbm).FullName);
                logger.Error(msdata, new NullReferenceException());
                Framework.ApplicationException Appex = new Framework.ApplicationException(msdata, new NullReferenceException());
                throw Appex;
            }
            return getDao.Execute(trxContext, vo);
        }
    }
}