using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using System;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchGA1DGVDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            GA1ModelVo inVo = (GA1ModelVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<GA1ModelVo> voList = new ValueObjectList<GA1ModelVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select row_number() over(order by a90_datetime asc) stt, a90_model, a90_line, a90_barcode, a90_thurst_status, a90_noise_status, a90_oqc_status, 
                                a90_oqc_data, a90_shipping, a90_user_cd, a90_datetime from t_checkpusha90
                                where 1=1 ");

            if (!string.IsNullOrEmpty(inVo.A90Model))
            {
                sql.Append(@" and a90_model  =:a90_model");
                sqlParameter.AddParameterString("a90_model", inVo.A90Model);
            }
            if(inVo.DaTa == false)
            {
                sql.Append(@" and a90_datetime >= :dtpfrom and a90_datetime <= :dtpto");
            }
           else if(inVo.DaTa == true)
            {
                sql.Append(@" and a90_datetime >= :dtpfrom ");
            }
            sqlParameter.AddParameterDateTime("dtpfrom", inVo.DateTimeFrom);
            sqlParameter.AddParameterDateTime("dtpto", inVo.DateTimeTo);
            sql.Append(@" order by a90_datetime desc");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                GA1ModelVo outVo = new GA1ModelVo
                {
                    STT = dataReader["stt"].ToString(),
                    A90Model = dataReader["a90_model"].ToString(),
                    A90Line = dataReader["a90_line"].ToString(),
                    A90Barcode = dataReader["a90_barcode"].ToString(),
                    A90ThurstStatus = dataReader["a90_thurst_status"].ToString(),
                    A90NoiseStatus = dataReader["a90_noise_status"].ToString(),
                    A90OQCStatus = dataReader["a90_oqc_status"].ToString(),
                    A90OQCData = dataReader["a90_oqc_data"].ToString(),
                    A90Shipping = bool.Parse(dataReader["a90_shipping"].ToString()),
                    RegistrationUserCode = dataReader["a90_user_cd"].ToString(),
                    RegistrationDateTime = DateTime.Parse(dataReader["a90_datetime"].ToString()),


                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}