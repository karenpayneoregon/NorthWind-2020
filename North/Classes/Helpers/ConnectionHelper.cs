using System;
using static System.Configuration.ConfigurationManager;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace North.Classes.Helpers
{
    public class ConnectionHelper
    {
        public static Exception Exception;
        public static async Task<bool> TestConnection()
        {
            var connectionString =
                $"Data Source={AppSettings["DatabaseServer"]};" +
                $"Initial Catalog={AppSettings["NorthWinCatalog"]};" +
                "Integrated Security=True";


            return await Task.Run(async () =>
            {
                using (var cn = new SqlConnection { ConnectionString = connectionString })
                {
                    try
                    {
                        await cn.OpenAsync();
                        return true;

                    }
                    catch (Exception ex)
                    {
                        Exception = ex;
                        return false;
                    }
                }

            });
        }
    }
}
