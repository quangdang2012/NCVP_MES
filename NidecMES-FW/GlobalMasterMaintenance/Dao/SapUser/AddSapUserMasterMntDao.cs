using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class AddSapUserMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            SapUserVo inVo = (SapUserVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Insert into m_sap_user");
            sqlQuery.Append(" ( ");            
            sqlQuery.Append(" mes_user_cd, ");            
            sqlQuery.Append(" sap_user, ");
            sqlQuery.Append(" sap_password, ");
            sqlQuery.Append(" registration_user_cd, ");
            sqlQuery.Append(" registration_date_time, ");
            sqlQuery.Append(" factory_cd");
            sqlQuery.Append(" ) ");
            sqlQuery.Append("VALUES	");
            sqlQuery.Append(" ( ");            
            sqlQuery.Append(" :mesusercd ,");            
            sqlQuery.Append(" :sapuser ,");
            sqlQuery.Append(" :sappassword  ,");
            sqlQuery.Append(" :registrationusercode ,");
            sqlQuery.Append(" now() ,");
            sqlQuery.Append(" :registrationfactorycode ");
            sqlQuery.Append(" ); ");

            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();            
            sqlParameter.AddParameterString("mesusercd", inVo.MesUserCode);           
            sqlParameter.AddParameterString("sapuser ", inVo.SapUser);
            sqlParameter.AddParameterString("sappassword ", inVo.SapPassWord);
            sqlParameter.AddParameterString("registrationusercode ", UserData.GetUserData().UserCode);            
            sqlParameter.AddParameterString("registrationfactorycode ", UserData.GetUserData().FactoryCode);

            SapUserVo outVo = new SapUserVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter) };

            return outVo; 
        }
    }
}
