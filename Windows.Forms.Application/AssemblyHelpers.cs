using System;
using static System.Configuration.ConfigurationManager;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using ExceptionHandling;
using System.Configuration;

namespace Windows.Forms.Application
{
    public class AssemblyHelpers
    {

        /// <summary>
        /// Get last sort column name from config file
        /// </summary>
        /// <returns>Last sort column</returns>
        public static string GetSortColumnName() => AppSettings["SortColumn"];
        /// <summary>
        /// Save last sort column name to config file
        /// </summary>
        /// <param name="value">New value</param>
        public static void SetSortColumn(string value)
        {
            SetValue("SortColumn", value);
        }
        /// <summary>
        /// Get last sort direction from config file
        /// </summary>
        /// <returns>Last sort direction</returns>
        public static string GetSortDirection() => AppSettings["SortDirection"];
        /// <summary>
        /// Save last sort direction to config file
        /// </summary>
        /// <param name="value"></param>
        public static void SetSortDirection(string value)
        {
            SetValue("SortDirection", value);
        }

        /// <summary>
        /// Save database default catalog
        /// </summary>
        /// <param name="value"></param>
        public static void SetDefaultCatalog(string value)
        {
            SetValue("Catalog", value);
        }
        public static string GetDefaultCatalog() => AppSettings["Catalog"];

        /// <summary>
        /// Must be called whenever values are changed as .NET only reads app settings once per session 
        /// </summary>
        public static void Reload()
        {
            RefreshSection("appSettings");
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
                var config = CurrentConfiguration();
                config.AppSettings.Settings[key].Value = value;

                config.Save();
                Reload();

            }
            catch (Exception e)
            {
                Exceptions.Write(e);
            }
        }

        public static Configuration CurrentConfiguration()
        {
            var path = ConfigurationFileName();
            var directory = Path.GetDirectoryName(path);
            var file = Path.GetFileName(path);

            var fileMap = new ExeConfigurationFileMap
            {
                ExeConfigFilename = Path.Combine(Path.GetFullPath(directory + "\\" + file))
            };

            return OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
        }
        /// <summary>
        /// Get calling program 
        /// </summary>
        /// <returns></returns>
        public static string CallingNamespace()
        {
            var currentAssembly = Assembly.GetExecutingAssembly();

            var callerAssemblies = new StackTrace().GetFrames()
                .Select(sf => sf.GetMethod().ReflectedType.Assembly)
                .Distinct()
                .Where(assembly => assembly.GetReferencedAssemblies()
                    .Any(assemblyName => assemblyName.FullName == currentAssembly.FullName));

            return callerAssemblies.Last().Location;
        }
        /// <summary>
        /// Get current executable configuration file name
        /// </summary>
        /// <returns></returns>
        public static string ConfigurationFileName() => $"{CallingNamespace()}.config";
        /// <summary>
        /// Determine if key exists
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyExists(string key) => AppSettings[key] != null;
    }
}
