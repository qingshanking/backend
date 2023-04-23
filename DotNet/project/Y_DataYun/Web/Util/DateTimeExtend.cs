using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Util
{
    public static class DateTimeExtend
    {
        /// <summary>
        /// 扩展时间 转化
        /// </summary>
        /// <param name="dt">时间</param>
        /// <returns></returns>
        public static string NullableDateToString(this DateTime? dt)
        {
            return string.Format("{0:yyyy-MM-dd HH:mm:ss}", dt);
        }
    }
}