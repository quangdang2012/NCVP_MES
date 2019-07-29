using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    class DeleteAndAddMoldItemCbm : CbmController
    {

        private readonly CbmController deleteMoldItemCbm = new DeleteMoldItemCbm();

        private readonly CbmController addMoldItemCbm = new AddMoldItemCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ValueObjectList<MoldItemVo> inVo = (ValueObjectList<MoldItemVo>)vo;

            if(inVo == null || inVo.GetList() ==null || inVo.GetList().Count ==0)
            {
                return null;
            }
            MoldItemVo delInVo = inVo.GetList()[0];
            deleteMoldItemCbm.Execute(trxContext, inVo.GetList()[0]);

            UpdateResultVo resultVo = null;

            foreach (MoldItemVo molditem in inVo.GetList())
            {
                MoldItemVo MoldItemOutVo = (MoldItemVo)addMoldItemCbm.Execute(trxContext, molditem);

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
