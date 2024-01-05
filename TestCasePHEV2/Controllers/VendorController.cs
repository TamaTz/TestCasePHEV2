using System.Linq;
using System.Web.Mvc;
using TestCasePHEV2.Data;
using TestCasePHEV2.Models;
using TestCasePHEV2.Repository;

namespace TestCasePHEV2.Controllers
{
    public class VendorController : Controller
    {
        private readonly VendorServices _vendorService;

        public VendorController()
        {
            TestCasePHEV2DbContext dbContext = new TestCasePHEV2DbContext();
            _vendorService = new VendorServices(dbContext);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Vendor vendorDto)
        {
            if (ModelState.IsValid)
            {
                var createdVendorDto = _vendorService.CreateVendor(vendorDto);

                if (createdVendorDto != null)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(vendorDto);
        }

        public ActionResult Index()
        {
            var vendors = _vendorService.GetAllVendor();
            return View(vendors); // Ganti dengan view yang sesuai
        }
    }
}