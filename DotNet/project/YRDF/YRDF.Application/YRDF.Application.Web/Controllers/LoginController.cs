using System;
using System.Web.Mvc;
using YRDF.Application.Busines.SystemManage;
using YRDF.Util;
using YRDF.Util.Log;

namespace YRDF.Application.Web.Controllers
{
    public class LoginController : Controller
    {
        private readonly Sys_UserInfoBusines _userbll = new Sys_UserInfoBusines();
        /// <summary>
        /// 登录页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 系统验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetValidateCode()
        {
            return File(new VerifyCode().GetVerifyCode(), @"image/Gif");
        }

        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public ActionResult CheckLogin(string username, string password, string vercode)
        {
            try
            {
                //获取前台传入验证码 加密后验证
                string _verifycode = Md5Helper.Encrypt(vercode.ToLower(), 16);
                //获取之前存入图片验证码Seesion
                string _VerifyCode = WebHelper.GetSession("session_verifycode");
                //判断验证码是否一致
                if (_VerifyCode == null || !_VerifyCode.Equals(_verifycode))
                {
                    var data = new { code = 1, msg = "验证码错误", data = "" };
                    return Content(data.ToJson());
                }
                var redata = _userbll.CheckLogin(username, password);
                return Content(redata.ToJson());
            }
            catch (Exception ex)
            {
                LogHelper.WriteErrorLog(ex.ToString());
            }
            return RedirectToAction("Index", "Home");
        }
    }
}