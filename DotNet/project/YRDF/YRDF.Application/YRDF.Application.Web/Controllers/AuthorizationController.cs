using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace YRDF.Application.Web.Controllers
{
    /// <summary>
    /// 第三方授权认证
    /// 2020年4月24日19:51:42
    /// </summary>
    public class AuthorizationController : Controller
    {
        /// <summary>
        /// QQ回调域
        /// </summary>
        /// <returns></returns>
        public ActionResult QQCallback()
        {
            return View();
        }
    }
}