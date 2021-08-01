using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWindCore.Classes.Helpers
{
    public static class TypeHelpers
    {
        public static string CSharpName(this Type type)
        {
            string typeName = type.Name;

            if (type.IsGenericType)
            {
                var genArgs = type.GetGenericArguments();

                if (!genArgs.Any()) return typeName;
                typeName = typeName.Substring(0, typeName.Length - 2);

                string arguments = "";

                foreach (var argType in genArgs)
                {
                    string argName = argType.Name;

                    if (argType.IsGenericType)
                    {
                        argName = argType.CSharpName();
                    }

                    arguments += argName + ", ";
                }

                typeName = $"{typeName}<{arguments.Substring(0, arguments.Length - 2)}>";
            }

            return typeName;
        }
    }
}
