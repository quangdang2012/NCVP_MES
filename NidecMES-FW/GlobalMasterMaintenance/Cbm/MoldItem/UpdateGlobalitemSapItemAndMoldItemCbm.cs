using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    class UpdateGlobalitemSapItemAndMoldItemCbm : CbmController
    {
        private readonly CbmController addglobalItemSapItemCbm = new AddGlobalitemSapItemCbm();

        private readonly CbmController deleteAndAddMoldItemCbm = new DeleteAndAddMoldItemCbm();

        private readonly CbmController deleteGlobalitemSapItemCbm = new DeleteGlobalitemSapItemCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            MoldItemVo inVo = (MoldItemVo)vo;

            int globalItemSapItemId;

            if (!(inVo.GlobalLocalItemId > 0))
            {
                MoldItemVo globalitemsapitemOutVo = (MoldItemVo)addglobalItemSapItemCbm.Execute(trxContext, inVo);

                globalItemSapItemId = globalitemsapitemOutVo.GlobalLocalItemId;
            }
            else
            {
                globalItemSapItemId = inVo.GlobalLocalItemId;
            }


            if (globalItemSapItemId > 0)
            {
                foreach (MoldItemVo curVo in inVo.MoldItemListVo)
                {
                    curVo.GlobalLocalItemId = globalItemSapItemId;
                }

                if (!(inVo.MoldItemListVo.Count > 0))
                {
                    deleteGlobalitemSapItemCbm.Execute(trxContext, inVo);
                }

                inVo.GlobalLocalItemId = globalItemSapItemId;
                return deleteAndAddMoldItemCbm.Execute(trxContext, inVo);
            }
            return null;

        }
    }
}
