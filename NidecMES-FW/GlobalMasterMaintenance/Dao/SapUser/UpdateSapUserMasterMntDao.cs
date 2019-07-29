using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class UpdateSapUserMasterMntDao : AbstractDataAccessObject
    {

        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            SapUserVo inVo = (SapUserVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Update m_sap_user");
            sqlQuery.Append(" Set ");            
            sqlQuery.Append(" mes_user_cd = :mesusercd, ");
            sqlQuery.Append(" sap_user = :sapuser, ");            
            sqlQuery.Append(" sap_password = :sappassword ");                     
            sqlQuery.Append(" Where	");
            sqlQuery.Append(" sap_user_id = :sapuserid ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter= sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("mesusercd", inVo.MesUserCode);
            sqlParameter.AddParameterString("sapuser", inVo.SapUser);            
            sqlParameter.AddParameterString("sappassword ", inVo.SapPassWord);
            sqlParameter.AddParameterInteger("sapuserid ", inVo.SapUserId);            

            SapUserVo outVo = new SapUserVo { AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)};

            return outVo; 
        }
    }
}
