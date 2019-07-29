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
    public class CheckProdutionWorkContentTypeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentTypeVo inVo = (ProdutionWorkContentTypeVo)vo;
            StringBuilder sql = new StringBuilder();

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append("Select Count(*) as CountNum ");
            sql.Append(" from m_work_content_type");
            sql.Append(" Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (!string.IsNullOrEmpty(inVo.ProdutionWorkContentTypeCode))
            {
                sql.Append(" and UPPER(work_content_type_cd) = UPPER(:prodution_work_content_type_cd) ");
                sqlParameter.AddParameterString("prodution_work_content_type_cd", inVo.ProdutionWorkContentTypeCode);
            }
            if (inVo.ProdutionWorkContentTypeId > 0)
            {
                sql.Append(" and work_content_type_id != :prodution_work_content_type_id ");
                sqlParameter.AddParameterInteger("prodution_work_content_type_id", inVo.ProdutionWorkContentTypeId);
            }

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);
            ProdutionWorkContentTypeVo outVo = new ProdutionWorkContentTypeVo();
            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["CountNum"].ToString());
            }
            dataReader.Close();
            return outVo;
        }
    }
}
