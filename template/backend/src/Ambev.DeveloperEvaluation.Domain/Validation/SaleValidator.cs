using Ambev.DeveloperEvaluation.Domain.Entities.Sale;
using FluentValidation;
using System.Globalization;

namespace Ambev.DeveloperEvaluation.Domain.Validation
{
    public class SaleValidator : AbstractValidator<Sale>
    {
        public SaleValidator()
        {
            RuleFor(sale => sale.SaleNumber)
                .NotEmpty()
                .Matches(@"^ABV_\d{8}\d{6}_\d{5}")
                .WithMessage("Sale number must start with 'ABV_' followed by date and time that it was created "
                            + "corresponding to the pattern yyyyMMddHHmmss and followed by "
                            + @"_\d5")
                .Must(IsValidDateTime)
                .WithMessage("Sale number contains an invalid date.")
                .Length(Constants.Constants.SaleNumberMaxLength)
                .WithMessage("Sale number must have "
                            + Constants.Constants.SaleNumberMaxLength
                            + " characters.");

            RuleFor(sale => sale.CustomerName)
                .NotEmpty()
                .WithMessage("Customer name must not be empty.");

            RuleFor(sale => sale.TotalAmount)
                .GreaterThanOrEqualTo(0m)
                .WithMessage("Total amount must be greater than or equal to 0.0.");

            RuleFor(sale => sale.BranchName)
                .NotEmpty()
                .WithMessage("Branch name must not be empty.");
        }
        private static bool IsValidDateTime(string saleNumber)
        {
            var dateTimePart = saleNumber.Substring(4, 14);

            // Try to parse it into a valid DateTime object
            return DateTime.TryParseExact(
                dateTimePart,
                "yyyyMMddHHmmss",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out _);
        }
    }
}
