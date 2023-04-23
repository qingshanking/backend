using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRDF.Application.Web.Controllers
{
    [AccountAuthorize]
    public class HomeController : Controller
    {
        /// <summary>
        /// 控制台首页
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Console()
        {
            return View();
        }
    }
}