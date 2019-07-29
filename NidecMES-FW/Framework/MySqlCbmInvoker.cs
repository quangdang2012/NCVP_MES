using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace Com.Nidec.Mes.Framework
{
    public class MySqlCbmInvoker
    {

        /// <summary>
        /// get the instance of CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(MySqlCbmInvoker));

        /// <summary>
        /// get the instance of DefaultTransactionContextFactory
        /// </summary>
        private static readonly TransactionContextFactory defaultTrxFactory = new DefaultTransactionContextFactory();

        /// <summary>
        /// executing transaction 
        /// </summary>
        /// <param name="cbm">cbm  to be executed</param>
        /// <param name="vo">input vo for the cbm</param>
        /// <returns>output vo will be returned/ exception will be thrown for error cases</returns>
        public static ValueObject Invoke(CbmController cbm, ValueObject vo)
        {

            string connectionString = ConfigurationDataTypeEnum.CONNECTION_STRING.GetValue();

            return Invoke(cbm, vo, connectionString);

        }

        /// <summary>
        /// invoking transaction for execution
        /// </summary>
        /// <param name="cbm">cbm instance to be executed</param>
        /// <param name="vo">input vo for the cbm</param>
        /// <param name="connectionString">connectionstring of thedb in which cbm to be execute</param>
        /// <exception cref="System.NullReferenceException">NullReferenceException has been thrown as system exception in case of connectionstring is null</exception>
        /// <returns>output vo will be returned/ exception will be thrown for error cases</returns>
        public static ValueObject Invoke(CbmController cbm, ValueObject vo, string connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString))
            {
                MessageData messageData = new MessageData("ffce00040", Properties.Resources.ffce00040);
                logger.Error(messageData, new NullReferenceException());
                throw new SystemException(messageData, new NullReferenceException());
            }

            return Invoke(cbm, vo, null, defaultTrxFactory, connectionString);

        }

        /// <summary>
        /// invoking and executing transaction using userdata and transaxtioncontextfacctory
        /// </summary>
        /// <param name="cbm">cbm  to be executed</param>
        /// <param name="vo">input vo for the cbm</param>
        /// <param name="userData">userdata</param>
        /// <param name="trxFactory">TransactionContextFactory to get transactioncontext using userdata</param>
        /// <returns>output vo will be returned / exception will be thrown for error cases</returns>
        public static ValueObject Invoke(CbmController cbm, ValueObject vo, UserData userData, TransactionContextFactory trxFactory)
        {

            string connectionString = ConfigurationDataTypeEnum.CONNECTION_STRING.GetValue();

            return Invoke(cbm, vo, userData, trxFactory, connectionString);

        }


        /// <summary>
        /// executing transaction 
        /// </summary>
        /// <param name="cbm">cbm  to be executed</param>
        /// <param name="vo">input vo for the cbm</param>
        /// <param name="userData">userdata</param>
        /// <param name="trxFactory">TransactionContextFactory to get transactioncontext using userdata</param>
        /// <param name="connectionString">connectionString for connecting with another database</param>
        /// <exception cref="Com.Nidec.Mes.Framework.ApplicationException">application exception handled in cbm access and cbm invoke</exception>
        /// <exception cref="Com.Nidec.Mes.Framework.SystemException">system exception handled in cbm access and cbm invoke</exception>
        /// <exception cref="System.Exception">Unhandled exception occured has been thrown as system exception in cbm access and cbm invoke</exception>
        /// <returns>output vo will be returned / exception will be thrown for error cases</returns>
        internal static ValueObject Invoke(CbmController cbm, ValueObject vo, UserData userData, TransactionContextFactory trxFactory, string connectionString)
        {

            if (cbm == null)
            {

                MessageData messageData = new MessageData("ffce00041", Properties.Resources.ffce00041, System.Reflection.MethodBase.GetCurrentMethod().Name);
                logger.Error(messageData, new NullReferenceException());
                throw new SystemException(messageData, new NullReferenceException());

            }

            if (trxFactory == null)
            {
                //please write code here
                defaultTrxFactory.GetTransactionContext(userData);
                trxFactory = defaultTrxFactory;
            }


            IDbTransaction dbTransaction = null;
            IDbConnection connection = null;
            //Get TransactionContext
            TransactionContext trxContext = trxFactory.GetTransactionContext(userData);

            try
            {

                connection = new MySqlConnection(connectionString);

                trxContext.DbConnection = connection;
                trxContext.DbConnection.Open();

                dbTransaction = trxContext.DbConnection.BeginTransaction();

                //Start transaction
                ValueObject returnedVo = cbm.Execute(trxContext, vo);

                //commit
                dbTransaction.Commit();

                return returnedVo;

            }
            catch (ApplicationException appEx)
            {

                //rollback
                DbTransactionRollback(dbTransaction);

                MessageData messageData = new MessageData("ffce00042", Properties.Resources.ffce00042, appEx.Message);
                logger.Error(messageData, appEx);

                throw appEx; //throw original app exception

            }
            catch (SystemException sysEx)
            {
                //rollback
                DbTransactionRollback(dbTransaction);

                MessageData messageData = new MessageData("ffce00043", Properties.Resources.ffce00043, sysEx.Message);
                logger.Error(messageData, sysEx);

                throw sysEx; //throw original sys exception
            }
            catch (Exception Ex)
            {

                //rollback
                DbTransactionRollback(dbTransaction);

                MessageData messageData = new MessageData("ffce00044", Properties.Resources.ffce00044, Ex.Message);
                logger.Error(messageData, Ex);

                throw new SystemException(messageData, Ex); //throw original exception as sys exception
            }
            finally
            {

                try
                {
                    if (connection != null) connection.Close();
                }
                catch (Exception ex)
                {
                    //need to be implemented
                    MessageData messageData = new MessageData("ffce00045", Properties.Resources.ffce00045, ex.Message);
                    logger.Error(messageData, ex);

                    throw new SystemException(messageData, ex); //throw original exception as sys exception
                }
            }
        }

        /// <summary>
        /// rollback transaction in exception
        /// </summary>
        /// <param name="dbTransaction">IDbTransaction to be rollback</param>
        /// <exception cref="System.InvalidOperationException">logging the InvalidOperationException occured when rollback the transaction</exception>
        /// <exception cref="System.Exception">logging the Exception occured when rollback the transaction</exception>
        private static void DbTransactionRollback(IDbTransaction dbTransaction)
        {
            if (dbTransaction == null) return; //do nothing

            try
            {
                dbTransaction.Rollback();
            }
            catch (InvalidOperationException InvalidEx)
            {
                MessageData messageData = new MessageData("ffce00046", Properties.Resources.ffce00046, InvalidEx.Message);
                logger.Error(messageData, InvalidEx); //only logging
            }
            catch (Exception Ex)
            {
                MessageData messageData = new MessageData("ffce00047", Properties.Resources.ffce00047, Ex.Message);
                logger.Error(messageData, Ex); //only logging

            }

        }
    }
}
