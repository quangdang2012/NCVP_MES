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
    public class DeleteProdutionWorkContentTypeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentTypeVo inVo = (ProdutionWorkContentTypeVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from m_work_content_type Where 1=1 ");
           
            if (inVo.ProdutionWorkContentTypeId > 0)
            {
                sql.Append(" and work_content_type_id = :prodution_work_content_type_id ");
                sqlParameter.AddParameterInteger("prodution_work_content_type_id", inVo.ProdutionWorkContentTypeId);
            }
            if (!string.IsNullOrEmpty(inVo.ProdutionWorkContentTypeCode))
            {
                sql.Append(" and work_content_type_cd = :prodution_work_content_type_cd ");
                sqlParameter.AddParameterString("prodution_work_content_type_cd", inVo.ProdutionWorkContentTypeCode);
            }
            if (!string.IsNullOrEmpty(inVo.ProdutionWorkContentTypeName))
            {
                sql.Append(" and work_content_type_name = :prodution_work_content_type_name ");
                sqlParameter.AddParameterString("prodution_work_content_type_name", inVo.ProdutionWorkContentTypeName);
            }

            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            ProdutionWorkContentTypeVo outVo = new ProdutionWorkContentTypeVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
