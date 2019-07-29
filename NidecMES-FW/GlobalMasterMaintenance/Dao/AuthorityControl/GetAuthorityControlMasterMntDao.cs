using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetAuthorityControlMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            AuthorityControlVo inVo = (AuthorityControlVo)arg;
            AuthorityControlVo outVo = new AuthorityControlVo();


            StringBuilder sqlQuery = new StringBuilder();

            //create SQL
            sqlQuery.Append("Select * from m_authority_control ");

            sqlQuery.Append(" where 1 = 1 ");

            if (inVo.AuthorityControlCode != null)
            {
                sqlQuery.Append(" and UPPER(authority_control_cd) like UPPER(:authcontcd) ");
            }

            if (inVo.AuthorityControlName != null)
            {
                sqlQuery.Append(" and UPPER(authority_control_name) like UPPER(:authcontname) ");
            }

            if (inVo.ParentControlCode != null)
            {
                sqlQuery.Append(" and parent_control_cd = :parentcontrol ");
            }

            if (inVo.AssemblyName != null)
            {
                sqlQuery.Append(" and UPPER(assembly_name) like UPPER(:assemblyname) ");
            }

            if (inVo.FormName != null)
            {
                sqlQuery.Append(" and UPPER(form_name) like UPPER(:formname) ");
            }

            sqlQuery.Append(" order by authority_control_cd");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            if (inVo.AuthorityControlCode != null)
            {
                sqlParameter.AddParameterString("authcontcd", inVo.AuthorityControlCode + "%");
            }

            if (inVo.AuthorityControlName != null)
            {
                sqlParameter.AddParameterString("authcontname", inVo.AuthorityControlName + "%");
            }

            if (inVo.AssemblyName != null)
            {
                sqlParameter.AddParameterString("assemblyname", inVo.AssemblyName + "%");
            }

            if (inVo.FormName != null)
            {
                sqlParameter.AddParameterString("formname", inVo.FormName + "%");
            }

            if (inVo.ParentControlCode != null)
            {
                sqlParameter.AddParameterString("parentcontrol", inVo.ParentControlCode);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                AuthorityControlVo currOutVo = new AuthorityControlVo
                {
                    AuthorityControlCode = dataReader["authority_control_cd"].ToString(),
                    AuthorityControlName = dataReader["authority_control_name"].ToString(),
                    ParentControlCode = dataReader["parent_control_cd"].ToString()
                };
                outVo.AuthorityControlListVo.Add(currOutVo);
            }

            dataReader.Close();

            return outVo;
        }

 
    }
}
