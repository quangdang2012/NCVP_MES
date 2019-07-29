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
    class UpdateModelItemForMultipleItemCbm : CbmController
    {
        private readonly DataAccessObject updateMoldItemDao = new UpdateMoldItemDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            ValueObjectList<MoldItemVo> inVo = (ValueObjectList<MoldItemVo>)vo;

            UpdateResultVo resultVo = null;
            foreach (MoldItemVo molditem in inVo.GetList())
            {
                MoldItemVo MoldItemOutVo = (MoldItemVo)updateMoldItemDao.Execute(trxContext, molditem);

                if (resultVo == null)
                {
                    resultVo = new UpdateResultVo();
                }
                resultVo.AffectedCount += MoldItemOutVo.AffectedCount;
            }

            return resultVo;
        }
    }
}
