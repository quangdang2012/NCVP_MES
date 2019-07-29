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
    public class DeleteProdutionWorkContentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentVo inVo = (ProdutionWorkContentVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from m_work_content Where 1=1 ");
            
            if (inVo.ProdutionWorkContentId > 0)
            {
                sql.Append(" and work_content_id = :prodution_work_content_id ");
                sqlParameter.AddParameterInteger("prodution_work_content_id", inVo.ProdutionWorkContentId);
            }
            if (!string.IsNullOrEmpty(inVo.ProdutionWorkContentCode))
            {
                sql.Append(" and work_content_cd = :prodution_work_content_cd ");
                sqlParameter.AddParameterString("prodution_work_content_cd", inVo.ProdutionWorkContentCode);
            }
            if (!string.IsNullOrEmpty(inVo.ProdutionWorkContentName))
            {
                sql.Append(" and work_content_name = :prodution_work_content_name ");
                sqlParameter.AddParameterString("prodution_work_content_name", inVo.ProdutionWorkContentName);
            }
            if (inVo.DisplayOrder > 0)
            {
                sql.Append(" and display_order = :display_order ");
                sqlParameter.AddParameterInteger("display_order", inVo.DisplayOrder);
            }
            if (inVo.ProdutionWorkContentTypeId > 0)
            {
                sql.Append(" and work_content_type_id = :prodution_work_content_type_id ");
                sqlParameter.AddParameterInteger("prodution_work_content_type_id", inVo.ProdutionWorkContentTypeId);
            }
            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            ProdutionWorkContentVo outVo = new ProdutionWorkContentVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
