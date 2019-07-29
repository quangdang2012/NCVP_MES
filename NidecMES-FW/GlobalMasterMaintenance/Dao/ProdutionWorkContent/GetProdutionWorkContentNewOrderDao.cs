using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetProdutionWorkContentNewOrderDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentVo inVo = (ProdutionWorkContentVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select COALESCE(max(display_order),0)+1 as neworder from m_work_content");
            sql.Append(" Where 1=1 ");

            if (inVo.ProdutionWorkContentTypeId > 0)
            {
                sql.Append(" and work_content_type_id = :prodution_work_content_type_id ");
                sqlParameter.AddParameterInteger("prodution_work_content_type_id", inVo.ProdutionWorkContentTypeId);
            }


            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            ProdutionWorkContentVo outVo = new ProdutionWorkContentVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["neworder"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
