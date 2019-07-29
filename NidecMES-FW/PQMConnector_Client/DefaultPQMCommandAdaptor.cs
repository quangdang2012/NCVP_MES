using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.PQMConnector_Client
{
    internal class DefaultPQMCommandAdaptor : PQMCommandAdapter
    {

        /// <summary>
        /// content type constant
        /// </summary>
        private const string REQUEST_CONTENTTYPE = "application/x-www-form-urlencoded";

        /// <summary>
        /// get method constant
        /// </summary>
        private const string REQUEST_METHOD_GET = "GET";

        /// <summary>
        /// get method constant
        /// </summary>
        private const string REQUEST_METHOD_POST = "POST";

        /// <summary>
        /// store command
        /// </summary>
        private static StringBuilder command;

        /// <summary>
        /// 
        /// </summary>
        private string methodUrl;

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultPQMCommandAdaptor));

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="rfcDestination"></param>
        /// <param name="functionName"></param>
        internal DefaultPQMCommandAdaptor(string methodurl)
        {//

            this.methodUrl = methodurl;
        }

        private string SetCommandParameter(PQMParameterList parameterList)
        {
            command = new StringBuilder();
            foreach (PQMParameter parameter in parameterList.Parameters)
            {
                if (command.Length > 0)
                {
                    command.Append("&");
                }
                command.Append(parameter.Name);
                command.Append("=");
                command.Append(parameter.Value);
            }
            return command.ToString();
        }

        /// <summary>
        /// execute with ExecuteReader
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="parameterList"></param>
        /// <returns></returns>
        public DataTable Execute(TransactionContext trxContext, PQMParameterList parameterList)
        {
            SetCommandParameter(parameterList);
            return Invoke(this.methodUrl);

        }

        /// <summary>
        /// create parameterlist object
        /// </summary>
        /// <returns></returns>
        public PQMParameterList CreateParameterList()
        {
            return new DefaultPQMParameterList();

        }

        /// <summary>
        /// invoke pqm service and get output
        /// </summary>
        /// <param name="serverURIPath"></param>        
        /// <param name="inVo"></param>
        /// <returns></returns>
        public static DataTable Invoke(string methodname)
        {
            //create the request
            HttpWebRequest request = CreateWebRequest(methodname);

            if (request == null)
            {
                MessageData messageData = new MessageData("pcci00001", Properties.Resources.pcci00001);
                logger.Error(messageData);

                throw new Framework.ApplicationException(messageData);
            }

            //get the response
            HttpWebResponse response = GetResponse(request);
            if (response == null)
            {
                MessageData messageData = new MessageData("pcci00002", Properties.Resources.pcci00002);
                logger.Error(messageData);

                throw new Framework.ApplicationException(messageData);
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                string output = GetContent(response);

                if (output == null)
                {
                    return null;
                }
                return (DataTable)JsonConvert.DeserializeObject(output, (typeof(DataTable)));
            }
            if (response.StatusCode == HttpStatusCode.NoContent)
            {
                response.Close();
            }
            if (response.StatusCode == HttpStatusCode.OK)
            {
                response.Close();
            }
            //get the output from the webservice

            return null;
        }

        /// <summary>
        /// webrequest creation
        /// </summary>
        /// <param name="serverURIPath"></param>
        /// <param name="ContentType"></param>
        /// <param name="requestMethod"></param>
        /// <returns></returns>
        private static HttpWebRequest CreateWebRequest(string serverURIPath)
        {
            HttpWebRequest webRequest = null;
            try
            {
                webRequest = (HttpWebRequest)WebRequest.Create(new Uri(serverURIPath));
                webRequest.ContentType = REQUEST_CONTENTTYPE;
                webRequest.Method = REQUEST_METHOD_POST;

                byte[] incontent = System.Text.Encoding.UTF8.GetBytes(command.ToString());
                webRequest.ContentLength = incontent.Length;

                using (System.IO.Stream sendStream = webRequest.GetRequestStream())
                {
                    sendStream.Write(incontent, 0, incontent.Length);
                    sendStream.Close();
                }

                // webRequest.
                return webRequest;
            }
            catch (NotSupportedException ex)
            {
                MessageData messageData = new MessageData("pcce00012", Properties.Resources.pcce00012, ex.Message);
                logger.Error(messageData, ex);

                throw new Framework.ApplicationException(messageData);
            }
            catch (ArgumentNullException ex)
            {
                MessageData messageData = new MessageData("pcce00013", Properties.Resources.pcce00013, ex.Message);
                logger.Error(messageData, ex);

                throw new Framework.ApplicationException(messageData);
            }
            catch (System.Security.SecurityException ex)
            {
                MessageData messageData = new MessageData("pcce00014", Properties.Resources.pcce00014, ex.Message);
                logger.Error(messageData, ex);

                throw new Framework.ApplicationException(messageData);
            }
            catch (Exception ex)
            {
                MessageData messageData = new MessageData("pcce00011", Properties.Resources.pcce00011, ex.Message);
                logger.Error(messageData, ex);

                throw new Framework.SystemException(messageData);
            }
        }

        /// <summary>
        /// get response for the web request
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        private static HttpWebResponse GetResponse(HttpWebRequest request)
        {
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                return response;
            }
            catch (ProtocolViolationException ex)
            {
                MessageData messageData = new MessageData("pcce00004", Properties.Resources.pcce00004, ex.Message);
                logger.Error(messageData, ex);

                throw new Framework.ApplicationException(messageData);
            }
            catch (WebException ex)
            {
                MessageData messageData = new MessageData("pcce00005", Properties.Resources.pcce00005, ex.Message);
                logger.Error(messageData, ex);

                throw new Framework.ApplicationException(messageData);
            }
            catch (NotSupportedException ex)
            {
                MessageData messageData = new MessageData("pcce00006", Properties.Resources.pcce00006, ex.Message);
                logger.Error(messageData, ex);

                throw new Framework.ApplicationException(messageData);
            }
            catch (InvalidOperationException ex)
            {
                MessageData messageData = new MessageData("pcce00007", Properties.Resources.pcce00007, ex.Message);
                logger.Error(messageData, ex);

                throw new Framework.ApplicationException(messageData);
            }

        }


        /// <summary>
        /// get the output content
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        private static string GetContent(HttpWebResponse response)
        {

            StreamReader responseStream = new StreamReader(response.GetResponseStream(), Encoding.UTF8);

            string content;
            try
            {
                content = responseStream.ReadToEnd();
                responseStream.Close();

                return content;

            }
            catch (OutOfMemoryException ex)
            {
                MessageData messageData = new MessageData("pcce00003", Properties.Resources.pcce00003, ex.Message);
                logger.Error(messageData, ex);

                throw new Framework.ApplicationException(messageData);
            }
            catch (IOException ex)
            {
                MessageData messageData = new MessageData("pcce00008", Properties.Resources.pcce00008, ex.Message);
                logger.Error(messageData, ex);

                throw new Framework.ApplicationException(messageData);
            }

        }

    }
}
