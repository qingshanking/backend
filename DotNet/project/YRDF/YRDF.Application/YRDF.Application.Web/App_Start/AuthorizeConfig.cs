using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YRDF.Util.Log;

namespace YRDF.Application.Web
{
    /// <summary>
    /// 授权登录验证
    /// </summary>
    public class AccountAuthorize : AuthorizeAttribute
    {
        /// <summary>
        /// 授权验证的逻辑处理，返回true的则是通过授权，返回了false则不是。
        /// 全局验证是否登录
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            try
            {
                var usersession = HttpContext.Current.Session["session_login_userInfo"];
                if (usersession == null)
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                //输出错误日志
                LogHelper.WriteErrorLog(ex.ToString());
                return false;
            }
        }
        /// <summary>
        /// 授权失败处理
        /// </summary>
        /// <param name="filterContext"></param>
        /// <remarks>授权失败，跳转登录</remarks>
        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            filterContext.HttpContext.Response.Redirect("/Login/Index");
        }
    }
}