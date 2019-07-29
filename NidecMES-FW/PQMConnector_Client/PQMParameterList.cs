
namespace Com.Nidec.Mes.PQMConnector_Client
{
    internal interface PQMParameterList
    {
        /// <summary>
        /// get and set the parameters
        /// </summary>
        PQMParameter[] Parameters { get; set; }

        /// <summary>
        /// method definition for AddParameter
        /// </summary>
        /// <param name="name"></param>
        /// <param name="value"></param>
        void AddParameter(string name, object value);

    }
}
