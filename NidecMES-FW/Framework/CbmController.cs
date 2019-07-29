namespace Com.Nidec.Mes.Framework
{
    public interface CbmController
    {
        /// <summary>
        /// method definition for Execute
        /// </summary>
        /// <param name="trxContext"></param>
        /// <param name="vo"></param>
        /// <returns></returns>
        ValueObject Execute(TransactionContext trxContext, ValueObject vo);
        

    }
}
