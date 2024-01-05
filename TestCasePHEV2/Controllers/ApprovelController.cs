using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestCasePHEV2.Contracts;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;
using TestCasePHEV2.Repository;

namespace TestCasePHEV2.Controllers
{
    public class ApprovelController : Controller
    {
        private readonly ApprovelServices _approvalServices;
        public ApprovelController()
        {
            TestCasePHEV2DbContext dbContext = new TestCasePHEV2DbContext();
            _approvalServices = new ApprovelServices(dbContext);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // Create
        [HttpPost]
        public ActionResult Create(Approvel ApprovelDto)
        {
            if (ModelState.IsValid)
            {
                var createdApprovalDto = _approvalServices.CreateApprovel(ApprovelDto);

                if (createdApprovalDto != null)
                {
                    return RedirectToAction("Index"); // Ganti dengan action yang sesuai
                }
            }

            // Handle validation errors
            return View(ApprovelDto); // Ganti dengan view yang sesuai
        }

        [HttpGet]
        public ActionResult TableApprovel()
        {
            var tableApprovel = _approvalServices.GetTableApprovel();
            return View(tableApprovel);
        }
    }
}