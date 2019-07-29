using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class DeleteMoldItemDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            MoldItemVo inVo = (MoldItemVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Delete From m_mold_item");
            sqlQuery.Append(" Where mold_id = :moldid ");

            if (inVo.GlobalItemId > 0)
            {
                sqlQuery.Append(" and global_item_id = :globalitemid ");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterInteger("moldid", inVo.MoldId);

            if (inVo.GlobalItemId > 0)
            {
                sqlParameter.AddParameterInteger("globalitemid", inVo.GlobalItemId);
            }

            MoldItemVo outVo = new MoldItemVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo;
        }
    }
}
