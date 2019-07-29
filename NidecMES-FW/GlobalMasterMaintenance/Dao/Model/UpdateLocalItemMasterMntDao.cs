using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateLocalItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            MoldDetailVo inVo = (MoldDetailVo)vo;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append(" Update m_local_item ");
            sqlQuery.Append(" SET ");
            sqlQuery.Append(" item_cd = :item_code ,");
            sqlQuery.Append(" item_name = :item_name ,");
            sqlQuery.Append(" registration_user_cd = :registration_user_code ,");
            sqlQuery.Append(" registration_date_time = now() ");
            sqlQuery.Append(" Where ");
            sqlQuery.Append(" item_id = :id; ");

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("id", inVo.MoldItemId);
            sqlParameter.AddParameterString("item_code", inVo.MoldItemCode);
            sqlParameter.AddParameterString("item_name", inVo.MoldItemCode);
            sqlParameter.AddParameterString("registration_user_code", UserData.GetUserData().UserCode);

            MoldDetailVo outVo = new MoldDetailVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;

        }
    }
}
