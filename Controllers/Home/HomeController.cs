using CompanyBranding.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompanyBranding.Repositary;

namespace CompanyBranding.Controllers.Home
{
    [HandleError]
    public class HomeController : Controller
    {
        // GET: Home

        private readonly CustomerRepo _customerRepo;

        public HomeController(): this(new CustomerRepo())
        { 
        }
        public HomeController(CustomerRepo customerRepo)
        {
            _customerRepo = customerRepo;
        }
        public ActionResult Index()
        {

            CustomViewModel customViewModel = new CustomViewModel();
            customViewModel.record = _customerRepo.GetRecord();
            return View(customViewModel);
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Index(CustomViewModel _customerVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bool status = _customerRepo.PostCustomer(_customerVM);
                    return RedirectToAction("ThankYou");
                }

                else
                {
                    var errors = ModelState.Select(x => x.Value.Errors)
                             .Where(y => y.Count > 0)
                             .ToList();
                    return View(_customerVM);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public ActionResult ThankYou()
        {
            return View();
        }

        public ActionResult User(Guid userId)
        {
            return View();
        }
    }
}