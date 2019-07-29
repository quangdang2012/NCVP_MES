using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckInvertoryRowDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InvertoryVo inVo = (InvertoryVo)vo;
            StringBuilder sql = new StringBuilder();
            InvertoryVo voNOList = new InvertoryVo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select count(*) as RowCount from t_invertory_equipments where ");
            sql.Append(" warehouse_main_id  =:warehouse_main_id");
            sqlParameter.AddParameterInteger("warehouse_main_id", inVo.WarehouseMainId);
            sql.Append(" and  invertory_time_id  =:invertory_time_id");
            sqlParameter.AddParameterInteger("invertory_time_id", inVo.InvertoryTimeId);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                InvertoryVo outVo = new InvertoryVo
                {

                    AffectedCount = Convert.ToInt32(dataReader["RowCount"].ToString()),

                };
                voNOList.AffectedCount = outVo.AffectedCount;
            }
            dataReader.Close();
            return voNOList;
        }
    }
}
