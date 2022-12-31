using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyBranding.Models;
using CompanyBranding.Repositary;

namespace CompanyBranding.Controllers.Login
{
    public class LoginController : Controller
    {
        private readonly UserRepo _userRepo;

        public LoginController() : this(new UserRepo())
        {
        }
        public LoginController(UserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        public ActionResult Index()
        {
          
                return View();

        }
        // GET: Login
        public ActionResult Post(User _user)
        {


            var _result = _userRepo.GetUser(_user);
            Session["useremail"] = _result.email;
            Session["id"] = _result.id;
           
            if(_result!= null)
            {
                return RedirectToAction("Index" ,"User");
            }
            else
            {
                return View("Index");
            }
            
        }
    }
}