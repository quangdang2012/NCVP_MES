using System;
using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;
using System.Data;

namespace Com.Nidec.Mes.GlobalMasterMaintenance.Dao
{
    class CheckInspectionSpecificationMasterMntDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject arg)
        {

            InspectionSpecificationVo inVo = (InspectionSpecificationVo)arg;

            StringBuilder sql = new StringBuilder();

            //create SQL
            sql.Append("Select Count(*) as InspectionSpecificationCount from m_inspection_specification");
            sql.Append(" where 1 = 1 ");

            if (inVo.InspectionSpecificationCode != null && inVo.Mode != CommonConstants.MODE_UPDATE)
            {
                sql.Append(" and UPPER(inspection_specification_cd) = UPPER(:inspectionspecificationcd)");
            }

            if (inVo.InspectionItemId > 0)
            {
                if (inVo.InspectionSpecificationCode != null && inVo.Mode != CommonConstants.MODE_UPDATE)
                {
                    sql.Append(" or ( ");
                }
                else
                {
                    sql.Append(" and ( ");
                }
                if (inVo.InspectionSpecificationId > 0 && inVo.Mode == CommonConstants.MODE_UPDATE)
                {
                    sql.Append(" inspection_specification_id <> :inspectionspecificationid and ");
                }

                sql.Append(" inspection_item_id = :inspectionitemid and factory_cd = :faccd)");
            }

            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sqlParameter.AddParameterString("faccd", UserData.GetUserData().FactoryCode);

            if (inVo.InspectionSpecificationCode != null && inVo.Mode != CommonConstants.MODE_UPDATE)
            {
                sqlParameter.AddParameterString("inspectionspecificationcd", inVo.InspectionSpecificationCode);
            }

            if (inVo.InspectionItemId > 0)
            {
                if (inVo.InspectionSpecificationId > 0 && inVo.Mode == CommonConstants.MODE_UPDATE)
                {
                    sqlParameter.AddParameterInteger("inspectionspecificationid", inVo.InspectionSpecificationId);
                }
                sqlParameter.AddParameterInteger("inspectionitemid", inVo.InspectionItemId);
            }

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            InspectionSpecificationVo outVo = new InspectionSpecificationVo { AffectedCount = 0 };

            while (dataReader.Read())
            {
                outVo.AffectedCount = Convert.ToInt32(dataReader["InspectionSpecificationCount"]);
            }

            dataReader.Close();

            return outVo;
        }
    }
}
