using IntelligencePipeline.Models.Reports;
using System;
namespace IntelligencePipeline.Validation
{
    class SoldierValidator : BaseValidator, IValidator
    {
        protected override ValidationResult ValidateSpecificFields(Report report)
        {
            if (report is not SoldierReport soldierReport)
            {
                return ValidationResult.Failure("report is invalid");
            }
            if (soldierReport.SoldierName.Length < 2|| soldierReport.SoldierName.Length > 50)
                return ValidationResult.Failure("soldier Name invalid");

            if (soldierReport.SoldierID.Length != 7)
                return ValidationResult.Failure("soldier Id invalid");

            if (soldierReport.Unit.Length < 2 || soldierReport.Unit.Length > 50)
                return ValidationResult.Failure("unit is invalid");

            if (soldierReport.ConfidenceLevel < 1 || soldierReport.ConfidenceLevel > 5)
                return ValidationResult.Failure("ConfidenceLevel is invalid");
            return ValidationResult.Success();


        }
    }
}
