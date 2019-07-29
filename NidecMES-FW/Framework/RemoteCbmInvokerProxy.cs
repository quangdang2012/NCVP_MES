using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.Framework
{
    public interface RemoteCbmInvokerProxy
    {

        bool IsServerRunning();

        ValueObject Execute(string CbmId, UserData userdata, ValueObject vo);
    }
}
