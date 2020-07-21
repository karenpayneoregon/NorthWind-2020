using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataValidationWindowsForms.Classes
{
    public class EntityValidationResult
    {
        public IList<ValidationResult> Errors { get; set; }

        public bool HasError => Errors.Count > 0;
        public EntityValidationResult(IList<ValidationResult> errors = null)
        {
            Errors = errors ?? new List<ValidationResult>();
        }
    }
}