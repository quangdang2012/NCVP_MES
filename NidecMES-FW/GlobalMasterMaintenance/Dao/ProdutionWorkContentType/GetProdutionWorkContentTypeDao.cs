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
    public class GetProdutionWorkContentTypeDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentTypeVo inVo = (ProdutionWorkContentTypeVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProdutionWorkContentTypeVo> voList = new ValueObjectList<ProdutionWorkContentTypeVo>();
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, string.Empty);
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append("select work_content_type_id, work_content_type_cd, work_content_type_name,registration_user_cd,registration_date_time,factory_cd from m_work_content_type");
            sql.Append(" Where 1=1 ");
            if (!String.IsNullOrEmpty(inVo.FactoryCode))
            {
                sql.Append(" and factory_cd = :factory_cd ");
                sqlParameter.AddParameterString("factory_cd", inVo.FactoryCode);
            }
            if (inVo.ProdutionWorkContentTypeId > 0)
            {
                sql.Append(" and work_content_type_id = :prodution_work_content_type_id ");
                sqlParameter.AddParameterInteger("prodution_work_content_type_id", inVo.ProdutionWorkContentTypeId);
            }
            if (!string.IsNullOrEmpty(inVo.ProdutionWorkContentTypeCode))
            {
                sql.Append(" and work_content_type_cd = :prodution_work_content_type_cd ");
                sqlParameter.AddParameterString("prodution_work_content_type_cd", inVo.ProdutionWorkContentTypeCode);
            }
            if (!string.IsNullOrEmpty(inVo.ProdutionWorkContentTypeName))
            {
                sql.Append(" and work_content_type_name = :prodution_work_content_type_name ");
                sqlParameter.AddParameterString("prodution_work_content_type_name", inVo.ProdutionWorkContentTypeName);
            }




            //create command
            //DbCommandAdaptor 
                sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProdutionWorkContentTypeVo outVo = new ProdutionWorkContentTypeVo
                {
                    ProdutionWorkContentTypeCode = dataReader["work_content_type_cd"].ToString(),
                    ProdutionWorkContentTypeId = int.Parse(dataReader["work_content_type_id"].ToString()),
                    ProdutionWorkContentTypeName =dataReader["work_content_type_name"].ToString(),

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
