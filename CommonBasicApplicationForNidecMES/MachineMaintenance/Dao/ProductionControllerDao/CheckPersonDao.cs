using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckPersonDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            PersonVo inVo = (PersonVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<PersonVo> voList = new ValueObjectList<PersonVo>();
            //PersonVo outVo = new PersonVo();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"select count(*) as counter from t_productioncontroller_person where 1=1 ");

            if (inVo.PersonId > 0)
            {
                sql.Append(" and person_id  =:person_id");
                sqlParameter.AddParameter("person_id", inVo.PersonId);
            }
            if (!String.IsNullOrEmpty(inVo.RegistrationUserCode))
            {
                sql.Append(" and registration_user_cd  =:registration_user_cd");
                sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);
            }
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL
            string dataReader = sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString();
            
                PersonVo outVo = new PersonVo
                {
                    AffectedCount = int.Parse(dataReader),
                };
            return outVo;
        }
    }
}
