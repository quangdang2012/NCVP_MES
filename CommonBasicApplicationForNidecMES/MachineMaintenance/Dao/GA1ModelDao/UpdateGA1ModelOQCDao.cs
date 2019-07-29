using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class UpdateGA1ModelOQCDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update  t_checkpusha90 set  a90_oqc_status=:a90_oqc_status, a90_oqc_data =:a90_oqc_data ");
            //sql.Append("where 1 = 1 and ");
            sql.Append(" where a90_barcode=:a90_barcode");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();


            sqlParameter.AddParameter("a90_oqc_data", inVo.A90OQCData);
            sqlParameter.AddParameter("a90_barcode", inVo.A90Barcode);
            sqlParameter.AddParameter("a90_oqc_status", inVo.A90OQCStatus);
          
            //execute SQL

            GA1ModelVo outVo = new GA1ModelVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
