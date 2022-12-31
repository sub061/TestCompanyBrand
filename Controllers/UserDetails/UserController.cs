using CompanyBranding.Repositary;
using CompanyBranding.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CompanyBranding.Controllers.UserDetails
{
    [HandleError]
    public class UserController : Controller
    {
        private readonly UserRepo _userRepo;
        private readonly CustomerRepo _customerRepo;

        public UserController() : this(new UserRepo() , new CustomerRepo())
        {
        }
        public UserController(UserRepo userRepo , CustomerRepo customerRepo)
        {
            _userRepo = userRepo;
            _customerRepo = customerRepo;
        }

        // GET: User
       
        public ActionResult Index()
        {
            var _email = Session["useremail"];
            if (_email == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["useremail"] = _email;
                var model = _userRepo.GetDetails();
                return View(model);
            }
        }
     
        public ActionResult Edit(Guid id)
        {
            var _email = Session["useremail"];
            if (_email == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["useremail"] = _email;
                var model = _userRepo.GetDetailById(id);
                return View(model);
            }

            
        }
      
        public ActionResult Update(CustomViewModel customerVM)
        {
                
            var _email = Session["useremail"];
            if (_email == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["useremail"] = _email;
                _customerRepo.PutCustomer(customerVM);
                return RedirectToAction("Index");
            }

        }

        public ActionResult Details( Guid id)
        {
           
            var _email = Session["useremail"];
            if (_email == null)
            {
                return RedirectToAction("Index", "Login");
            }
            else
            {
                ViewData["useremail"] = _email;
                var model = _userRepo.GetDetailById(id);
                return View(model);
            }
        }
    }
}