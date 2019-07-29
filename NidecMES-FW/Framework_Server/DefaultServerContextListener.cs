using System;
using System.Reflection;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Com.Nidec.Mes.Framework;
namespace Com.Nidec.Mes.Framework_Server
{
    public class DefaultServerContextListener : ServerContextListener
    {
        /// <summary>
        /// instance of this class
        /// </summary>
        private static readonly DefaultServerContextListener instance = new DefaultServerContextListener();

        /// <summary>
        /// initialize CommonLogger
        /// </summary>
        private static readonly CommonLogger logger = CommonLogger.GetInstance(typeof(DefaultServerContextListener));

        /// <summary>
        ///  get message data
        /// </summary>
        private static MessageData messageData;

        /// <summary>
        /// private constructor
        /// </summary>
        private DefaultServerContextListener()
        {
        }

        /// <summary>
        /// returns the current instance 
        /// </summary>
        /// <returns></returns>
        public static DefaultServerContextListener GetInstance()
        {
            return instance;
        }

        /// <summary>
        /// Initialize cbmcontroller list
        /// </summary>
        public void Init(string assemblyname)
        {
            //Server initialization
            DefaultServerApplicationInitializer.GetInstance().Init();


            CbmContainer cbmContainer = DefaultXmlCbmContainer.GetInstance();
            cbmContainer.Init(assemblyname);



            //service register
            RegisterServiceReceiver();

        }




        /// <summary>
        /// register cbm receiver
        /// </summary>
        /// <returns></returns>
        private void RegisterServiceReceiver()
        {
            TcpChannel channel = new TcpChannel(Convert.ToInt32(ServerConfigurationDataTypeEnum.DEFAULT_REMOTE_MES_SERVER_HOST_PORT.GetValue()));

            if (channel == null)
            {
                //message channel is null
                //Console.WriteLine(Properties.Resources.fsce00019.ToString());
                messageData = new MessageData("fsce00019", Properties.Resources.fsce00019);
                logger.Info(messageData);

                return;
            }


            if (!IsChannelRegistered(channel))
            {
                //message channel is not registered
                //Console.WriteLine(Properties.Resources.fsce00020.ToString());
                messageData = new MessageData("fsce00020", Properties.Resources.fsce00020);
                logger.Info(messageData);

                return;

            }

            try
            {
                //DEFAULT_REMOTE_MES_SERVER_DEFAULT_PROXY_CLASSNAME
                //DEFAULT_REMOTE_MES_SERVER_DEFAULT_SERVICE_NAME



                RemotingConfiguration.RegisterWellKnownServiceType(
                                    typeof(DefaultRemoteCbmInvokerProxy),
                                    Properties.Settings.Default.DEFAULT_REMOTE_MES_SERVER_DEFAULT_SERVICE_NAME,
                                    WellKnownObjectMode.Singleton);

                RemotingConfiguration.CustomErrorsMode = CustomErrorsModes.Off;
                RemotingConfiguration.CustomErrorsEnabled(false);

                //register 2015 service
                messageData = new MessageData("fsci00007", Properties.Resources.fsci00007);
                logger.Info(messageData);

                // Console.WriteLine(Properties.Resources.fsci00004.ToString());
                messageData = new MessageData("fsci00004", Properties.Resources.fsci00004);
                logger.Info(messageData);

            }
            catch (System.Security.SecurityException exception)
            {
                //log exception
                messageData = new MessageData("fsce00022", Properties.Resources.fsce00022, exception.Message);
                logger.Info(messageData);

                return;
            }

        }


        /// <summary>
        /// register the channel
        /// </summary>
        /// <param name="channel"></param>
        /// <returns></returns>
        private static bool IsChannelRegistered(TcpChannel channel)
        {
            try
            {
                ChannelServices.RegisterChannel(channel, false); //Register channel

                // Console.WriteLine(Properties.Resources.fsci00003.ToString());
                messageData = new MessageData("fsci00003", Properties.Resources.fsci00003);
                logger.Info(messageData);

                return true;
            }
            catch (ArgumentNullException exception)
            {
                //log exception
                messageData = new MessageData("fsce00018", Properties.Resources.fsce00018, exception.Message);
                logger.Info(messageData);
            }
            catch (RemotingException exception)
            {
                //log exception
                messageData = new MessageData("fsce00018", Properties.Resources.fsce00018, exception.Message);
                logger.Info(messageData);
            }
            catch (System.Security.SecurityException exception)
            {
                //log exception
                messageData = new MessageData("fsce00018", Properties.Resources.fsce00018, exception.Message);
                logger.Info(messageData);
            }
            catch (NotSupportedException exception)
            {
                //log exception
                messageData = new MessageData("fsce00018", Properties.Resources.fsce00018, exception.Message);
                logger.Info(messageData);
            }

            return false;
        }
    }
}
