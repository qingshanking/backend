using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRDF.Application.Web.Controllers
{
    [AccountAuthorize]
    public class SystemController : Controller
    {
        /// <summary>
        /// 网站设置
        /// </summary>
        /// <returns></returns>
        public ActionResult WebSite()
        {
            return View();
        }

        /// <summary>
        /// 邮箱设置
        /// </summary>
        /// <returns></returns>
        public ActionResult Email()
        {
            return View();
        }
    }
}