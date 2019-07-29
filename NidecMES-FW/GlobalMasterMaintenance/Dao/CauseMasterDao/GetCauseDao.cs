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
    public class GetCauseDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            CauseVo inVo = (CauseVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<CauseVo> voList = new ValueObjectList<CauseVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select cause_id, machine_id, defective_reason_id, registration_user_cd,registration_date_time,factory_cd from m_cause");
            sql.Append(" Where 1=1 ");

            //
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.MachineID > 0)
            {
                sql.Append(" and machine_id = :machine_id ");
                sqlParameter.AddParameterInteger("machine_id", inVo.MachineID);
            }
            if (inVo.DefectiveID > 0)
            {
                sql.Append(" and defective_reason_id = :defective_reason_id ");
                sqlParameter.AddParameterInteger("defective_reason_id", inVo.DefectiveID);
            }
            if (inVo.CauseID > 0)
            {
                sql.Append(" and cause_id = :cause_id ");
                sqlParameter.AddParameterInteger("cause_id", inVo.CauseID);
            }


            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                CauseVo outVo = new CauseVo
                {
                    //convert
                    CauseID = int.Parse(dataReader["cause_id"].ToString()),
                    MachineID = int.Parse(dataReader["machine_id"].ToString()),
                    DefectiveID = int.Parse(dataReader["defective_reason_id"].ToString()),

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
