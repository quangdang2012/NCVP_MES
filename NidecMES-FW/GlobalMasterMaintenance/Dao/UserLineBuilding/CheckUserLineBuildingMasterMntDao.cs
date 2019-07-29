using System;
using System.Text;
using System.Data;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    public class CheckUserLineBuildingMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {
            UserLineBuildingVo inVo = (UserLineBuildingVo)arg;

            StringBuilder sqlQuery = new StringBuilder();

            sqlQuery.Append("Select Count(*) as UserLineBuildingCount from m_user_line_building");
            sqlQuery.Append(" where factory_cd = :faccd ");

            if (inVo.LineBuildingId  >= 0)
            {
                sqlQuery.Append(" and line_building_id = :linebuildingid");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sqlQuery.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.LineBuildingId >= 0)
            {
                sqlParameter.AddParameterInteger("linebuildingid", inVo.LineBuildingId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            UserLineBuildingVo outVo = new UserLineBuildingVo();

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["UserLineBuildingCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
