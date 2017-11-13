using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MFU.Models.ValidationRules
{
    public class RecoveryPasswordValidator : AbstractValidator<RecoveryPassword>
    {
        private readonly IEnumerable<User> _users;
        public RecoveryPasswordValidator()
        {
            Validation();
        }

        public RecoveryPasswordValidator(IEnumerable<User> users)
        {
            _users = users;
            Validation();
            RuleFor(model => model.EmailAddress).Must(IsMatchUsername).WithMessage("Username incorrect");
        }

        private void Validation()
        {
            RuleFor(recoveryPassword => recoveryPassword.EmailAddress).NotEmpty().EmailAddress();
        }

        public bool IsMatchUsername(RecoveryPassword recoveryPassword, string newValue)
        {
            return _users.Any(x => x.EmailAddress == recoveryPassword.EmailAddress);
        }
    }
}

