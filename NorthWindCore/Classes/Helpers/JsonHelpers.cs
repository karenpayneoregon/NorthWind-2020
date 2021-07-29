using System.Collections.Generic;
using Newtonsoft.Json;

namespace NorthWindCore.Classes.Helpers
{
    public class JsonHelpers
    {
        public static string Serialize<T>(List<T> sender)
        {
            return JsonConvert.SerializeObject(sender);
        }
    }
}
