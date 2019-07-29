using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchPersonOutputNCVCDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerVo inVo = (ProductionControllerVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProductionControllerVo> voList = new ValueObjectList<ProductionControllerVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select case when max(output_data) is null then 0 else max(output_data) end output from t_productioncontroller_output04 ");
            sql.Append(" where 1=1  ");

            sql.Append(@" and dates =:dates");
            sqlParameter.AddParameterDateTime("dates",DateTime.Parse(inVo.Date));

         

            if (!String.IsNullOrEmpty(inVo.ProModel))
            {
                sql.Append(" and   model_cd  =:model_cd");
                sqlParameter.AddParameterString("model_cd", inVo.ProModel);
            }
            if (!String.IsNullOrEmpty(inVo.ProLine))
            {
                sql.Append(" and line_cd  =:line_cd");
                sqlParameter.AddParameterString("line_cd", inVo.ProLine);
            }

           
            //sql.Append(" order by datetimes");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerVo outVo = new ProductionControllerVo
                {
                    //  , h., i., k., o.prodution_work_content_name

                    ProOutput = int.Parse(dataReader["output"].ToString()),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }
}
