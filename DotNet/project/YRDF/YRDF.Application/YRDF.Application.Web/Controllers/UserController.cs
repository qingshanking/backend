using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YRDF.Application.Busines.SystemManage;
using YRDF.Application.Entity;
using YRDF.Util;

namespace YRDF.Application.Web.Controllers
{
    [AccountAuthorize]
    public class UserController : Controller
    {
        private readonly Sys_UserInfoBusines _userbll = new Sys_UserInfoBusines();
        private readonly Sys_RoleBusines _rolebll = new Sys_RoleBusines();



        #region 用户管理

        #region 视图
        /// <summary>
        /// 用户列表
        /// </summary>
        /// <returns></returns>
        public ActionResult UserList()
        {
            return View();
        }

        /// <summary>
        /// 用户表单
        /// </summary>
        /// <returns></returns>
        public ActionResult UserForm()
        {
            return View();
        }
        #endregion

        #region 操作数据

        #endregion
        /// <summary>
        /// 保存或者修改
        /// </summary>
        /// <param name="model">用户实体</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveUserForm(Sys_UserInfo model)
        {
            var data = _userbll.SaveUserForm(model);
            return Content(data.ToJson());
        }
        #endregion


        #region 管理员管理

        /// <summary>
        /// 管理员列表
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminList()
        {
            return View();
        }

        /// <summary>
        /// 管理员表单页面
        /// </summary>
        /// <returns></returns>
        public ActionResult AdminForm()
        {
            return View();
        }

        #endregion

        #region 角色列表

        #region 视图
        /// <summary>
        /// 角色列表
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleList()
        {
            return View();
        }
        /// <summary>
        /// 角色表单页面
        /// </summary>
        /// <returns></returns>
        public ActionResult RoleForm(string formId)
        {
            if (string.IsNullOrWhiteSpace(formId))
                return View();
            var model = _rolebll.GetRowModel(formId);
            if (model == null)
                return View();
            return View(model);
        }
        #endregion

        #region 操作数据

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="key">主键</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult DelRole(string key)
        {
            var data = new { code = 0, msg = "" };
            return Content(data.ToJson());
        }

        /// <summary>
        /// 获取角色列表
        /// </summary>
        /// <returns></returns>
        public ActionResult GetRoleTable()
        {
            //var data = new { code = 0, msg = "" };
            var data = _rolebll.GetTableJson();
            return Content(data.ToJson());
        }

        /// <summary>
        /// 保存角色表单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveRoleForm(Sys_Role model)
        {
            //var data = new { code = 0, msg = "操作成功" };
            var data = _rolebll.SaveRoleForm(model);
            return Content(data.ToJson());
        }
        #endregion

        #region 公共部分

        /// <summary>
        /// 获取角色下拉列表
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public ActionResult GetSelectList()
        {
            var data = _rolebll.GetSelectList();
            return Content(data.ToJson());
        }

        #endregion

        #endregion

        /// <summary>
        /// 用户资料
        /// </summary>
        /// <returns></returns>
        public ActionResult Info()
        {
            return View();
        }
        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult Password()
        {
            return View();
        }

    }
}