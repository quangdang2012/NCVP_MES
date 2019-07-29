using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo;
using Com.Nidec.Mes.Framework;
using System;
using System.Windows.Forms;
using Npgsql;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class AddSTWorkingStatusDao : AbstractDataAccessObject
    {
        public string con = Properties.Settings.Default.CONNECTION_STRING;
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            AddMachineStatusVo inVo = (AddMachineStatusVo)vo;
            int res1;
            bool res2 = false;
            NpgsqlConnection conn = new NpgsqlConnection(con);
            string sql = "insert into t_st_status_machine( st_machine,  st_model, st_site,st_factory, st_line , st_process, st_inspect_item, st_inspect_date , st_inspect_time, st_inspect_data ,st_tjudge , st_tstatus, st_remark) " + "values :st_machine,  :st_model, :st_site, :st_factory, :st_line , :st_process, :st_inspect_item , :st_inspect_date , :st_inspect_time, :st_inspect_data, :st_tjudge, :st_tstatus, :st_remark )";

            NpgsqlCommand comamnd = new NpgsqlCommand(sql, conn);

            comamnd.Parameters.Add("st_machine", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_model", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_site", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_factory", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_line", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_process", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_inspect_item", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_inspect_date", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_inspect_time", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_inspect_data", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_tjudge", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_tstatus", NpgsqlTypes.NpgsqlDbType.Varchar);
            comamnd.Parameters.Add("st_remark", NpgsqlTypes.NpgsqlDbType.Varchar);

            for (int i = 0; i < inVo.dt.Rows.Count; i++)
            {
                comamnd.Parameters["st_machine"].Value = inVo.dt.Rows[i]["colSTMachine"];
                comamnd.Parameters["st_model"].Value = "ALUMITE";
                comamnd.Parameters["st_site"].Value = "NCVP";
                comamnd.Parameters["st_factory"].Value = "2A";
                comamnd.Parameters["st_line"].Value = "L01";
                comamnd.Parameters["st_process"].Value = "IOT";
                comamnd.Parameters["st_inspect_item"].Value = "STATUS";
                comamnd.Parameters["st_inspect_date"].Value = inVo.dt.Rows[i]["colSDatetime"];
                comamnd.Parameters["st_inspect_time"].Value = DateTime.Now;
                comamnd.Parameters["st_inspect_data"].Value = inVo.dt.Rows[i]["colSTStatus"];
                comamnd.Parameters["st_tjudge"].Value = "0";
                comamnd.Parameters["st_tstatus"].Value = "INITIAL";
                comamnd.Parameters["st_remark"].Value = inVo.dt.Rows[i]["colSTRemark"];

                System.Diagnostics.Debug.Print(comamnd.CommandText);
                res1 = comamnd.ExecuteNonQuery();
            }
            if (!res2)
            {
                conn.Close();
            }
            else
            {
                MessageBox.Show("Not successful!", "Database Responce", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                conn.Close();
            }

            //create command
            //DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());
            //create parameter

            //DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            //sqlParameter.Parameters("",inVo.pla)
            //sqlParameter.AddParameterString("plan_section", inVo.PlanSection);
            //sqlParameter.AddParameterDateTime("plan_datetime_add", inVo.DateTimeAdd);
            //sqlParameter.AddParameterInteger("total_no", inVo.TotalNo);
            //sqlParameter.AddParameterInteger("plan_data_no", inVo.PlanNo);
            //sqlParameter.AddParameter("plan_data_div", inVo.Rate);
            //sqlParameter.AddParameterDateTime("registration_date_time", inVo.RegistrationDateTime);
            //sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            //sqlParameter.AddParameterString("registration_user_cd", inVo.RegistrationUserCode);

            //execute SQL
            AddMachineStatusVo outVo = new AddMachineStatusVo
            {
                //AffectedCount = res1
            };

            return outVo;
        }
    }
}
