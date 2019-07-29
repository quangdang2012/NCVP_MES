using Com.Nidec.Mes.Framework.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Com.Nidec.Mes.VCVP
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex mutex = new Mutex(false, Assembly.GetExecutingAssembly().ManifestModule.Name);

            try
            {
                if (mutex.WaitOne(0, false))
                {
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new LoginForm(
                   
                                                  Assembly.GetExecutingAssembly().ManifestModule.Name,
                                                  Properties.Settings.Default.ApplicationTypeName,
                                                  Assembly.GetExecutingAssembly().GetName().Name, true));
                }
            }
            catch(Exception EX)
            {
                MessageBox.Show(EX.ToString());
            }
            finally
            {
                 mutex.Close();
            }

        }
    }
}
