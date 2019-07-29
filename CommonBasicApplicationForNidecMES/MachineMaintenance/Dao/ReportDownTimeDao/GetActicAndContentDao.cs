using System.Text;
using Com.Nidec.Mes.Framework;
using Com.Nidec.Mes.GlobalMasterMaintenance.Vo;

using System.Data;

namespace Com.Nidec.Mes.Common.Basic.MachineMaintenance.Dao
{
    class GetActicAndContentDao : AbstractDataAccessObject
    {
        public override ValueObject Execute(TransactionContext trxContext, ValueObject vo)
        {
            ProdutionWorkContentVo  inVo = (ProdutionWorkContentVo)vo;
            StringBuilder sql = new StringBuilder();
            ValueObjectList<ProdutionWorkContentVo> voList = new ValueObjectList<ProdutionWorkContentVo>();
            //create command
            DbCommandAdaptor sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //create parameter
            DbParameterList sqlParameter = sqlCommandAdapter.CreateParameterList();
            sql.Append(@"SELECT a.prodution_work_content_id, a.prodution_work_content_name from m_prodution_work_content a left join m_response_machine b on b.prodution_work_content_id = a.prodution_work_content_id left join m_machine c on c.machine_id = b.machine_id where machine_name = :machine_name order by prodution_work_content_id");


            sqlParameter.AddParameterString("machine_name", inVo.ProdutionWorkContentCode);

            sqlCommandAdapter = base.GetDbCommandAdaptor(trxContext, sql.ToString());

            //execute SQL
            IDataReader dataReader = sqlCommandAdapter.ExecuteReader(trxContext, sqlParameter);

            while (dataReader.Read())
            {
                ProdutionWorkContentVo outVo = new ProdutionWorkContentVo
                {
                     ProdutionWorkContentId=int.Parse(dataReader["prodution_work_content_id"].ToString()),
                     ProdutionWorkContentName = dataReader["prodution_work_content_name"].ToString()
                };
                voList.add(outVo);
            }
            dataReader.Close();
            return voList;
        }

    }

}
