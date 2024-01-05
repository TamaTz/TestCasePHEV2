using System.Data.Entity;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TestCasePHEV2.Models;
using TestCasePHEV2.Repositories;
using TestCasePHEV2.Repository;
using Unity;
using Unity.Mvc5;

namespace TestCasePHEV2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ConfigureDependencyInjection();
        }

        private void ConfigureDependencyInjection()
        {
            var container = new UnityContainer();
            container.RegisterType<GeneralRepository<Approvel>, ApprovelRepository>();
            container.RegisterType<GeneralRepository<Role>, RoleRepository>();
            container.RegisterType<GeneralRepository<Vendor>, VendorRepository>();
            container.RegisterType<GeneralRepository<Company>, CompanyRepository>();
            container.RegisterType<GeneralRepository<User>, UserRepository>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}
