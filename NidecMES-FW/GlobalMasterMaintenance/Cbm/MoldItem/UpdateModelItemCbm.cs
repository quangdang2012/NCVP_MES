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
    class UpdateMoldItemCbm : CbmController
    {
        private readonly DataAccessObject updateMoldItemDao = new UpdateMoldItemDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            MoldItemVo inVo = (MoldItemVo)vo;

            return (MoldItemVo)updateMoldItemDao.Execute(trxContext, inVo);

        }
    }
}
