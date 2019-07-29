using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class SearchOvenDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            OvenBarcodeVo inVo = (OvenBarcodeVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<OvenBarcodeVo> voList = new ValueObjectList<OvenBarcodeVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            
            sql.Append(@"select dates+times as datetime,* from t_ovenmachine where 1=1 ");

            if(!String.IsNullOrEmpty(inVo.Model))
            {
                sql.Append(@" and model = :model ");
                sqlParameter.AddParameterString("model", inVo.Model);
            }
            if (!String.IsNullOrEmpty(inVo.Line))
            {
                sql.Append(@" and line_cd = :line_cd ");
                sqlParameter.AddParameterString("line_cd", inVo.Line);
            }
            if (!String.IsNullOrEmpty(inVo.Barcode))
            {
                sql.Append(@" and barcode = :barcode ");
                sqlParameter.AddParameterString("barcode", inVo.Barcode);
            }
            //if (!String.IsNullOrEmpty(inVo.Lower))
            //{
            //    sql.Append(@" and temperature >= :lower ");
            //    sqlParameter.AddParameterInteger("lower", int.Parse(inVo.Lower));
            //}
            //if (!String.IsNullOrEmpty(inVo.Upper))
            //{
            //    sql.Append(@" and temperature <= :upper ");
            //    sqlParameter.AddParameterInteger("upper",int.Parse(inVo.Upper));
            //}

            sql.Append(@" and dates+times between :timefrom and :timeto order by dates,barcode,times ");
            sqlParameter.AddParameter("timefrom", inVo.DateTimeForm);
            sqlParameter.AddParameter("timeto", inVo.DateTimeTo);



            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                OvenBarcodeVo outVo = new OvenBarcodeVo
                {
                    Date = DateTime.Parse(dataReader["datetime"].ToString()),
                    Times = dataReader["times"].ToString(),
                    FactoryCode = dataReader["factory_cd"].ToString(),
                    Model = dataReader["model"].ToString(),
                    Line = dataReader["line_cd"].ToString(),
                    Barcode = dataReader["barcode"].ToString(),                    
                    Temperature = dataReader["temperature"].ToString(),
                    Drying = int.Parse(dataReader["drying"].ToString()),
                    Status = dataReader["status"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
