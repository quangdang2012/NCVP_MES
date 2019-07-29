using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckItemMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ItemVo inVo = (ItemVo)arg;         

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as ItemCount from m_local_item ");
            sqlQuery.Append(" where factory_cd = :faccd ");

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
                outVo.AffectedCount = Convert.ToInt32(dataReader["ItemCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
