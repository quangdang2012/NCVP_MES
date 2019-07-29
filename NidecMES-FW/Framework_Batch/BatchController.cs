
namespace Com.Nidec.Mes.Framework_Batch
{
    public interface  BatchController
    {
        /// <summary>
        /// init method to call the batch execute
        /// </summary>
        /// <param name="batchMain">batchmain class instance</param>
        void Init(BatchMain batchMain);
    }
}
