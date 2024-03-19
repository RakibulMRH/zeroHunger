using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using zeroHunger.Mappings;

namespace zeroHunger
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private static IMapper _mapper;

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DetailProfile>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        public static IMapper Mapper
        {
            get
            {
                return _mapper;
            }
        }
    }
}
