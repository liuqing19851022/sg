using MJUSS.Infrastructure.Core.Error;
using MJUSS.Infrastructure.Core.Exceptions;
using Orleans;
using System;
using System.Linq;
using System.Threading.Tasks;
using Orleans.Configuration;
using Microsoft.Extensions.Logging;
using MJUSS.Infrastructure.Utils.Helper;
using MJUSS.Infrastructure.Core.Config;
using Orleans.Hosting;
using Orleans.Statistics;
using System.Net;
using MJUSS.Infrastructure.Core.Constants;
using System.Reflection;
using System.Collections.Generic;
using System.IO;

namespace MJUSS.Infrastructure.Utils.Orlelans
{
    public class OrleansClusterClientFactoryBase
    {
        protected IClusterClient clusterClient;
        public string ServerName { get; protected set; }
        //加载的程序集
        private List<Assembly> ApplicationPartAssemblys = null;

        protected OrleansClusterClientFactoryBase(string serverName, List<Assembly> applicationPartAssemblys = null)
        {
            this.ServerName = serverName;
            ApplicationPartAssemblys = applicationPartAssemblys;
        }

        //private bool IsConnecting=false;
        /// <summary>
        /// 获取客户端
        /// </summary>
        /// <returns></returns>
        public IClusterClient GetClusterClient()
        {
            if (clusterClient != null && clusterClient.IsInitialized)
            {
                return clusterClient;
            }
            else
            {                
                throw new BaseValidationException(MJErrorCode.ValidationError.ErrorCode, $"ServerName:{ServerName},请初始化客户端{this.GetType().Name}");
            }
        }           

        /// <summary>
        /// 获取客户端配置文件路径
        /// </summary>
        /// <returns></returns>
        private string GetConfigFilePath()
        {
            return  $"Config{Path.DirectorySeparatorChar}ServiceHostConfig2{Path.DirectorySeparatorChar}{ServerName}ClientConfiguration.xml";
        }
        
        private int attemptCount = 0; //已重试次数
        private int initializeAttemptsBeforeFailing = 3; //最大尝试次数
        private async Task<bool> RetryFilter(Exception exception)
        {            
            Console.WriteLine($"客户端尝试连接 {attemptCount} 次 {initializeAttemptsBeforeFailing} 失败。异常信息: {exception}");
            attemptCount++;            
            if (attemptCount > initializeAttemptsBeforeFailing)
            {
                return false;
            }
            await Task.Delay(TimeSpan.FromSeconds(3));
            return true;
        }

        /// <summary>
        /// 是否正在初始化
        /// </summary>
        private bool IsInitializing = false;
        
        /// <summary>
        /// 初始化配置
        /// </summary>
        /// <param name="configFileName"></param>
        /// <returns></returns>
        public async Task<bool> InitConfig(int MaxRertyTime = 3)
        {
            if(IsInitializing)
            {
                return true;
            }
            IsInitializing = true;
            initializeAttemptsBeforeFailing = MaxRertyTime;
            try
            {
                var siloHostClientConfig = ConfigHandler.GetConfig<SiloHostClientConfig>(GetConfigFilePath());

#if DEBUG
                var ipAddresses = Dns.GetHostAddresses(SysPredefined.OrleansSiloHostName);
                if (ipAddresses.Count() <= 0)
                {
                    throw new Exception("请配置hosts里面的主机：MJOrleans");
                }
                var ipaddr = ipAddresses[0].MapToIPv4().ToString().Replace(".", "");
                var md5IPSiloPortName = $"{ipaddr}_{siloHostClientConfig.ClusterId}";
                siloHostClientConfig.ClusterId = md5IPSiloPortName;
                siloHostClientConfig.ServiceId = md5IPSiloPortName;
#endif
                var ResponseTimeoutSeconds = siloHostClientConfig.ResponseTimeoutSeconds < 10 ? 30 : siloHostClientConfig.ResponseTimeoutSeconds;
                if (clusterClient == null)
                {
                    var clientBuilder = new ClientBuilder()
                        .Configure<ClusterOptions>(options =>
                        {
                            options.ClusterId = siloHostClientConfig.ClusterId;
                            options.ServiceId = siloHostClientConfig.ServiceId;
                        })
                        .UseConsulClustering(options =>
                        {                         
                            options.Address = new Uri(siloHostClientConfig.ConnectionString);
                            options.KvRootFolder = siloHostClientConfig.Invariant;
                        })
                        .Configure<SiloMessagingOptions>(options => options.ResponseTimeout = TimeSpan.FromSeconds(ResponseTimeoutSeconds))
                        //.Configure<SerializationProviderOptions>(options => options.SerializationProviders.Add(typeof(BondSerializer).GetTypeInfo()))
                        .UsePerfCounterEnvironmentStatistics()
                        .ConfigureLogging(builder => builder.SetMinimumLevel((LogLevel)siloHostClientConfig.MinLogLevel).AddConsole());
                    //指定加载程序集和类型
                    if (ApplicationPartAssemblys != null && ApplicationPartAssemblys.Count>0)
                    {
                        foreach (var assembly in ApplicationPartAssemblys)
                        {
                            clientBuilder.ConfigureApplicationParts(parts => parts.AddApplicationPart(assembly).WithReferences());
                        }                        
                    }
                    clusterClient = clientBuilder.Build();
                };


                if (!clusterClient.IsInitialized)
                {
                    await clusterClient.Connect(RetryFilter);
                }
                IsInitializing = false;
            }
            //OrleansException，SiloUnavailableException，InvalidOperationException
            catch (Exception ex)
            {
                IsInitializing = false;
                clusterClient?.Dispose();
                clusterClient = null;
                Console.WriteLine($"{ServerName} { attemptCount}\r\n{ ex.Message}");
                return false;
            }
            return true;
        }

    }
}
