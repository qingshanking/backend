using System.Web;

namespace YRDF.Util.Cache
{
    /// <summary>  
    /// Session 操作类  
    /// 1、GetSession(string name)根据session名获取session对象  
    /// 2、SetSession(string name, object val)设置session  
    /// </summary>  
    public class SessionHelper
    {
        #region 添加session

        /// <summary>  
        /// 设置session  
        /// </summary>  
        /// <param name="name">session 名</param>  
        /// <param name="val">session 值</param>  
        public static void SetSession(string name, object val)
        {
            HttpContext.Current.Session.Remove(name);
            HttpContext.Current.Session.Add(name, val);
        }
        /// <summary>  
        /// 添加Session，调动有效期为20分钟  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <param name="strValue">Session值</param>  
        public static void Add(string strSessionName, string strValue)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = 20;
        }

        /// <summary>  
        /// 添加Session，调动有效期为20分钟  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <param name="strValues">Session值数组</param>  
        public static void Adds(string strSessionName, string[] strValues)
        {
            HttpContext.Current.Session[strSessionName] = strValues;
            HttpContext.Current.Session.Timeout = 20;
        }

        /// <summary>  
        /// 添加Session  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <param name="strValue">Session值</param>  
        /// <param name="iExpires">调动有效期（分钟）</param>  
        public static void Add(string strSessionName, string strValue, int iExpires)
        {
            HttpContext.Current.Session[strSessionName] = strValue;
            HttpContext.Current.Session.Timeout = iExpires;
        }

        /// <summary>  
        /// 添加Session  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <param name="strValues">Session值数组</param>  
        /// <param name="iExpires">调动有效期（分钟）</param>  
        public static void Adds(string strSessionName, string[] strValues, int iExpires)
        {
            HttpContext.Current.Session[strSessionName] = strValues;
            HttpContext.Current.Session.Timeout = iExpires;
        }
        #endregion

        #region 获取Session
        
        /// <summary>  
        /// 读取某个Session对象值  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <returns>Session对象值</returns>  
        public static string Get(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Session[strSessionName] as string;
            }
        }

        /// <summary>  
        /// 读取某个Session对象值数组  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        /// <returns>Session对象值数组</returns>  
        public static string[] Gets(string strSessionName)
        {
            if (HttpContext.Current.Session[strSessionName] == null)
            {
                return null;
            }
            else
            {
                return (string[])HttpContext.Current.Session[strSessionName];
            }
        }
        #endregion

        #region 删除Session
        /// <summary>  
        /// 删除一个指定的ession  
        /// </summary>  
        /// <param name="name">Session名称</param>  
        /// <returns></returns>  
        public static void RemoveSession(string name)
        {
            HttpContext.Current.Session.Remove(name);
        }
        /// <summary>  
        /// 删除某个Session对象  
        /// </summary>  
        /// <param name="strSessionName">Session对象名称</param>  
        public static void Del(string strSessionName)
        {
            HttpContext.Current.Session[strSessionName] = null;
        }

        /// <summary>  
        /// 删除所有的ession  
        /// </summary>  
        /// <returns></returns>  
        public static void RemoveAllSession(string name)
        {
            HttpContext.Current.Session.RemoveAll();
        }
        
        #endregion
    }
}
