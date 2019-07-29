
namespace Com.Nidec.Mes.Framework_Server
{
    public class DefaultWebServiceInitializer
    {

        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly DefaultWebServiceInitializer instance = new DefaultWebServiceInitializer();


        /// <summary>
        /// private constructor
        /// </summary>
        private DefaultWebServiceInitializer()
        {
        }

        /// <summary>
        /// initialize server application initializer and cbm container
        /// </summary>
        /// <param name="assemblyname"></param>
        public void Init(string assemblyname)
        {
            DefaultServerApplicationInitializer.GetInstance().Init();

            CbmContainer cbmContainer = DefaultXmlCbmContainer.GetInstance();
            cbmContainer.Init(assemblyname, true);
        }

        /// <summary>
        /// returns the current instance 
        /// </summary>
        /// <returns></returns>
        public static DefaultWebServiceInitializer GetInstance()
        {
            return instance;
        }
    }
}
