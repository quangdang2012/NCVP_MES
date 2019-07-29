using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckItemRelationDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemVo inVo = (ItemVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("select itm.item_cd, ipw.item_process_work_id as ItmProcessId, ");
            sqlQuery.Append(" mtype.mold_type_id as MldTypeId from m_local_item itm ");
            sqlQuery.Append(" left outer join m_item_process_work ipw on itm.item_id = ipw.item_id ");
            sqlQuery.Append(" left outer join m_mold_type mtype on itm.item_id = mtype.item_id ");
            sqlQuery.Append(" where itm.factory_cd = :faccd ");

            if (inVo.ItemCode != null)
            {
                sqlQuery.Append(" and UPPER(item_cd) = UPPER(:itemcd)");
            }
           
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.ItemCode != null)
            {
                sqlParameter.AddParameterString("itemcd", inVo.ItemCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ItemVo outVo = new ItemVo();

            while (dataReader.Read())
            {
                outVo.ItemProcessWorkId = Convert.ToInt32("0" + dataReader["ItmProcessId"]);
                outVo.MoldTypeId = Convert.ToInt32("0" + dataReader["MldTypeId"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
