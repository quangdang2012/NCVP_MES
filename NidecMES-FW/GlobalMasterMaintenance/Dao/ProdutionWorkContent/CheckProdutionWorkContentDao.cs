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
    public class CheckProdutionWorkContentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentVo inVo = (ProdutionWorkContentVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("Select Count(*) as CountNum ");
            sql.Append(" from m_work_content");
            sql.Append(" Where (UPPER(work_content_cd) = UPPER(:prodution_work_content_cd)) ");


            sqlParameter.AddParameterString("prodution_work_content_cd", inVo.ProdutionWorkContentCode);
            sqlParameter.AddParameterInteger("display_order", inVo.DisplayOrder);

            //if (inVo.ProdutionWorkContentTypeId > 0)
            //{
            //    sql.Append(" and work_content_type_id = :prodution_work_content_type_id ");
            //    sqlParameter.AddParameterInteger("prodution_work_content_type_id", inVo.ProdutionWorkContentTypeId);
            //}
            if (inVo.ProdutionWorkContentId > 0)
            {
                sql.Append(" and work_content_id != :prodution_work_content_id ");
                sqlParameter.AddParameterInteger("prodution_work_content_id", inVo.ProdutionWorkContentId);
            }
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            ProdutionWorkContentVo outVo = new ProdutionWorkContentVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["CountNum"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
