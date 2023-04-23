using YRDF.Application.Entity;
using YRDF.Application.IService.SystemManage;
using YRDF.Data.Repository;

namespace YRDF.Application.Service.SystemManage
{
    /// <summary>
    /// 系统业务_用户表
    /// 数据层
    /// 2020年4月26日00:16:03
    /// </summary>
    public class Sys_UserInfoService : Repository<Sys_UserInfo>, ISys_UserInfoService
    {
        /// <summary>
        /// 添加用户实体
        /// </summary>
        /// <param name="model">用户数据</param>
        /// <returns></returns>
        public bool AddRowModel(Sys_UserInfo model)
        {
            return Add(model) == 1 ? true : false;
        }

        /// <summary>
        /// 根据登录名获取数据实体
        /// </summary>
        /// <param name="LoginName"></param>
        /// <returns></returns>
        public Sys_UserInfo GetModelByLoginName(string LoginName)
        {
            return GetModel(t => t.LoginName == LoginName || t.Email == LoginName || t.Phone == LoginName);
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// 判断用户数据是否存在
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Sys_UserInfo GetUserExist(Sys_UserInfo model)
        {
            return GetModel(t => t.LoginName == model.LoginName || t.Phone == model.Phone || t.Email == model.Email);
        }
    }
}
