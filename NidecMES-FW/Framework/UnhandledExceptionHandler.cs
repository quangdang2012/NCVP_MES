using System;

namespace Com.Nidec.Mes.Framework
{
    public interface UnhandledExceptionHandler
    {

        void HandleException(object sender, UnhandledExceptionEventArgs e);
    }
}
