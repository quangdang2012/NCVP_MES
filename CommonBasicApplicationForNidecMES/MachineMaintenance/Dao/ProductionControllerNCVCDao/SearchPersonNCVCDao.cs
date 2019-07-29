using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class SearchPersonNCVCDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            PersonVo inVo = (PersonVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<PersonVo> voList = new ValueObjectList<PersonVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();

            sql.Append(@"select person_id, model_cd, line_cd, datetimes, factory_cd, building_cd,lot_numbers, leader_name, shift,plan_pro, plan_st, actual_st, doing_co,absent_co,");
            sql.Append("doing_ra,absent_ra, doing_ca, absent_ca, doing_ba, absent_ba, doing_ma, absent_ma, timeover, timeoffset,  sum_timedoing, registration_user_cd, factory_cd from t_productioncontroller_person ");
            sql.Append(" where 1=1  ");

            sql.Append(@" and datetimes >= :timefrom");
            sqlParameter.AddParameterDateTime("timefrom", inVo.TimeFrom);

            sql.Append(" and datetimes <= :timeto");
            sqlParameter.AddParameterDateTime("timeto", inVo.TimeTo);

            if (!String.IsNullOrEmpty(inVo.Model))
            {
                sql.Append(" and   model_cd  =:model_cd");
                sqlParameter.AddParameterString("model_cd", inVo.Model);
            }
            if (!String.IsNullOrEmpty(inVo.Line))
            {
                sql.Append(" and line_cd  =:line_cd");
                sqlParameter.AddParameterString("line_cd", inVo.Line);
            }

            if (!String.IsNullOrEmpty(inVo.Shift.ToString()))
            {
                sql.Append(" and shift =:shift");
                sqlParameter.AddParameterInteger("shift", inVo.Shift);
            }
            
            //sql.Append(" order by datetimes");
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                PersonVo outVo = new PersonVo
                {
                    //  , h., i., k., o.prodution_work_content_name
                    PersonId = int.Parse(dataReader["person_id"].ToString()),
                    Model = dataReader["model_cd"].ToString(),
                    Line = dataReader["line_cd"].ToString(),
                    DateTimes = DateTime.Parse(dataReader["datetimes"].ToString()),
                    FactoryCode = dataReader["factory_cd"].ToString(),
                    BuildingCode = dataReader["building_cd"].ToString(),
                    LotNumber = dataReader["lot_numbers"].ToString(),
                    LeaderName = dataReader["leader_name"].ToString(),
                    Shift = int.Parse(dataReader["shift"].ToString()),
                    PlanPro = int.Parse(dataReader["plan_pro"].ToString()),
                    PlanST = double.Parse(dataReader["plan_st"].ToString()),
                    ActualSt = double.Parse(dataReader["actual_st"].ToString()),
                    DoCo = double.Parse(dataReader["doing_co"].ToString()),
                    AbsentCo = double.Parse(dataReader["absent_co"].ToString()),
                    DoRa = double.Parse(dataReader["doing_ra"].ToString()),
                    AbsentRa = double.Parse(dataReader["absent_ra"].ToString()),
                    DoCa = double.Parse(dataReader["doing_ca"].ToString()),
                    AbsentCa = double.Parse(dataReader["absent_ca"].ToString()),
                    DoBa = double.Parse(dataReader["doing_ba"].ToString()),
                    AbsentBa = double.Parse(dataReader["absent_ba"].ToString()),
                    DoMa = double.Parse(dataReader["doing_ma"].ToString()),
                    AbsentMa = double.Parse(dataReader["absent_ma"].ToString()),
                    TimeOver = double.Parse(dataReader["timeover"].ToString()),
                    TimeOffset = double.Parse(dataReader["timeoffset"].ToString()),
                    TimeTotal = double.Parse(dataReader["sum_timedoing"].ToString()),
                    RegistrationUserCode = dataReader["registration_user_cd"].ToString(),
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }
}
