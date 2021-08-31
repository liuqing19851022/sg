using System;
using System.IO;
using System.Xml.Serialization;

using MJUSS.Infrastructure.Utils.Caches;
using Microsoft.Extensions.Configuration;
namespace MJUSS.Infrastructure.Utils.Helper
{
    /// <summary>
    ///     配置文件处理类
    /// </summary>
    public static class ConfigHandler
    {
        public static T GetConfig<T>() where T : class
        {
            string defaultFilePath = Path.Combine("Config",$"{typeof(T).FullName}.config");
            return GetConfig<T>(defaultFilePath);
        }

        public static IConfigurationRoot BuildConfig<T>(string path = "~/Config") where T : class
        {
            string configName = $"{typeof(T).Name}.config";
            var filePath = GetMapPath(path);
            var configBuilder = new ConfigurationBuilder();
            configBuilder.SetBasePath(filePath);
            configBuilder.AddXmlFile(configName, false, true);
            var configuration = configBuilder.Build();
            return configuration;
        }

        public static IConfigurationRoot BuildJsonConfig<T>(string path = "~/Config") where T : class
        {
            string configName = $"{typeof(T).Name}.json";
            var filePath = GetMapPath(path);
            var configBuilder = new ConfigurationBuilder();
            configBuilder.SetBasePath(filePath);
            configBuilder.AddJsonFile(configName, false, true);
            var configuration = configBuilder.Build();
            return configuration;
        }


        /// <summary>
        ///     返回配置对象
        /// </summary>
        /// <param name="configFilePath">配置文件路径</param>
        /// <returns>配置对象</returns>
        public static T GetConfig<T>(string configFilePath) where T : class
        {
            var filePath = GetMapPath(configFilePath);
            var cacheKey = filePath;
            return MemoryCacheProvider.GetOrInsert<T>(cacheKey, filePath);            
        }

        /// <summary>
        ///     保存配置文件
        /// </summary>
        public static void Save<T>(T t, string configFilePath)
        {
            if (!Path.IsPathRooted(configFilePath))
            {
                configFilePath = GetMapPath(configFilePath);
            }
            var dirPath = Path.GetDirectoryName(configFilePath);
            if (dirPath != null && !Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            if (!File.Exists(configFilePath))
            {
                File.Create(configFilePath).Close();;
            }
            var xmlSerializer = new XmlSerializer(typeof(T));
            using var writer = new StreamWriter(configFilePath, false);
            xmlSerializer.Serialize(writer, t);
        }         

        public static string GetMapPath(string strPath)
        {            
            if (strPath.StartsWith("~"))
            {
                strPath = strPath.Substring(1);
            }
            strPath = strPath.Replace('/', Path.DirectorySeparatorChar);
            if (strPath.StartsWith(Path.DirectorySeparatorChar))
            {
                strPath = strPath.Substring(1);
            }
            var dir = AppContext.BaseDirectory;
            return Path.Combine(dir, strPath);
        }
    }
}