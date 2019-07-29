using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.Framework_Server
{
    public interface CbmContainer
    {
        /// <summary>
        /// get the cbmcontroller from the list using assembly and controllerid
        /// </summary>
        /// <param name="assembly"></param>
        /// <param name="cbmcontrollerId"></param>
        /// <returns></returns>
        CbmController GetCbm(string cbmcontrollerId);

        /// <summary>
        /// initialize the cbmcontroller
        /// </summary>
        void Init(string assemblyname, bool isWebService = false);
    }
}
