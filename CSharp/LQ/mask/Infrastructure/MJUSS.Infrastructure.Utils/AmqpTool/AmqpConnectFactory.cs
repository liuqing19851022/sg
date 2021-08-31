using Amqp;
using Amqp.Sasl;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MJUSS.Infrastructure.Core.Config;
using MJUSS.Infrastructure.Core.Error;
using Orleans.Runtime;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MJUSS.Infrastructure.Utils.AmqpTool
{
    public class AmqpConnectFactory : IAmqpConnectFactory
    {
        private Connection connection;
        private IOptionsMonitor<AliIotConfig> aliIotConfig;
        private string clientID;
        private ILoggerFactory loggerFactory;
      
        public AmqpConnectFactory(IOptionsMonitor<AliIotConfig> aliIotConfig, ILoggerFactory loggerFactory)
        {
            this.aliIotConfig = aliIotConfig;
            clientID = Guid.NewGuid().ToString("N");
            this.loggerFactory = loggerFactory;
        }

        public async Task<Connection> GetConnection(string amqpConsumerGroupId)
        {
            if(connection != null && !connection.IsClosed)
            {
                return connection;
            }
            clientID = Guid.NewGuid().ToString("N");
            var timestamp = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            var userName = await GetUserName(timestamp, amqpConsumerGroupId);
            var password = await GetPassword(timestamp);
            var address = new Address(aliIotConfig.CurrentValue.AmqpUrl, aliIotConfig.CurrentValue.AmqpPort, userName, password);
            var connectionFactory = new ConnectionFactory();
            //如果需要，使用本地TLS。
            //cf.SSL.ClientCertificates.Add(GetCert());
            //cf.SSL.RemoteCertificateValidationCallback = ValidateServerCertificate;
            connectionFactory.SASL.Profile = SaslProfile.External;
            connectionFactory.AMQP.IdleTimeout = 300000;
            //cf.AMQP.ContainerId、cf.AMQP.HostName请自定义。
            connectionFactory.AMQP.ContainerId = "client.1.2";
            connectionFactory.AMQP.HostName = "mjzhcl.com";
            connectionFactory.AMQP.MaxFrameSize = 8 * 1024;
            connection = await connectionFactory.CreateAsync(address);

            connection.Closed += Connection_Closed;
            return connection;
        }

        private void Connection_Closed(IAmqpObject sender, Amqp.Framing.Error error)
        {
            loggerFactory.CreateLogger(this.GetType().FullName).Error(MJErrorCode.Exception.ErrorCode, $"amqp连接断开, {error.ToString()}");
        }

        private Task<string> GetUserName(long timestamp, string amqpConsumerGroupId)
        {
            //userName组装方法，请参见AMQP客户端接入说明文档。
            string userName = $"{clientID}|authMode=aksign,signMethod=hmacmd5,consumerGroupId={amqpConsumerGroupId},iotInstanceId={aliIotConfig.CurrentValue.IotInstanceId},authId={aliIotConfig.CurrentValue.AccessKeyId},timestamp={timestamp}|";
            return Task.FromResult(userName);

        }

        private async Task<string> GetPassword(long timestamp)
        {
            var param = await GetParam(timestamp);
            //计算签名，password组装方法，请参见AMQP客户端接入说明文档。
            string password = await Sign(param, aliIotConfig.CurrentValue.AcessKeySecret);
            return password;
        }

        private Task<string> GetParam(long timestamp)
        {

            string param = $"authId={aliIotConfig.CurrentValue.AccessKeyId}&timestamp={timestamp}";
            return Task.FromResult(param);
        }

        private Task<string> Sign(string param, string accessSecret)
        {
            byte[] key = Encoding.UTF8.GetBytes(accessSecret);
            byte[] signContent = Encoding.UTF8.GetBytes(param);
            var hmac = new HMACMD5(key);
            byte[] hashBytes = hmac.ComputeHash(signContent);
            return Task.FromResult(Convert.ToBase64String(hashBytes));
        }
    }
}
