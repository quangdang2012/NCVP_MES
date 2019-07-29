using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class GetResponseMachineDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ResponseMachineVo inVo = (ResponseMachineVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ResponseMachineVo> voList = new ValueObjectList<ResponseMachineVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select response_machine_id, machine_id, prodution_work_content_id, registration_user_cd,registration_date_time,factory_cd from public.m_response_machine");
            sql.Append(" where 1=1 ");

            //
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
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ResponseMachineVo outVo = new ResponseMachineVo
                {
                    //convert
                    ResponseMachineId = int.Parse(dataReader["response_machine_id"].ToString()),
                    ProdutionWorkContentId = int.Parse(dataReader["prodution_work_content_id"].ToString()),
                    MachineId = int.Parse(dataReader["machine_id"].ToString()),

                    RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                    RegistrationDateTime = DateTime.Parse(dataReader["registration_date_time"].ToString()),
                    FactoryCode = dataReader["factory_cd"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }
    }
}
