using Com.Nidec.Mes.Framework;

namespace Com.Nidec.Mes.Framework_Batch
{
    public interface BatchMain
    {
        /// <summary>
        /// batch execution method
        /// </summary>
        /// <returns>valueobject</returns>
        ValueObject Execute();

        /// <summary>
        /// to store batchmain class name
        /// </summary>
        /// <returns>name as string</returns>
        string GetName();
    }
}
