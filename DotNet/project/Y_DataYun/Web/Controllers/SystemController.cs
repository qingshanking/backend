using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class SystemController : Controller
    {
        private DBModel db = new DBModel();
        /// <summary>
        /// 字典表视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Code()
        {
            return View();
        }
        /// <summary>
        /// 编码修改视图
        /// </summary>
        /// <returns></returns>
        public ActionResult Form()
        {
            return View();
        }
        public JsonResult SaveForm(Sys_Code model)
        {
            bool isok = false;
            if (!string.IsNullOrEmpty(model.GUID))
            {
                isok = UpdateCode(model);
            }
            else
            {
                model.GUID = Guid.NewGuid().ToString();
                db.Set<Sys_Code>().Add(model);
                isok = db.SaveChanges() == 1 ? true : false;
            }


            return Json(new { code = 200, data = isok });
        }
        /// <summary>
        /// 更新字典表
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateCode(Sys_Code model)
        {
            var dbmodel = db.Set<Sys_Code>().Where(T => T.GUID == model.GUID).FirstOrDefault();
            dbmodel.Remark = model.Remark;
            dbmodel.Content = model.Content;
            var e = db.Entry<Sys_Code>(dbmodel);
            e.State = EntityState.Modified;
            return db.SaveChanges() == 1 ? true : false;
        }
        public JsonResult GetJsonForm(string keyValue)
        {
            var data = db.Set<Sys_Code>().Where(T => T.GUID.Equals(keyValue)).FirstOrDefault();
            return Json(new { code = 200, data = data });
        }
        /// <summary>
        /// 获取Json树形图
        /// </summary>
        /// <returns></returns>
        public JsonResult GetCodeJson()
        {
            var sys_code = db.Set<Sys_Code>().Where(T => T.Level == 1).ToList();

            List<object> data = new List<object>();
            var model = new { text = "总父级", data = 0 };
            data.Add(model);
            foreach (var item in sys_code)
            {
                var pmodel = new { text = item.Content, data = item.GUID, Parent=item.Parent };
                data.Add(pmodel);
            }


            return Json(new { code = 200, data = data }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetDataByGuid(string gid)
        {
            var list = db.Set<Sys_Code>().Where(T => T.Parent == gid).ToList();
            List<object> data = new List<object>();
            int i = 1;
            foreach (var item in list)
            {
                var model = new
                {
                    id = i++,
                    gid = item.GUID,
                    Content = item.Content,
                    remark = item.Remark
                };
                data.Add(model);
            }
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        public bool Add()
        {

            Models.Sys_Code code = new Models.Sys_Code();
            code.GUID = System.Guid.NewGuid().ToString();
            code.Parent = "0";
            code.Content = "支付方式";
            code.Level = 1;
            code.Remark = "通用字典支付方式";

            db.Set<Sys_Code>().Add(code);
            return db.SaveChanges() == 1 ? true : false;
        }
    }
}