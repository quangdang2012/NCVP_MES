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
    public class GetProdutionWorkContentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentVo inVo = (ProdutionWorkContentVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProdutionWorkContentVo> voList = new ValueObjectList<ProdutionWorkContentVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select work_content_id,work_content_cd,work_content_name,remark,display_order,work_content_type_id,registration_user_cd,registration_date_time,factory_cd from m_work_content");
            sql.Append(" Where 1=1 ");
            
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
            //if (inVo.DisplayOrder > 0)
            //{
            //    sql.Append(" and display_order = :display_order ");
            //    sqlParameter.AddParameterInteger("display_order", inVo.DisplayOrder);
            //}
            if (inVo.ProdutionWorkContentTypeId > 0)
            {
                sql.Append(" and work_content_type_id = :prodution_work_content_type_id ");
                sqlParameter.AddParameterInteger("prodution_work_content_type_id", inVo.ProdutionWorkContentTypeId);
            }
            sql.Append(" order by work_content_type_id,display_order ");


            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProdutionWorkContentVo outVo = new ProdutionWorkContentVo
                {
                    ProdutionWorkContentCode = dataReader["work_content_cd"].ToString(),
                    ProdutionWorkContentId = int.Parse(dataReader["work_content_id"].ToString()),
                    ProdutionWorkContentName =dataReader["work_content_name"].ToString(),
                    DisplayOrder = int.Parse(dataReader["display_order"].ToString()),
                    Remark= dataReader["remark"].ToString(),
                    
                    ProdutionWorkContentTypeId =int.Parse(dataReader["work_content_type_id"].ToString()),
                    RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    FactoryCode = dataReader["factory_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
