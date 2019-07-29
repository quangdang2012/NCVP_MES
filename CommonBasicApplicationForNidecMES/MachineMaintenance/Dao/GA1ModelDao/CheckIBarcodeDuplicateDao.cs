using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckIBarcodeDuplicateDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as rowcount ");
            sql.Append(" from t_serno");
            sql.Append(" Where 1=1 ");
            sql.Append(" and barcode = :barcode ");

            sqlParameter.AddParameterString("barcode", inVo.A90Barcode);


            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            GA1ModelVo outVo = new GA1ModelVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["rowcount"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
