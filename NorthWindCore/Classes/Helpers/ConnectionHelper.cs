using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace NorthWindCore.Classes.Helpers
{
    public class ConnectionHelper
    {
        public static Exception Exception;
        public static async Task<bool> TestConnection()
        {


            return await Task.Run(async () =>
            {
                using var cn = new SqlConnection { ConnectionString = "connectionString" };
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
            });
        }
    }
}
