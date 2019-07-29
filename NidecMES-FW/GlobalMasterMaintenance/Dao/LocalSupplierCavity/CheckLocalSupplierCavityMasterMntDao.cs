using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckLocalSupplierCavityMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LocalSupplierCavityVo inVo = (LocalSupplierCavityVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as supplierCavityCount from m_local_supplier_cavity ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.LocalSupplierCavityCode != null)
            {
                sqlQuery.Append(" and UPPER(cavity_cd) = UPPER(:cavitycd) ");
            }
                        
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.LocalSupplierCavityCode != null)
            {
                sqlParameter.AddParameterString("cavitycd", inVo.LocalSupplierCavityCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            LocalSupplierCavityVo outVo = new LocalSupplierCavityVo();

            while (dataReader.Read())
            {
              outVo.AffectedCount = Convert.ToInt32(dataReader["supplierCavityCount"]);
            }
            dataReader.Close();

            return outVo;
        }
    }
}
