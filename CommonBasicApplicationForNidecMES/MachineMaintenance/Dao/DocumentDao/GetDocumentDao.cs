using System.Text;
using Com.Nidec.Mes.Framework;
using System.Data;
using System;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetDocumentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DocumentVo inVo = (DocumentVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<DocumentVo> voList = new ValueObjectList<DocumentVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select doc_id, doc_name, doc_no, version, update_date, doc_type, model, department from t_document where 1 = 1");

            if (!String.IsNullOrEmpty(inVo.ModelCode)) sql.Append(" and model = '" + inVo.ModelCode + "'");
            if (!String.IsNullOrEmpty(inVo.DocumentName)) sql.Append(" and doc_name like '%" + inVo.DocumentName + "%'");
            if (!String.IsNullOrEmpty(inVo.DocumentNo)) sql.Append(" and doc_no like '%" + inVo.DocumentNo + "%'");
            if (!String.IsNullOrEmpty(inVo.DocumentType)) sql.Append(" and doc_type = '" + inVo.DocumentType + "'");
            if (!String.IsNullOrEmpty(inVo.Department)) sql.Append(" and department = '" + inVo.Department + "'");

            sql.Append(" order by doc_id");

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DocumentVo outVo = new DocumentVo
                {
                    DocumentID = int.Parse(dataReader["doc_id"].ToString()),
                    DocumentName = dataReader["doc_name"].ToString(),
                    DocumentNo = dataReader["doc_no"].ToString(),
                    Version = dataReader["version"].ToString(),
                    Update_Date = DateTime.Parse(dataReader["update_date"].ToString()),
                    DocumentType = dataReader["doc_type"].ToString(),
                    ModelCode = dataReader["model"].ToString(),
                    Department = dataReader["department"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;

            //DataSet ds = new DataSet();
            //ds = sqlCommandAdapter.ExecuteDataSet(sqlParameter);

            //DocumentVo outVo = new DocumentVo
            //{
            //    dt = ds.Tables[0]
            //};

            //return outVo;
        }
    }
}