using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using Web.Util;

namespace Web.Controllers
{
    public class CardBagController : Controller
    {
        private Models.DBModel db = new Models.DBModel();
        /// <summary>
        /// 我的卡包
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View();
        }
        /// <summary>
        /// 表单页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Form()
        {
            return View();
        }

        public JsonResult GetCardBagJson()
        {
            var list = db.Set<CardBag>().ToList();
            List<object> data = new List<object>();
            int i = 1;
            foreach (var item in list)
            {
                var model = new
                {
                    id = i++,
                    gid = item.Guid,
                    CardId = item.CardId,
                    Money = item.Money,
                    CardBagType = item.CardBagType,
                    CreateTime = DateTimeExtend.NullableDateToString(item.CreateTime),
                    Remark = item.Remark
                };
                data.Add(model);
            }
            return Json(new { data = data }, JsonRequestBehavior.AllowGet);
        }
        
    }
}