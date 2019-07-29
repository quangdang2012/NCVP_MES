using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class CheckPerson_DuplicateNCVCDao : AbstractDataAccessObject
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
            
            if (!String.IsNullOrEmpty(inVo.DateTimes.ToString()))
            {
                sql.Append(" and cast(datetimes as date) = :datetimes");
                sqlParameter.AddParameter("datetimes", inVo.DateTimes.Date);
            }
            if (!String.IsNullOrEmpty(inVo.Model))
            {
                sql.Append(" and model_cd  =:model_cd");
                sqlParameter.AddParameterString("model_cd", inVo.Model);
            }
            if (!String.IsNullOrEmpty(inVo.Line))
            {
                sql.Append(" and line_cd  =:line_cd");
                sqlParameter.AddParameterString("line_cd", inVo.Line);
            }
            if (inVo.Shift > 0 && inVo.Shift < 4)
            {
                sql.Append(" and shift  =:shift");
                sqlParameter.AddParameter("shift", inVo.Shift);
            }
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());


            //execute SQL
            string dataReader = sqlCommandAdapter.ExecuteScalar(sqlParameter).ToString();
            
                PersonVo outVo = new PersonVo
                {
                    AffectedCount = int.Parse(dataReader),
                    //AffectedCount
                };
                //voList.add(outVo);
            
            //dataReader.Close();
            return outVo;
        }
    }
}
