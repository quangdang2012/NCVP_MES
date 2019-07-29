using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddPersonProDao : AbstractDataAccessObject
    {
        public string con = Properties.Settings.Default.CONNECTION_STRING;
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            PersonVo inVo = (PersonVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into t_productioncontroller_person(model_cd, line_cd,datetimes,factory_cd,building_cd, ");
            sql.Append("lot_numbers, leader_name, shift, plan_pro, plan_st,  actual_st, doing_co, absent_co, doing_ra,");
            sql.Append("absent_ra,doing_ca, absent_ca, doing_ba, absent_ba,doing_ma,  absent_ma, timeover,  timeoffset,  sum_timedoing, registration_user_cd )");

            sql.Append("values(:model_cd,:line_cd, :datetimes,:factory_cd,:building_cd,");
            sql.Append(":lot_numbers, :leader_name, :shift, :plan_pro,:plan_st,:actual_st,:doing_co,:absent_co,:doing_ra,");
            sql.Append(":absent_ra, :doing_ca,:absent_ca,:doing_ba, :absent_ba, :doing_ma, :absent_ma, :timeover, :timeoffset, :sum_timedoing, :registration_user_cd)");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("model_cd", inVo.Model);
            sqlParameter.AddParameterString("line_cd", inVo.Line);
            sqlParameter.AddParameterDateTime("datetimes", inVo.DateTimes);
            sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            sqlParameter.AddParameterString("building_cd", inVo.BuildingCode);
            sqlParameter.AddParameterString("lot_numbers", inVo.LotNumber);
            sqlParameter.AddParameterString("leader_name", inVo.LeaderName);
            sqlParameter.AddParameterInteger("shift", inVo.Shift);
            sqlParameter.AddParameterInteger("plan_pro", inVo.PlanPro);
            sqlParameter.AddParameter("plan_st", inVo.PlanST);
            sqlParameter.AddParameter("actual_st", inVo.ActualSt);
            sqlParameter.AddParameter("doing_co", inVo.DoCo);
            sqlParameter.AddParameter("doing_ra", inVo.DoRa);
            sqlParameter.AddParameter("doing_ca", inVo.DoCa);
            sqlParameter.AddParameter("doing_ba", inVo.DoBa);
            sqlParameter.AddParameter("doing_ma", inVo.DoMa);
            sqlParameter.AddParameter("absent_co", inVo.AbsentCo);
            sqlParameter.AddParameter("absent_ra", inVo.AbsentRa);
            sqlParameter.AddParameter("absent_ca", inVo.AbsentCa);
            sqlParameter.AddParameter("absent_ba", inVo.AbsentBa);
            sqlParameter.AddParameter("absent_ma", inVo.AbsentMa);
            sqlParameter.AddParameter("timeover", inVo.TimeOver);
            sqlParameter.AddParameter("timeoffset", inVo.TimeOffset);
            sqlParameter.AddParameter("sum_timedoing", inVo.TimeTotal);
            sqlParameter.AddParameter("registration_user_cd", inVo.RegistrationUserCode);
            //execute SQL

            PersonVo   outVo = new PersonVo
            {
                AffectedCount = sqlCommandAdapter.ExecuteNonQuery(sqlParameter)
            };

            return outVo;
        }
    }
}
