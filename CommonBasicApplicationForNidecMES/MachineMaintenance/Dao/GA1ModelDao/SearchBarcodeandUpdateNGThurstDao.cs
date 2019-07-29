using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchBarcodeandUpdateNGThurstDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            GA1ModelVo outVo = new GA1ModelVo();
            StringBuilder sql = new StringBuilder();
            StringBuilder sqlUpdate = new StringBuilder();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select count(*) from t_checkpusha90 where 1=1 ");
            
            if (!string.IsNullOrEmpty(inVo.A90Barcode))
            {
                sql.Append(@" and a90_barcode  =:a90_barcode");
                sqlParameter.AddParameterString("a90_barcode", inVo.A90Barcode);
            }
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            int rowCount = int.Parse(sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString());
            if (rowCount > 0)//neu co barcode 
            {
                sqlUpdate.Append("update t_checkpusha90 set a90_oqc_data = 'NG' where a90_barcode = '" + inVo.A90Barcode + "'");
                
                DbCommandAdaptor sqlCommandAdapterUpdate = base.GetDbCommandAdaptor(trxContext, sqlUpdate.ToString());
                DbParameterList sqlParameterUpdate = sqlCommandAdapterUpdate.CreateParameterList();
                sqlParameterUpdate.AddParameterString("a90_barcode2", inVo.A90Barcode);
                outVo = new GA1ModelVo
                {
                    AffectedCount = sqlCommandAdapterUpdate.ExecuteNonQuery(sqlParameterUpdate)
                };
            }
            return outVo;
        }
    }
}