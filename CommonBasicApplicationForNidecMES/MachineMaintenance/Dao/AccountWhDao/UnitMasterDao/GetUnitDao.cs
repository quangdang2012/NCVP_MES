using Com.Nidec.Mes.Common.Basic.MachineMaintenance.Vo.AccountWhVo;
using Com.Nidec.Mes.Framework;
using System;
using System.Data;
using System.Text;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    public class GetUnitDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            UnitVo inVo = (UnitVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<UnitVo> voList = new ValueObjectList<UnitVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select unit_id, unit_cd, unit_name, registration_user_cd,registration_date_time,factory_cd from  m_unit");
            sql.Append(" Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.UnitId > 0)
            {
                sql.Append(" and unit_id = :unit_id ");
                sqlParameter.AddParameterInteger("unit_id", inVo.UnitId);
            }
            if (!string.IsNullOrEmpty(inVo.UnitCode))
            {
                sql.Append(" and unit_cd = :unit_cd ");
                sqlParameter.AddParameterString("unit_cd", inVo.UnitCode);
            }
            if (!string.IsNullOrEmpty(inVo.UnitName))
            {
                sql.Append(" and unit_name = :unit_name ");
                sqlParameter.AddParameterString("unit_name", inVo.UnitName);
            }
           

            //create command
            //DbCommandAdaptor 
            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                UnitVo outVo = new UnitVo
                {
                    UnitCode = dataReader["unit_cd"].ToString(),
                    UnitId = int.Parse(dataReader["unit_id"].ToString()),
                    UnitName =dataReader["unit_name"].ToString(),

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
