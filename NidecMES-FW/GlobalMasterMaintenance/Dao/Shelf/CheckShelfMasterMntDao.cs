using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckShelfMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ShelfVo inVo = (ShelfVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select Count(*) as shelfCount from m_shelf ");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.ShelfCode != null)
            {
                sqlQuery.Append(" and UPPER(shelf_cd) = UPPER(:shelfcd) ");
            }

            //if (inVo.AreaId > 0)
            //{
            //    sqlQuery.Append(" and area_id = :areaid ");
            //}

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.ShelfCode != null)
            {
                sqlParameter.AddParameterString("shelfcd", inVo.ShelfCode);
            }

            //if (inVo.AreaId > 0)
            //{
            //    sqlParameter.AddParameterInteger("areaid", inVo.AreaId);
            //}

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ShelfVo outVo = new ShelfVo {AffectedCount = 0};

            while (dataReader.Read())
            {
              outVo.AffectedCount = Convert.ToInt32(dataReader["shelfCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
