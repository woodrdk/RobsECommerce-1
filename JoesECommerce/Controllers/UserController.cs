using JoesECommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JoesECommerce.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Models.RegistrationViewModel Reg)
        {
            if (ModelState.IsValid)
            {
                if (MemberDB.IsUserNameTaken(Reg))
                {
                    ModelState.AddModelError("UserNameTaken", "Username already exists");
                    return View(Reg);
                }
                Member m = new Member()
                {
                    Username = Reg.Username,
                    EmailAddress = Reg.Email,
                    Password = Reg.Password
                };

                MemberDB.AddNewMember(m);
                SessionHelper.LogUserIn(m.Username);
                return RedirectToAction("Index", "Home");
            }
            return View(Reg);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (ModelState.IsValid)
            {
                // query database and check if credentials match
                if (MemberDB.UserExists(login))
                {
                    SessionHelper.LogUserIn(login.Username);
                    return RedirectToAction("Index", "Home");
                }
                // add custom error we cannot find your credentials
                ModelState.AddModelError("InvalidCredentials", "User not found");
            }
            return View(login);
        }


        public ActionResult LogOut()
        {
            SessionHelper.LogUserOut();
            return RedirectToAction("Index", "Home");
        }
    }
}