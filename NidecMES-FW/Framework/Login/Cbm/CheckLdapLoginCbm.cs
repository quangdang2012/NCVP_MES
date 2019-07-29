using System;
using System.Net;
using System.DirectoryServices.Protocols;

namespace Com.Nidec.Mes.Framework.Login
{
    public class CheckLdapLoginCbm : CbmController
    {

        /// <summary>
        /// initialize LoginDao
        /// </summary>
        private readonly CheckLoginDao loginDao = new CheckLoginDao();

        /// <summary>
        /// Execute the dao
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {

            LoginInVo inVo = (LoginInVo)vo;

            LoginOutVo outVo = new LoginOutVo();

            string ldapConnectionHost = ConfigurationDataTypeEnum.LDAP_CONNECTION_HOST.GetValue(); //Properties.Settings.Default.LdapConnectionHost;
            string searchDN = "dc=nidec,dc=com";
            string searchFilterFormat = "(&(exgEnabledFlag=enabled)(uid={0}))";
            string distinguishedName = string.Empty;

            // search DistinguishedName
            LdapConnection ldapconnection = new LdapConnection(ldapConnectionHost);
            ldapconnection.AuthType = AuthType.Anonymous;
            ldapconnection.SessionOptions.ProtocolVersion = 3;
            ldapconnection.Bind();

            SearchRequest searchRequest = new SearchRequest(
                                                 searchDN,
                                                 string.Format(searchFilterFormat, inVo.InputUserId),
                                                 SearchScope.Subtree
                                                   );
            SearchResponse response = null;
            try
            {
                response = (SearchResponse)ldapconnection.SendRequest(searchRequest);
            }
            catch (ObjectDisposedException ex)
            {
                MessageData messageData = new MessageData("llce00014", Properties.Resources.llce00014, ex.Message);
  
                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (ArgumentNullException ex)
            {
                MessageData messageData = new MessageData("llce00015", Properties.Resources.llce00015, ex.Message);

                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (NotSupportedException ex)
            {
                MessageData messageData = new MessageData("llce00016", Properties.Resources.llce00016, ex.Message);

                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (LdapException ex)
            {
                MessageData messageData = new MessageData("llce00017", Properties.Resources.llce00017, ex.Message);

                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (DirectoryOperationException ex)
            {
                MessageData messageData = new MessageData("llce00018", Properties.Resources.llce00018, ex.Message);

                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }


            if (response != null)
            {
                SearchResultEntryCollection collection = response.Entries;

                foreach (SearchResultEntry searchResultEntry in collection)
                {
                    distinguishedName = searchResultEntry.DistinguishedName;
                    break;
                }
            }

            // authenticate
            if (string.IsNullOrEmpty(distinguishedName))
            {
                outVo.ResultCount = 0;
                return outVo;// user does not exist.

            }

            ldapconnection.AuthType = AuthType.Basic;
            ldapconnection.SessionOptions.ProtocolVersion = 3;
            try
            {
                ldapconnection.Bind(new NetworkCredential(distinguishedName, inVo.InputPassword));
            }
            catch (ObjectDisposedException ex)
            {
                MessageData messageData = new MessageData("llce00019", Properties.Resources.llce00019, ex.Message);

                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (LdapException ex)
            {
                MessageData messageData = new MessageData("llce00020", Properties.Resources.llce00020, ex.Message);

                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            catch (InvalidOperationException ex)
            {
                MessageData messageData = new MessageData("llce00021", Properties.Resources.llce00021, ex.Message);

                SystemException sysEx = new SystemException(messageData, ex);

                throw sysEx;
            }
            outVo.ResultCount = 1;
            return outVo;

        }
    }
}
