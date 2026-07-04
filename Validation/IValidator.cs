using IntelligencePipeline.Models.Reports;
using System;
using System.ComponentModel.DataAnnotations;
namespace IntelligencePipeline.Validation
{
    interface IValidator
    {
        ValidationResult Validate(Report report);
    }
}