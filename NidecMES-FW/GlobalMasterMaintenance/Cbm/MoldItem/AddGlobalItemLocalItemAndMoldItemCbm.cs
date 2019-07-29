using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    class AddGlobalItemLocalItemCbm : CbmController
    {

        private readonly CbmController getGlobalItemMasterMntCbm = new GetGlobalItemMasterMntCbm();
        private readonly CbmController addGlobalItemMasterMntCbm = new AddGlobalItemMasterMntCbm();

        private readonly CbmController getItemMasterMntCbm = new GetItemMasterMntCbm();
        private readonly CbmController addItemMasterMntCbm = new AddItemMasterMntCbm();

        private readonly CbmController checkGlobalLocalItemMasterMntCbm = new CheckGlobalLocalItemMasterMntCbm();
        private readonly CbmController addGlobalLocalItemMasterMntCbm = new AddGlobalLocalItemMasterMntCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            MoldItemVo inVo = (MoldItemVo)vo;

            ///global item add
            GlobalItemVo checkGlobalItemInVo = new GlobalItemVo();
            checkGlobalItemInVo.GlobalItemCode = inVo.GlobalItemCode;
            GlobalItemVo checkGlobalItemOutVo = (GlobalItemVo)getGlobalItemMasterMntCbm.Execute(trxContext, checkGlobalItemInVo);

            GlobalItemVo globalItemOutVo = null;
            if (checkGlobalItemOutVo == null || checkGlobalItemOutVo.GlobalItemListVo == null || checkGlobalItemOutVo.GlobalItemListVo.Count == 0)
            {
                GlobalItemVo globalItemInVo = new GlobalItemVo();
                globalItemInVo.GlobalItemCode = inVo.GlobalItemCode;
                globalItemInVo.GlobalItemName = inVo.GlobalItemCode;

                globalItemOutVo = (GlobalItemVo)addGlobalItemMasterMntCbm.Execute(trxContext, globalItemInVo);
            }
            else
            {
                globalItemOutVo = checkGlobalItemOutVo.GlobalItemListVo[0];
            }

            ///local item add
            ItemVo checkLocalItemInVo = new ItemVo();
            checkLocalItemInVo.ItemCode = inVo.LocalItemCode;
            ItemVo checkLocalItemOutVo = (ItemVo)getItemMasterMntCbm.Execute(trxContext, checkLocalItemInVo);

            ItemVo localItemOutVo = null;
            if (checkLocalItemOutVo == null || checkLocalItemOutVo.ItemListVo == null || checkLocalItemOutVo.ItemListVo.Count == 0)
            {
                ItemVo localItemInVo = new ItemVo();
                localItemInVo.ItemCode = inVo.LocalItemCode;
                localItemInVo.ItemName = inVo.LocalItemCode;
                localItemOutVo = (ItemVo)addItemMasterMntCbm.Execute(trxContext, localItemInVo);
            }
            else
            {
                localItemOutVo = checkLocalItemOutVo.ItemListVo[0];
            }

            GlobalLocalItemVo globalLocalItemInVo = new GlobalLocalItemVo();
            globalLocalItemInVo.GlobalItemId = globalItemOutVo.GlobalItemId;
            globalLocalItemInVo.LocalItemId = localItemOutVo.ItemId;

            //check and add globallocalitem link table
            ValueObjectList<GlobalLocalItemVo> checkGlobalLocalItemVo = (ValueObjectList<GlobalLocalItemVo>)checkGlobalLocalItemMasterMntCbm.Execute(trxContext, globalLocalItemInVo);
            if (checkGlobalLocalItemVo == null || checkGlobalLocalItemVo.GetList() == null || checkGlobalLocalItemVo.GetList().Count == 0)
            {
                GlobalLocalItemVo moldItemOutVo = (GlobalLocalItemVo)addGlobalLocalItemMasterMntCbm.Execute(trxContext, globalLocalItemInVo);
            }
            inVo.GlobalItemId = globalItemOutVo.GlobalItemId;
            inVo.LocalItemId = localItemOutVo.ItemId;

            return inVo;

        }
    }
}
