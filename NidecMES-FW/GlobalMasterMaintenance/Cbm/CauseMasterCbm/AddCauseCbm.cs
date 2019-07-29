using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class AddCauseCbm : CbmController
    {
        private static readonly DataAccessObject getDao = new AddCauseDao();
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            if (vo == null)
            {
                //throw ApplicationException
                return null;
            }

            ValueObjectList<CauseVo> ll = (ValueObjectList<CauseVo>)vo;
            foreach (CauseVo v in ll.GetList())
            {
                getDao.Execute(trxContext, v);
            }
            return null;
        }
    }
}
