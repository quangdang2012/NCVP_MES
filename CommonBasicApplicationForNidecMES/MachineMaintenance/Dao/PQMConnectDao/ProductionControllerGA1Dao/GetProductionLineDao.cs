using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetProductionLineDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProductionControllerGA1Vo inVo = (ProductionControllerGA1Vo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProductionControllerGA1Vo> voList = new ValueObjectList<ProductionControllerGA1Vo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append("select distinct line from processtbl a left join modeltbl b on a.model = b.model where 1=1 ");

            if (!string.IsNullOrEmpty(inVo.ModelCode))
            {
                sql.Append(@" and a.model  =:model_cd");
                sqlParameter.AddParameterString("model_cd", inVo.ModelCode);
            }
            sql.Append(@" order by line");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProductionControllerGA1Vo outVo = new ProductionControllerGA1Vo
                {
                    LineCode = dataReader["line"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}