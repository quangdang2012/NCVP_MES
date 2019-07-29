using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetShelfMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            ShelfVo inVo = (ShelfVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select ct.shelf_id, ct.shelf_cd, ct.shelf_name, md.area_id, md.area_name ");
            sqlQuery.Append(" from m_shelf ct ");
            sqlQuery.Append(" inner join m_area md on md.area_id = ct.area_id ");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.ShelfCode != null)
            {
                sqlQuery.Append(" and ct.shelf_cd like :shelfcd ");
            }

            if (inVo.ShelfName != null)
            {
                sqlQuery.Append(" and ct.shelf_name like :shelfname ");
            }

            if (inVo.AreaId != 0)
            {
                sqlQuery.Append(" and md.area_id = :areaid ");
            }

            sqlQuery.Append(" order by ct.shelf_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.ShelfCode != null)
            {
                sqlParameter.AddParameterString("shelfcd", inVo.ShelfCode + "%");
            }

            if (inVo.ShelfName != null)
            {
                sqlParameter.AddParameterString("shelfname", inVo.ShelfName + "%");
            }
            if (inVo.AreaId != 0)
            {
                sqlParameter.AddParameterInteger("areaid", inVo.AreaId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            ShelfVo outVo = new ShelfVo();

            while (dataReader.Read())

            {
                ShelfVo currOutVo = new ShelfVo
                {
                    ShelfId = Convert.ToInt32(dataReader["shelf_id"]),
                    ShelfCode = dataReader["shelf_cd"].ToString(),
                    ShelfName = dataReader["shelf_name"].ToString(),
                    AreaId = Convert.ToInt32(dataReader["area_id"]),
                    AreaName = dataReader["area_name"].ToString()
                };
                outVo.ShelfListVo.Add(currOutVo);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
