using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.RegularExpressions;
using ValidationMocked.LanguageExtensions;

namespace ValidationMocked.Validators
{
    public static class ValidatorExtensions
    {
        public static string SanitizedErrorMessage(this ValidationResult sender)
        {
            return Regex.Replace(sender.ErrorMessage.SplitCamelCase(), " {2,}", " ").Replace(" .",".");
        }

        public static string ErrorMessageList(this EntityValidationResult sender)
        {

            var sb = new StringBuilder();
            sb.AppendLine("Validation issues");

            foreach (var errorItem in sender.Errors)
            {
                sb.AppendLine(errorItem.SanitizedErrorMessage());
            }

            return sb.ToString();

        }

    }
}
