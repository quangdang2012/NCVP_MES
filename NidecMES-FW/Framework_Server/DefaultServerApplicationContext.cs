using System;
using System.Net;
using System.Net.Sockets;
using System.Globalization;
using System.Text;
using System.Threading;
using System.Reflection;
using System.Windows.Forms;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.Framework_Server
{
    public class DefaultServerApplicationContext : ApplicationContext
    {

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="assemblyname"></param>
        /// <param name="typename"></param>
        /// <param name="appricationname"></param>
        /// <param name="passwordCheckNeeded"></param>
        public DefaultServerApplicationContext(string assemblyname)
        {
            //Mutex mutex = new Mutex(false, assemblyname);

            try
            {
                //if (mutex.WaitOne(0, false))
                //{
                    DefaultServerContextListener.GetInstance().Init(assemblyname);
                    Console.WriteLine("server started successfully");
                    Console.ReadKey();
                //}
            }
            finally
            {
                //mutex.Close();
            }
        }

    }
}
