using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class UpdatePersonProNCVCDao : AbstractDataAccessObject
    {
        public string con = Properties.Settings.Default.CONNECTION_STRING;
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            PersonVo inVo = (PersonVo)vo;
            StringBuilder sql = new StringBuilder();
            sql.Append("update t_productioncontroller_person set model_cd =:model_cd  , line_cd =:line_cd  ,datetimes =:datetimes  ,factory_cd =:factory_cd  ,building_cd =:building_cd  , ");
            sql.Append("lot_numbers =:lot_numbers  , leader_name =:leader_name  , shift =:shift  , plan_pro =:plan_pro  , plan_st =:plan_st  ,  actual_st =:actual_st  , doing_co =:doing_co  , absent_co =:absent_co  , doing_ra =:doing_ra  ,");
            sql.Append("absent_ra =:absent_ra  ,doing_ca =:doing_ca  , absent_ca =:absent_ca  , doing_ba =:doing_ba  , absent_ba =:absent_ba  ,doing_ma =:doing_ma  ,  absent_ma =:absent_ma  , timeover =:timeover  ,  timeoffset =:timeoffset  ,  sum_timedoing =:sum_timedoing  , registration_user_cd=:registration_user_cd ");
            sql.Append(" where person_id=:person_id ");

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameter("person_id", inVo.PersonId);
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
