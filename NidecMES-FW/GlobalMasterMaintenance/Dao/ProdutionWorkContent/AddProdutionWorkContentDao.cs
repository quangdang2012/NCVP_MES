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
    public class AddProdutionWorkContentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentVo inVo = (ProdutionWorkContentVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into m_work_content(work_content_cd,work_content_name,display_order,remark,work_content_type_id,registration_user_cd,registration_date_time,factory_cd) ");
            sql.Append("values(:prodution_work_content_cd,:prodution_work_content_name,:display_order,:remark,:prodution_work_content_type_id,:registration_user_cd,:registrationDatetime,:factory_cd)");
            
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("prodution_work_content_cd", inVo.ProdutionWorkContentCode);
            sqlParameter.AddParameterString("prodution_work_content_name", inVo.ProdutionWorkContentName);
            sqlParameter.AddParameterInteger("display_order", inVo.DisplayOrder);
            sqlParameter.AddParameterInteger("prodution_work_content_type_id", inVo.ProdutionWorkContentTypeId);
            sqlParameter.AddParameterString("remark", inVo.Remark); 

            sqlParameter.AddParameterString("factory_cd", UserData.GetUserData().FactoryCode);
            sqlParameter.AddParameterString("registration_user_cd", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterDateTime("registrationDatetime", trxContext.ProcessingDBDateTime);
            //execute SQL

            ProdutionWorkContentVo outVo = new ProdutionWorkContentVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
