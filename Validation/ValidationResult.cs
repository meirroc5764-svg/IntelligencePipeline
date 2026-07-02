using ReportHierarchy;
using System;
using System.ComponentModel.DataAnnotations;
namespace IntelligencePipeline.Validation
{
    public class ValidationResult
    {
        private readonly bool _isValid;
        private readonly string _errorMessage;

        public bool IsValid => _isValid;
        public string ErrorMessage => _errorMessage;

        public ValidationResult(bool isValid, string errorMessage)
        {
            _isValid = isValid;
            _errorMessage = errorMessage;
        }

        public static ValidationResult Success()
        {
            return new ValidationResult(true, string.Empty);
        }

        public static ValidationResult Failure(string errorMessage)
        {
            return new ValidationResult(false, errorMessage);
        }
    }
}

