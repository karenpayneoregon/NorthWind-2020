using System;
using System.Configuration;
using System.IO;
using System.Reflection;
using ExceptionHandling;

namespace DynamicSortByPropertyName.Classes
{
    public class ApplicationSettings
    {
        /// <summary>
        /// Get last sort column name from config file
        /// </summary>
        /// <returns>Last sort column</returns>
        public static string GetSortColumnName() => ConfigurationManager.AppSettings["SortColumn"];
        /// <summary>
        /// Save last sort column name to config file
        /// </summary>
        /// <param name="value"></param>
        public static void SetSortColumn(string value)
        {
            SetValue("SortColumn", value);
        }
        /// <summary>
        /// Get last sort direction from config file
        /// </summary>
        /// <returns>Last sort direction</returns>
        public static string GetSortDirection() => ConfigurationManager.AppSettings["SortDirection"];
        /// <summary>
        /// Save last sort direction to config file
        /// </summary>
        /// <param name="value"></param>
        public static void SetSortDirection(string value)
        {
            SetValue("SortDirection", value);
        }
        /// <summary>
        /// Set a app setting key value
        /// </summary>
        /// <param name="key">Key in app setting</param>
        /// <param name="value">Value for key</param>
        public static void SetValue(string key, string value)
        {
            try
            {
                var applicationDirectoryName = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                // ReSharper disable once AssignNullToNotNullAttribute
                var configFile = Path.Combine(applicationDirectoryName, $"{Assembly.GetExecutingAssembly().GetName().Name}.exe.config");
                var configFileMap = new ExeConfigurationFileMap { ExeConfigFilename = configFile };
                var config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);
                config.AppSettings.Settings[key].Value = value;
                config.Save();

            }
            catch (Exception e)
            {
                Exceptions.Write(e);
            }
        }
        /// <summary>
        /// Must be called whenever values are changed as .NET only reads app settings once per session 
        /// </summary>
        public static void Reload()
        {
            ConfigurationManager.RefreshSection("appSettings");
        }
        /// <summary>
        /// Start fresh reading settings
        /// </summary>
        public static void Fetch()
        {
            Reload();
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        }
    }
}
