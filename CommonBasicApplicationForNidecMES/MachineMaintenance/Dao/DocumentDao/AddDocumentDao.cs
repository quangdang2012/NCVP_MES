using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class AddDocumentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DocumentVo inVo = (DocumentVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"insert into t_document(doc_name, doc_no, doc_type, model, version, update_date, department) values(:doc_name, :doc_no, :doc_type, :model, :version, :update_date, :department)");

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