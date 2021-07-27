using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace North.Classes.Helpers
{
    public class JsonHelpers
    {
        public static string Serialize<T>(List<T> sender)
        {
            return JsonConvert.SerializeObject(sender);
        }
    }
}
