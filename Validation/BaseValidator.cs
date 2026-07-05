using IntelligencePipeline.Models.Reports;
using System;
using System.ComponentModel.DataAnnotations;
namespace IntelligencePipeline.Validation
{
    
    abstract class BaseValidator : IValidator
    {
        DateTime my_date = new DateTime(2020, 01, 01);
        public ValidationResult Validate(Report report)
        {
            ValidationResult my_chek = ValidateCommonFields(report);
            if (!my_chek.IsValid)
                return my_chek;
            return ValidateSpecificFields(report);
        }
        protected ValidationResult ValidateCommonFields(Report report)
        {
            if (report.Timestamp > DateTime.Now)
                return ValidationResult.Failure("date time in futere not posseble");
            if (report.Timestamp < my_date)
                return ValidationResult.Failure("date time not valide");
            if (report.Latitude < 29.5000 && report.Latitude > 33.5000)
                return ValidationResult.Failure("Latitude not valide");
            if(report.Longitude < 34.0000 &&  report.Longitude > 36.0000)
                return ValidationResult.Failure("Longitude not valide");
            if (string.IsNullOrWhiteSpace(report.Description) ||report.Description.Length < 10 || report.Description.Length > 500)
            {
                return ValidationResult.Failure("Description invalid");
            }
            return ValidationResult.Success();
        }
        protected abstract ValidationResult ValidateSpecificFields(Report report);
    }
}