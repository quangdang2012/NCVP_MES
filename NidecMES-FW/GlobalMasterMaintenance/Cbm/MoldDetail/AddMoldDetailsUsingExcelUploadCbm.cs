using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Cbm;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System;

namespace Com.Nidec.Mes.GlobalMasterMaintenance
{
    public class AddMoldDetailsUsingExcelUploadCbm : CbmController
    {
        //check and add category master
        private readonly CbmController checkMoldCategoryMasterMntCbm = new CheckMoldCategoryMasterMntCbm();
        private readonly CbmController addMoldCategoryMasterMntCbm = new AddMoldCategoryMasterMntCbm();

        //check and add model master
        private readonly CbmController checkModelMasterMntCbm = new CheckModelMasterMntCbm();
        private readonly CbmController addModelMasterMntCbm = new AddModelMasterMntCbm();

        //check and add mold/molddetail master
        private readonly CbmController getMoldIdForExcelUploadCbm = new GetMoldIdForExcelUploadCbm();
        private readonly CbmController addMoldAndMoldDetailMasterMntCbm = new AddMoldAndMoldDetailMasterMntCbm();

        //check and add globalitem/localitem and globallocalitem link table
        private readonly CbmController addGlobalItemLocalItemCbm = new AddGlobalItemLocalItemCbm();

        //check and add molditem (check : mold and sapitem)
        private readonly CbmController getMoldItemCbm = new GetMoldItemCbm();
        private readonly CbmController addmoldItemCbm = new AddMoldItemCbm();
        private readonly CbmController updateMoldItemCbm = new UpdateMoldItemCbm();

        //cavity input
        private readonly CbmController checkCavityMasterMntCbm = new CheckCavityMasterMntCbm();
        private readonly CbmController addCavityMasterMntCbm = new AddCavityMasterMntCbm();

        //store inserted category list
        Hashtable categoryList = new Hashtable(StringComparer.InvariantCultureIgnoreCase);

        //store inserted mold list
        Hashtable moldList = new Hashtable(StringComparer.InvariantCultureIgnoreCase);

        //store inserted model list
        Hashtable modelList = new Hashtable(StringComparer.InvariantCultureIgnoreCase);

        //store inserted globaleitem(sapitem) list
        Hashtable globalItemList = new Hashtable(StringComparer.InvariantCultureIgnoreCase);

        //store inserted globaleitem(sapitem) list
        Hashtable localItemList = new Hashtable(StringComparer.InvariantCultureIgnoreCase);

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            List<ValueObject> inList = ((ValueObjectList<ValueObject>)vo).GetList();

            ValueObjectList<MoldCategoryVo> moldCategoryInVo = (ValueObjectList<MoldCategoryVo>)inList.FirstOrDefault();

            ValueObjectList<MoldDetailVo> moldInVo = (ValueObjectList<MoldDetailVo>)inList.Skip(1).FirstOrDefault();

            ValueObjectList<MoldItemVo> moldItemInVo = (ValueObjectList<MoldItemVo>)inList.Skip(2).FirstOrDefault();

            ValueObjectList<CavityVo> cavityInVo = (ValueObjectList<CavityVo>)inList.Skip(3).FirstOrDefault();


            //////////////add mold category   
            AddCategory(trxContext, moldCategoryInVo);

            //////////////add mold
            AddMold(trxContext, moldInVo);

            ////////////////add model
            AddModel(trxContext, moldItemInVo);

            /////////////// add global item, local item
            AddGlobalAndLocalItem(trxContext, moldItemInVo);

            /////////////// add mold item with stdcycletime
            AddMoldItemStdCycleTime(trxContext, moldItemInVo);

            //////////////add cavity
            AddCavity(trxContext, cavityInVo);

            UpdateResultVo outVo = new UpdateResultVo();

            if (moldList != null && moldList.Count > 0)
            {
                outVo.AffectedCount = 1;
            }

            return outVo;

        }

        private void AddCategory(TransactionContext trxContext, ValueObjectList<MoldCategoryVo> moldCategoryInVo)
        {
            foreach (MoldCategoryVo moldCategoryVo in moldCategoryInVo.GetList())
            {
                // Checking existing data
                ValueObjectList<MoldCategoryVo> moldCategoryCheckVo = (ValueObjectList<MoldCategoryVo>)checkMoldCategoryMasterMntCbm.Execute(trxContext, moldCategoryVo);
                if (moldCategoryCheckVo != null && moldCategoryCheckVo.GetList().Count > 0)
                {
                    foreach (MoldCategoryVo curVo in moldCategoryCheckVo.GetList())
                    {
                        if (!categoryList.ContainsKey(curVo.MoldCategoryCode))
                        {
                            categoryList.Add(curVo.MoldCategoryCode, curVo.MoldCategoryId);
                        }
                    }
                }
                else
                {
                    MoldCategoryVo moldCategoryOutVo = (MoldCategoryVo)addMoldCategoryMasterMntCbm.Execute(trxContext, moldCategoryVo);
                    categoryList.Add(moldCategoryVo.MoldCategoryCode, moldCategoryOutVo.MoldCategoryId);
                }

            }
        }

        private void AddMold(TransactionContext trxContext, ValueObjectList<MoldDetailVo> moldInVo)
        {
            MoldDetailVo moldOutVo = null;

            foreach (MoldDetailVo moldDetailVo in moldInVo.GetList())
            {
                ValueObjectList<MoldDetailVo> moldGetVo = (ValueObjectList<MoldDetailVo>)getMoldIdForExcelUploadCbm.Execute(trxContext, moldDetailVo);

                if (moldGetVo != null && moldGetVo.GetList().Count > 0)
                {
                    foreach (MoldDetailVo curVo in moldGetVo.GetList())
                    {
                        if (!moldList.ContainsKey(curVo.MoldCode))
                        {
                            moldList.Add(curVo.MoldCode, curVo.MoldId);
                        }
                    }
                }
                else
                {
                    if (categoryList.ContainsKey(moldDetailVo.MoldCategoryCode))
                    {
                        moldDetailVo.MoldCategoryId = (int)categoryList[moldDetailVo.MoldCategoryCode];
                    }

                    moldOutVo = (MoldDetailVo)addMoldAndMoldDetailMasterMntCbm.Execute(trxContext, moldDetailVo);

                    moldList.Add(moldDetailVo.MoldCode, moldOutVo.MoldId);
                }
            }

        }

        private void AddModel(TransactionContext trxContext, ValueObjectList<MoldItemVo> moldModelInVo)
        {

            foreach (MoldItemVo moldModelVo in moldModelInVo.GetList())
            {

                // Checking existing data
                Vo.ModelVo modelInVo = new Vo.ModelVo();

                modelInVo.ModelCode = moldModelVo.ModelCode;
                modelInVo.ModelName = moldModelVo.ModelCode;


                ValueObjectList<ModelVo> modelCheckVo = (ValueObjectList<ModelVo>)checkModelMasterMntCbm.Execute(trxContext, modelInVo);

                if (modelCheckVo != null && modelCheckVo.GetList() != null && modelCheckVo.GetList().Count > 0)
                {
                    foreach (Vo.ModelVo curVo in modelCheckVo.GetList())
                    {
                        if (!modelList.ContainsKey(curVo.ModelCode))
                        {
                            modelList.Add(curVo.ModelCode, curVo.ModelId);
                        }
                    }
                }
                else
                {
                    Vo.ModelVo modelOutVo = (Vo.ModelVo)addModelMasterMntCbm.Execute(trxContext, modelInVo);
                    modelList.Add(modelInVo.ModelCode, modelOutVo.ModelId);
                }
            }
        }

        private void AddGlobalAndLocalItem(TransactionContext trxContext, ValueObjectList<MoldItemVo> moldItemInVo)
        {

            if (moldItemInVo != null && moldItemInVo.GetList().Count > 0)
            {
                foreach (MoldItemVo moldItemVo in moldItemInVo.GetList())
                {
                    if (globalItemList.ContainsKey(moldItemVo.GlobalItemCode))
                    {
                        continue;
                    }
                    if (localItemList.ContainsKey(moldItemVo.LocalItemCode))
                    {
                        continue;
                    }
                    if (moldList.ContainsKey(moldItemVo.MoldCode))
                    {
                        moldItemVo.MoldId = (int)moldList[moldItemVo.MoldCode];
                    }

                    MoldItemVo moldItemOutVo = (MoldItemVo)addGlobalItemLocalItemCbm.Execute(trxContext, moldItemVo);

                    if (moldItemOutVo != null)
                    {
                        globalItemList.Add(moldItemOutVo.GlobalItemCode, moldItemOutVo.GlobalItemId);

                        localItemList.Add(moldItemOutVo.LocalItemCode, moldItemOutVo.LocalItemId);
                    }
                }
            }
        }

        private void AddMoldItemStdCycleTime(TransactionContext trxContext, ValueObjectList<MoldItemVo> moldItemInVo)
        {

            if (moldItemInVo != null && moldItemInVo.GetList().Count > 0)
            {
                foreach (MoldItemVo moldItemVo in moldItemInVo.GetList())
                {
                    if (moldList.ContainsKey(moldItemVo.MoldCode))
                    {
                        moldItemVo.MoldId = (int)moldList[moldItemVo.MoldCode];
                    }
                    if (modelList.ContainsKey(moldItemVo.ModelCode))
                    {
                        moldItemVo.ModelId = (int)modelList[moldItemVo.ModelCode];
                    }
                    if (globalItemList.ContainsKey(moldItemVo.GlobalItemCode))
                    {
                        moldItemVo.GlobalItemId = (int)globalItemList[moldItemVo.GlobalItemCode];
                    }

                    ValueObjectList<MoldItemVo> checkMoldItem = (ValueObjectList<MoldItemVo>)getMoldItemCbm.Execute(trxContext, moldItemVo);
                    if (checkMoldItem == null || checkMoldItem.GetList() == null || checkMoldItem.GetList().Count == 0)
                    {
                        MoldItemVo MoldItemOutVo = (MoldItemVo)addmoldItemCbm.Execute(trxContext, moldItemVo);
                    }
                    else
                    {
                        MoldItemVo MoldItemOutVo = (MoldItemVo)updateMoldItemCbm.Execute(trxContext, moldItemVo);
                    }
                }
            }
        }

        private void AddCavity(TransactionContext trxContext, ValueObjectList<CavityVo> cavityInVo)
        {
            if (cavityInVo != null && cavityInVo.GetList().Count > 0)
            {
                foreach (CavityVo cavityVo in cavityInVo.GetList())
                {
                    if (moldList.ContainsKey(cavityVo.MoldCode))
                    {
                        cavityVo.MoldId = (int)moldList[cavityVo.MoldCode];
                    }

                    CavityVo checkCavityOutVo = (CavityVo)checkCavityMasterMntCbm.Execute(trxContext, cavityVo);
                    if (checkCavityOutVo == null || checkCavityOutVo.AffectedCount == 0)
                    {
                        addCavityMasterMntCbm.Execute(trxContext, cavityVo);
                    }
                }
            }
        }
    }
}
