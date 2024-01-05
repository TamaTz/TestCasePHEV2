using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;
using TestCasePHEV2.Repository;

namespace TestCasePHEV2.Controllers
{
    public class CompanyController : Controller
    {
        private readonly CompanyServices  _companyServices;

        public CompanyController()
        {
            TestCasePHEV2DbContext _context = new TestCasePHEV2DbContext();
            _companyServices = new CompanyServices(_context);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Company company)
        {
            if (ModelState.IsValid)
            {
                var createdCompanyDto = _companyServices.CreateCompany(company);
                if (createdCompanyDto != null)
                {
                    return RedirectToAction("Index");
                }
            }
            return View(company);
        }

        public ActionResult Index()
        {

            var companies = _companyServices.GetAllCompanies();
            return View(companies);
        }

        [HttpGet]
        public ActionResult ApprovePending()
        {
            var pendingCompanies = _companyServices.GetPendingApprove();
            return View(pendingCompanies);
        }

        [HttpGet]
        public ActionResult ApproveProccess()
        {
            var pendingCompanies = _companyServices.GetProccessApprove();
            return View(pendingCompanies);
        }

        [HttpPost]
        public ActionResult CompanyAccept(string guid)
        {
            var result = _companyServices.CompanyAccept(guid);

            // Handle the result, for example, redirect to Index
            if (result == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle other results, e.g., display an error message
                ViewBag.ErrorMessage = "Failed to accept vendor.";
                return View("Error"); // Create an "Error" view or use a standard error view
            }
        }

        [HttpPost]
        public ActionResult CompanyApprove(string guid)
        {
            var result = _companyServices.CompanyApprove(guid);

            // Handle the result, for example, redirect to Index
            if (result == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                // Handle other results, e.g., display an error message
                ViewBag.ErrorMessage = "Failed to accept vendor.";
                return View("Error"); // Create an "Error" view or use a standard error view
            }
        }

        private string GetRoleGuidFromCookie()
        {
            // Mendapatkan nilai dari cookie "UserRole"
            var userRoleCookie = HttpContext.Request.Cookies["UserRole"];
            return userRoleCookie?.Value;
        }

        public ActionResult GetCompanies()
        {
            var companies = _companyServices.GetCompanies();
            return Json(companies, JsonRequestBehavior.AllowGet);
        }
    }
}