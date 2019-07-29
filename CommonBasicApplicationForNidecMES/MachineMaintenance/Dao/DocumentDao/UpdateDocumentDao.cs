using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdateDocumentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DocumentVo inVo = (DocumentVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"update t_document set doc_name=:doc_name,
                                           doc_no=:doc_no,
                                           doc_type=:doc_type,
                                           model=:model,
                                           version=:version,
                                           update_date=:update_date,
                                           department=:department");
            sql.Append(" where doc_id =:doc_id");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("doc_id", inVo.DocumentID);
            sqlParameter.AddParameter("doc_name", inVo.DocumentName);
            sqlParameter.AddParameter("doc_no", inVo.DocumentNo);
            sqlParameter.AddParameter("doc_type", inVo.DocumentType);
            sqlParameter.AddParameter("model", inVo.ModelCode);
            sqlParameter.AddParameter("version", inVo.Version);
            sqlParameter.AddParameter("update_date", inVo.Update_Date);
            sqlParameter.AddParameter("department", inVo.Department);

            //execute SQL

            DocumentVo outVo = new DocumentVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}