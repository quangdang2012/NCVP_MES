using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Text;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class DeleteResponseMachineDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ResponseMachineVo inVo = (ResponseMachineVo)vo;
            StringBuilder sql = new StringBuilder();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("delete from  public.m_response_machine Where 1=1 ");

            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.MachineId > 0)
            {
                sql.Append(" and machine_id = :machine_id ");
                sqlParameter.AddParameterInteger("machine_id", inVo.MachineId);
            }
            if (inVo.ProdutionWorkContentId > 0)
            {
                sql.Append(" and prodution_work_content_id = :prodution_work_content_id ");
                sqlParameter.AddParameterInteger("prodution_work_content_id", inVo.ProdutionWorkContentId);
            }
            if (inVo.ResponseMachineId > 0)
            {
                sql.Append(" and response_machine_id = :response_machine_id ");
                sqlParameter.AddParameterInteger("response_machine_id", inVo.ResponseMachineId);
            }




            //create command
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL

            MachineVo outVo = new MachineVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
