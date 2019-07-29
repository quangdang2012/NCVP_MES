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
    public class UpdateProdutionWorkContentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentVo inVo = (ProdutionWorkContentVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("Update m_work_content set work_content_cd=:prodution_work_content_cd,work_content_name=:prodution_work_content_name,remark=:remark,display_order=:display_order, work_content_type_id = :prodution_work_content_type_id");
            sql.Append(" where work_content_id=:prodution_work_content_id");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("prodution_work_content_cd", inVo.ProdutionWorkContentCode);
            sqlParameter.AddParameterString("prodution_work_content_name", inVo.ProdutionWorkContentName);
            sqlParameter.AddParameterInteger("display_order", inVo.DisplayOrder);
            sqlParameter.AddParameterInteger("prodution_work_content_type_id", inVo.ProdutionWorkContentTypeId);
            sqlParameter.AddParameterInteger("prodution_work_content_id", inVo.ProdutionWorkContentId);
            sqlParameter.AddParameterString("remark", inVo.Remark);             
            //execute SQL

            ProdutionWorkContentVo outVo = new ProdutionWorkContentVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
