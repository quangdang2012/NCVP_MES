﻿using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Dao;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Cbm
{
    public class CheckBuildingRelationCbm : CbmController
    {

        private readonly DataAccessObject CheckBuildingRelationDao = new CheckBuildingRelationDao();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            return CheckBuildingRelationDao.Execute(trxContext, vo);

        }
    }
}
