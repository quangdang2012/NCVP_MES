using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetInvertoryTimeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            InvertoryVo inVo = (InvertoryVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<InvertoryVo> voList = new ValueObjectList<InvertoryVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select invertory_time_id, invertory_time_cd, invertory_time_name, registration_user_cd,registration_date_time,factory_cd from  m_invertory_time");
            sql.Append(" Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.InvertoryTimeId > 0)
            {
                sql.Append(" and invertory_time_id = :invertory_time_id ");
                sqlParameter.AddParameterInteger("invertory_time_id", inVo.InvertoryTimeId);
            }
            if (!string.IsNullOrEmpty(inVo.InvertoryTimeCode))
            {
                sql.Append(" and invertory_time_cd = :invertory_time_cd ");
                sqlParameter.AddParameterString("invertory_time_cd", inVo.InvertoryTimeCode);
            }
            if (!string.IsNullOrEmpty(inVo.InvertoryTimeName))
            {
                sql.Append(" and invertory_time_name = :invertory_time_name ");
                sqlParameter.AddParameterString("invertory_time_name", inVo.InvertoryTimeName);
            }

            sql.Append(" order by invertory_time_id desc ");
            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                InvertoryVo outVo = new InvertoryVo
                {
                    InvertoryTimeCode = dataReader["invertory_time_cd"].ToString(),
                    InvertoryTimeId = int.Parse(dataReader["invertory_time_id"].ToString()),
                    InvertoryTimeName = dataReader["invertory_time_name"].ToString(),

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
