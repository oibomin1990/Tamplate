using MFU.Models;
using MFU.Models.ValidationRules;
using MFU.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MFU.WebAPI.Controllers
{
    public class RecoveryPasswordController : BaseController
    {
        private List<User> users = new List<User>() {
                                                  new User  {
                                                        UserId= 3001,
                                                        FullName= "Liz Lemon",
                                                        EmailAddress= "test@test.com",
                                                        Password= "Password1"
                                                      },
                                                  new User {
                                                        UserId= 3002,
                                                        FullName= "Jack Donaghy",
                                                        EmailAddress= "jack.donaghy@example.com",
                                                        Password= "Password1"
                                                  },
                                                  new User {
                                                        UserId= 3003,
                                                        FullName= "Tracy Jordan",
                                                        EmailAddress= "tracy.jordan@example.com",
                                                        Password= "Password1"
                                                  }
                                                };
        // GET: RecoveryPassword
        public ActionResult Index()
        {
            var changePassword = new ChangePassword();
            changePassword.EmailAddress = "test@test.com";
            return View(changePassword);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(ChangePassword changePassword)
        {

            ValidateModel<ChangePassword>(changePassword, new ChangePasswordValidator(users));

            if (ModelState.IsValid)
            {
                //do on business logic and repository
                var user = users.FirstOrDefault(x => x.EmailAddress == changePassword.EmailAddress && x.Password == changePassword.OldPassword);
                user.Password = changePassword.NewPassword;
                //Email.Send("test@test.com", "Recovery Password", "new password");
                return RedirectToAction("Index");
            }

            return View(changePassword);
        }

        public ActionResult RecoveryPassword()
        {
            var recoveryPassword = new RecoveryPassword();
            return View(recoveryPassword);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecoveryPassword(RecoveryPassword recoveryPassword)
        {
            ValidateModel<RecoveryPassword>(recoveryPassword, new RecoveryPasswordValidator(users));

            if (ModelState.IsValid)
            {
                //do on business logic and repository
                var user = users.FirstOrDefault(x => x.EmailAddress == recoveryPassword.EmailAddress);
                //Email.Send("test@test.com", "Recovery Password", user.Password);
                return RedirectToAction("RecoveryPassword");
            }

            return View(recoveryPassword);
        }
    }
}