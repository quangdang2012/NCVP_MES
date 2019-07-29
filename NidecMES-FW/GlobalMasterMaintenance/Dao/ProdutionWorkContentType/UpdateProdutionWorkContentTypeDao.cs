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
    public class UpdateProdutionWorkContentTypeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentTypeVo inVo = (ProdutionWorkContentTypeVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(" Update m_work_content_type set ");
            sql.Append(" work_content_type_cd =:prodution_work_content_type_cd, ");
            sql.Append(" work_content_type_name =:prodution_work_content_type_name");
            sql.Append(" where work_content_type_id=:prodution_work_content_type_id");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("prodution_work_content_type_cd", inVo.ProdutionWorkContentTypeCode);
            sqlParameter.AddParameterString("prodution_work_content_type_name", inVo.ProdutionWorkContentTypeName);
            sqlParameter.AddParameterInteger("prodution_work_content_type_id", inVo.ProdutionWorkContentTypeId);           
          
            //execute SQL

            ProdutionWorkContentTypeVo outVo = new ProdutionWorkContentTypeVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
