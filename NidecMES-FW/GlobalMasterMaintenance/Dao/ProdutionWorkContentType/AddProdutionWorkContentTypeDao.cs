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
    public class AddProdutionWorkContentTypeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentTypeVo inVo = (ProdutionWorkContentTypeVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append(" insert into ");
            sql.Append(" m_work_content_type( ");
            sql.Append(" work_content_type_cd,  ");
            sql.Append(" work_content_type_name,  ");
            sql.Append(" registration_user_cd,  ");
            sql.Append(" registration_date_time,  ");
            sql.Append(" factory_cd) ");
            sql.Append(" values( ");
            sql.Append(" :prodution_work_content_type_cd, ");
            sql.Append(" :prodution_work_content_type_name, ");
            sql.Append(" :registration_user_cd, ");
            sql.Append(" :registrationdatetime, ");
            sql.Append(" :factorycd)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("prodution_work_content_type_cd", inVo.ProdutionWorkContentTypeCode);
            sqlParameter.AddParameterString("prodution_work_content_type_name", inVo.ProdutionWorkContentTypeName);           
            sqlParameter.AddParameterDateTime("registrationdatetime", trxContext.ProcessingDBDateTime);
            sqlParameter.AddParameterString("registration_user_cd", UserData.GetUserData().UserCode);
            sqlParameter.AddParameterString("factorycd", UserData.GetUserData().FactoryCode);
            //execute SQL

            ProdutionWorkContentTypeVo outVo = new ProdutionWorkContentTypeVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
