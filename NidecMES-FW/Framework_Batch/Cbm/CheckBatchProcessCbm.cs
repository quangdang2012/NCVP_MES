using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Framework_Batch.Vo;

namespace Com.Nidec.Mes.Framework_Batch.Cbm
{
    internal class CheckBatchProcessCbm : CbmController
    {
        private readonly CbmController getBatchProcessCbm = new GetBatchProcessCbm();

        private readonly CbmController addBatchProcessCbm = new AddBatchProcessCbm();

        public ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AddBatchProcessVo inVo = (AddBatchProcessVo)vo;
            AddBatchProcessVo getOutVo = (AddBatchProcessVo)getBatchProcessCbm.Execute(trxContext, inVo);

            CheckBatchProcessVo outVo = new CheckBatchProcessVo();
            if (getOutVo != null)
            {
                outVo.IsBatchStarted = false;
            }
            else
            {
                UpdateResultVo updateVo = (UpdateResultVo)addBatchProcessCbm.Execute(trxContext, inVo);

                if (updateVo != null && updateVo.AffectedCount > 0)
                {
                    outVo.IsBatchStarted = true;
                }
            }
            return outVo;
        }
    }
}

