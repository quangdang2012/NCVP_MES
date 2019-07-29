using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System;
using System.Linq;
using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Framework_Server
{
    public class DefaultXmlCbmContainer : CbmContainer
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CbmContainer INSTANCE = new DefaultXmlCbmContainer();

        /// <summary>
        /// get the initialized flag
        /// </summary>
        private bool initializedFlg = false;

        /// <summary>
        /// store cbm instance
        /// </summary>
        private Dictionary<string, CbmController> dicAssemblyTypeObj = new Dictionary<string, CbmController>();

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultXmlCbmContainer));

        /// <summary>
        /// store assembly
        /// </summary>
        private string assemblyname;

        /// <summary>
        /// variable to check is it webservice
        /// </summary>
        private bool isWebService;

        /// <summary>
        /// constructor
        /// </summary>
        private DefaultXmlCbmContainer() { }

        /// <summary>
        /// get the instance of DefaultXmlCbmContainer class
        /// </summary>
        /// <returns>instance of DefaultXmlCbmContainer as CbmContainer</returns>
        public static CbmContainer GetInstance()
        {
            return INSTANCE;
        }

        /// <summary>
        /// initialize method for the cbm and create instance
        /// </summary>
        public void Init(string assemblyname, bool isWebService = false)
        {
            lock (INSTANCE)
            {
                this.assemblyname = assemblyname;

                this.isWebService = isWebService;

                // load each XML and Cached to the map objecct cbmTableListForEachAssmebly
                LoadCbmXmlAndCreateCbmInstance();

                initializedFlg = true;

            }

        }

        /// <summary>
        /// method to get the instance of the cbm
        /// </summary>
        /// <param name="cbmcontrollerId">cbm controller id from the client to be invoked</param>
        /// <exception cref="Exception">exception handled in cbm instance creation from xml</exception>
        /// <returns>instance of the cbm using cbmcontrollerid from xml</returns>
        public CbmController GetCbm(string cbmcontrollerId)
        {
            lock (INSTANCE)
            {
                if (!initializedFlg)
                {

                    Init(this.assemblyname);

                }

                try
                {
                    CbmController cbmController = (CbmController)dicAssemblyTypeObj.First(c => c.Key == cbmcontrollerId).Value;
                    return cbmController;
                }
                catch (ArgumentNullException exception)
                {
                    MessageData messageData = new MessageData("fsce00039", Properties.Resources.fsce00039, new string[] { cbmcontrollerId, exception.Message });
                    logger.Error(messageData, exception);

                    throw new Framework.SystemException(messageData, exception);
                }
                catch (InvalidOperationException exception)
                {
                    MessageData messageData = new MessageData("fsce00040", Properties.Resources.fsce00040, new string[] { cbmcontrollerId, exception.Message });
                    logger.Error(messageData, exception);

                    throw new Framework.SystemException(messageData, exception);
                }
            }
        }

        /// <summary>
        /// load cbm xl and create the instance of the cbm and stored in cache memory
        /// </summary>
        private void LoadCbmXmlAndCreateCbmInstance()
        {

            string filePath = AppDomain.CurrentDomain.BaseDirectory + ServerConfigurationDataTypeEnum.DEFAULT_CBM_LIST_XML.GetValue();

            if (!System.IO.File.Exists(filePath))
            {
                //logging
                return;
            }

            DataSet dsCbm = new DataSet();

            //Read Xml file from Exection Path
            dsCbm.ReadXml(filePath);

            Assembly assembly = LoadAssembly(this.assemblyname);

            if (assembly == null)
            {
                //log
                return;

            }


            DataTable dtCbm = dsCbm.Tables[0];

            if (dtCbm.Rows.Count == 0)
            {
                //logging
                return;
            }

            foreach (DataRow dr in dtCbm.Rows)
            {
                CbmController cbmController = CbmInstance(assembly, dr["Name"].ToString());

                if (cbmController != null)
                {
                    dicAssemblyTypeObj.Add(dr["ID"].ToString(), cbmController);

                }
            }

        }

        /// <summary>
        /// get the assembly with its name
        /// </summary>
        /// <param name="cbmAssblyName">load the assembly with name from basedirectory</param>
        /// <exception cref="Exception">exception handled in assembly load</exception>
        /// <returns>assembly</returns>
        private Assembly LoadAssembly(string cbmAssblyName)
        {
            try
            {
                string assemblyFilePath = AppDomain.CurrentDomain.BaseDirectory + cbmAssblyName;
                if (isWebService)
                {
                    assemblyFilePath = AppDomain.CurrentDomain.BaseDirectory + "\\bin\\" + cbmAssblyName;
                }
                Assembly assembly = Assembly.LoadFile(assemblyFilePath);

                return assembly;
            }
            catch (ArgumentNullException exception)
            {
                MessageData messageData = new MessageData("fsce00042", Properties.Resources.fsce00042, new string[] { cbmAssblyName, exception.Message });
                logger.Error(messageData, exception);

                throw new Framework.SystemException(messageData, exception);
            }
            catch (System.IO.FileLoadException exception)
            {
                MessageData messageData = new MessageData("fsce00043", Properties.Resources.fsce00043, new string[] { cbmAssblyName, exception.Message });
                logger.Error(messageData, exception);

                throw new Framework.SystemException(messageData, exception);
            }
            catch (System.IO.FileNotFoundException exception)
            {
                MessageData messageData = new MessageData("fsce00044", Properties.Resources.fsce00044, new string[] { cbmAssblyName, exception.Message });
                logger.Error(messageData, exception);

                throw new Framework.SystemException(messageData, exception);
            }
            catch (BadImageFormatException exception)
            {
                MessageData messageData = new MessageData("fsce00045", Properties.Resources.fsce00045, new string[] { cbmAssblyName, exception.Message });
                logger.Error(messageData, exception);

                throw new Framework.SystemException(messageData, exception);
            }
        }

        /// <summary>
        /// get the instance of the cbm
        /// </summary>
        /// <param name="assembly">assembly in which cbm contains</param>
        /// <param name="cbmName">cbm name for which instance has to be create</param>
        /// <exception cref="Exception">exception handled in cbm instance creation from xml</exception>
        /// <returns>instance of the cbm</returns>
        private CbmController CbmInstance(Assembly assembly, string cbmName)
        {
            try
            {
                CbmController cbmController = (CbmController)assembly.CreateInstance(cbmName);

                return cbmController;
            }
            catch (ArgumentException exception)
            {
                MessageData messageData = new MessageData("fsce00002", Properties.Resources.fsce00002, new string[] { cbmName, exception.Message });
                logger.Error(messageData, exception);

                throw new Framework.SystemException(messageData, exception);
            }
            catch (MissingMethodException exception)
            {
                MessageData messageData = new MessageData("fsce00046", Properties.Resources.fsce00046, new string[] { cbmName, exception.Message });
                logger.Error(messageData, exception);

                throw new Framework.SystemException(messageData, exception);
            }
            catch (System.IO.FileLoadException exception)
            {
                MessageData messageData = new MessageData("fsce00047", Properties.Resources.fsce00047, new string[] { cbmName, exception.Message });
                logger.Error(messageData, exception);

                throw new Framework.SystemException(messageData, exception);
            }
            catch (System.IO.FileNotFoundException exception)
            {
                MessageData messageData = new MessageData("fsce00048", Properties.Resources.fsce00048, new string[] { cbmName, exception.Message });
                logger.Error(messageData, exception);

                throw new Framework.SystemException(messageData, exception);
            }
            catch (BadImageFormatException exception)
            {
                MessageData messageData = new MessageData("fsce00049", Properties.Resources.fsce00049, new string[] { cbmName, exception.Message });
                logger.Error(messageData, exception);

                throw new Framework.SystemException(messageData, exception);
            }
        }
    }
}
