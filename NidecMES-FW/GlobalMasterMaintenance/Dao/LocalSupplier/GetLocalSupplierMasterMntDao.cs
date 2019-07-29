using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetLocalSupplierMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            LocalSupplierVo inVo = (LocalSupplierVo)arg;

            LocalSupplierVo outVo = new LocalSupplierVo();

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select * from m_local_supplier ");
            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.LocalSupplierCode != null)
            {
                sqlQuery.Append(" and local_supplier_cd like :localsuppliercd ");
            }

            if (inVo.LocalSupplierName != null)
            {
                sqlQuery.Append(" and local_supplier_name like :localsuppliername ");
            }

            sqlQuery.Append(" order by local_supplier_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.LocalSupplierCode != null)
            {
                sqlParameter.AddParameterString("localsuppliercd", inVo.LocalSupplierCode + "%");
            }

            if (inVo.LocalSupplierName != null)
            {
                sqlParameter.AddParameterString("localsuppliername", inVo.LocalSupplierName + "%");
            }


            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                LocalSupplierVo currOutVo = new LocalSupplierVo
                {
                    LocalSupplierId = Convert.ToInt32(dataReader["local_supplier_id"]),
                    LocalSupplierCode = dataReader["local_supplier_cd"].ToString(),
                    LocalSupplierName = dataReader["local_supplier_name"].ToString(),
                };

                outVo.LocalSupplierListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
