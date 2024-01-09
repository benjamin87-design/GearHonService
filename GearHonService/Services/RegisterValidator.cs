using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GearHonService.Services
{
	public class RegisterValidator : AbstractValidator<RegisterViewModel>
	{
		public RegisterValidator()
		{
			RuleFor(vm => vm.Email)
				.NotEmpty().WithMessage("Email is required")
				.EmailAddress().WithMessage("Invalid email address");

			RuleFor(vm => vm.Password)
				.NotEmpty().WithMessage("Password is required")
				.MinimumLength(8).WithMessage("Password must be at least 8 characters long")
				.MaximumLength(15).WithMessage("Password cannot exceed 15 characters")
				.Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,15}$")
				.WithMessage("Password must contain at least one uppercase letter, one lowercase letter, one number, and one special character");

			RuleFor(vm => vm.ConfirmPassword)
				.Equal(vm => vm.Password).WithMessage("Passwords do not match");
		}
	}
}