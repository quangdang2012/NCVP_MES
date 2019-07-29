using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetWarehouseMainIdDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
           WareHouseMainVo inVo = ( WareHouseMainVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList < WareHouseMainVo> voList = new ValueObjectList<WareHouseMainVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select g.warehouse_main_id from t_warehouse_main g
                      left join m_asset e on e.asset_id = g.asset_id
                      where 1=1 ");


            if (!String.IsNullOrEmpty(inVo.AssetCode))
            {
                sql.Append(@" and e.asset_cd  =:asset_cd");
                sqlParameter.AddParameterString("asset_cd", inVo.AssetCode);
            }
          
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                WareHouseMainVo outVo = new WareHouseMainVo
                {
                    WareHouseMainId = int.Parse(dataReader["warehouse_main_id"].ToString()),
                };
                voList.add(outVo);
            }
          
            dataReader.Close();
            return voList;
        }

    }
}
