using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFU.Models.ValidationRules
{
    public class ChangePasswordValidator : AbstractValidator<ChangePassword>
    {
        private readonly IEnumerable<User> _users;
        public ChangePasswordValidator()
        {
            Validation();
        }

        public ChangePasswordValidator(IEnumerable<User> users)
        {
            _users = users;
            Validation();
            RuleFor(model => model.EmailAddress).Must(IsMatchUsernamePassword).WithMessage("Username or Passsword incorrect");
        }

        private void Validation()
        {
            RuleFor(changePassword => changePassword.EmailAddress).NotEmpty().EmailAddress();
            RuleFor(changePassword => changePassword.OldPassword).NotEmpty();
            RuleFor(changePassword => changePassword.NewPassword).NotEmpty();
            RuleFor(changePassword => changePassword.ConfirmPassword).NotEmpty();
            RuleFor(changePassword => changePassword.ConfirmPassword).Equal(changePassword => changePassword.NewPassword);
        }

        public bool IsMatchUsernamePassword(ChangePassword changePassword, string newValue)
        {
            return _users.Any(x => x.EmailAddress == changePassword.EmailAddress && x.Password == changePassword.OldPassword);
        }
    }
}
