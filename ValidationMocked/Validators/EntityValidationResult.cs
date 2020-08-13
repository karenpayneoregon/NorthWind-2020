using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidationMocked.Validators
{
    public class EntityValidationResult
    {
        public IList<ValidationResult> Errors { get; set; }

        public bool HasError => Errors.Count > 0;
        public EntityValidationResult(List<ValidationResult> errors = null)
        {
            Errors = errors ?? new List<ValidationResult>();
        }
    }
}