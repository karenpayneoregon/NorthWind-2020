using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationMocked.LanguageExtensions;

namespace ValidationMocked.Validators
{
    /// <summary>
    /// An example for overriding [<see cref="RequiredAttribute"/>
    /// </summary>
    public class CustomRequired : RequiredAttribute
    {
        public override string FormatErrorMessage(string sender) => 
            $"{sender.SplitCamelCase()} is required";
    }
}
