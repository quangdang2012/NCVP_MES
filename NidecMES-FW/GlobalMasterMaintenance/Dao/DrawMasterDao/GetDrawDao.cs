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
    public class GetDrawDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            DrawVo inVo = (DrawVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<DrawVo> voList = new ValueObjectList<DrawVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select draw_id, draw_cd, draw_name, registration_user_cd, registration_date_time, factory_cd from m_draw");
            sql.Append(" Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.DrawId > 0)
            {
                sql.Append(" and draw_id = :draw_id ");
                sqlParameter.AddParameterInteger("draw_id", inVo.DrawId);
            }
            if (!string.IsNullOrEmpty(inVo.DrawCode))
            {
                sql.Append(" and draw_cd = :draw_cd ");
                sqlParameter.AddParameterString("draw_cd", inVo.DrawCode);
            }
            if (!string.IsNullOrEmpty(inVo.DrawName))
            {
                sql.Append(" and draw_name = :draw_name ");
                sqlParameter.AddParameterString("draw_name", inVo.DrawName);
            }
           

            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                DrawVo outVo = new DrawVo
                {
                    DrawCode = dataReader["draw_cd"].ToString(),
                    DrawId = int.Parse(dataReader["draw_id"].ToString()),
                    DrawName =dataReader["draw_name"].ToString(),

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
